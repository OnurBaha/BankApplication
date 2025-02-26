using AutoMapper;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Requests;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Responses;
using BankingCreditSystem.Domain.Entities;

namespace BankingCreditSystem.Application.Features.CorporateCustomers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CorporateCustomer, CreateCorporateCustomerRequest>().ReverseMap();
        CreateMap<CorporateCustomer, UpdateCorporateCustomerRequest>().ReverseMap();
        
        CreateMap<CorporateCustomer, CreatedCorporateCustomerResponse>();
        CreateMap<CorporateCustomer, UpdatedCorporateCustomerResponse>();
        CreateMap<CorporateCustomer, DeletedCorporateCustomerResponse>();
        CreateMap<CorporateCustomer, CorporateCustomerResponse>();
        
        CreateMap<Paginate<CorporateCustomer>, Paginate<CorporateCustomerResponse>>();
    }
} 