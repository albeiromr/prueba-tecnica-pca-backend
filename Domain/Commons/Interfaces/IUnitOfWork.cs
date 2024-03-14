using System.Threading;
using System.Threading.Tasks;

namespace Domain.Commons.Interfaces;

/// <summary>
/// Represents the required methods for implementing the unit of work design pattern
/// </summary>
public interface IUnitofWork
{
    /// <summary>
    /// Saves all pending entity changes into the database 
    /// if all and only all transactions were successfuly 
    /// handled it returns true, otherwise it internally 
    /// dispatches a rollback of all the transactions changes.
    /// returns true if changes were handled and saved successfully and 
    /// false if not
    /// </summary>
    Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Rolls back all the entity changes if the savechanges operation
    /// fails, returns true if changes were rolled back successfully and 
    /// false if not
    /// </summary>
    Task<bool> RollBackChangesAsync(CancellationToken cancellationToken = default);
}
