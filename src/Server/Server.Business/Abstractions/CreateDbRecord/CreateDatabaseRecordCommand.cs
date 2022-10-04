// See https://aka.ms/new-console-template for more information
using MediatR;
using Server.Database.Models;

public class CreateDatabaseRecordCommand : IRequest
{
    public Entity Entity { get; set; }
}
