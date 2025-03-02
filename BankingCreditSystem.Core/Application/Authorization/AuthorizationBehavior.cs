using BankingCreditSystem.Core.Security;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace BankingCreditSystem.Core.Application.Authorization;

public class AuthorizationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>, ISecuredRequest
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ITokenHelper _tokenHelper;

    public AuthorizationBehavior(IHttpContextAccessor httpContextAccessor, ITokenHelper tokenHelper)
    {
        _httpContextAccessor = httpContextAccessor;
        _tokenHelper = tokenHelper;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var userRole = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role)?.Value;
        var userId = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        if (!request.Roles.Contains(userRole))
            throw new UnauthorizedAccessException("You are not authorized for this operation.");

        // Eğer müşteri ise ve kendi verisi değilse erişimi engelle
        if (userRole == "Customer" && request is ICustomerSpecificRequest customerRequest)
        {
            if (customerRequest.CustomerId.ToString() != userId)
                throw new UnauthorizedAccessException("You can only access your own data.");
        }

        return await next();
    }
} 