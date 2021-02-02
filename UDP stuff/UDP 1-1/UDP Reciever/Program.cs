using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDP_Reciever
{
    class Program
    {
        static void Main(string[] args)
        {

            IPAddress ip = IPAddress.Parse("127.0.0.1");
            UdpClient udpReceiver = new UdpClient("127.0.0.1",7000);
            IPEndPoint remoteIpEndPoint = new IPEndPoint(ip, 7000);



            try
            {

                Console.WriteLine("insert amount of DKK");
                String currency = Console.ReadLine();
                Byte[] sendBytes = Encoding.ASCII.GetBytes(currency);

                udpReceiver.Send(sendBytes, sendBytes.Length);

                while (true)
                {

                    Byte[] receiveBytes = udpReceiver.Receive(ref remoteIpEndPoint);

                    string receivedData = Encoding.ASCII.GetString(receiveBytes);

                    Console.WriteLine(receivedData);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
