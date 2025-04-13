using AutoMapper;
using MaverickBankReal.Interfaces;
using MaverickBankReal.Interfaces.RepoInterface;
using MaverickBankReal.Models.DTOs;
using MaverickBankReal.Models;

namespace MaverickBankReal.Services
{
    public class TransactionTypeMasterService : ITransactionTypeMasterService
    {
        private readonly ITransactionTypeMasterRepository _transactionTypeMasterRepository;
        private readonly IMapper _mapper;

        public TransactionTypeMasterService(ITransactionTypeMasterRepository transactionTypeMasterRepository, IMapper mapper)
        {
            _transactionTypeMasterRepository = transactionTypeMasterRepository;
            _mapper = mapper;
        }

        public async Task<TransactionTypeMasterDTO> GetTransactionTypeDetailsAsync(int transactionTypeId)
        {
            var transactionType = await _transactionTypeMasterRepository.GetById(transactionTypeId);
            return _mapper.Map<TransactionTypeMasterDTO>(transactionType);
        }

        public async Task<IEnumerable<TransactionTypeMasterDTO>> GetAllTransactionTypesAsync()
        {
            var transactionTypes = await _transactionTypeMasterRepository.GetAll();
            return _mapper.Map<IEnumerable<TransactionTypeMasterDTO>>(transactionTypes);
        }

        public async Task<TransactionTypeMasterDTO> AddTransactionTypeAsync(TransactionTypeMasterDTO transactionTypeDTO)
        {
            var transactionType = _mapper.Map<TransactionTypeMaster>(transactionTypeDTO);
            var addedTransactionType = await _transactionTypeMasterRepository.Add(transactionType);
            return _mapper.Map<TransactionTypeMasterDTO>(addedTransactionType);
        }

        public async Task<TransactionTypeMasterDTO> UpdateTransactionTypeAsync(int transactionTypeId, TransactionTypeMasterDTO transactionTypeDTO)
        {
            var transactionType = _mapper.Map<TransactionTypeMaster>(transactionTypeDTO);
            transactionType.TransactionTypeID = transactionTypeId; // Ensure the ID is set
            var updatedTransactionType = await _transactionTypeMasterRepository.Update(transactionTypeId, transactionType);
            return _mapper.Map<TransactionTypeMasterDTO>(updatedTransactionType);
        }

        public async Task<bool> DeleteTransactionTypeAsync(int transactionTypeId)
        {
            try
            {
                await _transactionTypeMasterRepository.Delete(transactionTypeId);
                return true;
            }
            catch
            {
                return false;
            }
        }






    }
}
