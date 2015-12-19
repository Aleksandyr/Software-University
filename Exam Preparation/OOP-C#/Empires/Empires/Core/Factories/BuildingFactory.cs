namespace Empires.Core.Factories
{
    using System;
    using System.Reflection;
    using System.Linq;

    using Empires.Interfaces;
    using Empires.Models.Buildings;

    public class BuildingFactory : IBuildingFactory
    {
        public IBuilding CreateBuilding(string buildingType, IUnitFactory unitFactory, IResourceFactory resourceFacotory)
        {
            var type = Assembly.GetExecutingAssembly().GetTypes()
                .FirstOrDefault(t => t.Name.ToLowerInvariant() == buildingType);

            if (type == null)
            {
                throw new InvalidOperationException("Invalid building type.");
            }

            var building = Activator.CreateInstance(type, unitFactory, resourceFacotory) as IBuilding;

            return building;
        }
    }
}
