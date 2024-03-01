using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace LBM
{
    public class EF
    {
        public class Root
        {
            public Metadata Metadata { get; set; }
            public Record Record { get; set; }
        }

        [Table("Metadata")]
        public class Metadata
        {
            public int Id { get; set; }
            //public string GUID { get; set; }
            public bool Private { get; set; }
            public DateTime CreatedAt { get; set; }
            public string Name { get; set; }
        }

        public class Record
        {
            public List<Meting> Metingen { get; set; }
        }

        [Table("Metingen")]
        public class Meting
        {
            public int Id { get; set; }
            public int MetadataId { get; set; }
            public DateTime Meetdatum { get; set; }

            [NotMapped ]
            public string Name { get; set; }

            [NotMapped]
            public List<Zone> Zones = new List<Zone>(); //{ get; set; } 
        }

        [Table("Zones")]
        public class Zone
        {
            public int Id { get; set; }
            public int MetingId { get; set; }
            public int Number { get; set; }
            public string ZoneNaam { get; set; }

            [NotMapped]
            public string ZoneNaamEx { get; set; }

            [NotMapped]
            [Description("Gewassen")]
            public List<Gewas> Gewassen = new List<Gewas>();//{ get; set; }
        }

        [Table("Gewassen")]
        public class Gewas
        {
            public int Id { get; set; }
            public int GewasId { get; set; }
            public int ZoneId { get; set; }
            public string GewasNaam { get; set; }

            #region Temperatuur

            [NotMapped]
            public string Temperatuur { get; set; }

            public int TWaarde {  get; set; }

            public string TEenheid { get; set; }
            #endregion

            #region Vochtigheid
            [NotMapped]
            public string Vochtigheid { get; set; }

            public int VWaarde { get; set; }

            public string VEenheid { get; set; }
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
