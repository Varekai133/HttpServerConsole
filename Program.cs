using System;
using System.Net;
using System.Net.Sockets;

internal class Program
{
    private static void Main(string[] args)
    {
        TcpListener listener = new(IPAddress.Any, 80);
        listener.Start();

        var client = listener.AcceptTcpClient();
        using (var stream = client.GetStream()) {
            using (var reader = new StreamReader(stream))
            using (var writer = new StreamWriter(stream)) {
                for (string line = null; line != string.Empty; line = reader.ReadLine()) {
                    Console.WriteLine(line);
                }

                writer.Write("Hello from server!");
            }
        }
    }
}