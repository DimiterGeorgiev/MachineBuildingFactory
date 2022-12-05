using System.Runtime.Serialization;

namespace MachineBuildingFactory.Data.Enums
{
    public enum ColorOfPaintRal
    {
        [EnumMember(Value = "none")]
        none,

        [EnumMember(Value = "RAL7035")]
        RAL7035,

        [EnumMember(Value = "RAL1023")]
        RAL1023,

        [EnumMember(Value = "RAL3000")]
        RAL3000,

        [EnumMember(Value = "RAL2560")]
        RAL2560,

        [EnumMember(Value = "RAL1056")]
        RAL1056
    }
}

