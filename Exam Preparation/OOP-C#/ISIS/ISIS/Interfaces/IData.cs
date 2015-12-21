namespace ISIS.Interfaces
{
    using System.Collections;
    using System.Collections.Generic;

    public interface IData
    {
        IDictionary<string, IGroup> Groups { get; }

        void AddGroup(string name, IGroup group);
    }
}
