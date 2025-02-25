using AutoMapper;
using BankingCreditSystem.Application.Features.CreditApplications.Commands;
using BankingCreditSystem.Application.Features.CreditApplications.Queries;
using BankingCreditSystem.Domain.Entities;


namespace BankingCreditSystem.Application.Features.CreditApplications.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreditApplication, CreditApplicationResponse>()
                .ForMember(dest => dest.CreditTypeName, opt => opt.MapFrom(src => src.CreditType.Name))
                .ForMember(dest => dest.CustomerName, opt => opt.MapFrom(src => 
                    src.Customer.GetType() == typeof(IndividualCustomer)
                        ? $"{((IndividualCustomer)src.Customer).FirstName} {((IndividualCustomer)src.Customer).LastName}"
                        : ((CorporateCustomer)src.Customer).CompanyName));

            CreateMap<CreateCreditApplicationRequest, CreditApplication>();
            
            CreateMap<Paginate<CreditApplication>, Paginate<CreditApplicationResponse>>()
                .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items));
        }
    }
} 