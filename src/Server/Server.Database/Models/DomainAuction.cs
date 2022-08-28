using Persistance.Domain;
using Shared.Enums;

namespace Server.Database.Models;

public class DomainAuction : Entity<ulong>
{
    public DateTime ConsignmentDate { get; set; }
    public long Price { get; set; }
    public long CurrentBid { get; set; }
    public int SellerIndex { get; set; }
    public int CurrentBuyerIndex { get; set; }
    public DomainCharacter Seller { get; set; }
    public DomainCharacter Buyer { get; set; }
    public bool Expired { get; set; }
    public bool Sold { get; set; }
    public MarketItemType ItemType;

    public DomainItem Item { get; set; }
}