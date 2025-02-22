using Microsoft.AspNetCore.Http;

namespace BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.Handlers;

public interface IHttpExceptionHandler
{
    Task HandleExceptionAsync(Exception exception, HttpResponse response);
} 