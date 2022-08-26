namespace Shared.Models.Shared;

public class WorldMapSetup
{
    public bool Enabled;
    public List<WorldMapIcon> Icons = new List<WorldMapIcon>();

    public WorldMapSetup() { }

    public WorldMapSetup(BinaryReader reader)
    {
        Enabled = reader.ReadBoolean();
        int count = reader.ReadInt32();
        for (int i = 0; i < count; i++)
            Icons.Add(new WorldMapIcon(reader));
    }

    public void Save(BinaryWriter writer)
    {
        writer.Write(Enabled);
        writer.Write(Icons.Count);
        for (int i = 0; i < Icons.Count; i++)
            Icons[i].Save(writer);
    }
}