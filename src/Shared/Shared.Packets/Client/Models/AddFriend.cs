namespace Shared.Packets.Client.Models;

public sealed class AddFriend : Packet
{
    public override short Index { get { return (short)ClientPacketIds.AddFriend; } }

    public string Name;
    public bool Blocked;

    public override void ReadPacket(BinaryReader reader)
    {
        Name = reader.ReadString();
        Blocked = reader.ReadBoolean();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Name);
        writer.Write(Blocked);
    }
}