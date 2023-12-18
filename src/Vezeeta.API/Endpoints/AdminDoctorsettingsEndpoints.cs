namespace Vezeeta.API.Endpoints;

public static class AdminDoctorsettingsEndpoints
{
    public static WebApplication MapDoctorSettingsEndpoints(this WebApplication app)
    {
        var DoctorSettingsGroup = app.MapGroup("/DoctorSettings")
            .WithTags("DoctorSettings")
            .WithOpenApi();

        DoctorSettingsGroup.MapPost("/create-account", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("Test");
            return Results.Ok();
        });

        DoctorSettingsGroup.MapPut("/edit-info", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });

        DoctorSettingsGroup.MapDelete("/delete", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });

        DoctorSettingsGroup.MapGet("/doctors-info", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });

        DoctorSettingsGroup.MapGet("/doctor-info", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });
        return app;
    }
}
