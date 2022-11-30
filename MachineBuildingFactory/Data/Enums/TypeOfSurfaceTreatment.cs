using System.Runtime.Serialization;

namespace MachineBuildingFactory.Data.Enums
{
    public enum TypeOfSurfaceTreatment
    {
        [EnumMember(Value = "Untreated surface")]
        UntreatedSurface,

        [EnumMember(Value = "Electrogalvanized")]
        Electrogalvanized,

        [EnumMember(Value = "Oxidize")]
        Oxidize,

        [EnumMember(Value = "Paint")]
        Paint
    }
}

