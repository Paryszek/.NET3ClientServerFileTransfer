using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using FileContainer;

namespace zad3server
{
    public class Server
    {
        private string _host;
        private int _port;
        private TcpListener _server;
        private readonly FileSerializer _serializer;

        public Server(string host, int port)
        {
            _host = host;
            _port = port;
            _serializer = new FileSerializer();
        }
        public void InitializeServer() {
            _server = new TcpListener(IPAddress.Parse(_host), _port);
            _server.Start();
        }

        public void Listen()
        {
            while (true)
            {
                Console.WriteLine("Waiting for a connection... ");
                TcpClient client = _server.AcceptTcpClient();
                Thread clinetThread = new Thread(() => HandleClient(client));
                clinetThread.Start();
            }
        }



        void HandleClient(TcpClient client)
        {
            try {
                Console.WriteLine("Connected!");
                NetworkStream stream = client.GetStream();
                FileWrapper fileWrapper = _serializer.ReadFromStream(stream);
                System.IO.File.WriteAllBytes(fileWrapper._fileName, fileWrapper._file);
                Console.WriteLine("File successful copied");
            } catch(Exception e) {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
