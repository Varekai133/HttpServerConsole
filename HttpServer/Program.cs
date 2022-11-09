using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using Server.Itself;

internal class Program
{
    private static void Main(string[] args)
    {
        ServerHost serverHost = new ServerHost(new ControllersHandler(typeof(Program).Assembly));
        serverHost.Start();
    }
}