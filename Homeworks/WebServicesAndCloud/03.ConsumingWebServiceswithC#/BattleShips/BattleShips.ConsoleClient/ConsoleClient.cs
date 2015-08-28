using System;
using System.Collections.Generic;
using System.Net.Http;

namespace BattleShips.ConsoleClient
{
    class ConsoleClient
    {
        private static string loginToke = string.Empty;
        private const string RegisterUserEndpoint = "http://localhost:62858/api/Account/Register";
        private const string LoginEndpoint = "http://localhost:64411/Token";
        private const string CreateGameEndpoint = "http://localhost:64411/api/Games/Create";
        private const string JoinGameEndpoint = "http://localhost:64411/api/Games/Join";
        private const string PlayGameEndpoint = "http://localhost:64411/api/Games/Play";

        static void Main()
        {
            Console.WriteLine("Switch: 1, 2, 3, 4 or 5");
            Console.WriteLine("1.Register");
            Console.WriteLine("2.Login");
            Console.WriteLine("3.Create Game");
            Console.WriteLine("4.Join Game");
            Console.WriteLine("5.Play");

            int choice = int.Parse(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter register details: Email password confirmPassword");
                    string inputRegister = Console.ReadLine();
                    var detailsReqister = inputRegister.Split(' ');
                    RegisterUser(detailsReqister[0], detailsReqister[1], detailsReqister[2]);
                    break;
                case 2:
                    Console.WriteLine("Enter Login details: Username password");
                    string inputLogin = Console.ReadLine();
                    var detailsLogin = inputLogin.Split(' ');
                    Login(detailsLogin[0], detailsLogin[1]);
                    break;
                case 3:
                    Console.WriteLine("Game is creating...");
                    CreateGame();
                    break;
                case 4:
                    Console.WriteLine("Enter join game details: GameId");
                    string inputJoinGame = Console.ReadLine();
                    JoinGame(inputJoinGame);
                    break;
                case 5:
                    Console.WriteLine("Enter play details:GameId X Y");
                    string inputPlay = Console.ReadLine();
                    var detailsPlay = inputPlay.Split(' ');
                    RegisterUser(detailsPlay[0], detailsPlay[1], detailsPlay[2]);
                    break;
                default: Console.WriteLine("Incorect input you must chouse (1, 2, 3, 4 or 5)"); break;
            }
        }

        public static async void RegisterUser(string email, string password, string confirmPassword)
        {
            if (loginToke != string.Empty)
            {
                Console.WriteLine("Already logged!");
                return;
            }

            var httpClient = new HttpClient();
            using (httpClient)
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("email", email),
                    new KeyValuePair<string, string>("password", password),
                    new KeyValuePair<string, string>("confirmPassword", confirmPassword),
                });

                var request = await httpClient.PostAsync(RegisterUserEndpoint, content);

                if (!request.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(request.Content.ReadAsStringAsync().Result);
                }

                Console.WriteLine("User is registered!");
            }
        }

        public static async void Login(string username, string password)
        {
            if (loginToke != string.Empty)
            {
                Console.WriteLine("Already logged!");
                return;
            }

            var httpClient = new HttpClient();
            using (httpClient)
            {
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("username", username),
                    new KeyValuePair<string, string>("password", password),
                    new KeyValuePair<string, string>("grant_type", "password")
                });

                var request = await httpClient.PostAsync(LoginEndpoint, content);

                if (!request.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(request.Content.ReadAsStringAsync().Result);
                }

                var response = request.Content.ReadAsAsync<LoginData>().Result;
                loginToke = response.AccessToken;
                Console.WriteLine("Login successful");
            }
        }

        private static async void CreateGame()
        {
            var httpClient = new HttpClient();
            using (httpClient)
            {
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + loginToke);
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("", "")
                });

                var request = await httpClient.PostAsync(CreateGameEndpoint, content);
                if (!request.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(request.Content.ReadAsStringAsync().Result);
                }

                var gameId = request.Content.ReadAsStringAsync().Result;
                Console.WriteLine("Create game with id: " + gameId);
            }
        }

        private static async void JoinGame(string gameId)
        {
            var httpClinet = new HttpClient();
            using (httpClinet)
            {
                httpClinet.DefaultRequestHeaders.Add("Authorization", "Bearer " + loginToke);
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("GameId", gameId)
                });

                var request = await httpClinet.PostAsync(JoinGameEndpoint, content);

                if (!request.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(request.Content.ReadAsStringAsync().Result);
                }

                var gameid = request.Content.ReadAsStringAsync().Result;
                Console.WriteLine("Joinde game with id: " + gameid);
            }
        }

        private static async void Play(string gameId, string x, string y)
        {
            var httpClinet = new HttpClient();
            using (httpClinet)
            {
                httpClinet.DefaultRequestHeaders.Add("Authorization", "Bearer " + loginToke);
                var content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("GameId", gameId),
                    new KeyValuePair<string, string>("PositionX", x),
                    new KeyValuePair<string, string>("PositionY", y),
                });

                var request = await httpClinet.PostAsync(PlayGameEndpoint, content);
                if (request.IsSuccessStatusCode)
                {
                    throw new HttpRequestException(request.Content.ReadAsStringAsync().Result);
                }

                var gameid = request.Content.ReadAsStringAsync().Result;
                Console.WriteLine("Joined game with id: " + gameid);
            }
        }

    }
}
