using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace LBM
{
    public class DataHelper
    {
        #region Declarations
        // Specify the API endpoint
        private static readonly string _apiUrl = "https://api.jsonbin.io/v3/b/65c3a601266cfc3fde871b78/";

        private static readonly HttpClient _httpClient = new HttpClient(new HttpClientHandler
        {
            // Configure connection pooling settings
            MaxConnectionsPerServer = 10,
            UseProxy = false,
            UseDefaultCredentials = false,
            AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
        });
        #endregion

        #region Public methods
        public static async Task<Json.Root> RetreiveData()
        {
            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(_apiUrl);
                response.EnsureSuccessStatusCode(); // Throw on error code.

                string responseData = await response.Content.ReadAsStringAsync();

                // Process the response
                return JsonConvert.DeserializeObject<Json.Root>(responseData);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"API call failed: {ex.Message}");
                return null;
            }
        }

        public static EF.Root JsonToEf(Json.Root data)
        {
            //Create new Root
            EF.Root root = new EF.Root
            {
                Metadata = new EF.Metadata()
                {
                    CreatedAt = DateTime.Now, //data.Metadata.CreatedAt,
                    //GUID = data.Metadata.Id,
                    Name = data.Metadata.Name,
                    Private = data.Metadata.@private
                },

                Record = new EF.Record()
            };

            root.Record.Metingen = MapMetingen(data.Record.Metingen);

            return root;
        }

        public static async Task SaveToDatabase(EF.Root root)
        {
            await Task.Delay(TimeSpan.FromSeconds(1));

            using (var ctx = new DatabaseContext())
            {
                //Save Metadata
                ctx.Metadata.Add(root.Metadata);
                ctx.SaveChanges();
                int metadataId = root.Metadata.Id;

                //Save Metingen
                foreach (var meting in root.Record.Metingen)
                {
                    meting.MetadataId = metadataId;
                    ctx.Metingen.Add(meting);
                    ctx.SaveChanges();
                    int metingId = meting.Id;

                    //Save Zones
                    foreach (var zone in meting.Zones)
                    {
                        zone.Id = 0;
                        zone.MetingId = metingId;
                        ctx.Zones.Add(zone);
                        ctx.SaveChanges();
                        int zoneId = zone.Id;

                        //Save Gewassen
                        foreach (var gewas in zone.Gewassen)
                        {
                            gewas.ZoneId = zoneId;
                            ctx.Gewassen.Add(gewas);
                            ctx.SaveChanges();
                        }
                    }
                }
            }
        }

        public static List<EF.Meting> GetMetingen()
        {
            List<EF.Meting> metingen;

            using (var ctx = new DatabaseContext())
            {
                metingen = ctx.Metingen.ToList();

                foreach (var meting in metingen)
                {
                    meting.Name = "Kas Monitor";

                    meting.Zones = ctx.Zones.Where(x => x.MetingId == meting.Id).ToList();

                    foreach (var zone in meting.Zones)
                    {
                        zone.ZoneNaamEx = GetZoneNaamEx(zone.ZoneNaam, zone.Gewassen);
                        zone.Gewassen = ctx.Gewassen.Where(x => x.ZoneId == zone.Id).ToList();

                        foreach (var gewas in zone.Gewassen)
                        {
                            gewas.Temperatuur = string.Format("{0} {1}", gewas.TWaarde.ToString(), GetUnitString(gewas.TEenheid));
                            gewas.Vochtigheid = string.Format("{0} {1}", gewas.VWaarde.ToString(), GetUnitString(gewas.VEenheid));
                        }
                    }
                }
            }

            return metingen;
        }

        public static EF.Metadata GetMetadata(int id)
        {
            EF.Metadata metadata;
            using (var ctx = new DatabaseContext())
            {
                metadata = ctx.Metadata.Where(x => x.Id == id).FirstOrDefault();
            }

            return metadata;
        }

        public static List<string> GetZoneList()
        {
            List<string> zones;
            using (var ctx = new DatabaseContext())
            {
                zones = ctx.Zones.Select(x => x.ZoneNaam).Distinct().ToList();
            }

            return zones;
        }

        public static List<string> GetGewassenList()
        {
            List<string> gewassen;
            using (var ctx = new DatabaseContext())
            {
                gewassen = ctx.Gewassen.Select(x => x.GewasNaam).Distinct().ToList();
            }

            return gewassen;
        }

        public static List<EF.Gewas> GetGewassen(DateTime dateFrom, DateTime dateTo)
        {
            List<EF.Gewas> gewassen = new List<EF.Gewas>();
            using (var ctx = new DatabaseContext())
            {
                var rngMetingen = ctx.Metingen.Where(x => x.Meetdatum >= dateFrom && x.Meetdatum <= dateTo).ToList();

                foreach (var meting in rngMetingen)
                { 
                    var rngZones = ctx.Zones.Where(x => x.MetingId == meting.Id).ToList();

                    foreach (var zone in rngZones)
                    {
                        var rngGewassen = ctx.Gewassen.Where(p => p.ZoneId == zone.Id).ToList();

                        foreach (var gewas in rngGewassen)
                        { 
                            gewas.MeetDatum = meting.Meetdatum;
                            gewas.ZoneNaam = zone.ZoneNaam;
                            gewassen.Add(gewas);
                        }
                    }
                }

                //var rngMetingen = ctx.Metingen.Where(x => x.Meetdatum >= dateFrom && x.Meetdatum <= dateTo).Select(x => x.Id).ToList();
                //var rngZones = ctx.Zones.Where(x => rngMetingen.Contains(x.MetingId)).Select(y => y.Id ).ToList();  

                //gewassen = ctx.Gewassen.Where(p => p.GewasNaam.ToLower() == gewas && rngZones.Contains(p.ZoneId)).ToList();
            }

            return gewassen;
        }

        #endregion

        #region Private Methods
        private static List<EF.Meting> MapMetingen(List<Json.Meting> jMetingen)
        {
            List<EF.Meting> metingen = new List<EF.Meting>();

            foreach (var jMeting in jMetingen)
            {
                EF.Meting meting = new EF.Meting()
                {
                    Meetdatum = DateTime.Now, //jMeting.Meetdatum,
                    Zones = MapZones(jMeting.Zones),
                };
                metingen.Add(meting);
            }

            return metingen;
        }

        private static List<EF.Zone> MapZones(List<Json.Zone> jZones)
        {
            List<EF.Zone> zones = new List<EF.Zone>();
            foreach (var jZone in jZones)
            {
                EF.Zone zone = new EF.Zone()
                {
                    Number = jZone.ID,
                    ZoneNaam = jZone.ZoneNaam,
                    ZoneNaamEx = GetJsonZoneNaamEx(jZone.ZoneNaam, jZone.Gewassen),
                    Gewassen = MapGewassen(jZone.Gewassen),
                };

                zones.Add(zone);
            }

            return zones;
        }

        private static List<EF.Gewas> MapGewassen(List<Json.Gewas> jGewassen)
        {
            List<EF.Gewas> gewassen = new List<EF.Gewas>();
            foreach (var jGewas in jGewassen)
            {
                EF.Gewas gewas = new EF.Gewas()
                {
                    GewasId = jGewas.GewasId,
                    GewasNaam = jGewas.GewasNaam,
                };

                #region Temperatuur
                gewas.TWaarde = jGewas.Temperatuur.Waarde;
                gewas.TEenheid = jGewas.Temperatuur.Eenheid;

                if (jGewas.Temperatuur != null)
                {
                    gewas.Temperatuur = string.Format("{0} {1}", jGewas.Temperatuur.Waarde.ToString(), GetUnitString(jGewas.Temperatuur.Eenheid));
                }
                #endregion 

                #region Vochtigheid
                gewas.VWaarde = jGewas.Vochtigheid.Waarde;
                gewas.VEenheid = jGewas.Vochtigheid.Eenheid;

                if (jGewas.Vochtigheid != null)
                {
                    gewas.Vochtigheid = string.Format("{0} {1}", jGewas.Vochtigheid.Waarde.ToString(), GetUnitString(jGewas.Vochtigheid.Eenheid));
                }
                #endregion 

                #region Bodemgezondheid
                if (jGewas.Bodemgezondheid != null)
                {
                    gewas.PH = jGewas.Bodemgezondheid.PH;
                    gewas.Stikstof = jGewas.Bodemgezondheid.Voedingsstoffen.Stikstof;
                    gewas.Fosfor = jGewas.Bodemgezondheid.Voedingsstoffen.Fosfor;
                    gewas.Kalium = jGewas.Bodemgezondheid.Voedingsstoffen.Kalium;
                }
                #endregion 

                #region  Zonlicht
                if (jGewas.Zonlicht != null)
                {
                    gewas.Intensiteit = jGewas.Zonlicht.Intensiteit;
                    gewas.UrenPerDag = jGewas.Zonlicht.UrenPerDag;
                }
                #endregion 

                gewassen.Add(gewas);
            }

            return gewassen;
        }

        private static string GetUnitString(string value)
        {
            switch (value.ToLower())
            {
                case "celsius":
                    return "°C";
                case "Farenheit":
                    return "°F";
                case "percentage":
                    return "%";
                default:
                    return "";
            }
        }

        private static string GetJsonZoneNaamEx(string name, List<Json.Gewas> gewassen)
        {
            string fullName = name;

            if (gewassen.Count == 0)
                return fullName;

            List<string> names = new List<string>();
            foreach (var gewas in gewassen)
            {
                names.Add(gewas.GewasNaam);
            }

            fullName += "   (" + string.Join(" - ", names) + ")";

            return fullName;
        }

        private static string GetZoneNaamEx(string name, List<EF.Gewas> gewassen)
        {
            string fullName = name;

            if (gewassen.Count == 0)
                return fullName;

            List<string> names = new List<string>();
            foreach (var gewas in gewassen)
            {
                names.Add(gewas.GewasNaam);
            }

            fullName += "   (" + string.Join(" - ", names) + ")";

            return fullName;
        }

        #endregion 
    }
}
