namespace Shared.Packets.Server.Models;

public sealed class StartGame : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.StartGame; }
    }

    public byte Result;
    public int Resolution;

    /*
     * 0: Disabled.
     * 1: Not logged in
     * 2: Character not found.
     * 3: Start Game Error
     * */

    public override void ReadPacket(BinaryReader reader)
    {
        Result = reader.ReadByte();
        Resolution = reader.ReadInt32();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Result);
        writer.Write(Resolution);
    }
}