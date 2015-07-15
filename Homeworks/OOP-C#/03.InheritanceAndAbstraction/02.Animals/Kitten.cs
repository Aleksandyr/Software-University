using CatInfo;
using System;

namespace KittenInfo
{
    public class Kitten : Cat
    {
        public Kitten(string name, int age, string gander = "Female")
            :base(name, age, gander)
        {
        }
    }
}
