using TheaterSystem.Commands;

namespace TheaterSystem.Core
{
    using System;
    using System.Globalization;
    using System.Threading;

    using TheaterSystem.Commands;

    public class TheatreEngine
    {
        // public TheatreEngine(IPerformanceDatabase data)
        // { 
            // this.Data = data;
        // }

        // public IPerformanceDatabase Data { get; set; }

        public virtual void Run()
        {
            //Thread.CurrentThread.CurrentCulture = new CultureInfo("vi-VN");

            while (true)
            {
                string readLine = Console.ReadLine();
                if (readLine == null)
                {
                    return;
                }

                if (readLine != string.Empty)
                {
                    string[] commandLineParts = readLine.Split('(');

                    string commandName = commandLineParts[0];

                    string consoleResult;
                    try
                    {
                        switch (commandName)
                        {
                            case "AddTheatre":
                                var allTheaterPartsSeparated = readLine.Split(new[] { '(', ',', ')' },
                                    StringSplitOptions.RemoveEmptyEntries);

                                consoleResult = CommandExecutor.AddTheaterCommand(allTheaterPartsSeparated);
                                break;

                            // BUG FIXED: Command was invalid
                            case "PrintAllTheatres":
                                consoleResult = CommandExecutor.ExecutePrintAllTheatresCommand();
                                break;

                            case "AddPerformance":
                                var allPerformancePartsSeparated = readLine.Split(new[] { '(', ',', ')' }, 
                                    StringSplitOptions.RemoveEmptyEntries);
                                
                                consoleResult = CommandExecutor.AddPerformanceCommand(allPerformancePartsSeparated);

                                break;

                            case "PrintAllPerformances":
                                consoleResult = CommandExecutor.ExecutePrintAllPerformancesCommand();
                                break;

                            case "PrintPerformances":
                                //commandLineParts = readLine.Split('(');
                                //commandName = commandLineParts[0];
                                allPerformancePartsSeparated = readLine.Split(
                                    new[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries);

                                consoleResult = CommandExecutor.PrintPerformancesCommand(allPerformancePartsSeparated);

                                break;

                            default:
                                consoleResult = "Invalid command!";

                                break;
                        }
                    }

                    catch (Exception ex)
                    {
                        consoleResult = "Error: " + ex.Message;
                    }

                    Console.WriteLine(consoleResult);
                }
            }
        }
    }
}
