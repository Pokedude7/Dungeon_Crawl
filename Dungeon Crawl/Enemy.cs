using System;

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
            int randomItem;
            if (enemyType == "skeleton")
            {
                setLevel(enemyLevel);
                setEnemyType(enemyType);
                setHealth((int)(10 * (0.5 * enemyLevel)));
                setMaxHealth((int)(10 * (0.5 * enemyLevel)));
                setStr((int)(2 * (0.5 * enemyLevel)));
                setMagic(0);
                setDef((int)(1 * (0.5 * enemyLevel)));
                setRes((int)(1 * (0.5 * enemyLevel)));
                expReward = ran.Next(5 * enemyLevel, 10 * enemyLevel + 1);
                moneyReward = ran.Next(1 * enemyLevel, 5 * enemyLevel + 1);

                randomItem = ran.Next(1, 4);
                if (randomItem == 1)
                {
                    item = new Castle_Weapon("sword", enemyLevel);
                }
                else if (randomItem == 2)
                {
                    item = new Castle_Armor("plate", enemyLevel);
                }
                else if (randomItem == 3)
                {
                    item = new Castle_Jewlery("amulet", enemyLevel);
                }
            }
            else if (enemyType == "goblin")
            {
                setLevel(enemyLevel);
                setEnemyType(enemyType);
                setHealth((int)(5 * (0.5 * enemyLevel)));
                setMaxHealth((int)(5 * (0.5 * enemyLevel)));
                setStr((int)(2 * (0.5 * enemyLevel)));
                setMagic(0);
                setDef((int)(1 * (0.5 * enemyLevel)));
                setRes(0);
                expReward = ran.Next(2 * enemyLevel, 6 * enemyLevel + 1);
                moneyReward = ran.Next(2 * enemyLevel, 7 * enemyLevel + 1);

                randomItem = ran.Next(1, 3);
                if (randomItem == 1)
                {
                    item = new Castle_Weapon("sword", enemyLevel);
                }
                else if (randomItem == 2)
                {
                    item = new Castle_Jewlery("amulet", enemyLevel);
                }
            }
            else if (enemyType == "ogre")
            {
                setLevel(enemyLevel);
                setEnemyType(enemyType);
                setHealth((int)(15 * (0.5 * enemyLevel)));
                setMaxHealth((int)(15 * (0.5 * enemyLevel)));
                setStr((int)(4 * (0.5 * enemyLevel)));
                setMagic(0);
                setDef(0);
                setRes(0);
                expReward = ran.Next(8 * enemyLevel, 16 * enemyLevel + 1);
                moneyReward = ran.Next(8 * enemyLevel, 15 * enemyLevel + 1);

                item = new Castle_Weapon("sword", enemyLevel);
            }
        }

        public int getHealth()
        {
            return health;
        }
        public int getStr()
        {
            return strength;
        }
        public int getDef()
        {
            return defense;
        }
        public int getMagic()
        {
            return magic;
        }
        public int getRes()
        {
            return resistance;
        }
        public int getMaxHealth()
        {
            return maxHealth;
        }
        public string getEnemyType()
        {
            return enemyType;
        }
        public int getLevel()
        {
            return enemyLevel;
        }
        public int getXPReward()
        {
            return expReward;
        }
        public int getMonReward()
        {
            return moneyReward;
        }
        public Item getItem()
        {
            return item;
        }

        public void setEnemyType(string enemyType)
        {
            this.enemyType = enemyType;
        }
        public void setHealth(int health)
        {
            this.health = health;
        }
        public void setStr(int strength)
        {
            this.strength = strength;
        }
        public void setDef(int defense)
        {
            this.defense = defense;
        }
        public void setMagic(int magic)
        {
            this.magic = magic;
        }
        public void setRes(int resistance)
        {
            this.resistance = resistance;
        }
        public void setMaxHealth(int maxHealth)
        {
            this.maxHealth = maxHealth;
        }
        public void setLevel(int enemyLevel)
        {
            this.enemyLevel = enemyLevel;
        }

        public void TakeDamage(int damage)
        {
            health -= damage;
        }
    }
}
