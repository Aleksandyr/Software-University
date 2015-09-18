using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace ScoreBoard
{
    class ScoreBoard
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            var center = new ScoreBoardSolution();

            string command = Console.ReadLine();
            while (command != "End")
            {
                if (string.IsNullOrEmpty(command))
                {
                    command = Console.ReadLine();
                    continue;
                }
                string commandResult = center.ProcessCommand(command);
                Console.WriteLine(commandResult);
                command = Console.ReadLine();
            }

        }
    }

    public class ScoreBoardSolution
    {
        private List<Game> games = new List<Game>(); 

        private List<User> users = new List<User>();

        public List<Score> scores = new List<Score>(); 

        private string RegisterUser(string username, string password)
        {
            if (users.Any(u => u.Username == username))
            {
                return "Duplicated user";
            }

            var user = new User()
            {
                Username = username,
                Password = password
            };

            this.users.Add(user);
            return "User registered";
        }

        private string RegisterGame(string gameName, string gamePassword)
        {
            if (games.Any(g => g.GameName == gameName))
            {
                return "Duplicated game";
            }

            var game = new Game()
            {
                GameName = gameName,
                GamePassword = gamePassword
            };

            this.games.Add(game);
            return "Game registered";
        }

        private string AddScore(string username, string userPass, string gameName, string gamePass, int points)
        {
            User user = users.FirstOrDefault(u => u.Username == username && u.Password == userPass);
            Game game = games.FirstOrDefault(g => g.GameName == gameName && g.GamePassword == gamePass);
            if (user != null)
            {
                if (game != null)
                {
                    var score = new Score()
                    {
                        User = user,
                        Game = game,
                        Points = points
                    };

                    this.scores.Add(score);
                    return "Score added";
                }

                return "Cannot add score";
            }

            return "Cannot add score";
        }

        public string ShowScoreboard(string gameName)
        {
            var currGame = games.FirstOrDefault(g => g.GameName == gameName);
            if (currGame == null)
            {
                return "Game not found";
            }

            var scoreByGame = this.scores.FirstOrDefault(s => s.Game.GameName == currGame.GameName);
            if (scoreByGame == null)
            {
                return "No score";
            }

            var topScoreOfGame = this.scores
                .OrderByDescending(s => s.Points)
                .ThenBy(s => s.User.Username)
                .Where(s => s.Game.GameName == gameName)
                .Take(10);

            var sb = new StringBuilder();
            int counter = 1;
            foreach (var score in topScoreOfGame)
            {
                sb.AppendLine(string.Format("#{0} {1} {2}", counter++, score.User.Username, score.Points));
            }

            return sb.ToString();
        }

        public string ListGameByPrefix(string prefix)
        {
            var gamesByPrefix = this.games
                .Where(g => g.GameName.StartsWith(prefix))
                .OrderBy(g => g.GameName)
                .Select(g => g.GameName);

            if (!gamesByPrefix.Any())
            {
                return "No matches";
            }
           
            return String.Join(", ", gamesByPrefix);
        }

        public string DeleteGame(string gameName, string gamePassword)
        {
            var game = this.games.FirstOrDefault(g => g.GameName == gameName && g.GamePassword == gamePassword);
            if (game == null)
            {
                return "Cannot delete game";
            }

            this.games.Remove(game);
            var score = this.scores.FirstOrDefault(s => s.Game.GameName == gameName && s.Game.GamePassword == gamePassword);
            this.scores.RemoveAll(s => s.Game.GameName == gameName && s.Game.GamePassword == gamePassword);
            return "Game deleted";
        }


        public string ProcessCommand(string command)
        {
            int indexOfFirstSpace = command.IndexOf(' ');
            string method = command.Substring(0, indexOfFirstSpace);
            string parameterValues = command.Substring(indexOfFirstSpace + 1);
            string[] parameters = parameterValues.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            switch (method)
            {
                case "RegisterUser" :
                    return RegisterUser(parameters[0], parameters[1]);
                case "RegisterGame":
                    return RegisterGame(parameters[0], parameters[1]);
                case "AddScore":
                    return AddScore(parameters[0], parameters[1], parameters[2], parameters[3], int.Parse(parameters[4]));
                case "ShowScoreboard":
                    return ShowScoreboard(parameters[0]);
                case "ListGamesByPrefix":
                    return ListGameByPrefix(parameters[0]);
                case "DeleteGame":
                    return DeleteGame(parameters[0], parameters[1]);
                default :
                    return "Invalid command";
            }
        }
    }

    public class User
    {
        public string Username { get; set; }

        public string Password { get; set; }
    }

    public class Game
    {
        public string GameName { get; set; }

        public string GamePassword { get; set; }
    }

    public class Score
    {
        public User User { get; set; }
        public Game Game { get; set; }
        public int Points { get; set; }
    }

}
