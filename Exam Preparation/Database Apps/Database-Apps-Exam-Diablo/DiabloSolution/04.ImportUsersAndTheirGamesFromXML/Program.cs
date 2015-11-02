using System;
using System.Diagnostics;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using _01.DiabloDatabaseFirst;

namespace _04.ImportUsersAndTheirGamesFromXML
{
    class Program
    {
        static void Main()
        {
            var db = new DiabloEntities();

            var xmlDoc = XDocument.Load("../../users-and-games.xml");
            var xUsers = xmlDoc.XPathSelectElements("users/user");

            foreach (var user in xUsers)
            {
                var dbUser = new User();
                var userName = user.Attribute("username").Value;
                if (db.Users.Any(u => u.Username == userName))
                {
                    Console.WriteLine("User {0} already exists", userName);
                    dbUser = db.Users.FirstOrDefault(u => u.Username == userName);
                    continue;
                }
                else
                {
                    dbUser.Username = userName;
                    dbUser.IsDeleted = Convert.ToBoolean(int.Parse(user.Attribute("is-deleted").Value) == 0 ? "false" : "true");
                    dbUser.IpAddress = user.Attribute("ip-address").Value;
                    dbUser.RegistrationDate = DateTime.Parse(user.Attribute("registration-date").Value);
                    var firstName = user.Attribute("first-name");
                    if (firstName != null) dbUser.FirstName = firstName.Value;

                    var lastName = user.Attribute("last-name");
                    if (lastName != null) dbUser.FirstName = lastName.Value;

                    var email = user.Attribute("email");
                    if (email != null) dbUser.FirstName = email.Value;

                    db.Users.Add(dbUser);
                    db.SaveChanges();
                    Console.WriteLine("Successfully added user {0}", userName);
                }

                var games = user.XPathSelectElements("games/game");
                foreach (var gameXml in games)
                {
                    var game = new UsersGame();
                    var gameName = gameXml.Element("game-name").Value;
                    var characterName = gameXml.Element("character").Attribute("name").Value;
                    var currGame = db.Games.FirstOrDefault(g => g.Name == gameName);
                    var currCharacter = db.Characters.FirstOrDefault(g => g.Name == characterName);

                    game.GameId = currGame.Id;
                    game.UserId = dbUser.Id;
                    game.CharacterId = currCharacter.Id;
                    game.Cash = decimal.Parse(gameXml.Element("character").Attribute("cash").Value);
                    game.Level = int.Parse(gameXml.Element("character").Attribute("level").Value);
                    game.JoinedOn = DateTime.Parse(gameXml.Element("joined-on").Value);
                    db.SaveChanges();
                    Console.WriteLine("User {0} successfully added to game {1}", userName, gameXml.Element("game-name").Value);
                }
            }
        }
    }
}
