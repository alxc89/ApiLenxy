using Microsoft.AspNetCore.Mvc;
using ApiLenxy.Application.Services.Customer;
using ApiLenxy.Application.DTOs.Customer;

namespace ApiLenxy.Presentation.Api.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        [HttpPost]
        public async Task<IActionResult> Post(CreateCustomerDTO customer)
        {
            var newCustomer = await _customerService.CreateCustomerAsync(customer);
            if (newCustomer.IsSuccess)
            {
                var actionName = nameof(Get);
                var routeValues = new { idCustomer = newCustomer.Data.Id };
                return CreatedAtAction(actionName, routeValues, newCustomer.Data);
            }
            return BadRequest(newCustomer.Message);
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateCustomerDTO customerDTO)
        {
            var customerUpdated = await _customerService.UpdateCustomerAsync(customerDTO);
            if (customerUpdated.IsSuccess)
                return Ok(customerUpdated);

            return NotFound(customerUpdated.Message);
        }

        [HttpGet("{idCustomer}")]
        public async Task<IActionResult> Get(Guid idCustomer)
        {
            var customer = await _customerService.GetCustomerByIdAsync(idCustomer);
            if (customer.IsSuccess)
                return Ok(customer);
            return NotFound(customer.Message);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customer = await _customerService.GetCustomersAsync();

            return Ok(customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid Id)
        {
            var result = await _customerService.DeleteAsync(Id);
            if (result.IsSuccess)
                return NoContent();
            return BadRequest(result.Message);
        }
    }
}
