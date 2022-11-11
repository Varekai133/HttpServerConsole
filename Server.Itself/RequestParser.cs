namespace Server.Itself;

internal static class RequestParser {
    public static Request Parse(string header) {
        // TODO: Exceptions
        var split = header.Split(" ");
        return new Request(split[1], GetMethod(split[0]));
    }

    public static HttpMethod GetMethod(string method) {
        // Just for test
        // TODO: Normal method parser
        if (method == "GET")
            return HttpMethod.Get;
        return HttpMethod.Post;
    }
}