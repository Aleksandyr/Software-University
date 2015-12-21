namespace ISIS.Models.AttackTypes
{
    using ISIS.Interfaces;

    public abstract class AttackType : IAttackType
    {
        protected AttackType(int attackDamage, int health)
        {
            this.AttackDamage = attackDamage;
            this.Health = health;
        }

        public int AttackDamage { get; private set; }
        public int Health { get; private set; }
    }
}
