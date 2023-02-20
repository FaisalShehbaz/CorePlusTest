namespace ApplicationCore.Constants;

public static class AppConstants
{
    public static class ErrorMessages
    {
        public const string DataRead = "Data read error";
    }

    public static class FilePath
    {
        public const string Practitioners = @"./../Infrastructure/Data/practitioners.json";
        public const string Appointments = @"./../Infrastructure/Data/appointments.json";
    }

    public static class AllowedSpecificationOrigns
    {
        public const string LocalProjectPath = "http://localhost:5173/";
    }
}
