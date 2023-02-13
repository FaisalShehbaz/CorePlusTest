using ApplicationCore.Interfaces;

namespace PublicApi.Endpoints.Report;

public static class GetFinancialSummaryReport
{
    public static RouteGroupBuilder MapGetFinancialSummaryReport(this RouteGroupBuilder group)
    {
        group.MapGet("/financialSummaryReport", 
            async (
                int? practitionerId,
                DateOnly? startDate,
                DateOnly? endDate,
                IFinancialReportService financialReportService
                ) =>
        {
            var reportData = await financialReportService.GetPractitionerFinancialSummaryReport(practitionerId, startDate, endDate);
            return Results.Ok(reportData);
        });

        return group;
    }
}
