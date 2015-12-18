namespace Empires.Models.Units
{
    using Empires.Interfaces;

    public abstract class Unit : IUnit
    {
        protected Unit(int attackDamage, int health)
        {
            this.AttackDamage = attackDamage;
            this.Health = health;
        }

        public int AttackDamage { get; private set; }

        public int Health { get; private set; }
    }
}
