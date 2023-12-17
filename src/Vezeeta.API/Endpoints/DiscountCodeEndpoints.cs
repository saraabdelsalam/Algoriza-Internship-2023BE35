namespace Vezeeta.API.Endpoints;

public static class DiscountCodeEndpoints
{
    public static WebApplication MapDiscountCodeEndpoints(this WebApplication app)
    {
        var discountCodeGroup = app.MapGroup("/DiscountCode")
            .WithTags("DiscountCode")
            .WithOpenApi();

        discountCodeGroup.MapPost("/CreateDiscountCode", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("Test");
            return Results.Ok();
        });

        discountCodeGroup.MapPut("/EditDiscountCode", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });
        discountCodeGroup.MapPatch("/DeactivateDiscountCode", async (HttpContext context) =>
         {
             await context.Response.WriteAsync("");
             return Results.Ok();
         });

        discountCodeGroup.MapDelete("/DeleteDiscountCode", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });



        return app;
    }

}
