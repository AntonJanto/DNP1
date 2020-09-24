using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;

namespace Server03x03
{
    class Program
    {
        private static List<TcpClient> _clientsPool;
        static void Main(string[] args)
        {
            Console.WriteLine("Starting server");

            IPAddress ip = IPAddress.Parse("10.0.0.218");
            TcpListener listener = new TcpListener(ip, 5000);
            listener.Start();

            Console.WriteLine("Server started");

            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Console.WriteLine("Client Connected");

                var thread = new Thread(() => HandleClient(client));

                thread.Start();
            }
        }

        public static void HandleClient(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            string s;
            do
            {
                //read
                byte[] dataFromClient = new byte[1024];
                int bytesRead = stream.Read(dataFromClient, 0, dataFromClient.Length);
                s = Encoding.ASCII.GetString(dataFromClient, 0, bytesRead);
                Console.WriteLine(s);


                //respond
                byte[] dataToClient = Encoding.ASCII.GetBytes($"Returning {s}");
                stream.Write(dataToClient, 0, dataToClient.Length);

            }
            while (s.ToUpper() != "EXIT");
            client.Close();
        }
    }
}
