using System.Runtime.Serialization;

namespace MachineBuildingFactory.Data.Enums
{
    public enum Title
    {
        [EnumMember(Value = "Mr")]
        Mr,

        [EnumMember(Value = "Mrs")]
        Mrs,

        [EnumMember(Value = "DI")]
        DI,

        [EnumMember(Value = "FU")]
        FU,

        [EnumMember(Value = "Dr")]
        Dr,
    }
}

