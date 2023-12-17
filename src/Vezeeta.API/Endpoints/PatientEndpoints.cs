namespace Vezeeta.API.Endpoints;

public static class PatientEndpoints
{
    public static WebApplication MapPatientEndpoints(this WebApplication app)
    {
        var PatientGroup = app.MapGroup("/Patient")
            .WithTags("Patient")
            .WithOpenApi();

        PatientGroup.MapPost("/Register", async (HttpContext context) => 
        {

            await context.Response.WriteAsync("");
            return Results.Ok();
        });

        PatientGroup.MapPost("/RequestAppointment", async (HttpContext context) =>
        {

            await context.Response.WriteAsync("");
            return Results.Ok();
        });
        PatientGroup.MapGet("/GetAllRequests", async (HttpContext context) =>
        {

            await context.Response.WriteAsync("");
            return Results.Ok();
        });
        PatientGroup.MapPatch("/CancelRequest", async (HttpContext context) =>
        {

            await context.Response.WriteAsync("");
            return Results.Ok();
        });
        PatientGroup.MapGet("/SearchDoctors", async (HttpContext context) =>
        {

            await context.Response.WriteAsync("");
            return Results.Ok();
        });
        return app;
    }
}
