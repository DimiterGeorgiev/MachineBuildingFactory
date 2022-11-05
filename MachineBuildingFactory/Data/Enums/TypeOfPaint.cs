using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace MachineBuildingFactory.Data.Enums
{
    public enum TypeOfPaint
    {
        [EnumMember(Value = "Nitrocellulose")]
        Nitrocellulose,

        [EnumMember(Value = "Synthetic")]
        Synthetic,

        [EnumMember(Value = "Epoxy")]
        Epoxy,

        [EnumMember(Value = "Polyurethane")]
        Polyurethane
    }
}

