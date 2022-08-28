using Shared.Packets;
using Shared.Packets.Server.Models;
using System.Collections.Concurrent;

namespace Server.MirNetwork
{
    public class MirConnectionQueueManager
    {
        public ConcurrentQueue<Packet> ReceivedPacketsQueue { get; set; }
        public ConcurrentQueue<Packet> SentPacketsQueue { get; set; }
        public Queue<Packet> RetryQueue { get; set; }

        public MirConnectionQueueManager()
        {
            ReceivedPacketsQueue = new ConcurrentQueue<Packet>();
            SentPacketsQueue = new ConcurrentQueue<Packet>();
            SentPacketsQueue.Enqueue(new Connected());
            RetryQueue = new Queue<Packet>();
        }

        public void NullifyQueues()
        {
            ReceivedPacketsQueue = null;
            SentPacketsQueue = null;
            RetryQueue = null;
        }
    }
}
