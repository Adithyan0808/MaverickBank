using MaverickBankReal.Interfaces;
using MaverickBankReal.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MaverickBankReal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountTypeMasterController : ControllerBase
    {
        private readonly IAccountTypeMasterService _accountTypeMasterService;

        public AccountTypeMasterController(IAccountTypeMasterService accountTypeMasterService)
        {
            _accountTypeMasterService = accountTypeMasterService;
        }


        [HttpGet("{accountTypeId}")]
        public async Task<IActionResult> GetAccountTypeDetails(int accountTypeId)
        {
            var accountType = await _accountTypeMasterService.GetAccountTypeDetailsAsync(accountTypeId);
            return Ok(accountType);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccountTypes()
        {
            var accountTypes = await _accountTypeMasterService.GetAllAccountTypesAsync();
            return Ok(accountTypes);
        }

        [HttpPost]
        public async Task<IActionResult> AddAccountType([FromBody] AccountTypeMasterDTO accountTypeDTO)
        {
            var accountType = await _accountTypeMasterService.AddAccountTypeAsync(accountTypeDTO);
            return Ok(accountType);
        }

        [HttpPut("{accountTypeId}")]
        public async Task<IActionResult> UpdateAccountType(int accountTypeId, [FromBody] AccountTypeMasterDTO accountTypeDTO)
        {
            var accountType = await _accountTypeMasterService.UpdateAccountTypeAsync(accountTypeId, accountTypeDTO);
            return Ok(accountType);
        }

        [HttpDelete("{accountTypeId}")]
        public async Task<IActionResult> DeleteAccountType(int accountTypeId)
        {
            var result = await _accountTypeMasterService.DeleteAccountTypeAsync(accountTypeId);
            return result ? Ok("Account Type deleted successfully.") : BadRequest("Failed to delete account type.");
        }




    }
}
