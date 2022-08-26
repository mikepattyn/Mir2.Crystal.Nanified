namespace Shared.Packets.Server.Models;

public sealed class Disconnect : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.Disconnect; }
    }

    public byte Reason;

    /*
     * 0: Server Closing.
     * 1: Another User.
     * 2: ServerPacket Error.
     * 3: Server Crashed.
     */

    public override void ReadPacket(BinaryReader reader)
    {
        Reason = reader.ReadByte();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Reason);
    }
}