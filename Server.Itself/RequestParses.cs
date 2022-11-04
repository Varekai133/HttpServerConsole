namespace Server.Itself;

internal static class RequestParses {
    public static Request Parse(string header) {
        //Exceptions
        var split = header.Split(" ");
        return new Request(split[1], GetMethod(split[0]));
    }

    public static HttpMethod GetMethod(string method) {
        //Just for test
        if (method == "GET")
            return HttpMethod.Get;
        return HttpMethod.Post;
    }
}