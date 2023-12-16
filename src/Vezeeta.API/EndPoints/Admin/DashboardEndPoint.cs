namespace Vezeeta.API.EndPoints.Admin;

public static class DashboardEndPoint
{
    public static void AdminDashboardEndpoints(this IEndpointRouteBuilder routes)
    {
        

       routes.MapGet("/Dashboard/Top10Doctors", async context =>
       {
           await context.Response.WriteAsync("");
       });

        routes.MapGet("/Dashboard/Top5Specializations", async context =>
        {
            await context.Response.WriteAsync("");
        });
        routes.MapGet("/Dashboard/TotalNumberOfDoctors", async context =>
        {
            await context.Response.WriteAsync("");
        });
        routes.MapGet("/Dashboard/TotalNumberOfPatients", async context =>
        {
            await context.Response.WriteAsync("");
        });
        routes.MapGet("/Dashboard/TotalNumberOfRequests", async context =>
        {
            await context.Response.WriteAsync("");
        });




    }
}
