using System.Net;
using Server.Itself;

namespace HttpServer.Controllers;

public record User(string Name, string Surname, string Login);

public class UserController : IController {
    public User[] Index() {
        return new[] {
            new User("Egor", "Ivanov", "Egor123"),
            new User("Sasha", "Petrov", "YellowGreen1")
        };
    }
}