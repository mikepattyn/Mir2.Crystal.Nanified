using Shared.Models.Client;

namespace Shared.Packets.Server.Models;

public sealed class FriendUpdate : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.FriendUpdate; }
    }

    public List<ClientFriend> Friends = new List<ClientFriend>();

    public override void ReadPacket(BinaryReader reader)
    {
        int count = reader.ReadInt32();

        for (int i = 0; i < count; i++)
            Friends.Add(new ClientFriend(reader));
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Friends.Count);

        for (int i = 0; i < Friends.Count; i++)
            Friends[i].Save(writer);
    }
}