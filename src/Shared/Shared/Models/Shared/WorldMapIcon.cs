namespace Shared.Models.Shared;

public class WorldMapIcon
{
    public int ImageIndex;
    public string Title;
    public int MapIndex;
    public WorldMapIcon() { }

    public WorldMapIcon(BinaryReader reader)
    {
        ImageIndex = reader.ReadInt32();
        Title = reader.ReadString();
        MapIndex = reader.ReadInt32();
    }

    public void Save(BinaryWriter writer)
    {
        writer.Write(ImageIndex);
        writer.Write(Title);
        writer.Write(MapIndex);
    }
}