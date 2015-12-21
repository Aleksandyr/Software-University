namespace ISIS.Models.WarEffects
{
    using ISIS.Interfaces;

    public abstract class WarEffect : IWarEffect
    {
        protected WarEffect(
            int multipleIncrease,
            int multipleDecrease,
            int helathIncrease,
            int healthDecrease,
            int damageIncrease,
            int damageDecrease)
        {
            this.MultipleIncrease = multipleIncrease;
            this.MultipleDecrease = multipleDecrease;
            this.HealthIncrease = helathIncrease;
            this.HealthDecrase = healthDecrease;
            this.DamageIncrease = damageIncrease;
            this.DamageDecrease = damageDecrease;
            this.IsAlreadyUsed = false;
        }

        public int MultipleIncrease { get; private set; }

        public int MultipleDecrease { get; private set; }

        public int HealthIncrease { get; private set; }

        public int HealthDecrase { get; private set; }

        public int DamageIncrease { get; private set; }

        public int DamageDecrease { get; private set; }

        public bool IsAlreadyUsed { get; set; }

        public void Update()
        {
            this.IsAlreadyUsed = true;
        }
    }
}
