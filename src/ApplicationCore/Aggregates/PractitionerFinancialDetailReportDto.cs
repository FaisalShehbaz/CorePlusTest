namespace ApplicationCore.Aggregates;

public record PractitionerFinancialDetailReportDto(
    int practitionerid,
    string date,
    string practitionername,
    string clientName,
    string appointmentType,
    int duration,
    int revenue,
    int cost);
