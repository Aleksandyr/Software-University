namespace Empires.Models
{
    using Empires.Enums;
    using Empires.Interfaces;

    public class Resource : IResource
    {
        public Resource (ResourceType resourceType, int quantity)
	    {
            this.ResourceType = resourceType;
            this.Quantity = quantity;
	    }
        public ResourceType ResourceType { get; private set; }

        public int Quantity { get; private set; }
    }
}
