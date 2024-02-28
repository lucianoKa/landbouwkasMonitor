using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading;
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
        public static async Task<Json.Root> RetrieveData()
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
                    CreatedAt = data.Metadata.CreatedAt,
                    Id = data.Metadata.Id,
                    Name = data.Metadata.Name,
                    @private = data.Metadata.@private
                },

                Record = new EF.Record()
            };

            root.Record.Metingen = MapMetingen(data.Record.Metingen);

            return root;
        }

        private static List<EF.Meting> MapMetingen(List<Json.Meting> jMetingen)
        {
            List<EF.Meting> metingen = new List<EF.Meting>();

            foreach (var jMeting in jMetingen)
            {
                EF.Meting meting = new EF.Meting()
                {
                    Meetdatum = jMeting.Meetdatum,
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
                    Id = jZone.ID,
                    ZoneNaam = GetZoneNaamEx(jZone.ZoneNaam, jZone.Gewassen),
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
                if (jGewas.Temperatuur != null)
                {
                    gewas.Temperatuur = string.Format("{0} {1}", jGewas.Temperatuur.Waarde.ToString(), GetUnitString(jGewas.Temperatuur.Eenheid));
                }
                #endregion 

                #region Vochtigheid
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

        #endregion

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

        private static string GetZoneNaamEx(string name, List<Json.Gewas> gewassen)
        {
            string fullName = name;

            if(gewassen.Count == 0)
                return fullName;

            List<string> names = new List<string>();
            foreach(var gewas in gewassen) 
            {
                names.Add(gewas.GewasNaam);
            }

            fullName += "   (" + string.Join(" - ", names) + ")";

            return fullName;
        }
    }
}
