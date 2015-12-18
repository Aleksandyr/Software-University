namespace Empires.Interfaces
{
    using Empires.Enums;

    public interface IResourceFactory
    {
        IResource CreateResource(ResourceType resourceType, int quantity);
    }
}
