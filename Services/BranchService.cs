using AutoMapper;
using MaverickBankReal.Interfaces.RepoInterface;
using MaverickBankReal.Models.DTOs;
using MaverickBankReal.Models;
using MaverickBankReal.Interfaces;

namespace MaverickBankReal.Services
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository _branchRepository;
        private readonly IMapper _mapper;

        public BranchService(IBranchRepository branchRepository, IMapper mapper)
        {
            _branchRepository = branchRepository;
            _mapper = mapper;
        }
        public async Task<BranchDTO> GetBranchDetailsAsync(int branchId)
        {
            var branch = await _branchRepository.GetById(branchId);
            return _mapper.Map<BranchDTO>(branch);
        }

        public async Task<IEnumerable<BranchDTO>> GetAllBranchesAsync()
        {
            var branches = await _branchRepository.GetAll();
            return _mapper.Map<IEnumerable<BranchDTO>>(branches);
        }

        public async Task<BranchDTO> AddBranchAsync(BranchDTO branchDTO)
        {
            var branch = _mapper.Map<Branch>(branchDTO);
            var addedBranch = await _branchRepository.Add(branch);
            return _mapper.Map<BranchDTO>(addedBranch);
        }

        public async Task<BranchDTO> UpdateBranchAsync(int branchId, BranchDTO branchDTO)
        {
            var branch = _mapper.Map<Branch>(branchDTO);
            branch.BranchID = branchId; // Ensure the ID is set
            var updatedBranch = await _branchRepository.Update(branchId, branch);
            return _mapper.Map<BranchDTO>(updatedBranch);
        }

        public async Task<bool> DeleteBranchAsync(int branchId)
        {
            try
            {
                await _branchRepository.Delete(branchId);
                return true;
            }
            catch
            {
                return false;
            }
        }



    }
}
