using System.Text.Json;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Server.Database.Models;

public static class WebApplicationExtensions
{
    public static void UseCrystalM2Nanified(this WebApplication app)
    {
        app.MapGet("/", () =>
           typeof(DomainAccount).Assembly
                .ExportedTypes.Where(x => x.Name.StartsWith("Domain"))
                .Select(x => new DatabaseEntity(x))
                .ToList());

        app.MapGet("/dashboard", async (IMediator Mediator) =>
            await Mediator.Send(new GetDashboardDataQuery()));
    }
}