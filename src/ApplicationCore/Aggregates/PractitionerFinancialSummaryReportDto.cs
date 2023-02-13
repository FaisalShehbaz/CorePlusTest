namespace ApplicationCore.Aggregates;

public record PractitionerFinancialSummaryReportDto(
    string practitionerName,
    string monthName,
    int month,
    int revenue,
    int cost
    );
