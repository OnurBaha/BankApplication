using AutoMapper;
using MediatR;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Requests;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Responses;
using BankingCreditSystem.Application.Features.CorporateCustomers.Rules;
using BankingCreditSystem.Application.Features.CorporateCustomers.Constants;
using BankingCreditSystem.Application.Services.Repositories;

namespace BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Update;

public class UpdateCorporateCustomerCommand : IRequest<UpdatedCorporateCustomerResponse>
{
    public UpdateCorporateCustomerRequest Request { get; set; } = default!;

    public class UpdateCorporateCustomerCommandHandler : IRequestHandler<UpdateCorporateCustomerCommand, UpdatedCorporateCustomerResponse>
    {
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;
        private readonly IMapper _mapper;
        private readonly CorporateCustomerBusinessRules _businessRules;

        public UpdateCorporateCustomerCommandHandler(ICorporateCustomerRepository corporateCustomerRepository, IMapper mapper, CorporateCustomerBusinessRules businessRules)
        {
            _corporateCustomerRepository = corporateCustomerRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<UpdatedCorporateCustomerResponse> Handle(UpdateCorporateCustomerCommand request, CancellationToken cancellationToken)
        {
            var corporateCustomer = await _businessRules.CheckIfCustomerExists(request.Request.Id);
            
            _mapper.Map(request.Request, corporateCustomer);
            var updatedCustomer = await _corporateCustomerRepository.UpdateAsync(corporateCustomer);
            
            var response = _mapper.Map<UpdatedCorporateCustomerResponse>(updatedCustomer);
            response.Message = CorporateCustomerMessages.CustomerUpdated;
            
            return response;
        }
    }
} 