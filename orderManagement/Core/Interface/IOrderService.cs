using System.Threading.Tasks;
using orderManagement.Dtos.Order;
using orderManagement.Entities.Orders;

namespace orderManagement.Core.Interface
{
    public interface IOrderService
    {
        Task<Order> CreateOrder(OrderCreateParamsDto orderCreateParamsDto);
        Task<Order> GetOrderById(int id);
        Task<bool> UpdateOrder(Order update);
        Task<bool> DeleteOrder(int id);
    };
}