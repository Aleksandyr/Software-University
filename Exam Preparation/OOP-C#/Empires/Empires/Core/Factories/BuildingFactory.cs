namespace Empires.Core.Factories
{
    using System;

    using Empires.Interfaces;
    using Empires.Models.Buildings;

    public class BuildingFactory : IBuildingFactory
    {
        public IBuilding CreateBuilding(string buildingType, IUnitFactory unitFactory, IResourceFactory resourceFacotory)
        {
            switch (buildingType)
            {
                case "archery":
                    return new Archery(unitFactory, resourceFacotory);
                case  "barracks":
                    return new Barracks(unitFactory, resourceFacotory);
                default:
                    throw new InvalidOperationException("Uknown building type.");
            }
        }
    }
}
