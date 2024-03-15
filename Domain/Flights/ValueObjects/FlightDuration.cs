using Domain.Commons.Constants;
using System;

namespace Domain.Flights.ValueObjects;

/// <summary>
/// Represents all the time and dates data about the flight
/// </summary>
public sealed record FlightDuration
{
    public DateTime DepartureDate { get; private set; }
    public string DepartureHour 
    {
        get
        {
            string hour = $"{DepartureDate.Hour}:{DepartureDate.Minute}";
            return hour;
        }
    }

    public DateTime ArrivalDate { get; private set; }
    public string ArrivalHour
    {
        get
        {
            string hour = $"{ArrivalDate.Hour}:{ArrivalDate.Minute}";
            return hour;
        }
    }

    public double DurationInHours 
    { 
        get
        {
            TimeSpan difference = ArrivalDate - DepartureDate;
            double totalHours = difference.TotalHours;
            return totalHours;
        }
        private set { }
    }

    public FlightDuration(DateTime departureDate, DateTime arrivalDate)
    {
        if(arrivalDate == departureDate)
            throw new InvalidOperationException(FlightCreationConstants.ArrivalDateSameAsDeparture);
        if (arrivalDate < departureDate)
            throw new InvalidOperationException(FlightCreationConstants.ArrivalDateEarlierThanDeparture);

        DepartureDate = departureDate;
        ArrivalDate = arrivalDate;
    }
}
