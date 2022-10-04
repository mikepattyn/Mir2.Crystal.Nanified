// See https://aka.ms/new-console-template for more information
using MediatR;
public record GetDashboardDataQuery : IRequest<DashboardData>;
