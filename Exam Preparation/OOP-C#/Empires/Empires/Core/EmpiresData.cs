namespace Empires.Core
{
    using System;
    using System.Collections.Generic;

    using Empires.Enums;
    using Empires.Interfaces;

    public class EmpiresData : IData
    {
        private readonly ICollection<IBuilding> buildings = new List<IBuilding>();
        private readonly ICollection<IUnit> units = new List<IUnit>();

        public EmpiresData()
        {
            this.Resources = new Dictionary<ResourceType, int>();
            this.InitResources();
        }

        public IEnumerable<IBuilding> Buildings
        {
            get
            {
                return this.buildings;
            }
        }

        public IEnumerable<IUnit> Units
        {
            get
            {
                return this.units;
            }
        }

        public IDictionary<ResourceType, int> Resources { get; private set; }

        public void AddBuilding(IBuilding building)
        {
            if (building == null)
            {
                throw new ArgumentNullException("building");
            }

            this.buildings.Add(building);
        }

        public void AddUnit(IUnit unit)
        {
            if (unit == null)
            {
                throw new ArgumentNullException("unit");
            }

            this.units.Add(unit);
        }

        private void InitResources()
        {
            var resourceTypes = Enum.GetValues(typeof(ResourceType));

            foreach (ResourceType resourceType in resourceTypes)
            {
                this.Resources.Add(resourceType, 0);    
            }
        }
    }
}
