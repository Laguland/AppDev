using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using ServerData;
using System.Data.OleDb;
using System.IO;

namespace Server
{
    class Server
    {
        static Socket socketListener;
        static List<ClientData> _clients;
        static OleDbConnection dbConnection;

        static void Main(string[] args)
        {
            // Test database connection
            try
            {
                string fileName = "AppDevDtb.accdb";
                string path = Path.Combine(Environment.CurrentDirectory, fileName);
                dbConnection = new OleDbConnection();
                dbConnection.ConnectionString =   "Provider=Microsoft.ACE.OLEDB.12.0; Data Source="+path+";Persist Security Info=False;";
                dbConnection.Open();
                Console.WriteLine("Successful connection to database.");
                dbConnection.Close();
            }
            catch
            {
                Console.WriteLine("Cannot connect to database!");
            }

            // Start Server
            Console.WriteLine("Starting server on " + Packet.GetIP4Address().ToString() + " Port: 7009");
            socketListener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            _clients = new List<ClientData>();

            IPEndPoint ip = new IPEndPoint(IPAddress.Parse(Packet.GetIP4Address()),7009);
            socketListener.Bind(ip);

            // Start listening for clients
            Thread listenThread = new Thread(ListenThread);
            listenThread.Start();
        }

        public static void Data_IN(object cSocket)
        {
            Socket clientSocket = (Socket)cSocket;
            byte[] buffer;
            int readBytes;

            for (;;)
            {
                try
                {
                    buffer = new byte[clientSocket.SendBufferSize];
                    readBytes = clientSocket.Receive(buffer);

                    if (readBytes > 0)
                    {
                        Packet packet = new Packet(buffer);
                        DataManager(packet);
                    }
                }
                catch
                {
                Console.WriteLine("A client Disconnected!");
                }
            }
        }

        static void ListenThread()
        {
            while(true)
            {
                socketListener.Listen(0);
                _clients.Add(new ClientData(socketListener.Accept()));
            }
        }

