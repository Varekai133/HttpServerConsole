using System.Net;

namespace Server.Itself;

internal static class ResponseWriter {
    public static void WriteStatus(HttpStatusCode code, Stream stream) {
        using var writer = new StreamWriter(stream, leaveOpen: true);
        writer.WriteLine($"HTTP/1.1 {(int)code} {code}");
        writer.WriteLine();
    }

    public static async Task WriteStatusAsync(HttpStatusCode code, Stream stream) {
        using var writer = new StreamWriter(stream, leaveOpen: true);
        await writer.WriteLineAsync($"HTTP/1.1 {(int)code} {code}");
        await writer.WriteLineAsync();
    }
}