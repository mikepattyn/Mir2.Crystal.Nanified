//using MediatR;
//using Server.MirDatabase;
//using Server.MirEnvir;
//using Server.MirObjects;
//using Shared.Functions;
//using Shared.Packets;
//using Shared.Packets.Server;
//using System.Net.Sockets;

//namespace Server.MirNetwork
//{
//    public class MirConnectionOOld
//    {
//        internal TcpClient TcpClient { get; set; }
//        public MirConnectionDetails ConnectionDetails { get; init; }
//        public MirConnectionQueueManager QueueManager { get; init; }
//        public long TimeConnected { get; init; }
//        public long TimeDisconnected { get; set; }
//        public long TimeoutTime { get; set; }
//        public bool Connected { get; set; }
//        public bool Disconnecting { get; set; }

//        internal byte[] RawData = new byte[0];
//        internal byte[] RawBytes = new byte[8 * 1024];

//        public GameStage Stage;
//        public AccountInfo Account;
//        public PlayerObject Player;

//        public List<MirConnection> Observers = new List<MirConnection>();
//        public MirConnection Observing;
//        public IMediator Mediator;
//        private PacketService PacketService { get; init; }
//        public MirConnection(TcpClient tcpClient, IMediator mediator, PacketService packetService, int sessionId)
//        {
//            Mediator = mediator;
//            ConnectionDetails = new MirConnectionDetails(tcpClient.Client.RemoteEndPoint.ToString().Split(":").First(), sessionId);

//            TcpClient = tcpClient;
//            TcpClient.NoDelay = true;

//            PacketService = packetService;

//            TimeConnected = DateTime.Now.Ticks;
//            TimeoutTime = TimeConnected + 10000;

//            QueueManager = new MirConnectionQueueManager();

//            Connected = true;
//            BeginReceive();
//        }
//        private void BeginReceive()
//        {
//            if (!Connected) return;
//            try
//            {
//                TcpClient.Client.BeginReceive(RawBytes, 0, RawBytes.Length,
//                    SocketFlags.None, ReceiveData, RawBytes);
//            }
//            catch
//            {
//                Disconnecting = true;
//            }
//        }
//        private void ReceiveData(IAsyncResult asyncResult)
//        {
//            if (!Connected) return;
//            int dataRead;
//            try
//            {
//                dataRead = TcpClient.Client.EndReceive(asyncResult);
//            }
//            catch
//            {
//                Disconnecting = true;
//                return;
//            }
//            if (dataRead == 0)
//            {
//                Disconnecting = true;
//                return;
//            }

//            var rawBytes = asyncResult.AsyncState as byte[];
//            var tempBytes = RawBytes;
//            RawBytes = new byte[dataRead + tempBytes.Length];
//            Buffer.BlockCopy(tempBytes, 0, RawBytes, 0, tempBytes.Length);
//            Buffer.BlockCopy(rawBytes, 0, RawBytes, tempBytes.Length, dataRead);

//            Packet packet;
//            while ((packet = PacketService.ReceiveClientPacket(RawBytes, out RawBytes)) != null)
//                QueueManager.ReceivedPacketsQueue.Enqueue(packet);

//            BeginReceive();
//        }
//        private void BeginSend(IEnumerable<byte> data)
//        {
//            if (!Connected || data.Count() == 0) return;
//            try
//            {
//                TcpClient.Client.BeginSend(data.ToArray(), 0, data.Count(), SocketFlags.None, SendData, Disconnecting);
//            }
//            catch
//            {
//                Disconnecting = true;
//            }
//        }
//        private void SendData(IAsyncResult result)
//        {
//            try 
//            { 
//                TcpClient.Client.EndSend(result); 
//            }
//            catch { }
//        }

//        public void Enqueue(Packet packet)
//        {
//            if (packet == null) return;
//            if (QueueManager.SentPacketsQueue != null)
//                QueueManager.SentPacketsQueue.Enqueue(packet);
//            if (!packet.Observable) return;
//            foreach (MirConnection mirConnection in Observers)
//                mirConnection.Enqueue(packet);
//        }

//        public void Process()
//        {
//            if (TcpClient != null || !TcpClient.Connected)
//            {
//                Disconnect(20);
//                return;
//            }

//            while(!QueueManager.ReceivedPacketsQueue.IsEmpty && !Disconnecting)
//            {
//                Packet packet;

//                if (!QueueManager.ReceivedPacketsQueue.TryDequeue(out packet)) continue;
//                TimeoutTime = Mir2Envir.Main.Time + Settings.TimeOut;
//                ProcessPacket(packet);

//                if (QueueManager.ReceivedPacketsQueue == null)
//                    return;
//            }

//            while (QueueManager.RetryQueue.Any())
//                QueueManager.ReceivedPacketsQueue.Enqueue(QueueManager.RetryQueue.Dequeue());

//            if (Mir2Envir.Main.Time > TimeoutTime)
//            {
//                Disconnect(21);
//                return;
//            }

//            if (!QueueManager.SentPacketsQueue.Any()) return;

//            List<byte> data = new List<byte>();

//            while (!QueueManager.SentPacketsQueue.IsEmpty)
//            {
//                Packet packet;
//                if (!QueueManager.SentPacketsQueue.TryDequeue(out packet) || packet == null) continue;
//                data.AddRange(packet.GetPacketBytes());
//            }

//            BeginSend(data);
//        }

//        private void ProcessPacket(Packet packet)
//        {
//            throw new NotImplementedException();
//        }

//        public void SoftDisconnect(byte reason)
//        {
//            Stage = GameStage.Disconnected;
//            TimeDisconnected = Mir2Envir.Main.Time;

//            lock (Mir2Envir.AccountLock)
//            {
//                if (Player != null)
//                    Player.StopGame(reason);
//                if (Account != null && Account.Connection == this)
//                    Account.Connection = null;
//            }

//            Account = null;
//        }
//        public void Disconnect(byte reason)
//        {
//            if (!Connected) return;

//            Connected = false;
//            Stage = GameStage.Disconnected;
//            TimeDisconnected = Mir2Envir.Main.Time;

//            lock (Mir2Envir.Main.Connections)
//                Mir2Envir.Main.Connections.Remove(this);

//            lock (Mir2Envir.AccountLock)
//            {
//                if (Player != null)
//                    Player.StopGame(reason);

//                if (Account != null && Account.Connection == this)
//                    Account.Connection = null;
//            }

//            if (Observing != null)
//                Observing.Observers.Remove(this);

//            Account = null;

//            QueueManager.NullifyQueues();

//            RawBytes = null;

//            if (TcpClient != null)
//                TcpClient.Client.Dispose();
//            TcpClient = null;
//        }

//        public void CleanObservers()
//        {
//            foreach (MirConnection mirConnection in Observers)
//            {
//                mirConnection.Stage = GameStage.Login;
//                mirConnection.Enqueue(Mediator.Send(new GetPacketQuery((short)ServerPacketIds.ReturnToLogin, true)).Result);
//            }
//        }
//    }
//}
