using System.Collections.Generic;
using System.Linq;
using TheSlum;
using TheSlum.Interfaces;

namespace _03.GameEngine.Characters
{
    internal class Healer : Character, IHeal
    {
        private int healingPoints = 60;

        public Healer(string id, int x, int y, int healthPoints, int healingPoints, int defensePoints, Team team, int range)
            : base(id, x, y, healthPoints, defensePoints, team, range)
        {
            this.HealingPoints = healthPoints;
        }

        public int HealingPoints
        {
            get
            {
                return this.healingPoints;
            }
            set
            {
                this.healingPoints = value;
                
            }
        }

        public override Character GetTarget(IEnumerable<Character> targetsList)
        {
            var targetSortedByHealPoints = targetsList.OrderBy(t => t.HealthPoints);

            return targetSortedByHealPoints.ToList()[0];
        }

        public override void AddToInventory(Item item)
        {
            this.Inventory.Add(item);
            ApplyItemEffects(item);
        }

        public override void RemoveFromInventory(Item item)
        {
            this.Inventory.Remove(item);
            RemoveFromInventory(item);
        }

        public override string ToString()
        {
            string baseStr = base.ToString();
            return baseStr + string.Format(", Healing: {0}", this.HealingPoints);
        }
    }
}
