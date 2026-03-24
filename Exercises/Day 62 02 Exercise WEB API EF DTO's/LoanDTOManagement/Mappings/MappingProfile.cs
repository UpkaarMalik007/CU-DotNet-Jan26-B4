using AutoMapper;
using LoanDTOManagement.Models;
using LoanDTOManagement.DTOs;
namespace LoanDTOManagement.Mappings
{
    public class MappingProfile: Profile
    {
       public MappingProfile()
        {
            //Source -> Destination
            //From Client to Database
            CreateMap<LoanCreateDTO, Loan>();
            CreateMap<LoanUpdateDTO, Loan>();

            //From Database to Client
            CreateMap<Loan, LoanReadDTO>();

            //If you want to support bothe directions (Create/Update);
            //CreateMap<LoanCreateDTO, Loan>().ReverseMap();
        }
    }
}
