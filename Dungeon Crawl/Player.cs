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
        double weaponAdd;
        double defense;
        double armorAdd;
        double magic;
        double staffAdd;
        double resistance;
        double jewleryAdd;
        double health;
        double maxHealth;
        double money;
        int level;
        int exp;

        public Player()
        {
            strength = 0;
            defense = 0;
            magic = 0;
            resistance = 0;
            health = 10;
            maxHealth = 10;
            money = 0;
            level = 1;
            exp = 0;
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
        public void setArmorAdd(double armorAdd)
        {
            this.armorAdd = armorAdd;
        }
        public void setWeaponAdd(double weaponAdd)
        {
            this.weaponAdd = weaponAdd;
        }
        public void setStaffAdd(double staffAdd)
        {
            this.staffAdd = staffAdd;
        }
        public void setJewleryAdd(double jewleryAdd)
        {
            this.jewleryAdd = jewleryAdd;
        }

        public double getStrength()
        {
            return strength + weaponAdd;
        }
        public double getDefense()
        {
            return defense + armorAdd;
        }
        public double getMagic()
        {
            return magic + staffAdd;
        }
        public double getResistance()
        {
            return resistance + jewleryAdd;
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
        public int getLevel()
        {
            return level;
        }

        public void addMoney(int money)
        {
            this.money += money;
        }
        public void addExp(int exp)
        {
            this.exp += exp;
            if (exp >= 30 * level)
            {
                levelUp();
            }
        }
        public void levelUp()
        {
            exp -= 10 * level;
            maxHealth += 5 * level;
            health = maxHealth;
            strength += 2 * level;
            defense += 1 * level;
            magic += 1 * level;
            level++;
        }
        public void TakeDamage(double damage)
        {
            health -= damage;
        }
        public void checkLevelUp()
        {
            if (exp >= 10 * level)
            {
                levelUp();
            }
        }
    }
}
