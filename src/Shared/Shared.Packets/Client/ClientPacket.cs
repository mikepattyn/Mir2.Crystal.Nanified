namespace Shared.Packets.Client
{
    public abstract class ClientPacket : Packet
    {
        public ClientPacket() : base()
        {
            IsServer = false;
        }
    }
}
