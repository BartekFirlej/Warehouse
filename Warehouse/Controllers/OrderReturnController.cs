using Microsoft.AspNetCore.Mvc;
using Warehouse.DTOs;
using Warehouse.Services;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("order-returns")]
    public class OrderReturnController : ControllerBase
    {
        private readonly IOrderReturnService _orderReturnService;

        public OrderReturnController(IOrderReturnService orderReturnService)
        {
            _orderReturnService = orderReturnService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderReturns()
        {
            List<OrderReturnResponse> orderReturns;
            try
            {
                orderReturns = await _orderReturnService.GetOrderReturns();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok(orderReturns);
        }

        [HttpGet("{returnreasonid}")]
        public async Task<IActionResult> GetOrderReturn(int returnreasonid)
        {
            OrderReturnResponse orderReturn;
            try
            {
                orderReturn = await _orderReturnService.GetOrderReturn(returnreasonid);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok(orderReturn);
        }

        [HttpPost]
        public async Task<IActionResult> PostOrderReturn(OrderReturnRequest orderReturnDetails)
        {
            OrderReturnResponse addedOrderReturn;
            try
            {
                addedOrderReturn = await _orderReturnService.PostOrderReturn(orderReturnDetails);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return CreatedAtAction(nameof(PostOrderReturn), addedOrderReturn);
        }
    }
}
