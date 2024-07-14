using Microsoft.AspNetCore.Mvc;
using ShopMicroServices.OrdersDetails.Application.Dtos;

namespace ShopMicroServices.OrdersDetails.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailsController : ControllerBase
    {
        private readonly IOrderDetailsServices _orderDetailServices;

        public OrderDetailsController(IOrderDetailsServices orderDetailsServices)
        {
            this._orderDetailServices = orderDetailsServices;
        }

        [HttpGet("Get Orders Details")]
        public IActionResult Get()
        {
            var result = this._orderDetailServices.GetOrdersDetails();
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("Get DetailsById")]
        public IActionResult Get(int id)
        {
            var result = this._orderDetailServices.GetOrderDetailsById(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("Save Details")]
        public IActionResult Post([FromBody] OrderDetailsSaveDto saveDto)
        {
            var result = this._orderDetailServices.SaveOrderDetails(saveDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("Update Details")]
        public IActionResult Post(OrderDetailsUpdateDto updateDto)
        {
            var result = this._orderDetailServices.UpdateOrderDetails(updateDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("Delete Detail")]
        public IActionResult Post(OrderDetailsRemoveDto removeDto)
        {
            var result = this._orderDetailServices.RemoveOrderDetails(removeDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}