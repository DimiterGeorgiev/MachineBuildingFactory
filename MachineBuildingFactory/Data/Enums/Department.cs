using System.Runtime.Serialization;

namespace MachineBuildingFactory.Data.Enums
{
    public enum Department
    {
        [EnumMember(Value = "Managent")]
        Management,

        [EnumMember(Value = "Engineering")]
        Engineering,

        [EnumMember(Value = "Production")]
        Production,

        [EnumMember(Value = "IT")]
        IT,

        [EnumMember(Value = "HR")]
        HR
    }
}

/*
  [EnumMember(Value = "Managent")]
        Management,

        [EnumMember(Value = "Engineering")]
        Engineering,

        [EnumMember(Value = "Production")]
        Production,

        [EnumMember(Value = "IT")]
        IT,

        [EnumMember(Value = "HR")]
        HR


Management,
        Engineering,
        Production,
        IT,
        HR


*/
