namespace Vezeeta.API.Endpoints;

public static class DashboardEndpoints
{
    public static WebApplication MapAdminDashboardEndpoints(this WebApplication app)
    {
        var adminDashboardGroup = app.MapGroup("/Dashboard")
            .WithTags("Dashboard")
            .WithOpenApi();

        adminDashboardGroup.MapGet("/top-10-doctors", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });

        adminDashboardGroup.MapGet("/top-5-specializations", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });
        adminDashboardGroup.MapGet("/total-number-of-doctors", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });
        adminDashboardGroup.MapGet("/total-number-of-patients", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });
        adminDashboardGroup.MapGet("/total-number-of-requests", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });

        return app;
    }
}
