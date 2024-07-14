using Microsoft.AspNetCore.Mvc;
using ShopMicroServices.Orders.Application.Contracts;
using ShopMicroServices.Orders.Application.Dtos;

namespace ShopMicroServices.Orders.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IOrdersServices _OrderService;

        public OrdersController(IOrdersServices ordersServices)
        {
            this._OrderService = ordersServices;
        }

        [HttpGet("Get Orders")]
        public IActionResult Get()
        {
            var result = this._OrderService.GetOrders();
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("GetOrdersById")]
        public IActionResult Get(int id)
        {
            var result = this._OrderService.GetOrderById(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPost("Save Orders")]
        public IActionResult Post([FromBody] OrderSaveDto saveDto)
        {
            var result = this._OrderService.SaveOrder(saveDto);
            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpPut("Update Orders")]
        public IActionResult post(OrderUpdateDto updateDto)
        {
            var result = this._OrderService.UpdateOrder(updateDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpDelete("Delete Order")]
        public IActionResult post(OrderRemoveDto removeDto)
        {
            var result = this._OrderService.RemoveOrder(removeDto);

            if (!result.Success)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}