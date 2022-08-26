namespace Shared.Packets.Server.Models;

public sealed class NPCSRepair : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.NPCSRepair; } }

    public float Rate;

    public override void ReadPacket(BinaryReader reader)
    {
        Rate = reader.ReadSingle();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Rate);
    }
}