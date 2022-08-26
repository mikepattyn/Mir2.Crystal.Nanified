namespace Shared.Packets.Client.Models
{
    public sealed class ClientVersion : ClientPacket
    {
        public ClientVersion() : base() { }
        public override short Index => (short)ClientPacketIds.ClientVersion;
        public byte[] VersionHash;

        public override void ReadPacket(BinaryReader reader)
        {
            VersionHash = reader.ReadBytes(reader.ReadInt32());
        }

        public override void WritePacket(BinaryWriter writer)
        {
            writer.Write(VersionHash.Length);
            writer.Write(VersionHash);
        }
    }
}
