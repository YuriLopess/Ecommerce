using Ecommerce.Application.Dtos;
using Ecommerce.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerApplicationService _customerApplicationService;

        public CustomersController(ICustomerApplicationService customerApplicationService)
        {
            _customerApplicationService = customerApplicationService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult CreatedCustomer([FromBody] CustomerDto customerDto)
        {
            try
            {
                _customerApplicationService.SaveCustomer(customerDto);

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }

            return Created("", customerDto);
            
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetCustomers()
        {
            var customers = _customerApplicationService.GetAll();
            return Ok(customers);

        }

        [HttpGet("customers/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult GetCustomerById(string id)
        {
            var formattedId = Uri.UnescapeDataString(id);
            var customer = _customerApplicationService.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);

        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteCustomer(string id)
        {
            var formattedId = Uri.UnescapeDataString(id); 
            _customerApplicationService.DeleteCustomer(formattedId);
            return NoContent();

        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult UpdateCustomer([FromBody] CustomerDto customerDto)
        {
            try
            {
                _customerApplicationService.UpdateCustomer(customerDto);
            }
            catch (Exception ex)
            {
                return Conflict(ex.Message);
            }

            return NoContent();
        }
    }
}