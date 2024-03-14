using System;
using Domain.Commons.Constants;

namespace Domain.Commons.Abstractions;

/// <summary>
/// Represents the errors that could appears when handling queries and commands 
/// </summary>
public sealed record Error
{
    public string? Name { get; init; }
    public string? Description { get; init; }

    public Error(string name, string description)
    {
        if(name == null || name == "" )
            throw new ArgumentException(ErrorCreationConstants.InvalidErrorName!, nameof(name));

        if(description == null || description == "")
            throw new ArgumentException(ErrorCreationConstants.InvalidErrorDescription!, nameof(description));

        Name = name;
        Description = description;
    }
}
