using AutoMapper;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Requests;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Responses;
using BankingCreditSystem.Domain.Entities;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<IndividualCustomer, CreateIndividualCustomerRequest>().ReverseMap();
        CreateMap<IndividualCustomer, UpdateIndividualCustomerRequest>().ReverseMap();
        
        CreateMap<IndividualCustomer, CreatedIndividualCustomerResponse>();
        CreateMap<IndividualCustomer, UpdatedIndividualCustomerResponse>();
        CreateMap<IndividualCustomer, DeletedIndividualCustomerResponse>();
        CreateMap<IndividualCustomer, IndividualCustomerResponse>();
        
        CreateMap<Paginate<IndividualCustomer>, Paginate<IndividualCustomerResponse>>();
    }
} 