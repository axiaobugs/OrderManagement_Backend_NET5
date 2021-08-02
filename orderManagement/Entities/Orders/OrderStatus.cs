using System.Runtime.Serialization;

namespace orderManagement.Entities.Orders
{
    public enum OrderStatus
    {
        [EnumMember(Value = "Order drawing Completed")]
        OrderDrawingCompleted,
        [EnumMember(Value = "Order Laser Cut Completed")]
        OrderLaserCutCompleted,
        [EnumMember(Value = "Order Folded Completed")]
        OrderFoldCompleted,
        [EnumMember(Value = "Order Mig Weld Completed")]
        OrderMigWeldCompleted,
        [EnumMember(Value = "Order Tig Weld Completed")]
        OrderTigWeldCompleted,
        [EnumMember(Value = "Order Fit Completed")]
        OrderFitCompleted,
        [EnumMember(Value = "Order Pre Quality Check Completed")]
        OrderPreQcCompleted,
        [EnumMember(Value = "Order Paint Completed")]
        OrderPaintCompleted,
        [EnumMember(Value = "Order Final Quality Check Completed")]
        OrderFinalQcCompleted,
        [EnumMember(Value = "Order Dispatch Completed")]
        OrderDispatchCompleted,
        [EnumMember(Value = "Order Done")]
        OrderDone
    }
}