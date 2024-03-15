namespace Domain.Commons.Constants;

/// <summary>
/// Represents the exceptions and error descriptions thrown when creating Reservation objects
/// </summary>
internal static class ReservationCreationConstants
{
    public static string? EmptyOrNullEmail = "An empty string or null value can't be recived as parameter";
    public static string? InvalidEmailFormat = "An Invalid email format was provided";
    public static string? EmptyOrNullFirstName = "An empty string or null value can't be recived as first name";
    public static string? InvalidFirstNameFormat = "An Invalid first name format was provided";
    public static string? EmptyOrNullFirstLastName = "An empty string or null value can't be recived as first last name";
    public static string? InvalidFirstLastNameFormat = "An Invalid first last name format was provided";
    public static string? NullOrEmptySeat = "A null or empty string was provided as plane seat";
    public static string? SeatStringToShort = "A seat string can´t have less than 2 characters";
    public static string? SeatStringToLong = "A seat string can´t have more than 3 characters";
}
