using Bridge;

namespace RPG.Characters
{
    public class Mage : Character
    {
        public Mage(Weapon weapon)
            : base(weapon)
        {
        }

        public override string ToString()
        {
            return string.Format("Character: Mage, Weapon: {0}", this.Weapon.Name);
        }
    }
}
