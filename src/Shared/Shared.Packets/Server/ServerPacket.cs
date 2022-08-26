namespace Shared.Packets.Server
{
    public abstract class ServerPacket : Packet
    {
        public ServerPacket() : base()
        {
            IsServer = true;
        }
    }
}
