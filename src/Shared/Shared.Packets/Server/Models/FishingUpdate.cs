using System.Drawing;

namespace Shared.Packets.Server.Models;

public sealed class FishingUpdate : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.FishingUpdate; } }

    public long ObjectID;
    public bool Fishing;
    public int ProgressPercent;
    public int ChancePercent;
    public Point FishingPoint;
    public bool FoundFish;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadInt64();
        Fishing = reader.ReadBoolean();
        ProgressPercent = reader.ReadInt32();
        ChancePercent = reader.ReadInt32();
        FishingPoint = new Point(reader.ReadInt32(), reader.ReadInt32());
        FoundFish = reader.ReadBoolean();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(Fishing);
        writer.Write(ProgressPercent);
        writer.Write(ChancePercent);
        writer.Write(FishingPoint.X);
        writer.Write(FishingPoint.Y);
        writer.Write(FoundFish);
    }
}