using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.Handlers;

public abstract class ExceptionHandler
{
    public Task HandleExceptionAsync(Exception exception, HttpResponse response)
    {
        response.ContentType = "application/json";
        
        var problemDetails = HandleException(exception);
        response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;
        
        return response.WriteAsync(JsonSerializer.Serialize(problemDetails));
    }

    protected abstract ProblemDetails HandleException(Exception exception);
} 