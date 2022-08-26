using Shared.Models.Client;

namespace Shared.Packets.Server.Models;

public sealed class NewRecipeInfo : ServerPacket
{
    public override short Index
    {
        get { return (short)ServerPacketIds.NewRecipeInfo; }
    }

    public ClientRecipeInfo Info;

    public override void ReadPacket(BinaryReader reader)
    {
        Info = new ClientRecipeInfo(reader);
    }

    public override void WritePacket(BinaryWriter writer)
    {
        Info.Save(writer);
    }
}