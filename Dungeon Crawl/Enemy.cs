using System;

namespace Dungeon_Crawl
{
    internal class Enemy:Stats
    {
        protected Random ran = new Random();
        protected string enemyType;
        protected int randomItem;
        protected Item item;

        public Enemy() { }

        public string getEnemyType()
        {
            return enemyType;
        }
        public Item getItem()
        {
            return item;
        }

        public void setEnemyType(string enemyType)
        {
            this.enemyType = enemyType;
        }
        public void setLevel(double enemyLevel)
        {
            this.level = enemyLevel;
        }
    }
}
