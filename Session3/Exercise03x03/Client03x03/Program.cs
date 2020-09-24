using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text;


namespace Client03x03
{
    class Program
    {
        static void Main(string[] args)
        {
            string response = "";
            Console.WriteLine("Starting client..");

            TcpClient client = new TcpClient("10.0.0.134", 5000);

            NetworkStream stream = client.GetStream();

            while (!response.Contains("exit"))
            {
                Console.WriteLine("Input message:");

                string message = Console.ReadLine();

                byte[] dataToServer = Encoding.ASCII.GetBytes(message);
                stream.Write(dataToServer, 0, dataToServer.Length);

                //Response
                byte[] dataFromServer = new byte[1024];
                int bytesRead = stream.Read(dataFromServer, 0, dataFromServer.Length);
                response = Encoding.ASCII.GetString(dataFromServer, 0, bytesRead);
                Console.WriteLine(response);
            }

            stream.Close();
            client.Close();
        }

        public static void HandleServer(TcpClient client)
        {

        }
    }
}
