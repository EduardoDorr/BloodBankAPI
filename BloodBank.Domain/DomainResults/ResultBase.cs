using BloodBank.Domain.DomainErrors;

namespace BloodBank.Domain.DomainResults;

public abstract class ResultBase
{
    public IReadOnlyList<IError> Errors => _errors;

    protected readonly List<IError> _errors = new List<IError>();

    public bool Success { get; protected set; }
}