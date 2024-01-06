using BloodBank.Domain.DomainErrors;

namespace BloodBank.Domain.DomainResults;

public class Result : ResultBase
{
    protected Result()
    {
        Success = true;
    }

    protected Result(string errorMessage)
    {
        Success = false;
        _errors.Add(new Error(errorMessage, errorMessage));
    }

    protected Result(IError error)
    {
        Success = false;
        _errors.Add(error);
    }

    protected Result(IEnumerable<string> errorMessages)
    {
        if (errorMessages is null)
            throw new ArgumentNullException(nameof(errorMessages), "The list of error messages cannot be null");

        Success = false;
        foreach (var errorMessage in errorMessages)
            _errors.Add(new Error(errorMessage, errorMessage));
    }

    protected Result(IEnumerable<IError> errors)
    {
        if (errors is null)
            throw new ArgumentNullException(nameof(errors), "The list of errors cannot be null");

        Success = false;
        _errors.AddRange(errors);
    }

    public static Result Ok() => new Result();
    public static Result Fail(string errorMessage) => new Result(errorMessage);
    public static Result Fail(IError error) => new Result(error);
    public static Result Fail(IEnumerable<string> errorMessages) => new Result(errorMessages);
    public static Result Fail(IEnumerable<IError> errors) => new Result(errors);

    public static implicit operator Result(string errorMessage) => Fail(errorMessage);
    public static implicit operator Result(Error error) => Fail(error);
    public static implicit operator Result(List<string> errorMessages) => Fail(errorMessages);
    public static implicit operator Result(List<Error> errors) => Fail(errors);
}

public class Result<TValue> : ResultBase
{
    public TValue? Value => _value;
    public TValue? ValueOrDefault => _value ?? default;

    private readonly TValue? _value;

    protected Result()
    {
        Success = true;
    }

    protected Result(TValue value)
    {
        Success = true;
        _value = value;
    }

    protected Result(string errorMessage)
    {
        Success = false;
        _errors.Add(new Error(errorMessage, errorMessage));
    }

    protected Result(IError error)
    {
        Success = false;
        _errors.Add(error);
    }

    protected Result(IEnumerable<string> errorMessages)
    {
        if (errorMessages is null)
            throw new ArgumentNullException(nameof(errorMessages), "The list of error messages cannot be null");

        Success = false;
        foreach (var errorMessage in errorMessages)
            _errors.Add(new Error(errorMessage, errorMessage));
    }

    protected Result(IEnumerable<IError> errors)
    {
        if (errors == null)
            throw new ArgumentNullException(nameof(errors), "The list of errors cannot be null");

        Success = false;
        _errors.AddRange(errors);
    }

    public static Result<TValue> Ok(TValue value) => new Result<TValue>(value);
    public static Result<TValue> Fail(string errorMessage) => new Result<TValue>(errorMessage);
    public static Result<TValue> Fail(IError error) => new Result<TValue>(error);
    public static Result<TValue> Fail(IEnumerable<string> errorMessages) => new Result<TValue>(errorMessages);
    public static Result<TValue> Fail(IEnumerable<IError> errors) => new Result<TValue>(errors);

    public static implicit operator Result<TValue>(TValue value) => Ok(value);
    public static implicit operator Result<TValue>(string errorMessage) => Fail(errorMessage);
    public static implicit operator Result<TValue>(Error error) => Fail(error);
    public static implicit operator Result<TValue>(List<string> errorMessages) => Fail(errorMessages);
    public static implicit operator Result<TValue>(List<Error> errors) => Fail(errors);
}