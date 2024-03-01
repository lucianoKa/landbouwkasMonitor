using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ComponentFactory.Krypton.Toolkit;

namespace LBM
{
    public partial class Form2 : KryptonForm
    {
        private WaitWnd _waitForm = new WaitWnd();

        public Form2()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                    components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        }

        private async Task GenerateData()
        {
            btnGetData.Enabled = false;

            //Show WaitForm
            _waitForm.Show(this.ParentForm);


            for (int x = 15; x > 0; x--)
            {
                DateTime date = DateTime.Now.AddDays(-x);

                EF.Root root = new EF.Root()
                {
                    Metadata = new EF.Metadata()
                    {
                        Name = "Kas Monitor",
                        CreatedAt = date,
                        Private = false
                    },
                    Record = new EF.Record()
                    {
                        Metingen = new List<EF.Meting>
                        {
                            new EF.Meting()
                            {
                                 Meetdatum = date,
                                 Zones = GenerateZones()
                            }
                        }
                    }
                };
                await DataHelper.SaveToDatabase(root);
            }

            //Close waitform
            _waitForm.Close();

            this.Close();
        }

        private List<EF.Zone> GenerateZones()
        {
            List<EF.Zone> zones = new List<EF.Zone>();

            #region Zone 1
            var zone1Gewassen = new List<EF.Gewas>
            {
                GenerateGewas("Tomaten"),
                GenerateGewas("Paprika")
            };

            EF.Zone zone1 = new EF.Zone()
            {
                Number = 1,
                ZoneNaam = "Zone 1",
                Gewassen = zone1Gewassen
            };

            zones.Add(zone1);
            #endregion

            #region Zone 2
            var zone2Gewassen = new List<EF.Gewas>
            {
                GenerateGewas("Komkommer"),
                GenerateGewas("Courgette")
            };

            EF.Zone zone2 = new EF.Zone()
            {
                Number = 2,
                ZoneNaam = "Zone 2",
                Gewassen = zone1Gewassen
            };

            zones.Add(zone2);
            #endregion

            #region Zone 3
            var zone3Gewassen = new List<EF.Gewas>
            {
                GenerateGewas("Aubergine"),
                GenerateGewas("Radijs")
            };

            EF.Zone zone3 = new EF.Zone()
            {
                Number = 3,
                ZoneNaam = "Zone 3",
                Gewassen = zone1Gewassen
            };

            zones.Add(zone3);
            #endregion

            #region Zone 4
            var zone4Gewassen = new List<EF.Gewas>
            {
                GenerateGewas("Wortels"),
                GenerateGewas("Spinazie")
            };

            EF.Zone zone4 = new EF.Zone()
            {
                Number = 4,
                ZoneNaam = "Zone 4",
                Gewassen = zone1Gewassen
            };

            zones.Add(zone4);
            #endregion

            #region Zone 5
            var zone5Gewassen = new List<EF.Gewas>
            {
                GenerateGewas("Sla")
            };

            EF.Zone zone5 = new EF.Zone()
            {
                Number = 5,
                ZoneNaam = "Zone 5",
                Gewassen = zone1Gewassen
            };

            zones.Add(zone5);
            #endregion

            #region Zone 6
            var zone6Gewassen = new List<EF.Gewas>
            {
                GenerateGewas("Bloemkool"),
                GenerateGewas("Broccoli")
            };

            EF.Zone zone6 = new EF.Zone()
            {
                Number = 6,
                ZoneNaam = "Zone 6",
                Gewassen = zone1Gewassen
            };

            zones.Add(zone6);
            #endregion

            return zones;
        }

        private EF.Gewas GenerateGewas(string name)
        {
            Intensiteit intensiteit = GetIntensiteit();

            EF.Gewas gewas = new EF.Gewas()
            {
                GewasNaam = name,
                TWaarde = RandomNumberBetween(22.5, 26.5),
                TEenheid = "Celsius",
                VWaarde = RandomNumberBetween(59.5, 60.5),
                VEenheid = "Percentage",
                PH = RandomNumberBetween(5.7, 7.1),
                Stikstof = (int)RandomNumberBetween(18, 23),
                Fosfor = (int)RandomNumberBetween(6, 13),
                Kalium = (int)RandomNumberBetween(10, 20),
                Intensiteit = intensiteit == Intensiteit.Geen ? null : intensiteit.ToString(),
                UrenPerDag = intensiteit == Intensiteit.Geen ? 0 : (int)RandomNumberBetween(10, 20)
            };

            return gewas;
        }

        private enum Intensiteit
        {
            Hoog,
            Midden,
            Laag,
            Geen
        }

        private Intensiteit GetIntensiteit()
        {
            int val = random.Next(0, 3);

            return (Intensiteit)val;
        }




        private static readonly Random random = new Random();

        private static decimal RandomNumberBetween(double minValue, double maxValue)
        {
            double dbl = (random.NextDouble() * Math.Abs(maxValue - minValue)) + minValue;

            return Math.Round((decimal)dbl, 2);
        }

        private async void BtnGetData_Click(object sender, EventArgs e)
        {
            await GenerateData();
        }
    }
}
