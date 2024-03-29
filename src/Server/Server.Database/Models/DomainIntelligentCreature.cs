﻿using Server.Database.Models;
using Shared.Enums;
using Shared.Models.IntelligentCreature;

namespace Persistance.Domain;

public class DomainIntelligentCreature : Entity<int>
{
    public IntelligentCreatureType PetType { get; set; }
    public DomainIntelligentCreature Info { get; set; }
    public IntelligentCreatureItemFilter Filter { get; set; }

    public IntelligentCreaturePickupMode petMode { get; set; } = IntelligentCreaturePickupMode.SemiAutomatic;

    public string CustomName { get; set; }
    public int Fullness { get; set; }
    public int SlotIndex { get; set; }
    public DateTime Expire { get; set; }
    public long BlackstoneTime { get; set; } = 0;
    public long MaintainFoodTime { get; set; } = 0;
}