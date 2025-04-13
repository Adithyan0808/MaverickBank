using MaverickBankReal.Models.DTOs;

namespace MaverickBankReal.Interfaces
{
    public interface IBranchService
    {
        Task<BranchDTO> GetBranchDetailsAsync(int branchId);
        Task<IEnumerable<BranchDTO>> GetAllBranchesAsync();
        Task<BranchDTO> AddBranchAsync(BranchDTO branchDTO);
        Task<BranchDTO> UpdateBranchAsync(int branchId, BranchDTO branchDTO);
        Task<bool> DeleteBranchAsync(int branchId);
    }
}
