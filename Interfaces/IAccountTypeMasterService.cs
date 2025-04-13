using MaverickBankReal.Models.DTOs;

namespace MaverickBankReal.Interfaces
{
    public interface IAccountTypeMasterService
    {
        Task<AccountTypeMasterDTO> GetAccountTypeDetailsAsync(int accountTypeId);
        Task<IEnumerable<AccountTypeMasterDTO>> GetAllAccountTypesAsync();
        Task<AccountTypeMasterDTO> AddAccountTypeAsync(AccountTypeMasterDTO accountTypeDTO);
        Task<AccountTypeMasterDTO> UpdateAccountTypeAsync(int accountTypeId, AccountTypeMasterDTO accountTypeDTO);
        Task<bool> DeleteAccountTypeAsync(int accountTypeId);
    }
}
