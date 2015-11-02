using System;
using System.IO;
using System.Linq;
using System.Web.Script.Serialization;
using _01.DiabloDatabaseFirst;

namespace _02.CharactersAndPlayersAsJson
{
    class Program
    {
        static void Main()
        {
            var db = new DiabloEntities();
            var characters = db.Characters.Select(c => new
            {
                Name = c.Name,
                Player = c.UsersGames.Select(u => u.User.Username)
            })
            .OrderBy(c => c.Name)
            .ToList();

            var serializer = new JavaScriptSerializer();
            var json = serializer.Serialize(characters);
            File.WriteAllText("../../characters.json", json);
        }
    }
}
