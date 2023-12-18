

using MediatR;

using Vezeeta.Application.Features.DiscountCodes.AddDiscountCode;
using Vezeeta.Application.Features.DiscountCodes.ChangeDiscountCodeStatus;
using Vezeeta.Application.Features.DiscountCodes.DeleteDiscountCode;
using Vezeeta.Application.Features.DiscountCodes.DTOs;
using Vezeeta.Application.Features.DiscountCodes.EditDiscountCode;

namespace Vezeeta.API.Endpoints;

public static class DiscountCodeEndpoints
{

    public static WebApplication MapDiscountCodeEndpoints(this WebApplication app)
    {

        var discountCodeGroup = app.MapGroup("/DiscountCode")
                .WithTags("DiscountCode")
                .WithOpenApi();


        discountCodeGroup.MapPost("/create", async (HttpContext context, AddDiscountCodeDto Code) =>
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

                return result is not null ? Results.Ok(result) : Results.NotFound();
            }
            catch (Exception ex)
            {

                return Results.BadRequest(ex.Message);
            }
        });

        discountCodeGroup.MapPut("/edit", async (HttpContext context, EditDiscountCodeDto editDiscountCode) =>
        {
            try
            {
                var mediator = context.RequestServices.GetRequiredService<IMediator>();
                var discountCode = new EditDiscountCodeCommand
                {
                    editDto = editDiscountCode
                };
                var result = await mediator.Send(discountCode);
                return result is not null ? Results.Ok(result) : Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }

        });
        discountCodeGroup.MapPatch("/deactivate", async (HttpContext context, int id) =>
         {
             try
             {

                 var mediator = context.RequestServices.GetRequiredService<IMediator>();
                 var changeStatus = new ChangeDiscountCodeStatusCommand
                 {
                     Id = id
                 };

                 var result = await mediator.Send(changeStatus);
                 return result is not null ? Results.Ok(result) : Results.NotFound();
             }
             catch (Exception ex)
             {
                 return Results.BadRequest(ex.Message);
             }

         });

        discountCodeGroup.MapDelete("/delete", async (HttpContext context, int id) =>
        {
            try
            {

                var mediator = context.RequestServices.GetRequiredService<IMediator>();
                var deleteDiscountCodeCommand = new DeleteDiscountCodeCommand
                {
                    Id = id
                };

                var result = await mediator.Send(deleteDiscountCodeCommand);
                return result is not null ? Results.Ok(result) : Results.NotFound();
            }
            catch (Exception ex)
            {
                return Results.BadRequest(ex.Message);
            }

        });



        return app;
    }

}
