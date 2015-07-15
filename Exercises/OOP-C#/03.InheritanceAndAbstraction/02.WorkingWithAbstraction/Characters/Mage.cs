using CharacterInfo;
namespace MageInfo
{
    class Mage : Character
    {
        public const int initalHealth = 100;
        public const int initalMana = 300;
        public const int initalDamage = 75;

        public Mage() : base(initalHealth, initalMana, initalDamage)
        {

        }

        public override void Attack(Character target)
        {
            this.Mana -= 100;
            target.Health -= 2 * this.Damage;
        }
    }
}
