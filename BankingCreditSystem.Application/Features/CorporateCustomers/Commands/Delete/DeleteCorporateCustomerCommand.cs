using AutoMapper;
using MediatR;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Responses;
using BankingCreditSystem.Application.Features.CorporateCustomers.Rules;
using BankingCreditSystem.Application.Features.CorporateCustomers.Constants;
using BankingCreditSystem.Application.Services.Repositories;

namespace BankingCreditSystem.Application.Features.CorporateCustomers.Commands.Delete;

public class DeleteCorporateCustomerCommand : IRequest<DeletedCorporateCustomerResponse>
{
    public Guid Id { get; set; }

    public class DeleteCorporateCustomerCommandHandler : IRequestHandler<DeleteCorporateCustomerCommand, DeletedCorporateCustomerResponse>
    {
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;
        private readonly IMapper _mapper;
        private readonly CorporateCustomerBusinessRules _businessRules;

        public DeleteCorporateCustomerCommandHandler(ICorporateCustomerRepository corporateCustomerRepository, IMapper mapper, CorporateCustomerBusinessRules businessRules)
        {
            _corporateCustomerRepository = corporateCustomerRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<DeletedCorporateCustomerResponse> Handle(DeleteCorporateCustomerCommand request, CancellationToken cancellationToken)
        {
            var corporateCustomer = await _businessRules.CheckIfCustomerExists(request.Id);
            
            await _corporateCustomerRepository.DeleteAsync(corporateCustomer);
            
            return new DeletedCorporateCustomerResponse 
            { 
                Id = request.Id,
                Message = CorporateCustomerMessages.CustomerDeleted 
            };
        }
    }
} 