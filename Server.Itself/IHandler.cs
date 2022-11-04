namespace Server.Itself;

public interface IHandler {
    void Handle(Stream stream, Request request);
}