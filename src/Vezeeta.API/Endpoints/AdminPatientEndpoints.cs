namespace Vezeeta.API.Endpoints;

public static class AdminPatientEndpoints
{
    public static WebApplication MapPatientSettingsEndpoints(this WebApplication app)
    {
        var PatientSettingsGroup = app.MapGroup("/PatientSettings")
            .WithTags("PatientSettings")
            .WithOpenApi();

        PatientSettingsGroup.MapGet("/GetAllPatients", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });

        PatientSettingsGroup.MapGet("/GetPatientById", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });

        return app;
    }
}
