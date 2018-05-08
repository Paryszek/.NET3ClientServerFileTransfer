using System;
using System.Text;
using System.Net;
using System.Net.Sockets;
using zad3server;

public class serv {
    public static void Main() {
        try {
            Server server = new Server("127.0.0.1", 5050);
            server.InitializeServer();
            server.Listen();
        } catch (Exception e) {
            Console.WriteLine("Error..... " + e.StackTrace);
        }
        Console.WriteLine("\nPress enter to continue...");
        Console.Read();
    }

}