using Shared.Enums;

namespace Shared.Packets.Client.Models;

public sealed class NewHero : Packet
{
    public override short Index { get { return (short)ClientPacketIds.NewHero; } }

    public string Name = string.Empty;
    public MirGender Gender;
    public MirClass Class;
    public override void ReadPacket(BinaryReader reader)
    {
        Name = reader.ReadString();
        Gender = (MirGender)reader.ReadByte();
        Class = (MirClass)reader.ReadByte();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Name);
        writer.Write((byte)Gender);
        writer.Write((byte)Class);
    }
}