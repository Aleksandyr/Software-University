namespace Empires.Models.Buildings
{
    using Empires.Enums;
    using Empires.Interfaces;

    public class Barracks : Building
    {
        private const string BarracksUnitType = "Swordsman";
        private const int BarracksUnitCycleLength = 3;
        
        private const ResourceType BarracksResourceType = ResourceType.Steel;
        private const int BarracksResourceCycleLength = 3;
        private const int BarracksResourceQuantity = 5;

        public Barracks(IUnitFactory unitFactory, IResourceFactory resourceFactory)
            : base(BarracksUnitType, BarracksUnitCycleLength, BarracksResourceType, BarracksResourceCycleLength, BarracksResourceQuantity, unitFactory, resourceFactory)
        {

        }
    }
}
