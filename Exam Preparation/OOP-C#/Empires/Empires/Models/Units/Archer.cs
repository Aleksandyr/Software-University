namespace Empires.Models.Units
{
    public class Archer : Unit
    {
        private const int ArcherAttackDamage = 25;
        private const int ArcherHealth = 7;

        public Archer()
            : base(ArcherAttackDamage, ArcherHealth)
        {
        }
    }
}
