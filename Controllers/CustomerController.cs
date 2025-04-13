using MaverickBankReal.Interfaces;
using MaverickBankReal.Models;
using MaverickBankReal.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MaverickBankReal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("{customerId}")]
        public async Task<IActionResult> GetCustomerDetails(int customerId)
        {
            var customer = await _customerService.GetCustomerDetailsAsync(customerId);
            return Ok(customer);
        }

        [HttpPut("{customerId}")]
        public async Task<IActionResult> UpdateCustomerDetails(int customerId, [FromBody] CustomerDTO customerDTO)
        {
            await _customerService.UpdateCustomerAsync(customerId, customerDTO);
            return Ok("Customer details updated successfully.");
        }

        [HttpGet("{customerId}/transactions")]
        public async Task<IActionResult> GetTransactions(int customerId)
        {
            var transactions = await _customerService.GetTransactionsByCustomerIdAsync(customerId);
            return Ok(transactions);
        }
        [HttpPost("apply-loan")]
        public async Task<IActionResult> ApplyForLoan([FromBody] LoanDTO loanDTO)
        {
            var loan = await _customerService.ApplyForLoanAsync(loanDTO);
            return Ok(loan);
        }
        [HttpGet("{customerId}/loans")]
        public async Task<IActionResult> GetLoans(int customerId)
        {
            var loans = await _customerService.GetLoansByCustomerIdAsync(customerId);
            return Ok(loans);
        }
        [HttpGet("{customerId}/accounts")]
        public async Task<IActionResult> GetAccounts(int customerId)
        {
            var accounts = await _customerService.GetAccountsByCustomerIdAsync(customerId);
            return Ok(accounts);
        }



    }
}
