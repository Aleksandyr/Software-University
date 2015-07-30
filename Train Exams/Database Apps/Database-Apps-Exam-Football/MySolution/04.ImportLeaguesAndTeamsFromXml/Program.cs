using System;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using _01.FootballDatabaseFirst;

namespace _04.ImportLeaguesAndTeamsFromXml
{
    class Program
    {
        static void Main()
        {
            var context = new FootballEntities();
            var xmlDoc = XDocument.Load("../../leagues-and-teams.xml");
            var node = xmlDoc.XPathSelectElements("/leagues-and-teams/league");
            var processing = 1;
            foreach (var element in node)
            {
                Console.WriteLine("Processing league #{0}...", processing++);
                var league = new League();
                if (element.Element("league-name") != null)
                {
                    var leagueName = element.Element("league-name").Value;
                    if (!context.Leagues.Any(l => l.LeagueName == leagueName))
                    {
                        league = new League()
                        {
                            LeagueName = leagueName
                        };

                        context.Leagues.Add(league);
                        Console.WriteLine("Created league: " + leagueName);
                    }
                    else
                    {
                        Console.WriteLine("Existing league: " + leagueName);
                    }
                }
                var teams = element.XPathSelectElements("teams/team");
                foreach (var team in teams)
                {
                    if (team.Attribute("name") != null)
                    {
                        var currTeam = new Team();
                        var teamName = team.Attribute("name").Value;
                        string countryName = null;
                        if (team.Attribute("country") != null)
                        {
                            countryName = team.Attribute("country").Value;
                        }
                        if (!context.Teams.Any(l => l.TeamName == teamName))
                        {
                            currTeam = new Team()
                            {
                                TeamName = teamName,
                                Country = context.Countries.FirstOrDefault(c => c.CountryName == countryName)
                            };
                            context.Teams.Add(currTeam);

                            Console.WriteLine("Created team: New {0} ({1})", teamName, countryName??"no country");
                        }
                        else
                        {
                            Console.WriteLine("Existing team: {0} ({1})", teamName, countryName);
                        }

                        if (league != null)
                        {
                            if (currTeam.Leagues.Contains(league))
                            {
                                Console.WriteLine("Existing team in league: {0} to {1}", teamName, league.LeagueName);
                            }
                            else
                            {
                                Console.WriteLine("Added team to league: {0} to {1}", teamName, league.LeagueName);
                            }
                        }
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
