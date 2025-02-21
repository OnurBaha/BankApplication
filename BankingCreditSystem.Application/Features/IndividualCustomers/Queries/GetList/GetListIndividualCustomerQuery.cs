using AutoMapper;
using MediatR;
using BankingCreditSystem.Application.Features.IndividualCustomers.Dtos.Responses;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Core.Repositories;

namespace BankingCreditSystem.Application.Features.IndividualCustomers.Queries.GetList;

public class GetListIndividualCustomerQuery : IRequest<Paginate<IndividualCustomerResponse>>
{
    public PaginationParams PaginationParams { get; set; }

    public class GetListIndividualCustomerQueryHandler : IRequestHandler<GetListIndividualCustomerQuery, Paginate<IndividualCustomerResponse>>
    {
        private readonly IIndividualCustomerRepository _individualCustomerRepository;
        private readonly IMapper _mapper;

        public GetListIndividualCustomerQueryHandler(IIndividualCustomerRepository individualCustomerRepository, IMapper mapper)
        {
            _individualCustomerRepository = individualCustomerRepository;
            _mapper = mapper;
        }

        public async Task<Paginate<IndividualCustomerResponse>> Handle(GetListIndividualCustomerQuery request, CancellationToken cancellationToken)
        {
            var individualCustomers = await _individualCustomerRepository.GetListAsync(
                index: request.PaginationParams.PageNumber,
                size: request.PaginationParams.PageSize,
                cancellationToken: cancellationToken
            );

            var response = _mapper.Map<Paginate<IndividualCustomerResponse>>(individualCustomers);
            return response;
        }
    }
} 