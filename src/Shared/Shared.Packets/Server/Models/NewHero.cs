namespace Shared.Packets.Server.Models;

public sealed class NewHero : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.NewHero; }
    }

    /*
     * 0: Disabled.
     * 1: Bad Character Name
     * 2: Bad Gender
     * 3: Bad Class
     * 4: Max Heroes
     * 5: Name Exists.
     * */
    public byte Result;

    public override void ReadPacket(BinaryReader reader)
    {
        Result = reader.ReadByte();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Result);
    }
}