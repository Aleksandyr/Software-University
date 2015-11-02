using System;
using System.IO;
using System.Linq;
using _01.FootballDatabaseFirst;
using System.Web;
using System.Web.Script.Serialization;

namespace _02.LeaguesAndTeamsAsJson
{
    class Program
    {
        static void Main()
        {
            var context = new FootballEntities();
            var leagues = context.Leagues
            .OrderBy(l => l.LeagueName)
            .Select(l => new
            {
                leagueName = l.LeagueName,
                teams = l.Teams.OrderBy(t => t.TeamName).Select(t => t.TeamName)
            }).ToList();

            var initializer = new JavaScriptSerializer();
            var json = initializer.Serialize(leagues);
            File.WriteAllText("../../leagues-and-teams.json", json);
        }
    }
}
