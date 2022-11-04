﻿using System.Net;
using System.Net.Sockets;

namespace Server.Itself;
public class ServerHost {
    private readonly IHandler _handler;
    public ServerHost(IHandler handler) {
        _handler = handler;
    }

    public void Start() {
        TcpListener listener = new(IPAddress.Any, 80);
        listener.Start();

        while (true) {
            var client = listener.AcceptTcpClient();
            using (var stream = client.GetStream()) 
            using (var reader = new StreamReader(stream)){
                var firstLine = reader.ReadLine();
                for (string line = null; line != string.Empty; line = reader.ReadLine())
                    ;

                var request = RequestParser.Parse(firstLine);
            
                _handler.Handle(stream, request);
            }
        }
    }
}
