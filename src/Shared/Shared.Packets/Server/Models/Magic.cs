using Shared.Enums;
using System.Drawing;

namespace Shared.Packets.Server.Models;

public sealed class Magic : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.Magic; } }

    public Spell Spell;
    public uint TargetID;
    public Point Target;
    public bool Cast;
    public byte Level;

    public List<uint> SecondaryTargetIDs = new List<uint>();

    public override void ReadPacket(BinaryReader reader)
    {
        Spell = (Spell)reader.ReadByte();
        TargetID = reader.ReadUInt32();
        Target = new Point(reader.ReadInt32(), reader.ReadInt32());
        Cast = reader.ReadBoolean();
        Level = reader.ReadByte();

        var count = reader.ReadInt32();
        SecondaryTargetIDs = new List<uint>();
        for (int i = 0; i < count; i++)
        {
            SecondaryTargetIDs.Add(reader.ReadUInt32());
        }
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write((byte)Spell);
        writer.Write(TargetID);
        writer.Write(Target.X);
        writer.Write(Target.Y);
        writer.Write(Cast);
        writer.Write(Level);

        writer.Write(SecondaryTargetIDs.Count);
        foreach (var targetID in SecondaryTargetIDs)
        {
            writer.Write(targetID);
        }

    }
}