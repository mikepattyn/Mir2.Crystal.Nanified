namespace Shared.Packets.Server.Models;

public sealed class Roll : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.Roll; } }

    public int Type;
    public string Page;
    public int Result;
    public bool AutoRoll;

    public override void ReadPacket(BinaryReader reader)
    {
        Type = reader.ReadInt32();
        Page = reader.ReadString();
        Result = reader.ReadInt32();
        AutoRoll = reader.ReadBoolean();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Type);
        writer.Write(Page);
        writer.Write(Result);
        writer.Write(AutoRoll);
    }
}