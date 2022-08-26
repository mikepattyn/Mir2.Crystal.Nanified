using Shared.Models.Items;

namespace Shared.Packets.Server.Models;

public sealed class UserSlotsRefresh : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.UserSlotsRefresh; }
    }

    public UserItem[] Inventory, Equipment;

    public override void ReadPacket(BinaryReader reader)
    {

        if (reader.ReadBoolean())
        {
            Inventory = new UserItem[reader.ReadInt32()];
            for (int i = 0; i < Inventory.Length; i++)
            {
                if (!reader.ReadBoolean()) continue;
                Inventory[i] = new UserItem(reader);
            }
        }

        if (reader.ReadBoolean())
        {
            Equipment = new UserItem[reader.ReadInt32()];
            for (int i = 0; i < Equipment.Length; i++)
            {
                if (!reader.ReadBoolean()) continue;
                Equipment[i] = new UserItem(reader);
            }
        }
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Inventory != null);
        if (Inventory != null)
        {
            writer.Write(Inventory.Length);
            for (int i = 0; i < Inventory.Length; i++)
            {
                writer.Write(Inventory[i] != null);
                if (Inventory[i] == null) continue;

                Inventory[i].Save(writer);
            }

        }

        writer.Write(Equipment != null);
        if (Equipment != null)
        {
            writer.Write(Equipment.Length);
            for (int i = 0; i < Equipment.Length; i++)
            {
                writer.Write(Equipment[i] != null);
                if (Equipment[i] == null) continue;

                Equipment[i].Save(writer);
            }
        }
    }
}