﻿using Shared.Enums;
using Shared.Models.Items;

namespace Shared.Packets.Server.Models;

public sealed class NPCPearlGoods : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.NPCPearlGoods; } }

    public List<UserItem> List = new List<UserItem>();
    public float Rate;
    public PanelType Type;

    public override void ReadPacket(BinaryReader reader)
    {
        int count = reader.ReadInt32();

        for (int i = 0; i < count; i++)
            List.Add(new UserItem(reader));

        Rate = reader.ReadSingle();

        Type = (PanelType)reader.ReadByte();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(List.Count);

        for (int i = 0; i < List.Count; i++)
            List[i].Save(writer);

        writer.Write(Rate);
        writer.Write((byte)Type);
    }
}