using Shared.Enums;

namespace Persistance.DbModels;

public class DomainBuff : Entity<int>
{
    public BuffType Type { get; set; }
    public BuffStackType StackType { get; set; }
    public BuffProperty Properties { get; set; }
    public int Icon { get; set; }
    public bool Visible { get; set; }
}