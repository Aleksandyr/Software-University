using System.Collections.Generic;

namespace Composite
{
    public abstract class Tag
    {
        protected string name;

        protected Tag(string name)
        {
            this.name = name;
        }

        public abstract void Add(Tag elem);

        public abstract void Remove(Tag elem);

        public abstract string Display(int depth);
    }
}
