using AutoMapper;
using MaverickBankReal.Interfaces;
using MaverickBankReal.Interfaces.RepoInterface;
using MaverickBankReal.Models.DTOs;
using MaverickBankReal.Models;

namespace MaverickBankReal.Services
{
    public class AccountTypeMasterService : IAccountTypeMasterService
    {
        private readonly IAccountTypeMasterRepository _accountTypeMasterRepository;
        private readonly IMapper _mapper;

        public AccountTypeMasterService(IAccountTypeMasterRepository accountTypeMasterRepository, IMapper mapper)
        {
            _accountTypeMasterRepository = accountTypeMasterRepository;
            _mapper = mapper;
        }

        public async Task<AccountTypeMasterDTO> GetAccountTypeDetailsAsync(int accountTypeId)
        {
            var accountType = await _accountTypeMasterRepository.GetById(accountTypeId);
            return _mapper.Map<AccountTypeMasterDTO>(accountType);
        }

        public async Task<IEnumerable<AccountTypeMasterDTO>> GetAllAccountTypesAsync()
        {
            var accountTypes = await _accountTypeMasterRepository.GetAll();
            return _mapper.Map<IEnumerable<AccountTypeMasterDTO>>(accountTypes);
        }

        public async Task<AccountTypeMasterDTO> AddAccountTypeAsync(AccountTypeMasterDTO accountTypeDTO)
        {
            var accountType = _mapper.Map<AccountTypeMaster>(accountTypeDTO);
            var addedAccountType = await _accountTypeMasterRepository.Add(accountType);
            return _mapper.Map<AccountTypeMasterDTO>(addedAccountType);
        }

        public async Task<AccountTypeMasterDTO> UpdateAccountTypeAsync(int accountTypeId, AccountTypeMasterDTO accountTypeDTO)
        {
            var accountType = _mapper.Map<AccountTypeMaster>(accountTypeDTO);
            accountType.AccountTypeID = accountTypeId; // Ensure the ID is set
            var updatedAccountType = await _accountTypeMasterRepository.Update(accountTypeId, accountType);
            return _mapper.Map<AccountTypeMasterDTO>(updatedAccountType);
        }

        public async Task<bool> DeleteAccountTypeAsync(int accountTypeId)
        {
            try
            {
                await _accountTypeMasterRepository.Delete(accountTypeId);
                return true;
            }
            catch
            {
                return false;
            }
        }



    }
}
