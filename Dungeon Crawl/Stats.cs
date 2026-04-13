using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawl
{
    internal class Stats
    {
        protected double strength;
        protected double defense;
        protected double magic;
        protected double resistance;
        protected double health;
        protected double maxHealth;
        protected double money;
        protected double level;
        protected double exp;

        public Stats()
        {

        }

        public virtual double getStrength()
        {
            return strength;
        }
        public virtual double getDefense()
        {
            return defense;
        }
        public virtual double getMagic()
        {
            return magic;
        }
        public virtual double getResistance()
        {
            return resistance;
        }
        public virtual double getHealth()
        {
            return health;
        }
        public virtual double getMaxHealth()
        {
            return maxHealth;
        }
        public virtual double getMoney()
        {
            return money;
        }
        public virtual double getLevel()
        {
            return level;
        }
        public virtual double getXP()
        {
            return exp;
        }

        public void setStrength(double strength)
        {
            this.strength = strength;
        }
        public void setDefense(double defense)
        {
            this.defense = defense;
        }
        public void setMagic(double magic)
        {
            this.magic = magic;
        }
        public void setResistance(double resistance)
        {
            this.resistance = resistance;
        }
        public void setHealth(double health)
        {
            this.health = health;
            if (this.health > maxHealth)
            {
                this.health = maxHealth;
            }
        }
        public void setMaxHealth(double maxHealth)
        {
            this.maxHealth = maxHealth;
        }
        public void setMoney(double money)
        {
            this.money = money;
        }

        public void TakeDamage(double damage)
        {
            health -= damage;
        }
    }
}
