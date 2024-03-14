using Domain.Commons.Interfaces;
using System.Text.RegularExpressions;

namespace Domain.Commons.Services;

public sealed class RegularExpressionsService : IRegularExpressionsService
{
    public bool IsValidEmail(string email)
    {
        // pattern for validating emails
        string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(email);
    }

    public bool IsValidNameOrLastName(string nameType)
    {
        // pattern for validating names ans lastnames
        string pattern = @"^[a-zA-Z]+(?:['-][a-zA-Z\s*]+)*$";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(nameType);
    }

    public bool IsValidAirlineCode(string airlineCode)
    {
        // Pattern for validating two uppercase letters only
        string pattern = @"^[A-Z]{2}$";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(airlineCode) && airlineCode.Length == 2;
    }

    public bool IsValidFlightCode(string flightCode)
    {
        // Pattern for validating two uppercase letters followed by 5 digits
        string pattern = @"^[A-Z]{2}\d{5}$";
        Regex regex = new Regex(pattern);
        return regex.IsMatch(flightCode) && flightCode.Length <= 7;
    }
}
