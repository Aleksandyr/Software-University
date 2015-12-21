using ISIS.Interfaces;
namespace ISIS.Models.WarEffects
{
    public class Kamikaze : WarEffect
    {
        private const int MultipleIncrease = 0;
        private const int MultipleDecrease = 0;
        
        private const int HealthIncrease = 50;
        private const int HelathDecrease = 10;

        private const int DamageIncrease = 0;
        private const int DamageDecrease = 0;

        public Kamikaze()
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
