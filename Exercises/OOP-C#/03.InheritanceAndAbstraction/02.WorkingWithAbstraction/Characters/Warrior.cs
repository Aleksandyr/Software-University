using CharacterInfo;
namespace WarriorInfo
{
    class Warrior : Character
    {
        public const int initalHealth = 300;
        public const int initalMana = 0;
        public const int initalDamage = 120;

        public Warrior() : base(initalHealth, initalMana, initalDamage)
        {
        }

        public override void Attack(Character target)
        {
            this.Mana -= 100;
            target.Health -= this.Damage;
        }
    }
}
