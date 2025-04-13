using AutoMapper;
using MaverickBankReal.Models.DTOs;
using MaverickBankReal.Models;

namespace MaverickBankReal.Mapper
{
    public class AdminMapper : Profile
    {
        public AdminMapper()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Account, AccountDTO>().ReverseMap();
            CreateMap<Transaction, TransactionDTO>().ReverseMap();
            CreateMap<Loan, LoanDTO>().ReverseMap();
            CreateMap<BankEmployee, EmployeeDTO>().ReverseMap();
            CreateMap<Admin, AdminDTO>().ReverseMap();
        }
    }
}
