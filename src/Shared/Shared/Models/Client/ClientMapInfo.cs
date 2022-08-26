namespace Shared.Models.Client;

public class ClientMapInfo
{
    public int Width;
    public int Height;
    public int BigMap;
    public string Title;
    public List<ClientMovementInfo> Movements = new List<ClientMovementInfo>();
    public List<ClientNPCInfo> NPCs = new List<ClientNPCInfo>();

    public ClientMapInfo() { }

    public ClientMapInfo(BinaryReader reader)
    {
        Title = reader.ReadString();
        Width = reader.ReadInt32();
        Height = reader.ReadInt32();
        BigMap = reader.ReadInt32();
        var count = reader.ReadInt32();
        for (int i = 0; i < count; i++)
            Movements.Add(new ClientMovementInfo(reader));
        count = reader.ReadInt32();
        for (int i = 0; i < count; i++)
            NPCs.Add(new ClientNPCInfo(reader));
    }

    public void Save(BinaryWriter writer)
    {
        writer.Write(Title);
        writer.Write(Width);
        writer.Write(Height);
        writer.Write(BigMap);
        writer.Write(Movements.Count);
        for (int i = 0; i < Movements.Count; i++)
            Movements[i].Save(writer);
        writer.Write(NPCs.Count);
        for (int i = 0; i < NPCs.Count; i++)
            NPCs[i].Save(writer);
    }
}