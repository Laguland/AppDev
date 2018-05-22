using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerData;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Client
{
    static class Connection
    {
        public static Socket master;
        public static string id;
        public static Thread t;

        // log in
        public static bool isValidUser = false;
        public static string logInMessage = "fail";
        public static string loggedUserEmail = "";

        // sign up
        public static bool newUserRegistered;

        // check duplicate
        public static bool checkedEmail = true;

        //profile data load
        public static string userFName;
        public static string userSName;
        public static string userCity;
        public static string instruments;
        public static string description;
        public static string memberOf;

        //post ad
        public static bool poadAdSuccess;

        // search
        //public static string[] findedNames;
        public static string[] findedTitles;
        public static string[] findedDesc;
        public static string[] findedemail;
         
        public static void ConnectToServer(string serverIP, int port)
        {
            master = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(serverIP), port);

            try
            {
                master.Connect(ip);
            }
            catch
            {

            }

            if(master.Connected)
            {
                t = new Thread(Data_IN);
                t.Start();
            }
        }

        static void Data_IN()
        {
            byte[] buffer;
            int readBytes;

            for (;;)
            {
                try
                {
                    buffer = new byte[master.SendBufferSize];
                    readBytes = master.Receive(buffer);

                    if (readBytes > 0)
                    {
                        DataMenager(new Packet(buffer));
                    }
                }
                catch
                {
                    Console.WriteLine("Server Disconnected!");
                    break;
                }
            }
        }

        public static bool IsConnected()
        {
            try // prevent from null value error
            {
                if (master.Connected)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        static void DataMenager(Packet p)
        {
            switch (p.packetType)
            {
                case Packet.PacketType.Registration:
                    id = p.gData[0];
                    break;

                case Packet.PacketType.LogIn:
                    isValidUser = p.packetBool;
                    logInMessage = p.gData[0];
                    break;

                case Packet.PacketType.SignUp:
                    newUserRegistered = p.packetBool;
                    break;

                case Packet.PacketType.CheckDuplicate:
                    checkedEmail = p.packetBool;
                    break;

                case Packet.PacketType.ProfileLoad:
                    userFName = p.gData[0];
                    userSName = p.gData[1];
                    userCity = p.gData[2];
                    instruments = p.gData[3];
                    description = p.gData[4];
                    memberOf = p.gData[5];
                    break;

                case Packet.PacketType.PostAd:
                    poadAdSuccess = p.packetBool;
                    break;

                case Packet.PacketType.Search:
                    //findedNames = p.gDataArray[0];
                    findedemail = p.gDataArray[0];
                    findedTitles = p.gDataArray[1];
                    findedDesc = p.gDataArray[2];
                    break;
                default:
                    break;
            }
        }
    }
}
