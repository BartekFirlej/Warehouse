using Microsoft.AspNetCore.Mvc;
using Warehouse.DTOs;
using Warehouse.Services;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            List<OrderResponse> orders;
            try
            {
                orders = await _orderService.GetOrders();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok(orders);
        }

        [HttpGet("{orderid}")]
        public async Task<IActionResult> GetOrders(int orderid)
        {
            OrderResponse order;
            try
            {
                order = await _orderService.GetOrder(orderid);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<IActionResult> PostOrder(OrderRequest orderDetails)
        {
            OrderResponse addedOrder;
            try
            {
                addedOrder = await _orderService.PostOrder(orderDetails);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return CreatedAtAction(nameof(PostOrder), addedOrder);
        }
    }
}
