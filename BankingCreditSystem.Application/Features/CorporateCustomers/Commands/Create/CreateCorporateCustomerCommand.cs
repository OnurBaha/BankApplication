using AutoMapper;
using MediatR;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Requests;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Responses;
using BankingCreditSystem.Application.Features.CorporateCustomers.Rules;
using BankingCreditSystem.Application.Features.CorporateCustomers.Constants;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Domain.Entities;

namespace BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Create;

public class CreateCorporateCustomerCommand : IRequest<CreatedCorporateCustomerResponse>
{
    public CreateCorporateCustomerRequest Request { get; set; } = default!;

    public class CreateCorporateCustomerCommandHandler : IRequestHandler<CreateCorporateCustomerCommand, CreatedCorporateCustomerResponse>
    {
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;
        private readonly IMapper _mapper;
        private readonly CorporateCustomerBusinessRules _businessRules;

        public CreateCorporateCustomerCommandHandler(ICorporateCustomerRepository corporateCustomerRepository, IMapper mapper, CorporateCustomerBusinessRules businessRules)
        {
            _corporateCustomerRepository = corporateCustomerRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<CreatedCorporateCustomerResponse> Handle(CreateCorporateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _businessRules.TaxNumberCannotBeDuplicatedWhenInserted(request.Request.TaxNumber);
            await _businessRules.CompanyRegistrationNumberCannotBeDuplicatedWhenInserted(request.Request.CompanyRegistrationNumber);

            CorporateCustomer corporateCustomer = _mapper.Map<CorporateCustomer>(request.Request);
            CorporateCustomer createdCorporateCustomer = await _corporateCustomerRepository.AddAsync(corporateCustomer);
            
            CreatedCorporateCustomerResponse response = _mapper.Map<CreatedCorporateCustomerResponse>(createdCorporateCustomer);
            response.Message = CorporateCustomerMessages.CustomerCreated;
            
            return response;
        }
    }
} 