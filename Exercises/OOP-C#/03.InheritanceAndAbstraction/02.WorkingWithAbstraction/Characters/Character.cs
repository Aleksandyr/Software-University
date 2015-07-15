using Attack;
using System;

namespace CharacterInfo
{
    public abstract class Character : IAttack
    {
        private int health;
        private int mana;
        private int damage;
        protected Character(int health, int mana, int damage)
        {
            this.Health = health;
            this.Mana = mana;
            this.Damage = damage;
        }

        public int Health 
        { 
            get
            {
                return this.health;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("Health can not be negative")
                }

                this.health = value;
            }
        }

        public int Mana
        {
            get
            {
                return this.mana;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("Health can not be negative")
                }

                this.mana = value;
            }
        }

        public int Damage
        {
            get
            {
                return this.damage;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentOutOfRangeException("Health can not be negative")
                }

                this.damage = value;
            }
        }

        public abstract void Attack(Character target);
    }
}
