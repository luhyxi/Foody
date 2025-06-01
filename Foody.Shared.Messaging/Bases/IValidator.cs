using Foody.Shared.Messaging.ValueObjects;

namespace Foody.Shared.Messaging.Bases;

public interface IValidator<T>
{
    Task<ValidationResult> ValidateAsync(T instance, CancellationToken cancellationToken = default);
}

public class ValidationResult (bool isValid = true)
{
    public bool IsValid { get; set; } = isValid;
    public List<Error> Errors { get; set; } = new();
}