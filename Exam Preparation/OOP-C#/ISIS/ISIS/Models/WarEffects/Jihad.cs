namespace ISIS.Models.WarEffects
{
    using ISIS.Interfaces;

    public class Jihad : WarEffect
    {
        private const int MultipleIncrease = 2;
        private const int MultipleDecrease = 0;
        
        private const int HealthIncrease = 0;
        private const int HelathDecrease = 0;

        private const int DamageIncrease = 0;
        private const int DamageDecrease = 5;

        public Jihad()
            : base(
            MultipleIncrease, 
            MultipleDecrease, 
            HealthIncrease, 
            HelathDecrease, 
            DamageIncrease, 
            DamageDecrease)
        {
        }
    }
}
