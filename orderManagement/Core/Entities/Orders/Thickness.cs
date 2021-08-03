using System.Runtime.Serialization;

namespace orderManagement.Entities.Orders
{
    public enum Thickness
    {
        [EnumMember(Value = "1.6")]
        BaseThick,
        [EnumMember(Value = "2.0")]
        MiddleThick,
        [EnumMember(Value = "2.5")]
        HeavyThick,
        [EnumMember(Value = "5")]
        SuperThick,
        [EnumMember(Value = "Over 5")]
        CustomerThick


    }
}