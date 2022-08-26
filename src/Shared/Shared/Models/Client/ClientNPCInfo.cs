using System.Drawing;

namespace Shared.Models.Client;

public class ClientNPCInfo
{
    public uint ObjectID;
    public string Name;
    public Point Location;
    public int Icon;
    public bool CanTeleportTo;

    public ClientNPCInfo() { }

    public ClientNPCInfo(BinaryReader reader)
    {
        ObjectID = reader.ReadUInt32();
        Name = reader.ReadString();
        Location = new Point(reader.ReadInt32(), reader.ReadInt32());
        Icon = reader.ReadInt32();
        CanTeleportTo = reader.ReadBoolean();
    }

    public void Save(BinaryWriter writer)
    {
        writer.Write(ObjectID);
        writer.Write(Name);
        writer.Write(Location.X);
        writer.Write(Location.Y);
        writer.Write(Icon);
        writer.Write(CanTeleportTo);
    }
}