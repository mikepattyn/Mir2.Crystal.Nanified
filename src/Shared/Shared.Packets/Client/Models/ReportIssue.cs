namespace Shared.Packets.Client.Models;

public sealed class ReportIssue : Packet
{
    public override short Index { get { return (short)ClientPacketIds.ReportIssue; } }

    public byte[] Image;
    public int ImageSize;
    public int ImageChunk;

    public string Message;

    public override void ReadPacket(BinaryReader reader)
    {
        Image = reader.ReadBytes(reader.ReadInt32());
        ImageSize = reader.ReadInt32();
        ImageChunk = reader.ReadInt32();
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Image.Length);
        writer.Write(Image);
        writer.Write(ImageSize);
        writer.Write(ImageChunk);
    }
}