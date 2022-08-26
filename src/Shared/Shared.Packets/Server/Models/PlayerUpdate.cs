namespace Shared.Packets.Server.Models;

public sealed class PlayerUpdate : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.PlayerUpdate; }
    }

    public uint ObjectID;
    public byte Light;
    public short Weapon, WeaponEffect, Armour;
    public byte WingEffect;

    public override void ReadPacket(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();

        Light = reader.ReadByte();
        Weapon = reader.ReadInt16();
        WeaponEffect = reader.ReadInt16();
        Armour = reader.ReadInt16();
        WingEffect = reader.ReadByte();
    }

    public override void WritePacket(BinaryWriter writer)
    {
        writer.Write(ObjectID);

        writer.Write(Light);
        writer.Write(Weapon);
        writer.Write(WeaponEffect);
        writer.Write(Armour);
        writer.Write(WingEffect);
    }
}