using MaverickBankReal.Interfaces;
using MaverickBankReal.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MaverickBankReal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetEmployeeDetails(int employeeId)
        {
            var employee = await _employeeService.GetEmployeeDetailsAsync(employeeId);
            return Ok(employee);
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> UpdateEmployeeDetails(int employeeId, [FromBody] EmployeeDTO employeeDTO)
        {
            await _employeeService.UpdateEmployeeDetailsAsync(employeeId, employeeDTO);
            return Ok("Employee details updated successfully.");
        }

        [HttpGet("{employeeId}/transactions")]
        public async Task<IActionResult> GetTransactions(int employeeId)
        {
            var transactions = await _employeeService.GetTransactionsAsync(employeeId);
            return Ok(transactions);
        }

        [HttpGet("{employeeId}/loans")]
        public async Task<IActionResult> GetLoans(int employeeId)
        {
            var loans = await _employeeService.GetLoansAsync(employeeId);
            return Ok(loans);
        }

        [HttpGet("{employeeId}/accounts")]
        public async Task<IActionResult> GetAccounts(int employeeId)
        {
            var accounts = await _employeeService.GetAccountsAsync(employeeId);
            return Ok(accounts);
        }

    }
}
