using AutoMapper;
using MaverickBankReal.Interfaces;
using MaverickBankReal.Interfaces.RepoInterface;
using MaverickBankReal.Models.DTOs;
using MaverickBankReal.Models;

namespace MaverickBankReal.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
        }

        public async Task<EmployeeDTO> GetEmployeeDetailsAsync(int employeeId)
        {
            var employee = await _employeeRepository.GetById(employeeId);
            return _mapper.Map<EmployeeDTO>(employee);
        }

        public async Task UpdateEmployeeDetailsAsync(int employeeId, EmployeeDTO employeeDTO)
        {
            var employee = _mapper.Map<BankEmployee>(employeeDTO);
            employee.EmployeeID = employeeId; // Ensure the ID is set
            await _employeeRepository.Update(employeeId, employee);
        }

        public async Task<IEnumerable<TransactionDTO>> GetTransactionsAsync(int employeeId)
        {
            var transactions = await _employeeRepository.GetTransactionsByEmployeeIdAsync(employeeId);
            return _mapper.Map<IEnumerable<TransactionDTO>>(transactions);
        }

        public async Task<IEnumerable<LoanDTO>> GetLoansAsync(int employeeId)
        {
            var loans = await _employeeRepository.GetLoansByEmployeeIdAsync(employeeId);
            return _mapper.Map<IEnumerable<LoanDTO>>(loans);
        }

        public async Task<IEnumerable<AccountDTO>> GetAccountsAsync(int employeeId)
        {
            var accounts = await _employeeRepository.GetAccountsByEmployeeIdAsync(employeeId);
            return _mapper.Map<IEnumerable<AccountDTO>>(accounts);
        }



    }
}
