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

    protected Result(IEnumerable<IError> errors)
    {
        if (errors == null)
            throw new ArgumentNullException(nameof(errors), "The list of error messages cannot be null");

        Success = false;
        _errors.AddRange(errors);
    }

    public static Result Ok() => new Result();
    public static Result Fail(string errorMessage) => new Result(errorMessage);
    public static Result Fail(IError error) => new Result(error);
    public static Result Fail(IEnumerable<IError> errors) => new Result(errors);

    //public static implicit operator Result(string errorMessage) => new Result(errorMessage);
    //public static implicit operator Result(IError error) => new Result(error);
    //public static implicit operator Result(IEnumerable<IError> errors) => new Result(errors);
}

public class Result<TValue> : ResultBase
{
    public TValue? Value => _value;

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

    protected Result(IEnumerable<IError> errors)
    {
        if (errors == null)
            throw new ArgumentNullException(nameof(errors), "The list of error messages cannot be null");

        Success = false;
        _errors.AddRange(errors);
    }

    public static Result<TValue> Ok(TValue value) => new Result<TValue>(value);
    public static Result<TValue> Fail(string errorMessage) => new Result<TValue>(errorMessage);
    public static Result<TValue> Fail(IError error) => new Result<TValue>(error);
    public static Result<TValue> Fail(IEnumerable<IError> errors) => new Result<TValue>(errors);

    //public static implicit operator Result<TValue>(TValue value) => new Result<TValue>(value);
    //public static implicit operator Result<TValue>(string errorMessage) => new Result<TValue>(errorMessage);
    //public static implicit operator Result<TValue>(IError error) => new Result<TValue>(error);
    //public static implicit operator Result<TValue>(IEnumerable<IError> errors) => new Result<TValue>(errors);
}

public static class ResultExtensions
{
    public static Result<T> ToResult<T>(this T value)
    {
        return Result<T>.Ok(value);
    }
}