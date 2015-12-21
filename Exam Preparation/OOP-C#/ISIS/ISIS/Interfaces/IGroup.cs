namespace ISIS.Interfaces
{
    public interface IGroup : IUpdateable
    {
        int Health { get; set; }

        int Damage { get; set; }

        IAttackType AttackType { get; }

        IWarEffect WarEffect { get; }

        bool IsAlive { get; }
    }
}
