using System;
using System.Collections.Generic;
using System.Text;

namespace Composite
{
    public class Element : Tag
    {
        private ICollection<Tag> children;

        public Element(string name, params Tag[] children)
            : base(name)
        {
            this.children = new List<Tag>();
            foreach (var child in children)
            {
                this.children.Add(child);
    
            }
        }

        public override void Add(Tag elem)
        {
            this.children.Add(elem);
        }

        public override void Remove(Tag elem)
        {
            this.children.Remove(elem);
        }

        public override string Display(int depth)
        { 
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(new String(' ', depth) + '<' + name + '>');

            foreach (var child in children)
            {
                sb.AppendLine(child.Display(depth + 2));
            }

            sb.AppendLine(new String(' ', depth) + '<' + '/' + name + '>');

            return sb.ToString();
        }
    }
}
