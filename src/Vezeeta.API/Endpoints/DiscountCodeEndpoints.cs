using MediatR;

using Vezeeta.Application.Features.DiscountCodes.AddDiscountCode;
using Vezeeta.Application.Features.DiscountCodes.DTOs;

namespace Vezeeta.API.Endpoints;

public static class DiscountCodeEndpoints
{

    public static WebApplication MapDiscountCodeEndpoints(this WebApplication app)
    {

        var discountCodeGroup = app.MapGroup("/DiscountCode")
                .WithTags("DiscountCode")
                .WithOpenApi();


        discountCodeGroup.MapPost("/create", async (HttpContext context,AddDiscountCodeDto Code) =>
        {

            try
            {
                // Retrieve Mediator from the DI container
                var mediator = context.RequestServices.GetRequiredService<IMediator>();

                var addDiscountCodeCommand = new AddDiscountCodeCommand
                {
                    CodeDto = Code
                 
                };

                var result = await mediator.Send(addDiscountCodeCommand);

                await context.Response.WriteAsync($"Discount code created: {result}");
                return Results.Ok();
            }
            catch (Exception ex)
            {
                // Handle exceptions and return an appropriate response
                await context.Response.WriteAsync($"Error creating discount code: {ex.Message}");
                return Results.StatusCode(StatusCodes.Status500InternalServerError);
            }
        });

        discountCodeGroup.MapPut("/edit", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });
        discountCodeGroup.MapPatch("/deactivate", async (HttpContext context) =>
         {
             await context.Response.WriteAsync("");
             return Results.Ok();
         });

        discountCodeGroup.MapDelete("/delete", async (HttpContext context) =>
        {
            await context.Response.WriteAsync("");
            return Results.Ok();
        });



        return app;
    }

}
