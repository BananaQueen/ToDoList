using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ToDoListClientApp
{
    public class MyTcpClient
    {
        public MyTcpClient()
        {
            try
            {
                TcpClient client = new TcpClient("127.0.0.2", 8080);

                byte[] data = Encoding.ASCII.GetBytes("hi");

                NetworkStream stream = client.GetStream();

                stream.Write(data, 0, data.Length);

                Console.WriteLine("Sent: ", "hi");

                data = new byte[256];

                string responseData = string.Empty;

                int bytes = stream.Read(data, 0, data.Length);
                responseData = Encoding.ASCII.GetString(data, 0, bytes);
                Console.WriteLine("Received: {0}", responseData);

                stream.Close();
                client.Close();
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine("ArgumentNullException: {0}", e);
            }
            catch (SocketException e)
            {
                Console.WriteLine("SocketException: {0}", e);
            }

            Console.WriteLine("\n Press Enter to continue...");
            //Console.Read();
        }
    }
}
