using CatInfo;
using System;

namespace TomCatInfo
{
    public class TomCat : Cat
    {
        public TomCat(string name, int age, string gander = "Male")
            :base(name, age, gander)
        {
        }

        public override string ToString()
        {
            return this.Gander;
        }
    }
}
