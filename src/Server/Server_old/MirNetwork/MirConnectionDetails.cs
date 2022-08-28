namespace Server.MirNetwork
{
    public class MirConnectionDetails
    {
        public string IpAddress { get; init; }
        public int SessionId { get; init; }
        public MirConnectionDetails(string ipAddress, int sessionId)
        {
            IpAddress = ipAddress;
            SessionId = sessionId;
        }
    }
}
