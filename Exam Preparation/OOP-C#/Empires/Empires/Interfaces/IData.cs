namespace Empires.Interfaces
{
    using Empires.Enums;
    
    using System.Collections;
    using System.Collections.Generic;

    public interface IData
    {
        IEnumerable<IBuilding> Buildings { get; }

        IDictionary<string, int> Units { get; }

        IDictionary<ResourceType, int> Resources { get; }

        void AddBuilding(IBuilding building);

        void AddUnit(IUnit unit);
    }
}
