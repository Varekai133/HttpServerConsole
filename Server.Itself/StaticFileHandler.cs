namespace Server.Itself;

public class StaticFileHandler : IHandler
{
    private readonly string _path;
    public StaticFileHandler(string path) {
        _path = path;
    }
    public void Handle(Stream networkStream) {
        using (var reader = new StreamReader(networkStream))
        using (var writer = new StreamWriter(networkStream)) {
            var firstLine = reader.ReadLine();
            for (string line = null; line != string.Empty; line = reader.ReadLine())
                ;

            var request = RequestParses.Parse(firstLine);
            var filePath = Path.Combine(_path, request.Path.Substring(1));

            if (!File.Exists(filePath)) {
                // TODO: 404
            }
            else {
                using (var fileStream = File.OpenRead(filePath)) {
                    fileStream.CopyTo(networkStream);
                }
            }

            Console.WriteLine(filePath);
        }
    }
}