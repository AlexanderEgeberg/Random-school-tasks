using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UDP_Broadcaster
{
    class Program
    {
        static void Main(string[] args)
        {
            //creates server
            UdpClient udpServer = new UdpClient(7000);

            //Create endpoint

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            IPEndPoint remoteIpEndPoint = new IPEndPoint(ip,7000);

            try
            {
                Console.WriteLine("Server is waiting for request");

                Byte[] receiveBytes = udpServer.Receive(ref remoteIpEndPoint);
                Console.WriteLine("Server received request");
                while (true)
                {
                    string receivedData = Encoding.ASCII.GetString(receiveBytes);

                    int DKK = Int32.Parse(receivedData);

                    string SEK = ValutaConvert.Converter.TilSvenskeKroner(DKK).ToString();

                    //var message = "xD";
                    Byte[] sendBytes = Encoding.ASCII.GetBytes($"{receivedData} DKK to SEK: {SEK} SEK");

                    udpServer.Send(sendBytes, sendBytes.Length, remoteIpEndPoint);

                    Console.WriteLine("message sent");

                    Thread.Sleep(1000);
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                
            }

        }
    }
}
