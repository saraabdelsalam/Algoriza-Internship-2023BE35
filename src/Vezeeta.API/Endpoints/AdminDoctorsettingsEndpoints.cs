namespace Vezeeta.API.Endpoints;

public static class AdminDoctorsettingsEndpoints
{
    public static WebApplication MapDoctorSettingsEndpoints(this WebApplication app)
    {
        var DoctorSettingsGroup = app.MapGroup("/DoctorSettings")
            .WithTags("DoctorSettings")
            .WithOpenApi();

        DoctorSettingsGroup.MapPost("/CreateDoctorAccount", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("Test");
            return Results.Ok();
        });

        DoctorSettingsGroup.MapPut("/EditDoctorInfo", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });

        DoctorSettingsGroup.MapDelete("/DeleteDoctor", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });

        DoctorSettingsGroup.MapGet("/GetAllDoctors", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });

        DoctorSettingsGroup.MapGet("/GetDoctorById", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });
        return app;
    }
}
