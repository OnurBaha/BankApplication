using AutoMapper;
using MediatR;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Responses;
using BankingCreditSystem.Application.Features.CorporateCustomers.Rules;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Core.Application.Authorization;

namespace BankingCreditSystem.Application.Features.CorporateCustomers.Queries.GetById;

public class GetByIdCorporateCustomerQuery : IRequest<CorporateCustomerResponse>, ISecuredRequest, ICustomerSpecificRequest
{
    public Guid Id { get; set; }
    public Guid CustomerId => Id;

    public string[] Roles => new[] { "Customer", "BankStaff" };

    public class GetByIdCorporateCustomerQueryHandler : IRequestHandler<GetByIdCorporateCustomerQuery, CorporateCustomerResponse>
    {
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;
        private readonly IMapper _mapper;
        private readonly CorporateCustomerBusinessRules _businessRules;

        public GetByIdCorporateCustomerQueryHandler(ICorporateCustomerRepository corporateCustomerRepository, IMapper mapper, CorporateCustomerBusinessRules businessRules)
        {
            _corporateCustomerRepository = corporateCustomerRepository;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public async Task<CorporateCustomerResponse> Handle(GetByIdCorporateCustomerQuery request, CancellationToken cancellationToken)
        {
            var corporateCustomer = await _businessRules.CheckIfCustomerExists(request.Id);
            return _mapper.Map<CorporateCustomerResponse>(corporateCustomer);
        }
    }
} 