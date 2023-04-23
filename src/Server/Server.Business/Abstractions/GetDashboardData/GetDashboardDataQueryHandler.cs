using MediatR;
using Microsoft.EntityFrameworkCore;
using Server.Database.DbContexts;

public class GetDashboardDataQueryHandler : DatabaseHandler, IRequestHandler<GetDashboardDataQuery, DashboardData>
{
    public GetDashboardDataQueryHandler(MirDbContext context) : base(context)
    {
    }

    public async Task<DashboardData> Handle(GetDashboardDataQuery request, CancellationToken cancellationToken)
    {
        var data = new DashboardData();
        var players = 1;
        data.OnlinePlayers = players;
        data.ServerTimeOnline = TimeSpan.FromMinutes(10);
        data.ActiveDungeons = 22;
        data.TotalMonstersSpawned = 42312;
        data.HighestPlayerLevel = 56;
        return data;
    }
}