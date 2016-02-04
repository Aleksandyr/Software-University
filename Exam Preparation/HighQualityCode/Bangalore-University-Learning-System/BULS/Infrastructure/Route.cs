namespace BangaloreUniversityLearningSystem.Infrastructure
{
    using System;
    using System.Collections.Generic;
    using System.Net;

    using BangaloreUniversityLearningSystem.Interfaces;
    using BangaloreUniversityLearningSystem.Utilities;

    public class Route : IRoute
    {
        public Route(string routeUrl)
        {
            this.Parse(routeUrl);
        }

        public string ActionName { get; private set; }

        public string ControllerName { get; private set; }

        public IDictionary<string, string> Parameters { get; private set; }

        private void Parse(string routeUrl)
        {
            string[] parts = routeUrl.Split(
                new[] { "/", "?" }, 
                StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length < 2)
            {
                throw new InvalidOperationException("The provided route is invalid.");
            }

            this.ControllerName = parts[0] + Constants.ControllerSuffix;
            this.ActionName = parts[1];

            if (parts.Length >= 3)
            {
                this.Parameters = new Dictionary<string, string>();
                string[] parameterPairs = parts[2].Split('&');

                foreach (var pair in parameterPairs)
                {
                    string[] nameAndValue = pair.Split('=');
                    string name = WebUtility.UrlDecode(nameAndValue[0]);
                    string value = WebUtility.UrlDecode(nameAndValue[1]);

                    // BUG FIX: key value added was paid
                    this.Parameters.Add(name, value);
                }
            }
        }
    }
}