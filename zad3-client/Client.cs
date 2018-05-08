using System;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using FileContainer;

namespace zad3client
{
    public class Client
    {
        private TcpClient _connect;
        private string _filePath;
        private string _fileName;
        private string _host;
        private int _port;
        private readonly FileSerializer _serializer;
        public Client(string host, int port)
        {
            _host = host;
            _port = port;
            _serializer = new FileSerializer();
        }

        public void InitConnection()
        {
            _connect = new TcpClient();
            Console.WriteLine("Connecting.....");
            _connect.Connect(_host, _port);
        }

        public void GetFileInfo() {
            _fileName = GetInputString("fileName");
            _filePath = GetInputString("filePath");
        }

        public void UploadFile() {
            IFormatter formatter = new BinaryFormatter();
            FileWrapper fileWrapper = new FileWrapper(_fileName, GetFileData(_filePath));
            _serializer.WriteToStream(_connect.GetStream(), fileWrapper);
        }

        private string GetInputString(string v)
        {
            string stringToReturn = "";
            switch (v)
            {
                case "fileName":
                    Console.WriteLine("Insert file name");
                    stringToReturn = GetInputString("");
                    break;
                case "filePath":
                    Console.WriteLine("Insert file path");
                    stringToReturn = GetInputString("");
                    break;
                default:
                    stringToReturn = Console.ReadLine();
                    break;
            }
            return stringToReturn;
        }

        private byte[] GetFileData(string filePath)
        {
            using (FileStream fileStream = File.OpenRead(filePath))
            {
                String filename = Path.GetFileName(filePath);
                return File.ReadAllBytes(filePath);
            }

        }



    }
}


