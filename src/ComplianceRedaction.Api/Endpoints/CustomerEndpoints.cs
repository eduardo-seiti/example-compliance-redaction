using ComplianceRedaction.Application.Customers.Create;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ComplianceRedaction.Api.Endpoints;

public static class CustomerEndpoints
{
    public static IEndpointRouteBuilder AddCustomerEndpoints(this IEndpointRouteBuilder app)
    {
        var endpoints = app.MapGroup("/customers");

        endpoints.MapPost("/", async ([FromBody] CreateCustomerCommand command,
                       [FromServices] ISender sender)
                       => await CreateCustomer(sender, command))
            .WithName("CreateCustomer")
            .Produces(200, typeof(Guid));

        return app;
    }

    private static async Task<IResult> CreateCustomer(ISender sender, CreateCustomerCommand command)
    {
        var result = await sender.Send(command);

        return TypedResults.Ok(result);
    }
}
