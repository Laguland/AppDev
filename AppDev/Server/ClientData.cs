using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;
using ServerData;

namespace Server
{
    class ClientData
    {
        public Socket clientSocket;
        public Thread clientThread;
        public string id;

        public ClientData()
        {
            id = Guid.NewGuid().ToString();
            clientThread = new Thread(Server.Data_IN);
            clientThread.Start(clientSocket);
            SendRegistrationPacket();
        }

        public ClientData(Socket cSocket)
        {
            this.clientSocket = cSocket;
            id = Guid.NewGuid().ToString();
            clientThread = new Thread(Server.Data_IN);
            clientThread.Start(clientSocket);
            SendRegistrationPacket();
            Console.WriteLine("New client connected " + clientSocket.ToString());
        }

        public void SendRegistrationPacket()
        {
            Packet p = new Packet(Packet.PacketType.Registration,"server");
            p.gData.Add(id);
            clientSocket.Send(p.ToBytes());
        }
    }
}
