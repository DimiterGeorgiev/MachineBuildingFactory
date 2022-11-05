using System.Runtime.Serialization;

namespace MachineBuildingFactory.Data.Enums
{
    public enum MaterialNumber
    {
        [EnumMember(Value = "1.0038")]
        S235JRG2,

        [EnumMember(Value = "1.8714")]
        Hardox400,

        [EnumMember(Value = "1.0577")]
        S355J2,

        [EnumMember(Value = "1.4301")]
        X5CrNi18,

        [EnumMember(Value = "3.3535")]
        Alu
    }
}