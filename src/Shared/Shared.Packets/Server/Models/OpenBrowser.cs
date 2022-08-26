namespace Shared.Packets.Server.Models;

public sealed class OpenBrowser : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.OpenBrowser; }
    }

    public string Url;

    public override void ReadPacket(BinaryReader reader)
    {
        Url = reader.ReadString();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Url);
    }
}