using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;
using BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.Types;

namespace BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.Handlers;

public class HttpExceptionHandler : ExceptionHandler
{
    protected override ProblemDetails HandleException(Exception exception)
    {
        ProblemDetails problemDetails = exception switch
        {
            BusinessException businessException => new BusinessProblemDetails(businessException.Message),
            ValidationException validationException => new ValidationProblemDetails(
                validationException.Errors.Select(error => new ValidationFailureDetails
                {
                    Property = error.PropertyName,
                    Error = error.ErrorMessage
                })),
            AuthorizationException authorizationException => new AuthorizationProblemDetails(authorizationException.Message),
            NotFoundException notFoundException => new NotFoundProblemDetails(notFoundException.Message),
            _ => new InternalServerErrorProblemDetails(exception.Message)
        };

        return problemDetails;
    }
} 