using System.Runtime.Serialization;

namespace orderManagement.Entities.Orders
{
    public enum OrderStatus
    {
        OrderAcceptance,
        OrderDrawingCompleted,
        OrderLaserCutCompleted,
        OrderFoldCompleted,
        OrderMigWeldCompleted,
        OrderTigWeldCompleted,
        OrderFitCompleted,
        OrderPreQcCompleted,
        OrderPaintCompleted,
        OrderFinalQcCompleted,
        OrderDispatchCompleted,
        OrderDone
    }
}