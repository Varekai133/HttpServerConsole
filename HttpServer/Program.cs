using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using Server.Itself;

internal class Program
{
    private static async Task Main(string[] args)
    {
        ServerHost serverHost = new ServerHost(new ControllersHandler(typeof(Program).Assembly));
        await serverHost.StartV2();
    }
}