using Shared.Enums;
using System.Drawing;

namespace Shared.Packets.Server.Models;

public class ObjectPlayer : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.ObjectPlayer; }
    }

    public uint ObjectID;
    public string Name = string.Empty;
    public string GuildName = string.Empty;
    public string GuildRankName = string.Empty;
    public Color NameColour;
    public MirClass Class;
    public MirGender Gender;
    public ushort Level;
    public Point Location;
    public MirDirection Direction;
    public byte Hair;
    public byte Light;
    public short Weapon, WeaponEffect, Armour;
    public PoisonType Poison;
    public bool Dead, Hidden;
    public SpellEffect Effect;
    public byte WingEffect;
    public bool Extra;

    public short MountType;
    public bool RidingMount;
    public bool Fishing;

    public short TransformType;

    public uint ElementOrbEffect;
    public uint ElementOrbLvl;
    public uint ElementOrbMax;

    public LevelEffects LevelEffects;

    public List<BuffType> Buffs = new List<BuffType>();

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        Name = reader.ReadString();
        GuildName = reader.ReadString();
        GuildRankName = reader.ReadString();
        NameColour = Color.FromArgb(reader.ReadInt32());
        Class = (MirClass)reader.ReadByte();
        Gender = (MirGender)reader.ReadByte();
        Level = reader.ReadUInt16();
        Location = new Point(reader.ReadInt32(), reader.ReadInt32());
        Direction = (MirDirection)reader.ReadByte();
        Hair = reader.ReadByte();
        Light = reader.ReadByte();
        Weapon = reader.ReadInt16();
        WeaponEffect = reader.ReadInt16();
        Armour = reader.ReadInt16();
        Poison = (PoisonType)reader.ReadUInt16();
        Dead = reader.ReadBoolean();
        Hidden = reader.ReadBoolean();
        Effect = (SpellEffect)reader.ReadByte();
        WingEffect = reader.ReadByte();
        Extra = reader.ReadBoolean();
        MountType = reader.ReadInt16();
        RidingMount = reader.ReadBoolean();
        Fishing = reader.ReadBoolean();

        TransformType = reader.ReadInt16();

        ElementOrbEffect = reader.ReadUInt32();
        ElementOrbLvl = reader.ReadUInt32();
        ElementOrbMax = reader.ReadUInt32();

        int count = reader.ReadInt32();
        for (int i = 0; i < count; i++)
        {
            Buffs.Add((BuffType)reader.ReadByte());
        }

        LevelEffects = (LevelEffects)reader.ReadByte();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(Name);
        writer.Write(GuildName);
        writer.Write(GuildRankName);
        writer.Write(NameColour.ToArgb());
        writer.Write((byte)Class);
        writer.Write((byte)Gender);
        writer.Write(Level);
        writer.Write(Location.X);
        writer.Write(Location.Y);
        writer.Write((byte)Direction);
        writer.Write(Hair);
        writer.Write(Light);
        writer.Write(Weapon);
        writer.Write(WeaponEffect);
        writer.Write(Armour);
        writer.Write((ushort)Poison);
        writer.Write(Dead);
        writer.Write(Hidden);
        writer.Write((byte)Effect);
        writer.Write(WingEffect);
        writer.Write(Extra);
        writer.Write(MountType);
        writer.Write(RidingMount);
        writer.Write(Fishing);

        writer.Write(TransformType);

        writer.Write(ElementOrbEffect);
        writer.Write(ElementOrbLvl);
        writer.Write(ElementOrbMax);

        writer.Write(Buffs.Count);
        for (int i = 0; i < Buffs.Count; i++)
        {
            writer.Write((byte)Buffs[i]);
        }

        writer.Write((byte)LevelEffects);
    }
}