        public static void DataManager(Packet p)
        {
            switch(p.packetType)
            {
                case Packet.PacketType.Chat:
                    foreach(ClientData c in _clients)
                    {
                        c.clientSocket.Send(p.ToBytes());
                    }
                    break;

                case Packet.PacketType.Registration:

                    break;

                case Packet.PacketType.LogIn:
                    string email = p.gData[0];
                    string UserPassword = "";
                    string password = p.gData[1];
                    int countRows = 0;

                    dbConnection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = dbConnection;
                    command.CommandText = "SELECT * FROM USERS WHERE USER_EMAIL = '" + email + "';";
                    OleDbDataReader readedRows = command.ExecuteReader();
                    
                    while(readedRows.Read())
                    {
                        UserPassword = readedRows["PASSWORD"].ToString();
                        countRows++;
                    }

                    if (!readedRows.HasRows)
                    {
                        // WRONG EMAIL
                        foreach (ClientData c in _clients)
                        {
                            if (c.id == p.senderID)
                            {
                                Packet responsePacket = new Packet(Packet.PacketType.LogIn,"server");
                                responsePacket.gData.Add("Wrong email address");
                                responsePacket.packetBool = false;
                                c.clientSocket.Send(responsePacket.ToBytes());
                            }
                        }
                    }
                    else if (countRows > 1) // check number of rows
                    {
                        // DUPLICATED USER
                        Console.WriteLine("Warning: Duplicated record! User e-mail: " + readedRows["USER_EMAIL"].ToString());
                        foreach (ClientData c in _clients)
                        {
                            if (c.id == p.senderID)
                            {
                                Packet responsePacket = new Packet(Packet.PacketType.LogIn, "server");

                                if (readedRows["PASSWORD"].ToString() == password)
                                {
                                    responsePacket.gData.Add("success");
                                    responsePacket.packetBool = true;
                                }
                                else
                                {
                                    responsePacket.gData.Add("Wrong password");
                                    responsePacket.packetBool = false;
                                }

                                c.clientSocket.Send(responsePacket.ToBytes());
                            }
                        }
                    }
                    else if (UserPassword == password)
                    {
                        // log in successful
                        foreach (ClientData c in _clients)
                        {
                            if (c.id == p.senderID)
                            {
                                Packet responsePacket = new Packet(Packet.PacketType.LogIn, "server");
                                responsePacket.gData.Add("success");
                                responsePacket.packetBool = true;
                                c.clientSocket.Send(responsePacket.ToBytes());
                            }
                        }
                    }
                    else
                    {
                        // wrong password
                        foreach (ClientData c in _clients)
                        {
                            if (c.id == p.senderID)
                            {
                                Packet responsePacket = new Packet(Packet.PacketType.LogIn, "server");
                                responsePacket.gData.Add("Wrong password");
                                responsePacket.packetBool = false;
                                c.clientSocket.Send(responsePacket.ToBytes());
                            }
                        }
                    }

                    dbConnection.Close();
                    break;

                case Packet.PacketType.SignUp:

                    string newEmail = p.gData[0];
                    string newFName = p.gData[1];
                    string newSName = p.gData[2];
                    string newDOB = p.gData[3];
                    string newCity = p.gData[4];
                    string newPassword = p.gData[5];

                    try
                    {
                        dbConnection.Open();
                        OleDbCommand commandSignUp1 = new OleDbCommand();
                        commandSignUp1.Connection = dbConnection;
                        commandSignUp1.CommandText = "INSERT INTO USERS ([USER_EMAIL], [PASSWORD]) VALUES ('" + newEmail + "','" + newPassword + "')";
                        commandSignUp1.ExecuteNonQuery();
                        dbConnection.Close();
                        dbConnection.Open();
                        OleDbCommand commandSignUp2 = new OleDbCommand();
                        commandSignUp2.Connection = dbConnection;
                        commandSignUp2.CommandText = "INSERT INTO USER_DATA ([USER_EMAIL], [USER_NAME], [USER_SURNAME], [USER_DOB], [USER_CITY]) VALUES ('" +
                                                     newEmail + "','" + newFName + "','" + newSName + "','" + newDOB + "','" + newCity + "')";
                        commandSignUp2.ExecuteNonQuery();
                        dbConnection.Close();
                        dbConnection.Open();
                        OleDbCommand commandSignUp3 = new OleDbCommand();
                        commandSignUp3.Connection = dbConnection;
                        commandSignUp3.CommandText = "INSERT INTO PROFILE_DATA ([USER_EMAIL]) VALUES ('" + newEmail + "')";
                        commandSignUp3.ExecuteNonQuery();
                        dbConnection.Close();

                        dbConnection.Open();
                        OleDbCommand commandSignUp4 = new OleDbCommand();
                        commandSignUp4.Connection = dbConnection;
                        commandSignUp4.CommandText = "SELECT * FROM USERS WHERE USER_EMAIL = '" + newEmail + "'";
                        OleDbDataReader Checkifsaved = commandSignUp4.ExecuteReader();

                        if (!Checkifsaved.HasRows)
                        {
                            // new user didnt sign up
                            foreach (ClientData c in _clients)
                            {
                                if (c.id == p.senderID)
                                {
                                    Packet signUpPacket = new Packet(Packet.PacketType.SignUp, "server");
                                    signUpPacket.packetBool = false;
                                    c.clientSocket.Send(signUpPacket.ToBytes());
                                }
                            }
                        }
                        else
                        {
                            // success
                            foreach (ClientData c in _clients)
                            {
                                if (c.id == p.senderID)
                                {
                                    Packet signUpPacket = new Packet(Packet.PacketType.SignUp, "server");
                                    signUpPacket.packetBool = true;
                                    c.clientSocket.Send(signUpPacket.ToBytes());
                                }
                            }
                        }
                        dbConnection.Close();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    break;
                case Packet.PacketType.CheckDuplicate:

                    string emailToCheck = p.gData[0];
                    dbConnection.Open();
                    OleDbCommand checkCmd = new OleDbCommand();
                    checkCmd.Connection = dbConnection;
                    checkCmd.CommandText = "SELECT * FROM USERS WHERE USER_EMAIL = '" + emailToCheck + "'";
                    OleDbDataReader emailQuery = checkCmd.ExecuteReader();

                    if(emailQuery.HasRows)
                    {
                        // Email exists in database
                        Packet checkedEmailPacket = new Packet(Packet.PacketType.CheckDuplicate, "server");
                        checkedEmailPacket.packetBool = true;

                        foreach (ClientData c in _clients)
                        {
                            if (c.id == p.senderID)
                            {
                                c.clientSocket.Send(checkedEmailPacket.ToBytes());
                            }
                        }
                    }
                    else
                    {
                        // user can create account with this email address
                        Packet checkedEmailPacket = new Packet(Packet.PacketType.CheckDuplicate, "server");
                        checkedEmailPacket.packetBool = false;

                        foreach (ClientData c in _clients)
                        {
                            if (c.id == p.senderID)
                            {
                                c.clientSocket.Send(checkedEmailPacket.ToBytes());
                            }
                        }
                    }
                    dbConnection.Close();
                    break;

                case Packet.PacketType.ProfileLoad: // TODO: dodac zdjecia

                    string userEmail = p.gData[0];
                    string userFName = "";
                    string userSName = "";
                    string userCity = "";
                    string instruments = "";
                    string description = "";
                    string memberOF = "";
                    Packet profilePacket = new Packet(Packet.PacketType.ProfileLoad, "server");

                    try
                    {
                        dbConnection.Open();
                        OleDbCommand getUserDataCmd = new OleDbCommand();
                        getUserDataCmd.Connection = dbConnection;
                        getUserDataCmd.CommandText = "SELECT USER_NAME,USER_SURNAME,USER_CITY FROM USER_DATA WHERE USER_EMAIL = '" + userEmail + "'";
                        OleDbDataReader userData = getUserDataCmd.ExecuteReader();

                        while(userData.Read())
                        {
                            userFName = userData["USER_NAME"].ToString();
                            userSName = userData["USER_SURNAME"].ToString();
                            userCity = userData["USER_CITY"].ToString();
                        }
                        dbConnection.Close();

                        dbConnection.Open();
                        OleDbCommand getUserProfileCmd = new OleDbCommand();
                        getUserProfileCmd.Connection = dbConnection;
                        getUserProfileCmd.CommandText = "SELECT USER_DESC,INSTRUMENTS FROM PROFILE_DATA WHERE USER_EMAIL = '" + userEmail + "'";
                        OleDbDataReader profileData = getUserProfileCmd.ExecuteReader();

                        while (profileData.Read())
                        {
                            description = profileData["USER_DESC"].ToString();
                            instruments = profileData["INSTRUMENTS"].ToString();
                        }
                        dbConnection.Close();

                        dbConnection.Open();                                         
                        OleDbCommand getMemberOfCmd = new OleDbCommand();
                        getMemberOfCmd.Connection = dbConnection;
                        getMemberOfCmd.CommandText = "SELECT BAND_NAME FROM BAND_MEMBERS WHERE MEMBER_EMAIL = '" + userEmail + "'";
                        OleDbDataReader memberData = getMemberOfCmd.ExecuteReader();

                        while (memberData.Read())
                        {
                            memberOF = memberData["BAND_NAME"].ToString();
                        }
                        dbConnection.Close();

                        profilePacket.gData.Add(userFName);
                        profilePacket.gData.Add(userSName);
                        profilePacket.gData.Add(userCity);
                        profilePacket.gData.Add(instruments);
                        profilePacket.gData.Add(description);
                        profilePacket.gData.Add(memberOF);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }

                    foreach (ClientData c in _clients)
                    {
                        if (c.id == p.senderID)
                        {
                            c.clientSocket.Send(profilePacket.ToBytes());
                        }
                    }
                    break;

                case Packet.PacketType.PostAd:
                    string title = p.gData[0];
                    string desc = p.gData[1];
                    string adType = p.gData[2];
                    string instrument = p.gData[3];
                    string genre = p.gData[4];
                    string postedEmail = p.gData[5];
                    try
                    {
                        dbConnection.Open();
                        OleDbCommand inserAdCmd = new OleDbCommand();
                        inserAdCmd.Connection = dbConnection;
                        inserAdCmd.CommandText = "INSERT INTO ADVERTS ([EMAIL], [TYPE], [TITLE], [DESCRIPTION], [GENRE], [INSTRUMENT]) VALUES ('" + postedEmail + "','" + adType + "','" + title + "','" + desc + "','" + genre + "','" + instrument + "')";
                        inserAdCmd.ExecuteNonQuery();
                        dbConnection.Close();

                        Packet adPostSuccess = new Packet(Packet.PacketType.PostAd, "server");
                        adPostSuccess.packetBool = true;

                        foreach (ClientData c in _clients)
                        {
                            if (c.id == p.senderID)
                            {
                                c.clientSocket.Send(adPostSuccess.ToBytes());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    break;

                case Packet.PacketType.Search: // return name, email, title, desc

                    int count = 0;
                    int rows = 0;
                    string advType;
                    string adGenre;
                    string adInstrument;

                    advType = p.gData[0];
                    adGenre = p.gData[1];
                    adInstrument = p.gData[2];

                    try
                    {
                        dbConnection.Open();
                        OleDbCommand countRowsCmd = new OleDbCommand();
                        countRowsCmd.Connection = dbConnection;
                        countRowsCmd.CommandText = "SELECT EMAIL,TITLE,DESCRIPTION FROM ADVERTS WHERE TYPE = '" + advType + "' AND GENRE = '" + adGenre + "' AND INSTRUMENT = '" + adInstrument + "'";
                        OleDbDataReader adDataCount = countRowsCmd.ExecuteReader();
                        while (adDataCount.Read())
                        {
                            rows++;
                        }
                        dbConnection.Close();

                        string[] adEmails = new string[rows];
                        string[] adTitles = new string[rows];
                        string[] adDescriptions = new string[rows];
                        //string[] adNames = new string[rows];

                        dbConnection.Open();
                        OleDbCommand getAdsCmd = new OleDbCommand();
                        getAdsCmd.Connection = dbConnection;
                        getAdsCmd.CommandText = "SELECT EMAIL,TITLE,DESCRIPTION FROM ADVERTS WHERE TYPE = '" + advType + "' AND GENRE = '" + adGenre + "' AND INSTRUMENT = '" + adInstrument + "'";
                        OleDbDataReader adData = getAdsCmd.ExecuteReader();

                        while (adData.Read())
                        {
                            adEmails[count] = adData["EMAIL"].ToString();
                            adTitles[count] = adData["TITLE"].ToString();
                            adDescriptions[count] = adData["DESCRIPTION"].ToString();
                            count++;
                        }
                        dbConnection.Close();

                        //if(rows > 0)
                        //{
                        //    for (int i = 0; i <= count; i++)
                        //    {
                        //        dbConnection.Open();
                        //        OleDbCommand getNameCmd = new OleDbCommand();
                        //        getNameCmd.Connection = dbConnection;
                        //        getNameCmd.CommandText = "SELECT NAME FROM USER_DATA WHERE USER_EMAIL = '" + adEmails[i] + "'";
                        //        OleDbDataReader nameData = getNameCmd.ExecuteReader();
                        //        adNames[i] = nameData["NAME"].ToString();
                        //        dbConnection.Close();
                        //    }
                        //}

                        Packet adsPacket = new Packet(Packet.PacketType.Search, "server");
                        //adsPacket.gDataArray.Add(adNames);
                        adsPacket.gDataArray.Add(adEmails);
                        adsPacket.gDataArray.Add(adTitles);
                        adsPacket.gDataArray.Add(adDescriptions);

                        foreach (ClientData c in _clients)
                        {
                            if (c.id == p.senderID)
                            {
                                c.clientSocket.Send(adsPacket.ToBytes());
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                    break;

                default:
                    break;
            }
        }
    }
}
