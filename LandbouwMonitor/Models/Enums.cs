using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBM
{
    public enum Choices
    {
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
}
