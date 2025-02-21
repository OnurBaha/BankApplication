using AutoMapper;
using MediatR;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Responses;
using BankingCreditSystem.Application.Features.IndividualCustomers.Rules;
using BankingCreditSystem.Application.Features.IndividualCustomers.Constants;
using BankingCreditSystem.Application.Services.Repositories;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Commands.Delete;

public class DeleteIndividualCustomerCommand : IRequest<DeletedIndividualCustomerResponse>
{
    public Guid Id { get; set; }

    public class DeleteIndividualCustomerCommandHandler : IRequestHandler<DeleteIndividualCustomerCommand, DeletedIndividualCustomerResponse>
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IMapper _mapper;
        private readonly IndividualCustomerBusinessRules _businessRules;

        public DeleteIndividualCustomerCommandHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper, IndividualCustomerBusinessRules businessRules)
        {
            _individualCustomerRepository = individualCustomerRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<DeletedIndividualCustomerResponse> Handle(DeleteIndividualCustomerCommand request, CancellationToken cancellationToken)
        {
            var individualCustomer = await _businessRules.CheckIfCustomerExists(request.Id);
            
            await _individualCustomerRepository.DeleteAsync(individualCustomer);
            
            return new DeletedIndividualCustomerResponse 
            { 
                Id = request.Id,
                Message = IndividualCustomerMessages.CustomerDeleted 
            };
        }
    }
} 