using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

        class MyTcpListener
        {
            public static void Main(string[] args)
            {

                Console.WriteLine("Starting...");
                TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.2"), 8080);
                server.Start();
                Console.WriteLine("Started.");

                byte[] bytes = new byte[256];
                string data = null;

                // Enter the listening loop.
                while (true)
                {
                    int i;

                    Console.Write("Waiting for a connection... ");
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Connected!");

                    //StreamReader reader = new StreamReader(client.GetStream());

                    data = null;

                    NetworkStream stream = client.GetStream();

                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {

                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("Received: {0}", data);

                        data = data.ToUpper();

                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                        stream.Write(msg, 0, msg.Length);
                        Console.WriteLine("Sent: {0}", data);
                    }

                    Console.WriteLine("closing...");
                    Console.ReadLine();
                    server.Stop();
                }
            }
        }
    



