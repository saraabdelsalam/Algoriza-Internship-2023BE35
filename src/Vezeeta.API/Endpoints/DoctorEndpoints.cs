namespace Vezeeta.API.Endpoints;

public static class DoctorEndpoints
{
    public static WebApplication MapDoctorEndpoints(this WebApplication app)
    {
        var DoctorGroup = app.MapGroup("/Doctor")
            .WithTags("Doctor")
            .WithOpenApi();

        DoctorGroup.MapPost("/price", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("Test");
            return Results.Ok();
        });

        DoctorGroup.MapPost("/appointments/add", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });

        DoctorGroup.MapPatch("/appointments/edit", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });

        DoctorGroup.MapDelete("/appoinments/delete", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });

        DoctorGroup.MapPatch("/requests/confirm", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });
        DoctorGroup.MapGet("/requests", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });
        return app;
    }

}
