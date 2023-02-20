using ApplicationCore.Interfaces;

namespace PublicApi.Endpoints.Practitioner;

public static class GetPractitioners
{
    public static RouteGroupBuilder MapGetAllPractitioners(this RouteGroupBuilder group)
    {
        group.MapGet("/practitioners", async (IPractitionerService practitionerService) =>
        {
            var practitioners = await practitionerService.GetPractitioners();
            return Results.Ok(practitioners);
        });

        return group;
    }
}