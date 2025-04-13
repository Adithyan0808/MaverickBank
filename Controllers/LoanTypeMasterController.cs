using MaverickBankReal.Interfaces;
using MaverickBankReal.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MaverickBankReal.Controllers
{
    [Route("api/controller")]
    [ApiController]
    public class LoanTypeMasterController : ControllerBase
    {
        private readonly ILoanTypeMasterService _loanTypeMasterService;

        public LoanTypeMasterController(ILoanTypeMasterService loanTypeMasterService)
        {
            _loanTypeMasterService = loanTypeMasterService;
        }

        [HttpGet("{loanTypeId}")]
        public async Task<IActionResult> GetLoanTypeDetails(int loanTypeId)
        {
            var loanType = await _loanTypeMasterService.GetLoanTypeDetailsAsync(loanTypeId);
            return Ok(loanType);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLoanTypes()
        {
            var loanTypes = await _loanTypeMasterService.GetAllLoanTypesAsync();
            return Ok(loanTypes);
        }

        [HttpPost]
        public async Task<IActionResult> AddLoanType([FromBody] LoanTypeMasterDTO loanTypeDTO)
        {
            var loanType = await _loanTypeMasterService.AddLoanTypeAsync(loanTypeDTO);
            return Ok(loanType);
        }

        [HttpPut("{loanTypeId}")]
        public async Task<IActionResult> UpdateLoanType(int loanTypeId, [FromBody] LoanTypeMasterDTO loanTypeDTO)
        {
            var loanType = await _loanTypeMasterService.UpdateLoanTypeAsync(loanTypeId, loanTypeDTO);
            return Ok(loanType);
        }

        [HttpDelete("{loanTypeId}")]
        public async Task<IActionResult> DeleteLoanType(int loanTypeId)
        {
            var result = await _loanTypeMasterService.DeleteLoanTypeAsync(loanTypeId);
            return result ? Ok("Loan Type deleted successfully.") : BadRequest("Failed to delete loan type.");
        }




    }
}
