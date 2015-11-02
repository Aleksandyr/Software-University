using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using _01.FootballDatabaseFirst;

namespace _03.InternationalMatchesAsXml
{
    class Program
    {
        static void Main(string[] args)
        {
            var context = new FootballEntities();
            var internationalMatches = context.InternationalMatches
            .OrderBy(i => i.MatchDate)
            .ThenBy(i => i.CountryHome.CountryName)
            .ThenBy(i => i.CountryAway.CountryName)
            .Select(i => new
            {
                homeCountry = i.CountryHome.CountryName,        
                awayCountry = i.CountryAway.CountryName,        
                homeCountryCode = i.CountryHome.CountryCode,        
                awayCountryCode = i.CountryAway.CountryCode,
                league = i.League.LeagueName,
                matchDate = i.MatchDate,
                homeScore = i.HomeGoals,
                awayScore = i.AwayGoals
            }).ToList();

            var root = new XElement("matches");
            foreach (var internationalMatch in internationalMatches)
            {
                var matchNode = new XElement("match");
                if (internationalMatch.matchDate != null)
                {
                    if (internationalMatch.matchDate.Value.TimeOfDay.TotalSeconds == 0)
                    {
                        var date = internationalMatch.matchDate.Value.ToString("dd-MMM-yyyy");
                        matchNode.Add(new XAttribute("date", date));
                    }
                    else
                    {
                        var date = internationalMatch.matchDate.Value.ToString("dd-MMM-yyyy hh:mm");
                        matchNode.Add(new XAttribute("date-time", date));
                    }
                }
               
                matchNode.Add(new XElement("home-country", internationalMatch.homeCountry, new XAttribute("code", internationalMatch.homeCountryCode)));
                matchNode.Add(new XElement("away-country", internationalMatch.awayCountry, new XAttribute("code", internationalMatch.awayCountryCode)));
                if (internationalMatch.league != null)
                {
                    matchNode.Add(new XElement("league", internationalMatch.league));
                }
                if (internationalMatch.homeScore != null && internationalMatch.awayScore != null)
                {
                    matchNode.Add(new XElement("score", internationalMatch.homeScore + "-" + internationalMatch.awayScore));
                }
                root.Add(matchNode);
            }

            var xmlDoc = new XDocument(root);
            xmlDoc.Save("../../international-matches.xml");
        }
    }
}
