using System.Net.Sockets;
using System.Text;

namespace ConsoleApp5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpClient tcpclnt = new TcpClient();
            Console.WriteLine("Підключення до сервера...");
            tcpclnt.Connect("192.168.100.3", 8001);

            Console.WriteLine("Введіть рядок для відправлення:");
            string str = Console.ReadLine();
            Stream stm = tcpclnt.GetStream();

            ASCIIEncoding asen = new ASCIIEncoding();
            byte[] ba = asen.GetBytes(str);
            Console.WriteLine("Відправлення рядка...");
            stm.Write(ba, 0, ba.Length);

            byte[] bb = new byte[100];
            int k = stm.Read(bb, 0, 100);

            for (int i = 0; i < k; i++)
                Console.Write(Convert.ToChar(bb[i]));

            tcpclnt.Close();
        }
    }
}
