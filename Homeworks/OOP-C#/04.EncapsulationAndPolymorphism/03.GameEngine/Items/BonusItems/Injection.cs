using TheSlum;
namespace _03.GameEngine.Items.BonusItems
{
    class Injection : Bonus
    {
        public Injection(string id, int healthEffect = 200, int defenseEffect = 0, int attackEffect = 0)
            : base(id, healthEffect, defenseEffect, attackEffect)
        {
            this.Timeout = 3;
            this.Countdown = 3;
            this.HasTimedOut = false;
        }
    }
}
