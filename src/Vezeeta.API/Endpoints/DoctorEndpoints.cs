namespace Vezeeta.API.Endpoints;

public static class DoctorEndpoints
{
    public static WebApplication MapDoctorEndpoints(this WebApplication app)
    {
        var DoctorGroup = app.MapGroup("/Doctor")
            .WithTags("Doctor")
            .WithOpenApi();

        DoctorGroup.MapPost("/SetPrice", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("Test");
            return Results.Ok();
        });

        DoctorGroup.MapPost("/AddPointments", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });

        DoctorGroup.MapPatch("/EditAppointments", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });

        DoctorGroup.MapDelete("/DeleteAppoinments", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });

        DoctorGroup.MapPatch("/ConfirmRequest", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });
        DoctorGroup.MapGet("/GetDoctorRequests", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });
        return app;
    }

}
