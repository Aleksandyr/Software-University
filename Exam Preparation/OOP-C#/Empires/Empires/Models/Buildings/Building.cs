namespace Empires.Models.Buildings
{
    using Empires.Enums;
    using Empires.Interfaces;

    public abstract class Building : IBuilding
    {
        private string unitType;
        private int unitCycleLength;
        private int resourceCycleLength;
        private int resourceQuantity;
        private ResourceType resourceType;
        private IUnitFactory unitFactory;
        private IResourceFactory resourceFactory;

        protected Building(
            string unitType, 
            int unitCycleLength, 
            ResourceType resourceType, 
            int resourceCycleLength,
            int resourceQuantity,
            IUnitFactory unitFactory,
            IResourceFactory resourceFactory)
        {
            this.unitType = unitType;
            this.unitCycleLength = unitCycleLength;
            this.resourceType = resourceType;
            this.resourceCycleLength = resourceCycleLength;
            this.resourceQuantity = resourceQuantity;
            this.unitFactory = unitFactory;
            this.resourceFactory = resourceFactory;
        }

        public bool CanProduceResource { get; private set; }

        public bool CanProduceUnit { get; private set; }

        public IResource ProduceResource()
        {
            var resource = this.resourceFactory.CreateResource(this.resourceType, this.resourceQuantity);

            return resource;
        }

        public IUnit ProduceUnit()
        {
            var unit = this.unitFactory.CreateUnit(this.unitType);

            return unit;
        }

        public void Update()
        {
            throw new System.NotImplementedException();
        }
    }
}
