using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.Handlers;

namespace BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context, IHttpExceptionHandler exceptionHandler)
    {
        try
        {
            await _next(context);
        }
        catch (Exception exception)
        {
            _logger.LogError(exception, "An unhandled exception has occurred.");
            await exceptionHandler.HandleExceptionAsync(exception, context.Response);
        }
    }
} 