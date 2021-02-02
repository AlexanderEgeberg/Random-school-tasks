using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UDP_Broadcaster
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient udpServer = new UdpClient("127.0.0.1",7000);

            while (true)
            {
                var message = "xD";
                Byte[] sendBytes = Encoding.ASCII.GetBytes(message);

                udpServer.Send(sendBytes, sendBytes.Length);

                Console.WriteLine("message sent");

                Thread.Sleep(1000);
            }
        }
    }
}
