using AutoMapper;
using MediatR;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Requests;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Responses;
using BankingCreditSystem.Application.Features.IndividualCustomers.Rules;
using BankingCreditSystem.Application.Features.IndividualCustomers.Constants;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Domain.Entities;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Create;

public class CreateIndividualCustomerCommand : IRequest<CreatedIndividualCustomerResponse>
{
    public CreateIndividualCustomerRequest Request { get; set; } = default!;

    public class CreateIndividualCustomerCommandHandler : IRequestHandler<CreateIndividualCustomerCommand, CreatedIndividualCustomerResponse>
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IMapper _mapper;
        private readonly IndividualCustomerBusinessRules _businessRules;

        public CreateIndividualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper, IndividualCustomerBusinessRules businessRules)
        {
            _individualCustomerRepository = individualCustomerRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<CreatedIndividualCustomerResponse> Handle(CreateIndividualCustomerCommand request, CancellationToken cancellationToken)
        {
            await _businessRules.NationalIdCannotBeDuplicatedWhenInserted(request.Request.NationalId);

            IndividualCustomer individualCustomer = _mapper.Map<IndividualCustomer>(request.Request);
            IndividualCustomer createdIndividualCustomer = await _individualCustomerRepository.AddAsync(individualCustomer);
            
            CreatedIndividualCustomerResponse response = _mapper.Map<CreatedIndividualCustomerResponse>(createdIndividualCustomer);
            response.Message = IndividualCustomerMessages.CustomerCreated;
            
            return response;
        }
    }
} 