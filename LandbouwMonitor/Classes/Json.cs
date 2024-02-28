using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBM
{
    public class Json
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
            public int ID { get; set; }
            public string ZoneNaam { get; set; }
            public List<Gewas> Gewassen { get; set; }
        }

        public class Gewas
        {
            public int GewasId { get; set; }
            public string GewasNaam { get; set; }
            public Temperatuur Temperatuur { get; set; }
            public Vochtigheid Vochtigheid { get; set; }
            public Bodemgezondheid Bodemgezondheid { get; set; }
            public Zonlicht Zonlicht { get; set; }
        }

        public class Bodemgezondheid
        {
            public double PH { get; set; }
            public Voedingsstof Voedingsstoffen { get; set; }
        }        

        public class Temperatuur
        {
            public int Waarde { get; set; }
            public string Eenheid { get; set; }
        }

        public class Vochtigheid
        {
            public int Waarde { get; set; }
            public string Eenheid { get; set; }
        }

        public class Voedingsstof
        {
            public int Stikstof { get; set; }
            public int Fosfor { get; set; }
            public int Kalium { get; set; }
        }

        

        public class Zonlicht
        {
            public string Intensiteit { get; set; }
            public int UrenPerDag { get; set; }
        }
    }
}
