using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace BabyAlarmSender
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            UdpClient udpServer = new UdpClient("127.0.0.1", 7000);

            var UnitNo = 1;
            
            while (true)
            {


                var Breath = rand.Next(0, 30);
                var Crying = rand.Next(0, 2);

                var message = $"{UnitNo},{Breath},{Crying}";

                UnitNo++; //spørg om den skal tælle op "konstant værdi"


                Byte[] sendBytes = Encoding.ASCII.GetBytes(message);

                udpServer.Send(sendBytes, sendBytes.Length);

                Console.WriteLine("message sent");

                Thread.Sleep(1000);
            }
        }
    }
}