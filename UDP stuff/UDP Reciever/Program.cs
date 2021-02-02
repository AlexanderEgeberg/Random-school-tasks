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
            UdpClient udpReceiver = new UdpClient(7000);
            IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 7000);

            try
            {
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
