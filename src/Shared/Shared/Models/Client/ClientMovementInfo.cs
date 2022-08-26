using System.Drawing;

namespace Shared.Models.Client;

public class ClientMovementInfo
{
    public int Destination;
    public string Title;
    public Point Location;
    public int Icon;

    public ClientMovementInfo() { }

    public ClientMovementInfo(BinaryReader reader)
    {
        Destination = reader.ReadInt32();
        Title = reader.ReadString();
        Location = new Point(reader.ReadInt32(), reader.ReadInt32());
        Icon = reader.ReadInt32();
    }

    public void Save(BinaryWriter writer)
    {
        writer.Write(Destination);
        writer.Write(Title);
        writer.Write(Location.X);
        writer.Write(Location.Y);
        writer.Write(Icon);
    }
}