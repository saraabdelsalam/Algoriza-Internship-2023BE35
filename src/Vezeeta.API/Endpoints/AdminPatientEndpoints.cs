namespace Vezeeta.API.Endpoints;

public static class AdminPatientEndpoints
{
    public static WebApplication MapPatientSettingsEndpoints(this WebApplication app)
    {
        var PatientSettingsGroup = app.MapGroup("/PatientSettings")
            .WithTags("PatientSettings")
            .WithOpenApi();

        PatientSettingsGroup.MapGet("/patients", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });

        PatientSettingsGroup.MapGet("/patient", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });

        return app;
    }
}
