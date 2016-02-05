using Bridge;

namespace RPG.Characters
{
    public class Warrior : Character
    {
        public Warrior(Weapon weapon)
            : base(weapon)
        {
        }

        public override string ToString()
        {
            return string.Format("Character: Warrior, Weapon: {0}", this.Weapon.Name);
        }
    }
}
