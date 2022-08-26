using Shared.Models.Items;

namespace Shared.Packets.Server.Models;

public sealed class AwakeningNeedMaterials : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.AwakeningNeedMaterials; } }

    public ItemInfo[] Materials;
    public byte[] MaterialsCount;

    public override void ReadPacket(BinaryReader reader)
    {
        if (!reader.ReadBoolean()) return;

        int count = reader.ReadInt32();
        Materials = new ItemInfo[count];
        MaterialsCount = new byte[count];

        for (int i = 0; i < Materials.Length; i++)
        {
            if (!reader.ReadBoolean()) continue;
            Materials[i] = new ItemInfo(reader);
            MaterialsCount[i] = reader.ReadByte();
        }
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Materials != null);
        if (Materials == null) return;

        writer.Write(Materials.Length);
        for (int i = 0; i < Materials.Length; i++)
        {
            writer.Write(Materials[i] != null);
            if (Materials[i] == null) continue;

            Materials[i].Save(writer);
            writer.Write(MaterialsCount[i]);
        }
    }
}