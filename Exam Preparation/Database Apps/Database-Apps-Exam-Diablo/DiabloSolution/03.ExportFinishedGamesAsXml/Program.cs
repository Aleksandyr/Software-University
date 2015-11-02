using System.Linq;
using System.Xml.Linq;
using _01.DiabloDatabaseFirst;

namespace _03.ExportFinishedGamesAsXml
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new DiabloEntities();
            var finishedGames = db.Games
            .Where(g => g.IsFinished)
            .Select(g => new
            {
                GameName = g.Name,
                Darution = g.Duration,
                Users = g.UsersGames.Select(u => new
                {
                    UserName = u.User.Username,
                    IpAddress = u.User.IpAddress
                })
            })
            .OrderBy(g => g.GameName)
            .ThenBy(g => g.Darution)
            .ToList();

            var root = new XElement("games");
            foreach (var finishedGame in finishedGames)
            {
                var game = new XElement("game", new XAttribute("name", finishedGame.GameName));
                if (finishedGame.Darution != null)
                {
                    game.Add(new XAttribute("duration", finishedGame.Darution));
                }
                var users = new XElement("users");
                foreach (var user in finishedGame.Users)
                {
                    var userXml = new XElement("user");
                    userXml.Add(new XAttribute("username", user.UserName));
                    userXml.Add(new XAttribute("ip-address", user.IpAddress));
                    users.Add(userXml);
                }

                game.Add(users);
                root.Add(game);
            }

            var xmlDoc = new XDocument(root);
            xmlDoc.Save("../../finished-games.xml");
        }
    }
}
