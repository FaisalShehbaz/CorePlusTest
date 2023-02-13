using ApplicationCore.Interfaces;

namespace PublicApi.Endpoints.Report;

public static class GetFinancialDetailsReport
{
    public static RouteGroupBuilder MapGetFinancialDetailsReport(this RouteGroupBuilder group)
    {
        group.MapGet("/financialDetailReport", 
            async (
                int practitionerId,
                int month,
                DateOnly? startDate,
                DateOnly? endDate,
                IFinancialReportService financialReportService
                ) =>
        {
            var reportData = await financialReportService.GetPractitionerFinancialDetailReport(practitionerId, month, startDate, endDate);
            return Results.Ok(reportData);
        });

        return group;
    }
}
