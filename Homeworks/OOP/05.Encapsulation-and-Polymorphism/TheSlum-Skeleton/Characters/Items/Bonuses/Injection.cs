namespace TheSlum.Characters.Items.Bonuses
{
    public class Injection : Bonus
    {
        public Injection(string id, int healthEffect, int defenseEffect, int attackEffect)
            : base(id, healthEffect, defenseEffect, attackEffect)
        {
            this.Countdown = 3;
        }
    }
}
