using System.Net;
using System.Net.Sockets;

namespace Server.Itself;
public class ServerHost {
    private readonly IHandler _handler;
    public ServerHost(IHandler handler) {
        _handler = handler;
    }

    public void StartV1() {
        TcpListener listener = new(IPAddress.Any, 80);
        listener.Start();

        while (true) {
            try {
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
            catch(Exception ex) { }
        }
    }

    public async Task StartV2() {
        TcpListener listener = new(IPAddress.Any, 80);
        listener.Start();

        while (true) {
            try {
                var client = listener.AcceptTcpClient();
                ProcessClient(client);
            }
            catch(Exception ex) { }
        }
    }

    private async void ProcessClient(TcpClient client) {
        using(client)
        using (var stream = client.GetStream()) 
        using (var reader = new StreamReader(stream)){
            var firstLine = await reader.ReadLineAsync();
            for (string line = null; line != string.Empty; line = await reader.ReadLineAsync())
                ;

            var request = RequestParser.Parse(firstLine);
        
            await _handler.HandleAsync(stream, request);
        }
    }
}
