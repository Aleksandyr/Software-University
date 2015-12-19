namespace Empires.Core.Factories
{
    using System;

    using Empires.Interfaces;
    using Empires.Models.Units;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            switch (unitType)
            {
                case "Archer":
                    return new Archer();
                case "Swordsman":
                    return new Swordsman();
                default:
                    throw new InvalidOperationException("Unknown unit type.");
            }
        }
    }
}
