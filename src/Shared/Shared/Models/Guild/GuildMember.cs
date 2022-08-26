namespace Shared.Models.Guild;

public class GuildMember
{
    public string Name = "";
    public int Id;
    public object Player;
    public DateTime LastLogin;
    public bool hasvoted;
    public bool Online;

    public GuildMember() { }

    public GuildMember(BinaryReader reader, bool offline = false)
    {
        Name = reader.ReadString();
        Id = reader.ReadInt32();
        LastLogin = DateTime.FromBinary(reader.ReadInt64());
        hasvoted = reader.ReadBoolean();
        Online = reader.ReadBoolean();
        Online = offline ? false : Online;
    }
    public void Save(BinaryWriter writer)
    {
        writer.Write(Name);
        writer.Write(Id);
        writer.Write(LastLogin.ToBinary());
        writer.Write(hasvoted);
        writer.Write(Online);
    }
}