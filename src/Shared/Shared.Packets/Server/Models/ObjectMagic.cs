using Shared.Enums;
using System.Drawing;

namespace Shared.Packets.Server.Models;

public sealed class ObjectMagic : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.ObjectMagic; } }

    public uint ObjectID;
    public Point Location;
    public MirDirection Direction;

    public Spell Spell;
    public uint TargetID;
    public Point Target;
    public bool Cast;
    public byte Level;
    public bool SelfBroadcast = false;
    public List<uint> SecondaryTargetIDs = new List<uint>();

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        Location = new Point(reader.ReadInt32(), reader.ReadInt32());
        Direction = (MirDirection)reader.ReadByte();

        Spell = (Spell)reader.ReadByte();
        TargetID = reader.ReadUInt32();

        Target = new Point(reader.ReadInt32(), reader.ReadInt32());
        Cast = reader.ReadBoolean();
        Level = reader.ReadByte();
        SelfBroadcast = reader.ReadBoolean();

        var count = reader.ReadInt32();
        SecondaryTargetIDs = new List<uint>();
        for (int i = 0; i < count; i++)
        {
            SecondaryTargetIDs.Add(reader.ReadUInt32());
        }
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(Location.X);
        writer.Write(Location.Y);
        writer.Write((byte)Direction);

        writer.Write((byte)Spell);
        writer.Write(TargetID);

        writer.Write(Target.X);
        writer.Write(Target.Y);
        writer.Write(Cast);
        writer.Write(Level);
        writer.Write(SelfBroadcast);

        writer.Write(SecondaryTargetIDs.Count);
        foreach (var targetID in SecondaryTargetIDs)
        {
            writer.Write(targetID);
        }
    }
}