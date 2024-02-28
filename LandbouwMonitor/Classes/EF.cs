using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace LBM
{
    public class EF
    {
        public class Root
        {
            public Metadata Metadata { get; set; }
            public Record Record { get; set; }            
        }

        public class Metadata
        {
            public string Id { get; set; }
            public bool @private { get; set; }
            public DateTime CreatedAt { get; set; }
            public string Name { get; set; }
        }

        public class Record
        {
            public List<Meting> Metingen { get; set; }
        }

        public class Meting
        {
            public DateTime Meetdatum { get; set; }
            public List<Zone> Zones { get; set; }
        }

        public class Zone
        {
            public int Id { get; set; }
            public string ZoneNaam { get; set; }

            [Description("Gewassen")]
            public List<Gewas> Gewassen = new List<Gewas>();//{ get; set; }
        }

        public class Gewas
        {
            public int GewasId { get; set; }
            public string GewasNaam { get; set; }

            #region Temperatuur
            public string Temperatuur { get; set; }
            #endregion

            #region Vochtigheid
            public string Vochtigheid { get; set; }
            #endregion

            #region Bodemgezondheid
            public double PH { get; set; }
            public int Stikstof { get; set; }
            public int Fosfor { get; set; }
            public int Kalium { get; set; }
            #endregion

            #region Zonlicht
            public string Intensiteit { get; set; }
            public int UrenPerDag { get; set; }
            #endregion
        }
    }
}
