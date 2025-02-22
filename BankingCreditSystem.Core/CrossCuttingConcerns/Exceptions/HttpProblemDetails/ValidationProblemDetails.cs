using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.HttpProblemDetails;

public class ValidationProblemDetails : ProblemDetails
{
    public IEnumerable<ValidationFailureDetails> Errors { get; init; }

    public ValidationProblemDetails(IEnumerable<ValidationFailureDetails> errors)
    {
        Title = "Validation error(s)";
        Detail = "One or more validation errors occurred.";
        Errors = errors;
        Status = StatusCodes.Status400BadRequest;
        Type = "https://example.com/probs/validation";
    }
}

public class ValidationFailureDetails
{
    public string Property { get; init; }
    public string Error { get; init; }
} 