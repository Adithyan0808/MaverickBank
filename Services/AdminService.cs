using AutoMapper;
using MaverickBankReal.Context;
using MaverickBankReal.Interfaces;
using MaverickBankReal.Interfaces.RepoInterface;
using MaverickBankReal.Models.DTOs;
using MaverickBankReal.Models;

namespace MaverickBankReal.Services
{
    public class AdminService : IAdminService
    {
        private readonly IAdminRepository _adminRepository;
        private readonly IMapper _mapper;
        private readonly BankDbContext _context;

        public AdminService(IAdminRepository adminRepository, IMapper mapper, BankDbContext context)
        {
            _adminRepository = adminRepository;
            _mapper = mapper;
            _context = context;
        }

        public async Task<AdminDTO> GetAdminDetailsAsync(int adminId)
        {
            var admin = await _adminRepository.GetById(adminId);
            return _mapper.Map<AdminDTO>(admin);
        }

        public async Task UpdateAdminDetailsAsync(int adminId, AdminDTO adminDTO)
        {
            var admin = _mapper.Map<Admin>(adminDTO);
            admin.AdminID = adminId; // Ensure the ID is set
            await _adminRepository.Update(adminId, admin);
        }

        public async Task<IEnumerable<TransactionDTO>> GetTransactionsAsync()
        {
            var transactions = await _adminRepository.GetTransactionsAsync();
            return _mapper.Map<IEnumerable<TransactionDTO>>(transactions);
        }

        public async Task<IEnumerable<LoanDTO>> GetLoansAsync()
        {
            var loans = await _adminRepository.GetLoansAsync();
            return _mapper.Map<IEnumerable<LoanDTO>>(loans);
        }

        public async Task<IEnumerable<AccountDTO>> GetAccountsAsync()
        {
            var accounts = await _adminRepository.GetAccountsAsync();
            return _mapper.Map<IEnumerable<AccountDTO>>(accounts);
        }


    }
}
