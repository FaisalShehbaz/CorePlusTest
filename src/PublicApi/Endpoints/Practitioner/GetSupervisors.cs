using ApplicationCore.Interfaces;

namespace PublicApi.Endpoints.Practitioner;

public static class GetSupervisors
{
    public static RouteGroupBuilder MapGetSupervisorPractitioners(this RouteGroupBuilder group)
    {
        group.MapGet("/supervisors", async (IPractitionerService practitionerService) =>
        {
            var practitioners = await practitionerService.GetSupervisorPractitioners();
            return Results.Ok(practitioners);
        });

        return group;
    }
}