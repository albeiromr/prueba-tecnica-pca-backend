namespace Domain.Reservations.Interfaces;

/// <summary>
/// Contains Methods for working with plane seats
/// </summary>
public interface IPlaneSeatService
{
    /// <summary>
    /// Generates a plane seat string for a given flight reservation
    /// </summary>
    string? GetSeatCode();
}
