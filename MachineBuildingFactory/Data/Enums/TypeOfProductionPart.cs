using Newtonsoft.Json.Linq;
using System.Runtime.Serialization;

namespace MachineBuildingFactory.Data.Enums
{
    public enum TypeOfProductionPart
    {
        [EnumMember(Value = "MechanicallyProcessed")]
        MechanicallyProcessed,

        [EnumMember(Value = "Sheetmetal")]
        Sheetmetal,

        [EnumMember(Value = "Weldconstruction")]
        Weldconstruction,

        [EnumMember(Value = "Lasercut")]
        Lasercut
    }
}

