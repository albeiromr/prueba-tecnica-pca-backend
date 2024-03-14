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
    /// Represents the creation date of the entity register in the database
    /// </summary>
    public DateTime CreatedAt { get; init; }

    /// <summary>
    /// Represent the date where the last modification was made to the entity register
    /// in the database
    /// </summary>
    public DateTime LastModificationAt { get; private set; }

    /// <summary>
    /// This default constructor is required for creating entities configurations in the database
    /// using an ORM.
    /// </summary>
    protected Entity() { }
    protected Entity(
        Guid id,
        DateTime createdAt,
        DateTime lastmodificationAt
    )
    {
        Id = id;
        CreatedAt = createdAt;
        LastModificationAt = lastmodificationAt;
    }
}
