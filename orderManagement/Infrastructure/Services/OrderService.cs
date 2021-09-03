using Microsoft.EntityFrameworkCore;
using orderManagement.Core.Entities.Orders;
using orderManagement.Core.Interface;
using orderManagement.Dtos.Order;
using orderManagement.Entities.Orders;
using orderManagement.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace orderManagement.Infrastructure.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly StoreDbContext _context;

        public OrderService(IUnitOfWork unitOfWork, StoreDbContext context)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }

        #region creat an order
        public async Task<Order> CreateOrder(OrderCreateParamsDto orderCreateParamsDto)
        {
            var order = Order.CreateOrder(orderCreateParamsDto.OrderCreateDto);
            order.RequirementBase = OrderRequirementsBase.CreateOrderRequirementsBase(orderCreateParamsDto.OrderRequirementBaseDto);
            var orderDetail = OrderDetail.CreateOrderDetail(orderCreateParamsDto.OrderDetailDto);
            order.OrderDetails = new List<OrderDetail>();
            order.OrderDetails.Add(orderDetail);
            _unitOfWork.Repository<Order>().Add(order);
            var result = await _unitOfWork.Complete();
            return result ? order : null;
        }
        #endregion

        #region get an order by id
        public async Task<Order> GetOrderById(int id)
        {
            var order = await _context.Orders.Include(x => x.RequirementBase).Include(x => x.OrderDetails)
                .FirstOrDefaultAsync(x => x.Id == id);
            if (order == null)
            {
                throw new Exception("no order found with id: " + id + "in our database!");
            }

            return order;
        }
        #endregion

        #region update an order
        public async Task<bool> UpdateOrder(Order update)
        {
            if (update == null) return false;
            _unitOfWork.Repository<Order>().Update(update);
            foreach (var orderdetail in update.OrderDetails)
            {
                _unitOfWork.Repository<OrderDetail>().Update(orderdetail);
            }

            _unitOfWork.Repository<OrderRequirementsBase>().Update(update.RequirementBase);
            var result = await _unitOfWork.Complete();
            return result;
        }
        #endregion

        #region delete an order
        public async Task<bool> DeleteOrder(int id)
        {
            // fetch the order by id
            var orderFetch = await _unitOfWork.Repository<Order>().GetByIdAsync(id);
            if (orderFetch == null) return false;
            _unitOfWork.Repository<Order>().Delete(orderFetch);
            return await _unitOfWork.Complete();
        }
        #endregion
    }
}