using ApplicationCore.Aggregates;

namespace ApplicationCore.Interfaces;

public interface IFinancialReportService
{
    Task<IReadOnlyCollection<PractitionerFinancialSummaryReportDto>> GetPractitionerFinancialSummaryReport(int? practitionerId, DateOnly? startDate, DateOnly? endDate);

    Task<IReadOnlyCollection<PractitionerFinancialDetailReportDto>> GetPractitionerFinancialDetailReport(int? practitionerId, int month, DateOnly? startDate, DateOnly? endDate);
}
