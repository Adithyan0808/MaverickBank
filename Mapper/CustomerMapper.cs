﻿using AutoMapper;
using MaverickBankReal.Models.DTOs;
using MaverickBankReal.Models;

namespace MaverickBankReal.Mapper
{
    public class CustomerMapper : Profile
    {
        public CustomerMapper()
        {
            CreateMap<Customer, CustomerDTO>().ReverseMap();
            CreateMap<Account, AccountDTO>().ReverseMap();
            CreateMap<Transaction, TransactionDTO>().ReverseMap();
            CreateMap<Loan, LoanDTO>().ReverseMap();
        }
    }
}
