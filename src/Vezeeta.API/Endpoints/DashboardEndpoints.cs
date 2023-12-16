namespace Vezeeta.API.Endpoints;

public static class DashboardEndpoints
{
    public static WebApplication MapAdminDashboardEndpoints(this WebApplication app)
    {
        var adminDashboardGroup = app.MapGroup("/Dashboard")
            .WithOpenApi();

        adminDashboardGroup.MapGet("/Top10Doctors", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("Test");
            return Results.Ok();
        });

        adminDashboardGroup.MapGet("/Top5Specializations", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });
        adminDashboardGroup.MapGet("/TotalNumberOfDoctors", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });
        adminDashboardGroup.MapGet("/TotalNumberOfPatients", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });
        adminDashboardGroup.MapGet("/TotalNumberOfRequests", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });

        return app;
    }
}
