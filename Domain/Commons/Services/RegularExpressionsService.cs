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
}
