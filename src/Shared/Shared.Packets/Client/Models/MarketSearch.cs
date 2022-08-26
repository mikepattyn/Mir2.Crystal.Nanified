using Shared.Enums;

namespace Shared.Packets.Client.Models;

public sealed class MarketSearch : Packet
{
    public override short Index { get { return (short)ClientPacketIds.MarketSearch; } }

    public string Match = string.Empty;
    public ItemType Type = 0;
    public bool Usermode = false;
    public short MinShape = 0, MaxShape = 5000;
    public MarketPanelType MarketType = MarketPanelType.Market;

    public override void ReadPacket(BinaryReader reader)
    {
        Match = reader.ReadString();
        Type = (ItemType)reader.ReadByte();
        Usermode = reader.ReadBoolean();
        MinShape = reader.ReadInt16();
        MaxShape = reader.ReadInt16();
        MarketType = (MarketPanelType)reader.ReadByte();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Match);
        writer.Write((Byte)Type);
        writer.Write(Usermode);
        writer.Write(MinShape);
        writer.Write(MaxShape);
        writer.Write((byte)MarketType);
    }
}