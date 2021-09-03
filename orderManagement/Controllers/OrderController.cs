using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using orderManagement.Core.Interface;
using orderManagement.Core.Specifications;
using orderManagement.Core.Specifications.Order;
using orderManagement.Dtos.Order;
using orderManagement.Entities.Orders;
using orderManagement.Errors;
using orderManagement.Helpers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace orderManagement.Controllers
{
    public class OrderController:BaseController
    {
        private readonly IGenericRepository<Order> _orderRepository;
        private readonly IMapper _mapper;
        private readonly IOrderService _orderService;

        public OrderController(
            IGenericRepository<Order> orderRepository,
            IMapper mapper,
            IOrderService orderService
            )
        {

            _orderRepository = orderRepository;
            _mapper = mapper;
            _orderService = orderService;
            
        }

        // Get List of Order
        [HttpGet]
        public async Task<ActionResult<Pagination<OrderReturnDto>>> GetAllOrders([FromQuery] OrderSpecificationParams orderSpecificationParams)
        {
            var spec = new OrderWithSpecification(orderSpecificationParams);
            var countSpec = new OrderWithFilterForCountSpec(orderSpecificationParams);
            var totalItems = await _orderRepository.CountAsync(countSpec);
            var orders = await _orderRepository.ListAsync(spec);
            var data = _mapper.Map<IReadOnlyList<OrderReturnDto>>(orders);
            return Ok(new Pagination<OrderReturnDto>(orderSpecificationParams.PageIndex, orderSpecificationParams.PageSize, totalItems, data));
        }

        // Get order by id
        [HttpGet("{id}")]
        public async Task<ActionResult<OrderReturnDto>> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderById(id);
            if (order is null) return NotFound();
            return Ok(_mapper.Map<OrderReturnDto>(order));
        }

        [HttpPost]
        public async Task<ActionResult<OrderReturnDto>> CreateOrder(OrderCreateParamsDto orderCreateParamsDto)
        {
            
            var resultData = await _orderService.CreateOrder(orderCreateParamsDto);
            if (resultData==null)
            {
                return BadRequest(new ApiResponse(400));
            }

            return Ok(_mapper.Map<OrderReturnDto>(resultData));
        }

        // Update order by updateDto(define in the DTO)
        [HttpPut]
        public async Task<ActionResult> UpdateOrder(Order order)
        {
            var result = await _orderService.UpdateOrder(order);
            
            
            if (!result)
            {
                return BadRequest(new ApiResponse(400, "Update failure"));
            }

            return Ok();
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var result = await _orderService.DeleteOrder(id);
            if (!result)
            {
                return BadRequest(new ApiResponse(400, "Update failure"));
            }

            return Ok();
        }
    }
}