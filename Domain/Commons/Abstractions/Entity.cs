using System;

namespace Domain.Commons.Abstractions;

/// <summary>
/// Represent the base class from where all the 
/// domain entities inherit
/// </summary>
public abstract class Entity
{
    public Guid Id { get; init; }

    /// <summary>
    /// This default constructor is required for creating entities configurations in the database
    /// using an ORM.
    /// </summary>
    protected Entity() { }

    protected Entity( Guid id )
    {
        Id = id;
    }
}
