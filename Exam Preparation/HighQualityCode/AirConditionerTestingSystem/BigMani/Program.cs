namespace BigMani
{
    using BigMani.Command;
    using BigMani.GoodStuff;
    using BigMani.Interfaces;
    using BigMani.UI;
    using BigMani.Wokr;

    public class Program
    {
        public static void Main()
        {
            IDatabase db = new Database();
            ICommandExecutor commandExecutor = new CommandExecutor(db);
            IUserInterface userInterface = new ConsoleUserInterface();

            var engine = new Engine(userInterface, commandExecutor);

            engine.Run();
        }
    }
}
