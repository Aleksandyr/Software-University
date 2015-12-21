namespace ISIS.Interfaces
{
    public interface IAttackTypeFactory
    {
        IAttackType CreateAttackType(string attackType, int attackDamage, int health);
    }
}
