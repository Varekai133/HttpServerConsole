namespace Server.Itself;

public class StaticFileHandler : IHandler
{
    private readonly string _path;
    public StaticFileHandler(string path) {
        _path = path;
    }
    public void Handle(Stream stream) {
        using (var reader = new StreamReader(stream))
        using (var writer = new StreamWriter(stream)) {
            var firstLine = reader.ReadLine();
            for (string line = null; line != string.Empty; line = reader.ReadLine())
                ;

            var request = RequestParses.Parse(firstLine);
            var filePath = Path.Combine(_path, request.Path.Substring(1));

            Console.WriteLine(filePath);
            
            writer.Write("Hello from server!");
        }
    }
}