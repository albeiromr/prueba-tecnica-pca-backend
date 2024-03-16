using Domain.Reservations.Interfaces;
using System;

namespace Domain.Commons.Services;

public sealed class PlaneSeatService : IPlaneSeatService
{
    private readonly Random random = new Random();
    public string? GetSeatCode()
    {
        // Allowed characters for generating the seat code (from 'a' to 'f' and '0' to '9')
        string allowedChars = "ABCDEF0123456789";

        // Generate the seat code randomly (letter first, then number)
        char[] codeChars = new char[2];

        // Generate random letter
        int randomLetterIndex = random.Next(0, 6); // 6 letters in total (from 'a' to 'f')
        codeChars[0] = allowedChars[randomLetterIndex];

        // Generate random number (0 to 9)
        int randomNumber = random.Next(0, 10);
        codeChars[1] = (char)('0' + randomNumber);

        return new string(codeChars);
    }
}
