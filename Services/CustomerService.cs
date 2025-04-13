using AutoMapper;
using MaverickBankReal.Interfaces;
using MaverickBankReal.Repo;
using MaverickBankReal.Models.DTOs;
using MaverickBankReal.Interfaces.RepoInterface;
using MaverickBankReal.Models;

namespace MaverickBankReal.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerDTO> GetCustomerDetailsAsync(int customerId)
        {
            var customer = await _customerRepository.GetById(customerId);
            return _mapper.Map<CustomerDTO>(customer);
        }

        public async Task<CustomerDTO> UpdateCustomerAsync(int customerId, CustomerDTO customerDTO)
        {
            var customer = _mapper.Map<Customer>(customerDTO);
            customer.CustomerID = customerId; // Ensure the ID is set
            var UpdatedCustomer = await _customerRepository.Update(customerId, customer);
            return _mapper.Map<CustomerDTO>(UpdatedCustomer);
        }

        public async Task<IEnumerable<TransactionDTO>> GetTransactionsByCustomerIdAsync(int customerId)
        {
            var transactions = await _customerRepository.GetTransactionsByCustomerIdAsync(customerId);
            return _mapper.Map<IEnumerable<TransactionDTO>>(transactions);
        }

        public async Task<LoanDTO> ApplyForLoanAsync(LoanDTO loanDTO)
        {
            var loan = _mapper.Map<Loan>(loanDTO);
            var addedLoan = await _customerRepository.ApplyForLoanAsync(loan);
            return _mapper.Map<LoanDTO>(addedLoan);
        }

        public async Task<IEnumerable<LoanDTO>> GetLoansByCustomerIdAsync(int customerId)
        {
            var loans = await _customerRepository.GetLoansByCustomerIdAsync(customerId);
            return _mapper.Map<IEnumerable<LoanDTO>>(loans);
        }

        public async Task<IEnumerable<AccountDTO>> GetAccountsByCustomerIdAsync(int customerId)
        {
            var accounts = await _customerRepository.GetAccountsByCustomerIdAsync(customerId);
            return _mapper.Map<IEnumerable<AccountDTO>>(accounts);
        }

    }
}
