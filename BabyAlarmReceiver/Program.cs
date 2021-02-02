using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using BabyLibrary;

namespace BabyAlarmReceiver
{
    class Program
    {
        static void Main(string[] args)
        {

            UdpClient udpReceiver = new UdpClient(7000);
            IPEndPoint remoteIpEndPoint = new IPEndPoint(IPAddress.Any, 7000);

            int UnitNo;
            int Breath;
            int Crying;

            try
            {
                while (true)
                {

                    Byte[] receiveBytes = udpReceiver.Receive(ref remoteIpEndPoint);

                    string receivedData = Encoding.ASCII.GetString(receiveBytes);

                    Console.WriteLine(receivedData);

                    string[] receivedArray =  receivedData.Split(",");

                    UnitNo = Int32.Parse(receivedArray[0]);
                    Breath = Int32.Parse(receivedArray[1]);
                    Crying = Int32.Parse(receivedArray[2]);

                    Console.WriteLine($"UnitNo: {UnitNo} - Breath: {Breath} - Crying: {Crying}");

                    Console.WriteLine(BabyCool.AlarmBreath(Breath));
                    Console.WriteLine(BabyCool.AlarmCry(Crying));

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
