namespace Application.Reservations.Dtos;

public class CreateReservationDto
{
    public string? ClientName { get; set; }
    public string? ClientLastName { get; set; }
    public string? ClientEmail { get; set; }
    public string? FlightCode { get; set; }
}
