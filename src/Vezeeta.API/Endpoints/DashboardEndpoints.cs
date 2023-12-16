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
        });

        adminDashboardGroup.MapGet("/Top5Specializations", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
        });
        adminDashboardGroup.MapGet("/TotalNumberOfDoctors", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
        });
        adminDashboardGroup.MapGet("/TotalNumberOfPatients", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
        });
        adminDashboardGroup.MapGet("/TotalNumberOfRequests", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
        });

        return app;
    }
}
