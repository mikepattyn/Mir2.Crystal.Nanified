using Shared.Models.Guild;

namespace Shared.Packets.Server.Models;

public sealed class GuildBuffList : ServerPacket
{
    public override short Index { get { return (short)ServerPacketIds.GuildBuffList; } }

    public byte Remove = 0;
    public List<GuildBuff> ActiveBuffs = new List<GuildBuff>();
    public List<GuildBuffInfo> GuildBuffs = new List<GuildBuffInfo>();

    public override void ReadPacket(BinaryReader reader)
    {
        Remove = reader.ReadByte();
        int count = reader.ReadInt32();
        for (int i = 0; i < count; i++)
            ActiveBuffs.Add(new GuildBuff(reader));
        count = reader.ReadInt32();
        for (int i = 0; i < count; i++)
            GuildBuffs.Add(new GuildBuffInfo(reader));
    }
    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(Remove);
        writer.Write(ActiveBuffs.Count);
        for (int i = 0; i < ActiveBuffs.Count; i++)
            ActiveBuffs[i].Save(writer);
        writer.Write(GuildBuffs.Count);
        for (int i = 0; i < GuildBuffs.Count; i++)
            GuildBuffs[i].Save(writer);
    }
}