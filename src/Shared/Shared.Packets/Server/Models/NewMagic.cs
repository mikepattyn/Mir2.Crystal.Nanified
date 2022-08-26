using Shared.Models.Client;

namespace Shared.Packets.Server.Models;

public sealed class NewMagic : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.NewMagic; }
    }

    public ClientMagic Magic;
    public bool Hero;
    public override void ReadPacket(BinaryReader reader)
    {
        Magic = new ClientMagic(reader);
        Hero = reader.ReadBoolean();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        Magic.Save(writer);
        writer.Write(Hero);
    }
}