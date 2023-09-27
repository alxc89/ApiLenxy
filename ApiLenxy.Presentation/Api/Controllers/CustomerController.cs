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
        public async Task<IActionResult> CreateAsync(CreateCustomerDTO customer)
        {
            var newCustomer = await _customerService.CreateCustomerAsync(customer);
            if (newCustomer.IsSuccess)
                return CreatedAtAction(nameof(GetByIdAsync), new { idCustomer = newCustomer.Data.Id }, newCustomer);
            return BadRequest(newCustomer.Message);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateCustomerDTO customerDTO)
        {
            var customerUpdated = await _customerService.UpdateCustomerAsync(customerDTO);
            if (customerUpdated.IsSuccess)
                return Ok(customerUpdated);

            return NotFound(customerUpdated.Message);
        }

        [HttpGet("{idCustomer}")]
        public async Task<IActionResult> GetByIdAsync(Guid idCustomer)
        {
            var customer = await _customerService.GetCustomerByIdAsync(idCustomer);
            if (customer.IsSuccess)
                return Ok(customer);
            return NotFound(customer.Message);
        }
        [HttpGet]
        public async Task<IActionResult> GetAsync()
        {
            var customer = await _customerService.GetCustomersAsync();

            return Ok(customer);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(Guid Id)
        {
            var result = await _customerService.DeleteAsync(Id);
            if (result.IsSuccess)
                return NotFound();
            return BadRequest(result.Message);
        }
    }
}
