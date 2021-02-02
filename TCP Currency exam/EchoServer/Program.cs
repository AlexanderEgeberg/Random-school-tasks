using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using ValutaConvert;


namespace EchoServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Server.Start();
        }
    }
    class Server
    {
        static int _clientNr = 0;

        public static void Start()
        {
            int port = 3002;
            TcpListener listener = new TcpListener(IPAddress.Loopback, port);
            listener.Start();
            Console.WriteLine("Server started...");

            while (true)
            {
                TcpClient socket = listener.AcceptTcpClient();
                _clientNr++;
                Console.WriteLine("User connected");
                Console.WriteLine($"Number of users online {_clientNr}");

                Task.Run(() =>
                {
                    // TcpClient tempSocket = socket;
                    DoClient(socket);
                }
                );
            }

        }

        public static void DoClient(TcpClient socket)
        {

            NetworkStream ns = socket.GetStream();
            StreamReader reader = new StreamReader(ns);
            StreamWriter writer = new StreamWriter(ns) { AutoFlush = true };

            writer.WriteLine("Connected to server...");

            try
            {

                while (true)
                {
                    writer.WriteLine("Would you like to convert to DKK or SEK");
                    string inputValuta = "";
                    inputValuta = reader.ReadLine();

                    if (inputValuta == "SEK")
                    {
                        writer.WriteLine("Insert amount of DKK to SEK");
                        var inputDKK = reader.ReadLine();
                        var intDKK = Int32.Parse(inputDKK);

                        writer.WriteLine(Converter.TilSvenskeKroner(intDKK));
                    }

                    if (inputValuta == "DKK")
                    {
                        writer.WriteLine("Insert amount of SEK to DKK");
                        var inputSEK = reader.ReadLine();
                        var intSEK = Int32.Parse(inputSEK);

                        writer.WriteLine(Converter.TilDanskeKroner(intSEK));
                    }

                    if (inputValuta == null)
                    {
                        ns.Close();
                        break;
                    }

                }
            }
            catch (Exception e)
            {

                if (e.Message == "Unable to read data from the transport connection: En eksisterende forbindelse blev tvangsafbrudt af en ekstern vært..")
                {
                    ns.Close();
                }
                else
                {
                    Console.WriteLine(e);
                    throw;
                }
            }

            ns.Close();
            _clientNr--;
            Console.WriteLine($"User disconnected... current number of users: {_clientNr}");
        }
    }
}
