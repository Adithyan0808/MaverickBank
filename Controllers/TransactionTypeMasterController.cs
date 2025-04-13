using MaverickBankReal.Interfaces;
using MaverickBankReal.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MaverickBankReal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionTypeMasterController : ControllerBase
    {
        private readonly ITransactionTypeMasterService _transactionTypeMasterService;

        public TransactionTypeMasterController(ITransactionTypeMasterService transactionTypeMasterService)
        {
            _transactionTypeMasterService = transactionTypeMasterService;
        }


        [HttpGet("{transactionTypeId}")]
        public async Task<IActionResult> GetTransactionTypeDetails(int transactionTypeId)
        {
            var transactionType = await _transactionTypeMasterService.GetTransactionTypeDetailsAsync(transactionTypeId);
            return Ok(transactionType);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTransactionTypes()
        {
            var transactionTypes = await _transactionTypeMasterService.GetAllTransactionTypesAsync();
            return Ok(transactionTypes);
        }

        [HttpPost]
        public async Task<IActionResult> AddTransactionType([FromBody] TransactionTypeMasterDTO transactionTypeDTO)
        {
            var transactionType = await _transactionTypeMasterService.AddTransactionTypeAsync(transactionTypeDTO);
            return Ok(transactionType);
        }

        [HttpPut("{transactionTypeId}")]
        public async Task<IActionResult> UpdateTransactionType(int transactionTypeId, [FromBody] TransactionTypeMasterDTO transactionTypeDTO)
        {
            var transactionType = await _transactionTypeMasterService.UpdateTransactionTypeAsync(transactionTypeId, transactionTypeDTO);
            return Ok(transactionType);
        }

        [HttpDelete("{transactionTypeId}")]
        public async Task<IActionResult> DeleteTransactionType(int transactionTypeId)
        {
            var result = await _transactionTypeMasterService.DeleteTransactionTypeAsync(transactionTypeId);
            return result ? Ok("Transaction Type deleted successfully.") : BadRequest("Failed to delete transaction type.");
        }








    }
}
