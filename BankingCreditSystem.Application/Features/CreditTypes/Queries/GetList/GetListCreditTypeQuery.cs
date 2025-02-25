using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using BankingCreditSystem.Application.Services;
using BankingCreditSystem.Application.Services.Repositories;
using BankingCreditSystem.Domain.Enums;

namespace BankingCreditSystem.Application.Features.CreditTypes.Queries.GetList
{
    public class GetListCreditTypeQuery : IRequest<Paginate<CreditTypeResponse>>
    {
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public CustomerType? CustomerType { get; set; }

        public class GetListCreditTypeQueryHandler : IRequestHandler<GetListCreditTypeQuery, Paginate<CreditTypeResponse>>
        {
            private readonly ICreditTypeRepository _creditTypeRepository;
            private readonly IMapper _mapper;

            public GetListCreditTypeQueryHandler(ICreditTypeRepository creditTypeRepository, IMapper mapper)
            {
                _creditTypeRepository = creditTypeRepository;
                _mapper = mapper;
            }

            public async Task<Paginate<CreditTypeResponse>> Handle(GetListCreditTypeQuery request, CancellationToken cancellationToken)
            {
                var creditTypes = request.CustomerType.HasValue
                    ? await _creditTypeRepository.GetListAsync(
                        predicate: c => c.CustomerType == request.CustomerType.Value,
                        index: request.PageIndex,
                        size: request.PageSize,
                        cancellationToken: cancellationToken)
                    : await _creditTypeRepository.GetListAsync(
                        index: request.PageIndex,
                        size: request.PageSize,
                        cancellationToken: cancellationToken);

                var response = _mapper.Map<Paginate<CreditTypeResponse>>(creditTypes);
                return response;
            }
        }
    }
} 