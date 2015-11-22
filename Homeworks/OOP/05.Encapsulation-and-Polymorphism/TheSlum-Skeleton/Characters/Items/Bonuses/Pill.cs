namespace TheSlum.Characters.Items.Bonuses
{
    public class Pill : Bonus
    {
        public Pill(string id, int healthEffect, int defenseEffect, int attackEffect)
            : base(id, healthEffect, defenseEffect, attackEffect)
        {
            this.Countdown = 1;
        }
    }
}
