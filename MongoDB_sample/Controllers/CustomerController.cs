using Microsoft.AspNetCore.Mvc;
using MongoDB_sample.Models.Domain;
using MongoDB_sample.Service;

namespace MongoDB_sample.Controllers
{
    [ApiController]
    [Route("api/customer")]
    public class CustomerController : ControllerBase
    {
        private readonly CustomerService _customerService;

        public CustomerController(CustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpPost("crate")]
        public async Task<IActionResult> CreateCustomer(CreateCustomerDomain request)
        {
            var result = await _customerService.CreateCustomer(request);


            return Ok(result.Id);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomer(string id)
        {
            var result = await _customerService.GetCustomer(id);
            return Ok(result);
        }

        [HttpGet("customers")]
        public async Task<IActionResult> GetCustomers()
        {
            var result = await _customerService.GetCustomers();
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateCustomer(UpdateCustomerDomain request)
        {
            var result = await _customerService.UpdateCustomer(request);
            return Ok(result);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteCustomer(string id)
        {
            var result = await _customerService.DeleteCustomer(id);
            return Ok(result);
        }


    }
}
