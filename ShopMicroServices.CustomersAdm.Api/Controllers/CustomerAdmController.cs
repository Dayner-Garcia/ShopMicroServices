using Microsoft.AspNetCore.Mvc;
using ShopMicroServices.Customers.Application.Contracts;
using ShopMicroServices.Customers.Application.Dtos;

namespace ShopMicroServices.CustomersAdm.Api.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CustomerAdmController : ControllerBase
    {
        private readonly ICustomersService CustomerServices;

        public CustomerAdmController(ICustomersService customerServices)
        {
            this.CustomerServices = customerServices;
        }

        [HttpGet ("GetCustomers")]
        public IActionResult Get()
        {
            var result = this.CustomerServices.GetCustomers();
            if (!result.Success) 
            { 
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpGet("GetCustomerById")]
        public IActionResult Get(int id)
        {
            var result = this.CustomerServices.GetCustomerById(id);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("SaveCustomers")]
        public IActionResult Post([FromBody] CustomerDtoSave dtoSave)
        {
            var result = this.CustomerServices.SaveCustomer(dtoSave);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPut("UpdateCustomers")]
        public IActionResult post(CustomerDtoUpdate dtoUpdate)
        {
            var result = this.CustomerServices.UpdateCustomer(dtoUpdate);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpDelete("DeleteCustomer")]
        public IActionResult post(CustomerDtoRemove dtoRemove)
        {
            var result = this.CustomerServices.RemoveCustomer(dtoRemove);

            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
