using System;
using _02.DistanceServiceClient.DistanceServiceCalculator;

namespace _02.DistanceServiceClient
{
    class ConsoleClient
    {
        static void Main()
        {
            var service = new ServiceCalculatorClient();
            var startPoint = new Point()
            {
                X = 10,
                Y = 10
            };
            var endPoint = new Point()
            {
                X = 20,
                Y = 20
            };

            var result = service.CalculateDistance(startPoint, endPoint);
            Console.WriteLine(result);
        }
    }
}
