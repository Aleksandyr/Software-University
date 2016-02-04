namespace BangaloreUniversityLearningSystem.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using BangaloreUniversityLearningSystem.Infrastructure;
    using BangaloreUniversityLearningSystem.Interfaces;
    using BangaloreUniversityLearningSystem.Models;
    using BangaloreUniversityLearningSystem.Utilities;
    using BangaloreUniversityLearningSystem.Data;

    public class BangaloreUniversityEngine : IBangaloreUniversityEngine
    {
        public void Run()
        {
            var data = new BangaloreUniversityData();
            User user = null;
            while (true)
            {
                string readLine = Console.ReadLine();
                if (readLine == null)
                {
                    break;
                }
                var route = new Route(readLine);

                var controllerType = Assembly.GetExecutingAssembly()
                    .GetTypes()
                    .FirstOrDefault(type => type.Name == route.ControllerName);

                var controller = Activator.CreateInstance(controllerType, data, user) as Controller;
                var method = controllerType.GetMethod(route.ActionName);

                object[] @params = MapParameters(route, method);

                try
                {
                    var view = method.Invoke(controller, @params) as IView;
                    Console.WriteLine(view.Display());

                    user = controller.User;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }

        private static object[] MapParameters(Route route, MethodInfo action)
        {
            var parametars = action.GetParameters()
                .Select<ParameterInfo, object>(p =>
                {
                    if (p.ParameterType == typeof (int))
                    {
                        //BUG FIXED: parse value not name
                        return int.Parse(route.Parameters[p.Name]);
                    }
                    else
                    {
                        return route.Parameters[p.Name];
                    }
                }).ToArray();

            return parametars;
        }
    }
}
