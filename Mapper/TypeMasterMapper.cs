using AutoMapper;
using MaverickBankReal.Models.DTOs;
using MaverickBankReal.Models;

namespace MaverickBankReal.Mapper
{
    public class TypeMasterMapper : Profile
    {
        public TypeMasterMapper()
        {
            CreateMap<AccountTypeMaster, AccountTypeMasterDTO>().ReverseMap();
            CreateMap<LoanTypeMaster, LoanTypeMasterDTO>().ReverseMap();
            CreateMap<LoanStatusMaster, LoanStatusMasterDTO>().ReverseMap();
            CreateMap<TransactionTypeMaster, TransactionTypeMasterDTO>().ReverseMap();
        }
    }
}
