using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using BankingCreditSystem.Application.Services.Repositories;

namespace BankingCreditSystem.Application.Features.CreditApplications.Queries.GetListByCustomer
{
    public class GetListByCustomerCreditApplicationQuery : IRequest<Paginate<CreditApplicationResponse>>
    {
        public Guid CustomerId { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }

        public class GetListByCustomerCreditApplicationQueryHandler : IRequestHandler<GetListByCustomerCreditApplicationQuery, Paginate<CreditApplicationResponse>>
        {
            private readonly ICreditApplicationRepository _creditApplicationRepository;
            private readonly IMapper _mapper;

            public GetListByCustomerCreditApplicationQueryHandler(
                ICreditApplicationRepository creditApplicationRepository,
                IMapper mapper)
            {
                _creditApplicationRepository = creditApplicationRepository;
                _mapper = mapper;
            }

            public async Task<Paginate<CreditApplicationResponse>> Handle(GetListByCustomerCreditApplicationQuery request, CancellationToken cancellationToken)
            {
                var applications = await _creditApplicationRepository.GetListAsync(
                    predicate: c => c.CustomerId == request.CustomerId,
                    index: request.PageIndex,
                    size: request.PageSize,
                    include: c => c.Include(x => x.CreditType),
                    cancellationToken: cancellationToken
                );

                var response = _mapper.Map<Paginate<CreditApplicationResponse>>(applications);
                return response;
            }
        }
    }
} 