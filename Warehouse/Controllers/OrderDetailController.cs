using Microsoft.AspNetCore.Mvc;
using Warehouse.DTOs;
using Warehouse.Services;

namespace Warehouse.Controllers
{
    [ApiController]
    [Route("order-details")]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderDetails()
        {
            List<OrderDetailResponse> orderDetails;
            try
            {
                orderDetails = await _orderDetailService.GetOrderDetails();
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok(orderDetails);
        }

        [HttpGet("{orderdetailid}")]
        public async Task<IActionResult> GetOrderDetails(int orderdetailid)
        {
            OrderDetailResponse orderDetail;
            try
            {
                orderDetail = await _orderDetailService.GetOrderDetail(orderdetailid);
            }
            catch (Exception e)
            {
                return NotFound(e.Message);
            }
            return Ok(orderDetail);
        }

        [HttpPost]
        public async Task<IActionResult> PostOrderDetail(OrderDetailRequest orderDetailDetails)
        {
            OrderDetailResponse addedOrderDetail;
            try
            {
                addedOrderDetail = await _orderDetailService.PostOrderDetail(orderDetailDetails);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            return CreatedAtAction(nameof(PostOrderDetail), addedOrderDetail);
        }
    }
}
