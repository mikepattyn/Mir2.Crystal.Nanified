namespace Shared.Packets.Server.Models;

public sealed class HeroCreateRequest : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.HeroCreateRequest; } }

    public bool[] CanCreateClass;
    public override void ReadPacket(BinaryReader reader)
    {
        int count = reader.ReadInt32();
        CanCreateClass = new bool[count];
        for (int i = 0; i < count; i++)
            CanCreateClass[i] = reader.ReadBoolean();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(CanCreateClass.Length);
        for (int i = 0; i < CanCreateClass.Length; i++)
            writer.Write(CanCreateClass[i]);
    }
}