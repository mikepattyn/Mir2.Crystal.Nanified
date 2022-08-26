namespace Shared.Packets.Client.Models;

public sealed class SearchMap : Packet
{
    public override short Index { get { return (short)ClientPacketIds.SearchMap; } }

    public string Text;

    public override void ReadPacket(BinaryReader reader)
    {
        Text = reader.ReadString();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Text);
    }
}