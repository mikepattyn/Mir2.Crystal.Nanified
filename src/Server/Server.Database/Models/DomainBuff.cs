using Microsoft.EntityFrameworkCore;
using Server.Database.Models;
using Shared.Enums;

namespace Persistance.Domain;

public class DomainBuff : Entity<int>
{
    public BuffType Type { get; set; }
    public BuffStackType StackType { get; set; }
    public BuffProperty Properties { get; set; }
    public int Icon { get; set; }
    public bool Visible { get; set; }
}