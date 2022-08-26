using Shared.Models.Shared;

namespace Shared.Packets.Server.Models;

public sealed class LogOutSuccess : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.LogOutSuccess; }
    }

    public override bool Observable => false;

    public List<SelectInfo> Characters = new List<SelectInfo>();

    public override void ReadPacket(BinaryReader reader)
    {
        int count = reader.ReadInt32();

        for (int i = 0; i < count; i++)
            Characters.Add(new SelectInfo(reader));
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Characters.Count);

        for (int i = 0; i < Characters.Count; i++)
            Characters[i].Save(writer);
    }
}