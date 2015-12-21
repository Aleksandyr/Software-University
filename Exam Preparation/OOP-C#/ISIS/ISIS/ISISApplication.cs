namespace ISIS
{
    using ISIS.Core;
    using ISIS.Core.Factories;
    using ISIS.IO;

    public class ISISApplication
    {
        public static void Main()
        {
            var reader = new ConsoleReader();
            var writer = new ConsoleWriter();
            var data = new ISISData();
            var warFactory = new WarEffectFactory();
            var attackFactory = new AttackTypeFactory();
            var groupFactory = new GroupFactory();

            var engine = new Engine(data, reader, writer, warFactory, attackFactory, groupFactory);
            engine.Run();
        }
    }
}
