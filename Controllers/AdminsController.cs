using MaverickBankReal.Interfaces;
using MaverickBankReal.Models.DTOs;
using MaverickBankReal.Models;
using Microsoft.AspNetCore.Mvc;

namespace MaverickBankReal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminsController : ControllerBase
    {
        private readonly IAdminService _adminService;

        public AdminsController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet("{adminId}")]
        public async Task<IActionResult> GetAdminDetails(int adminId)
        {
            var admin = await _adminService.GetAdminDetailsAsync(adminId);
            return Ok(admin);
        }

        [HttpPut("{adminId}")]
        public async Task<IActionResult> UpdateAdminDetails(int adminId, [FromBody] AdminDTO adminDTO)
        {
            await _adminService.UpdateAdminDetailsAsync(adminId, adminDTO);
            return Ok("Admin details updated successfully.");
        }

        [HttpGet("transactions")]
        public async Task<IActionResult> GetTransactions()
        {
            var transactions = await _adminService.GetTransactionsAsync();
            return Ok(transactions);
        }

        [HttpGet("loans")]
        public async Task<IActionResult> GetLoans()
        {
            var loans = await _adminService.GetLoansAsync();
            return Ok(loans);
        }

        [HttpGet("accounts")]
        public async Task<IActionResult> GetAccounts()
        {
            var accounts = await _adminService.GetAccountsAsync();
            return Ok(accounts);
        }


    }
}
