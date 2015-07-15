
using CharacterInfo;
using Heal;
namespace PriestInfo
{
    class Priest : Character, IHeal
    {
        public const int initalHealth = 125;
        public const int initalMana = 200;
        public const int initalDamage = 100;
        private const int heal = 150;

        public Priest() : base(initalHealth, initalMana, initalDamage)
        {

        }

        public override void Attack(Character target)
        {
            this.Mana -= 100;
            target.Health -= this.Damage;
            this.Health += this.Damage / 10;
        }

        public void Heal(Character target)
        {
            this.Mana -= 100;
            target.Health += heal;
        }
    }
}
