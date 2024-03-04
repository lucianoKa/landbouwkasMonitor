using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.ComponentModel;

namespace LBM
{
    public enum Choices
    {
        [Description("Alles")]
        All,
        [Description("Per Zone")]
        Zone,
        [Description("Per gewas")]
        Gewas
    }

    public enum Values
    {
        [Description("Temperatuur")]
        Temperature,
        [Description("Vochtigheid")]
        Moist,
        [Description("Bodemgezondheid")]
        Soil,
        //[Description("Zonlicht")]
        //Sunlight,
        [Description("Temperatuur + Vochtigheid")]
        TemperatureMoist,
    }

    public struct Marges
    {
        public string GewasNaam;
        public string Field;
        public decimal Min;
        public decimal Max;
    }

    public class DictMarges
    {

        private Dictionary<string, Marges> dict;

        public Dictionary<string, Marges> GetMarges
        {
            get { return dict; }
        }

        public DictMarges()
        {
            dict = new Dictionary<string, Marges>
            {
                { "Temperatuur", new Marges(){GewasNaam = "Tomaten", Field = "TWaarde", Min = 24, Max = 26 } },
                //{ "Temperatuur", new Marges(){Field = "TWaarde", Min = 24, Max = 26 } },



                { "Vochtigheid", new Marges(){GewasNaam = "Tomaten",Field = "VWaarde",Min = 60.0M, Max = 60.2M } },
                { "PH", new Marges(){GewasNaam = "Tomaten",Field = "PH", Min = 6.40M, Max = 6.90M }},
                { "Stikstof", new Marges(){GewasNaam = "Tomaten",Field = "Stikstof",Min = 19, Max = 21 }},
                { "Fosfor", new Marges(){GewasNaam = "Tomaten",Field = "Fosfor",Min = 8, Max = 11 }},
                { "Kalium", new Marges(){GewasNaam = "Tomaten",Field = "Kalium",Min = 12, Max = 18 }},
                //{ "UrenPerDag", new Marges(){Field = "Urenperdag",Min = 0, Max = 10 }},
            };

        }
    }
}
