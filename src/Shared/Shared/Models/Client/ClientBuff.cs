using Shared.Enums;

namespace Shared.Models.Client;

public class ClientBuff
{
    public BuffType Type;
    public string Caster;
    public bool Visible;
    public uint ObjectID;
    public long ExpireTime;
    public bool Infinite;
    public Stats Stats;
    public bool Paused;

    public int[] Values;

    public ClientBuff()
    {
        Stats = new Stats();
    }

    public ClientBuff(BinaryReader reader)
    {
        Caster = null;

        Type = (BuffType)reader.ReadByte();
        Visible = reader.ReadBoolean();
        ObjectID = reader.ReadUInt32();
        ExpireTime = reader.ReadInt64();
        Infinite = reader.ReadBoolean();
        Paused = reader.ReadBoolean();

        Stats = new Stats(reader);

        int count = reader.ReadInt32();

        Values = new int[count];

        for (int i = 0; i < count; i++)
        {
            Values[i] = reader.ReadInt32();
        }
    }

    public void Save(BinaryWriter writer)
    {
        writer.Write((byte)Type);
        writer.Write(Visible);
        writer.Write(ObjectID);
        writer.Write(ExpireTime);
        writer.Write(Infinite);
        writer.Write(Paused);

        Stats.Save(writer);

        writer.Write(Values.Length);
        for (int i = 0; i < Values.Length; i++)
        {
            writer.Write(Values[i]);
        }
    }
}