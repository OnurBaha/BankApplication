using AutoMapper;
using MediatR;
using BankingCreditSystem.Application.Features.CorporateCustomers.Dtos.Responses;
using BankingCreditSystem.Application.Services.Repositories;

namespace BankingCreditSystem.Application.Features.CorporateCustomers.Queries.GetList;

public class GetListCorporateCustomerQuery : IRequest<Paginate<CorporateCustomerResponse>>
{
    public PaginationParams PaginationParams { get; set; }

    public class GetListCorporateCustomerQueryHandler : IRequestHandler<GetListCorporateCustomerQuery, Paginate<CorporateCustomerResponse>>
    {
        private readonly ICorporateCustomerRepository _corporateCustomerRepository;
        private readonly IMapper _mapper;

        public GetListCorporateCustomerQueryHandler(ICorporateCustomerRepository corporateCustomerRepository, IMapper mapper)
        {
            _corporateCustomerRepository = corporateCustomerRepository;
            _mapper = mapper;
        }

        public async Task<Paginate<CorporateCustomerResponse>> Handle(GetListCorporateCustomerQuery request, CancellationToken cancellationToken)
        {
            var corporateCustomers = await _corporateCustomerRepository.GetListAsync(
                index: request.PaginationParams.PageNumber,
                size: request.PaginationParams.PageSize,
                cancellationToken: cancellationToken
            );

            var response = _mapper.Map<Paginate<CorporateCustomerResponse>>(corporateCustomers);
            return response;
        }
    }
} 