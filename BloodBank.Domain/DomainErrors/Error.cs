namespace BloodBank.Domain.DomainErrors;

public record Error(string Code, string Message) : IError
{
    public static readonly Error None = new(string.Empty, string.Empty);
}