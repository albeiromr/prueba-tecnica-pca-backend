namespace Domain.Commons.Constants;

/// <summary>
/// Represents the exceptions and error descriptions thrown when creating Result objects
/// </summary>
internal static class ResultCreationConstants
{
    public static string? MissingValidError = "A failed result object should have a valid error";
    public static string? NotNullErrorDetected = "A successful result object can´t have errors";
    public static string? NullGenericTypeDetected = "A Result<T> instance can´t receive a null value as the T type in it´s constructor";
}
