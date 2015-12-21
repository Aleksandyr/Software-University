namespace ISIS.Models
{
    using ISIS.Interfaces;

    public class GroupGame : IGroup
    {
        public GroupGame(int health, int damage, IAttackType attackType, IWarEffect warEffect)
        {
            this.Health = health;
            this.Damage = damage;
            this.AttackType = attackType;
            this.WarEffect = warEffect;
            this.IsAlive = true;
        }

        public int Health { get; set; }

        public int Damage { get; set; }

        public IAttackType AttackType { get; private set; }

        public IWarEffect WarEffect { get; private set; }

        public bool IsAlive { get; private set; }

        public void Update()
        {
            if (this.Health <= 0)
            {
                this.IsAlive = false;
            }

            this.Damage -= WarEffect.DamageDecrease;
            this.Health -= WarEffect.HealthDecrase;
            if (this.WarEffect.IsAlreadyUsed)
            {
                if (this.Damage <= 0)
                {
                    this.IsAlive = false;
                }
            }
        }

        public override string ToString()
        {
            var result = string.Empty;
            if (this.IsAlive)
            {
                result = string.Format("{0} HP, {1} Damage", this.Health, this.Damage);
            }

            return result.ToString();
        }
    }
}
