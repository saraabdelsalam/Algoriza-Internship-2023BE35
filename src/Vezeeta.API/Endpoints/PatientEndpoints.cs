using MediatR;

using Vezeeta.Application.Features.DiscountCodes.AddDiscountCode;
using Vezeeta.Application.Features.Patients.DTOs;
using Vezeeta.Application.Features.Patients.Register;

namespace Vezeeta.API.Endpoints;

public static class PatientEndpoints
{
    public static WebApplication MapPatientEndpoints(this WebApplication app)
    {
        var PatientGroup = app.MapGroup("/Patient")
            .WithTags("Patient")
            .WithOpenApi();

        PatientGroup.MapPost("/register", async (HttpContext context, PatientRegisterDto patient) => 
        {
            try
            {
                // Retrieve Mediator from the DI container
                var mediator = context.RequestServices.GetRequiredService<IMediator>();

                var RegisterCommand = new RegisterCommand
                {
                    _registrationDto = patient
                };

                var result = await mediator.Send(RegisterCommand);

                return result is not null ? Results.Ok(result) : Results.NotFound();
            }
            catch (Exception ex)
            {

                return Results.BadRequest(ex.Message);
            }
        });

        PatientGroup.MapPost("/requests/new-request", async (HttpContext context) =>
        {

            await context.Response.WriteAsync("");
            return Results.Ok();
        });
        PatientGroup.MapGet("/requests", async (HttpContext context) =>
        {

            await context.Response.WriteAsync("");
            return Results.Ok();
        });
        PatientGroup.MapPatch("/requests/cancell", async (HttpContext context) =>
        {

            await context.Response.WriteAsync("");
            return Results.Ok();
        });
        PatientGroup.MapGet("/doctors", async (HttpContext context) =>
        {

            await context.Response.WriteAsync("");
            return Results.Ok();
        });
        return app;
    }
}
