using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawl
{
    internal class Enemy
    {
        Random ran = new Random();
        int health;
        int strength;
        int magic;
        int defense;
        int resistance;
        int maxHealth;
        string enemyType;
        int enemyLevel;
        int expReward;
        int moneyReward;
        Item item;

        public Enemy(string enemyType, int enemyLevel)
        {
            int randomItem = ran.Next(1, 4);
            if (enemyType == "skeleton")
            {
                health = 10 * (1/2 * enemyLevel);
                maxHealth = health;
                strength = 2 * (1/2 * enemyLevel);
                magic = 0;
                defense = 1 * (1/2 * enemyLevel);
                resistance = 1 * (1/2 * enemyLevel);
                expReward = ran.Next(5 * enemyLevel, 10 * enemyLevel + 1);
                moneyReward = ran.Next(1 * enemyLevel, 5 * enemyLevel + 1);
                if (randomItem == 1)
                {
                    item = new Item("weapon", ran.Next(enemyLevel - 1, enemyLevel + 1));
                }
                else if (randomItem == 2)
                {
                    item = new Item("armor", ran.Next(enemyLevel - 1, enemyLevel + 1));
                }
                else if (randomItem == 3)
                {
                    item = new Item("jewlery", ran.Next(enemyLevel - 1, enemyLevel + 1));
                }
            }
        }

        public int GetHealth()
        {
            return health;
        }
        public int GetStr()
        {
            return strength;
        }
        public int GetDef()
        {
            return defense;
        }
        public int GetMagic()
        {
            return magic;
        }
        public int GetRes()
        {
            return resistance;
        }
        public int GetMaxHealth()
        {
            return maxHealth;
        }
        public string GetEnemyType()
        {
            return enemyType;
        }
        public int GetLevel()
        {
            return enemyLevel;
        }
        public int GetXPReward()
        {
            return expReward;
        }
        public int GetMonReward()
        {
            return moneyReward;
        }
        public Item GetItem()
        {
            return item;
        }

        public void SetHelth(int health)
        {
            this.health = health;
        }
        public void SetStr(int strength)
        {
            this.strength = strength;
        }
        public void SetDef(int defense)
        {
            this.defense = defense;
        }
        public void SetMagic(int magic)
        {
            this.magic = magic;
        }
        public void SetRes(int resistance)
        {
            this.resistance = resistance;
        }
        public void SetMaxHealth(int maxHealth)
        {
            this.maxHealth = maxHealth;
        }
    }
}
