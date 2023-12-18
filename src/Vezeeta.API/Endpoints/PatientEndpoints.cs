namespace Vezeeta.API.Endpoints;

public static class PatientEndpoints
{
    public static WebApplication MapPatientEndpoints(this WebApplication app)
    {
        var PatientGroup = app.MapGroup("/Patient")
            .WithTags("Patient")
            .WithOpenApi();

        PatientGroup.MapPost("/register", async (HttpContext context) => 
        {

            await context.Response.WriteAsync("");
            return Results.Ok();
        });

        PatientGroup.MapPost("/requests/new-request", async (HttpContext context) =>
        {

            await context.Response.WriteAsync("");
            return Results.Ok();
        });
        PatientGroup.MapGet("/requests", async (HttpContext context) =>
        {

            await context.Response.WriteAsync("");
            return Results.Ok();
        });
        PatientGroup.MapPatch("/requests/cancell", async (HttpContext context) =>
        {

            await context.Response.WriteAsync("");
            return Results.Ok();
        });
        PatientGroup.MapGet("/doctors", async (HttpContext context) =>
        {

            await context.Response.WriteAsync("");
            return Results.Ok();
        });
        return app;
    }
}
