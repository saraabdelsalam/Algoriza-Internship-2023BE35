namespace Vezeeta.API.Endpoints;

public static class AuthenticationEndpoints
{
    public static WebApplication MapAuthenticationEndpoints(this WebApplication app)
    {
        var AuthenticationGroup = app.MapGroup("/Account")
            .WithTags("Account")
            .WithOpenApi();

        AuthenticationGroup.MapPost("/SignIn", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });
        AuthenticationGroup.MapPost("/SignOut", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });
        return app;
    }
}
