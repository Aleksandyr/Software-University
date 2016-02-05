using System;

namespace Bridge
{
    public class Character
    {
        public Character(Weapon weapon)
        {
            this.Weapon = weapon;
        }

        public Weapon Weapon { get; set; }
    }
}
