using Shared.Models.Items;

namespace Shared.Packets.Server.Models;

public sealed class UserStorage : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.UserStorage; } }

    public UserItem[] Storage;

    public override void ReadPacket(BinaryReader reader)
    {
        if (!reader.ReadBoolean()) return;

        Storage = new UserItem[reader.ReadInt32()];
        for (int i = 0; i < Storage.Length; i++)
        {
            if (!reader.ReadBoolean()) continue;
            Storage[i] = new UserItem(reader);
        }
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Storage != null);
        if (Storage == null) return;

        writer.Write(Storage.Length);
        for (int i = 0; i < Storage.Length; i++)
        {
            writer.Write(Storage[i] != null);
            if (Storage[i] == null) continue;

            Storage[i].Save(writer);
        }
    }
}