using Microsoft.AspNetCore.Mvc;
using Warehouse.DTOs;
using Warehouse.Services;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("order-methods")]
    public class OrderMethodController : ControllerBase
    {
        private readonly IOrderMethodService _orderMethodService;

        public OrderMethodController(IOrderMethodService orderMethodService)
        {
            _orderMethodService = orderMethodService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderMethods()
        {
            List<OrderMethodResponse> orderMethods;
            try
            {
                orderMethods = await _orderMethodService.GetOrderMethods();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok(orderMethods);
        }

        [HttpGet("{ordermethodid}")]
        public async Task<IActionResult> GetOrderMethod(int ordermethodid)
        {
            OrderMethodResponse orderMethod;
            try
            {
                orderMethod = await _orderMethodService.GetOrderMethod(ordermethodid);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok(orderMethod);
        }

        [HttpPost]
        public async Task<IActionResult> PostOrderMethod(OrderMethodRequest orderMethodDetails)
        {
            OrderMethodResponse addedOrderMethod;
            try
            {
                addedOrderMethod = await _orderMethodService.PostOrderMethod(orderMethodDetails);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return CreatedAtAction(nameof(PostOrderMethod), addedOrderMethod);
        }
    }
}
