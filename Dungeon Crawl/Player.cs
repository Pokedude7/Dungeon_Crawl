using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawl
{
    internal class Player
    {
        double strength;
        double defense;
        double magic;
        double resistance;
        double health;
        double maxHealth;
        double money;

        public Player()
        {
            strength = 0;
            defense = 0;
            magic = 0;
            resistance = 0;
            health = 10;
            maxHealth = 10;
            money = 0;
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
        }
        public void setMaxHealth(double maxHealth)
        {
            this.maxHealth = maxHealth;
        }
        public void setMoney(double money)
        {
            this.money = money;
        }

        public double getStrength()
        {
            return strength;
        }
        public double getDefense()
        {
            return defense;
        }
        public double getMagic()
        {
            return magic;
        }
        public double getResistance()
        {
            return resistance;
        }
        public double getHealth()
        {
            return health;
        }
        public double getMaxHealth()
        {
            return maxHealth;
        }
        public double getMoney()
        {
            return money;
        }

    }
}
