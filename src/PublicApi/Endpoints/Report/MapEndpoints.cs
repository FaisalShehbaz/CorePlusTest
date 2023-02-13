
namespace PublicApi.Endpoints.Report;

public static class MapEndpoints
{
    public static RouteGroupBuilder MapFinancialReportsEndpoints(this RouteGroupBuilder group)
    {
        group.MapGetFinancialSummaryReport();
        group.MapGetFinancialDetailsReport();
        return group;
    }
}
