using Shared.Enums;

namespace Shared.Models.Client;

public class ClientHeroInformation
{
    public int Index;
    public string Name;
    public ushort Level;
    public MirClass Class;
    public MirGender Gender;

    public ClientHeroInformation() { }

    public ClientHeroInformation(BinaryReader reader)
    {
        Index = reader.ReadInt32();
        Name = reader.ReadString();
        Level = reader.ReadUInt16();
        Class = (MirClass)reader.ReadByte();
        Gender = (MirGender)reader.ReadByte();
    }

    public void Save(BinaryWriter writer)
    {
        writer.Write(Index);
        writer.Write(Name);
        writer.Write(Level);
        writer.Write((byte)Class);
        writer.Write((byte)Gender);
    }

    public override string ToString()
    {
        string text = Name;
        text += Environment.NewLine + $"Level {Level} {Enum.GetName(typeof(MirGender), Gender).ToLower()} {Enum.GetName(typeof(MirClass), Class).ToLower()}";
        return text;
    }
}