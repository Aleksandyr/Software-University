namespace TheaterSystem.Commands
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    using TheaterSystem.Data;

    public static class CommandExecutor
    {
        public static IPerformanceDatabase Data = new TheatreDatabase();

        public static string AddTheaterCommand(string[] allTheaterPartsSeparated)
        {
            string [] theaterParametars = allTheaterPartsSeparated
                                    .Skip(1)
                                    .Select(p => p.Trim())
                                    .ToArray();

            var result = ExecuteAddTheatreCommand(theaterParametars);

            return result;
        }
        
        public static string ExecutePrintAllTheatresCommand()
        {
            var theatres = Data
                .ListTheatres()
                .ToList();

            if (theatres.Count > 0)
            {
                // This is unnecessary
                // var resultTheatres = new LinkedList<string>();
                // for (int i = 0; i < theatresCount; i++)
                // {
                //     Data.ListTheatres()
                //         .Skip(i).ToList()
                //         .ForEach(t => resultTheatres.AddLast(t));

                //     foreach (var t in Data.ListTheatres().Skip(i + 1))
                //     {
                //         resultTheatres.Remove(t);
                //     }
                // }

                return String.Join(", ", theatres);
            }

            return "No theatres";
        }

        public static string AddPerformanceCommand(string[] allPerformancePartsSeparated)
        {
            var performanceParameters = allPerformancePartsSeparated
                .Skip(1)
                .Select(p => p.Trim())
                .ToArray();

            string theatreName = performanceParameters[0];
            string performanceTitle = performanceParameters[1];
            DateTime startDateTime = DateTime.ParseExact(performanceParameters[2], "dd.MM.yyyy HH:mm", CultureInfo.InvariantCulture);
            TimeSpan duration = TimeSpan.Parse(performanceParameters[3]);
            decimal price = decimal.Parse(performanceParameters[4]);

            Data.AddPerformance(theatreName, performanceTitle, startDateTime, duration, price);

            return "Performance added";
        }

        public static string PrintPerformancesCommand(string[] allPerformancePartsSeparated)
        {
            var performanceParameters = allPerformancePartsSeparated.Skip(1).Select(p => p.Trim()).ToArray();
            var chiHuyParams = performanceParameters;

            string theatre = chiHuyParams[0];
            var performances = Data.ListPerformances(theatre)
                .Select(p =>
                {
                    string startDate = p.StartDate.ToString("dd.MM.yyyy HH:mm");
                    return string.Format("({0}, {1})", p.PerformanceName, startDate);
                })
                .ToList();

            if (performances.Any())
            {
                return string.Join(", ", performances);
            }
            else
            {
                return "No performances";
            }
        }

        public static string ExecutePrintAllPerformancesCommand()
        {
            var performances = Data.ListAllPerformances().ToList();
            var result = String.Empty;

            if (performances.Any())
            {
                for (int i = 0; i < performances.Count; i++)
                {
                    var sb = new StringBuilder();
                    sb.Append(result);

                    // May if is unnecessary
                    if (i > 0)
                    {
                        sb.Append(", ");
                    }

                    string result1 = performances[i].StartDate.ToString("dd.MM.yyyy HH:mm");
                    sb.AppendFormat("({0}, {1}, {2})", performances[i].PerformanceName, performances[i].TheatreName, result1);
                    result = sb + "";
                }

                // BUG FUXED: Here should return StringBuilder
                return result;
            }

            return "No performances";
        }

        private static string ExecuteAddTheatreCommand(string[] parameters)
        {
            string theatreName = parameters[0];
            Data.AddTheatre(theatreName);

            return "Theatre added";
        }
    }
}
