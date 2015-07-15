using Battleships.Interfaces;

namespace Battleships.Ships
{
    public abstract class BattleShip : Ship, IAttack
    {

        protected BattleShip(string name, double lengthInMeters, double volume)
            : base(name, lengthInMeters, volume)
        {
        }

        public abstract string Attack(Ship target);

        public void DestroyShip(Ship target)
        {
            target.IsDestroyed = true;
        }
    }
}
