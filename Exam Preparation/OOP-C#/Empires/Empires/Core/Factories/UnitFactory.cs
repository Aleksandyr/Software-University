namespace Empires.Core.Factories
{
    using System;
    using System.Reflection;
    using System.Linq;

    using Empires.Interfaces;
    using Empires.Models.Units;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name.ToLowerInvariant() == unitType.ToLowerInvariant());

            if (type == null)
            {
                throw new InvalidOperationException("Invalid unit type.");
            }

            var unit = Activator.CreateInstance(type) as IUnit;

            return unit;
        }
    }
}
