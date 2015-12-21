namespace ISIS.Core
{
    using System;

    using ISIS.Interfaces;
    using System.Collections.Generic;

    public class ISISData : IData
    {
        public ISISData()
        {
            this.Groups = new Dictionary<string, IGroup>();
        }

        public IDictionary<string, IGroup> Groups { get; private set; }


        public void AddGroup(string name, IGroup group)
        {
            if (group == null)
            {
                throw new ArgumentNullException("Groups");
            }

            if (!this.Groups.ContainsKey(name))
            {
                this.Groups.Add(name, group);
            }
        }
    }
}
