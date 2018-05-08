using System;
using System.IO;
using System.Net;
using System.Text;
using System.Net.Sockets;
using zad3client;

public class clnt {

    public static void Main() {
        try
        {
            Client client = new Client("127.0.0.1", 5050);
            client.GetFileInfo();
            client.InitConnection();
            client.UploadFile();
        }
        catch (Exception e)
        {
            Console.WriteLine("Error..... " + e.StackTrace);
        }
        Console.WriteLine("\nPress enter to continue...");
        Console.Read();
    }

}