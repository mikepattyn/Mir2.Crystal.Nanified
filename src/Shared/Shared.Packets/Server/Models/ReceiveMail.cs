using Shared.Models.Client;

namespace Shared.Packets.Server.Models;

public sealed class ReceiveMail : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.ReceiveMail; }
    }

    public List<ClientMail> Mail = new List<ClientMail>();

    public override void ReadPacket(BinaryReader reader)
    {
        int count = reader.ReadInt32();

        for (int i = 0; i < count; i++)
            Mail.Add(new ClientMail(reader));
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Mail.Count);

        for (int i = 0; i < Mail.Count; i++)
            Mail[i].Save(writer);
    }
}