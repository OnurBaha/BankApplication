using FluentValidation.Results;

namespace BankingCreditSystem.Core.CrossCuttingConcerns.Exceptions.Types;

public class ValidationException : Exception
{
    public IEnumerable<ValidationFailure> Errors { get; }

    public ValidationException(IEnumerable<ValidationFailure> errors) : base(BuildErrorMessage(errors))
    {
        Errors = errors;
    }

    private static string BuildErrorMessage(IEnumerable<ValidationFailure> errors)
    {
        return $"Validation failed: {string.Join(", ", errors.Select(x => x.ErrorMessage))}";
    }
} 