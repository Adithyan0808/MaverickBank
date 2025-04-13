using MaverickBankReal.Models.DTOs;

namespace MaverickBankReal.Interfaces
{
    public interface ITransactionTypeMasterService
    {
        Task<TransactionTypeMasterDTO> GetTransactionTypeDetailsAsync(int transactionTypeId);
        Task<IEnumerable<TransactionTypeMasterDTO>> GetAllTransactionTypesAsync();
        Task<TransactionTypeMasterDTO> AddTransactionTypeAsync(TransactionTypeMasterDTO transactionTypeDTO);
        Task<TransactionTypeMasterDTO> UpdateTransactionTypeAsync(int transactionTypeId, TransactionTypeMasterDTO transactionTypeDTO);
        Task<bool> DeleteTransactionTypeAsync(int transactionTypeId);
    }
}
