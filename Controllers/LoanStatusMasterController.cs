using MaverickBankReal.Interfaces;
using MaverickBankReal.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MaverickBankReal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanStatusMasterController : ControllerBase
    {
        private readonly ILoanStatusMasterService _loanStatusMasterService;

        public LoanStatusMasterController(ILoanStatusMasterService loanStatusMasterService)
        {
            _loanStatusMasterService = loanStatusMasterService;
        }

        [HttpGet("{loanStatusId}")]
        public async Task<IActionResult> GetLoanStatusDetails(int loanStatusId)
        {
            var loanStatus = await _loanStatusMasterService.GetLoanStatusDetailsAsync(loanStatusId);
            return Ok(loanStatus);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLoanStatuses()
        {
            var loanStatuses = await _loanStatusMasterService.GetAllLoanStatusesAsync();
            return Ok(loanStatuses);
        }

        [HttpPost]
        public async Task<IActionResult> AddLoanStatus([FromBody] LoanStatusMasterDTO loanStatusDTO)
        {
            var loanStatus = await _loanStatusMasterService.AddLoanStatusAsync(loanStatusDTO);
            return Ok(loanStatus);
        }

        [HttpPut("{loanStatusId}")]
        public async Task<IActionResult> UpdateLoanStatus(int loanStatusId, [FromBody] LoanStatusMasterDTO loanStatusDTO)
        {
            var loanStatus = await _loanStatusMasterService.UpdateLoanStatusAsync(loanStatusId, loanStatusDTO);
            return Ok(loanStatus);
        }

        [HttpDelete("{loanStatusId}")]
        public async Task<IActionResult> DeleteLoanStatus(int loanStatusId)
        {
            var result = await _loanStatusMasterService.DeleteLoanStatusAsync(loanStatusId);
            return result ? Ok("Loan Status deleted successfully.") : BadRequest("Failed to delete loan status.");
        }





    }
}
