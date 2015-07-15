using TheSlum;

namespace _03.GameEngine.Items
{
    public class Pill : Bonus
    {
        public Pill(string id, int healthEffect = 0, int defenseEffect = 0, int attackEffect = 100)
            : base(id, healthEffect, defenseEffect, attackEffect)
        {
            this.Timeout = 1;
            this.Countdown = 1;
            this.HasTimedOut = false;
        }


    }
}
