using MaverickBankReal.Interfaces;
using MaverickBankReal.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MaverickBankReal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly IBranchService _branchService;

        public BranchesController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet("{branchId}")]
        public async Task<IActionResult> GetBranchDetails(int branchId)
        {
            var branch = await _branchService.GetBranchDetailsAsync(branchId);
            return Ok(branch);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBranches()
        {
            var branches = await _branchService.GetAllBranchesAsync();
            return Ok(branches);
        }

        [HttpPost]
        public async Task<IActionResult> AddBranch([FromBody] BranchDTO branchDTO)
        {
            var branch = await _branchService.AddBranchAsync(branchDTO);
            return Ok(branch);
        }

        [HttpPut("{branchId}")]
        public async Task<IActionResult> UpdateBranch(int branchId, [FromBody] BranchDTO branchDTO)
        {
            var branch = await _branchService.UpdateBranchAsync(branchId, branchDTO);
            return Ok(branch);
        }

        [HttpDelete("{branchId}")]
        public async Task<IActionResult> DeleteBranch(int branchId)
        {
            var result = await _branchService.DeleteBranchAsync(branchId);
            return result ? Ok("Branch deleted successfully.") : BadRequest("Failed to delete branch.");
        }

    }
}
