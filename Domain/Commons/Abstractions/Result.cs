using System;
using Domain.Commons.Constants;

namespace Domain.Commons.Abstractions;

/// <summary>
/// Represent the result of every single query 
/// or command that occurs into the application.
/// </summary>
public record Result
{
    /// <summary>
    /// It's value is true if the operation is successful, otherwise the value is false
    /// </summary>
    public bool Success { get; init; }

    /// <summary>
    /// Represents the operation failure cause in case that there was any 
    /// </summary>
    public Error? Error { get; init; }

    public Result( bool success, Error error)
    {
        if (success == true && error != null)
            throw new InvalidOperationException(ResultCreationConstants.NotNullErrorDetected!);

        if(success == false && error == null)
            throw new InvalidOperationException(ResultCreationConstants.MissingValidError!);

        Success = success;
        Error = error;
    }
}

public sealed record Result<TResponse> : Result
{
    /// <summary>
    /// Represents the data that must be sent to the user
    /// </summary>
    public TResponse? Data { get; init; }

    public Result(TResponse response, bool success, Error error) : base(success, error)
    {
        if (response == null)
            throw new ArgumentNullException(ResultCreationConstants.NullGenericTypeDetected!, nameof(response));

        Data = response;
    }
}
