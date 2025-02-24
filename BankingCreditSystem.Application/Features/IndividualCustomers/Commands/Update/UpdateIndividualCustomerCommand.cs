using AutoMapper;
using MediatR;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Requests;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Responses;
using BankingCreditSystem.Application.Features.IndividualCustomers.Rules;
using BankingCreditSystem.Application.Features.IndividualCustomers.Constants;
using BankingCreditSystem.Application.Services.Repositories;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Update;

public class UpdateIndividualCustomerCommand : IRequest<UpdatedIndividualCustomerResponse>
{
    public UpdateIndividualCustomerRequest Request { get; set; } = default!;

    public class UpdateIndividualCustomerCommandHandler : IRequestHandler<UpdateIndividualCustomerCommand, UpdatedIndividualCustomerResponse>
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IMapper _mapper;
        private readonly IndividualCustomerBusinessRules _businessRules;

        public UpdateIndividualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper, IndividualCustomerBusinessRules businessRules)
        {
            _individualCustomerRepository = individualCustomerRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<UpdatedIndividualCustomerResponse> Handle(UpdateIndividualCustomerCommand request, CancellationToken cancellationToken)
        {
            var individualCustomer = await _businessRules.CheckIfCustomerExists(request.Request.Id);
            
            _mapper.Map(request.Request, individualCustomer);
            var updatedCustomer = await _individualCustomerRepository.UpdateAsync(individualCustomer);
            
            var response = _mapper.Map<UpdatedIndividualCustomerResponse>(updatedCustomer);
            response.Message = IndividualCustomerMessages.CustomerUpdated;
            
            return response;
        }
    }
} 