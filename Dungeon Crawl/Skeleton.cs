using System.Drawing;

namespace Dungeon_Crawl
{
    internal class Skeleton : Enemy
    {
        public Skeleton() { }
        public Skeleton(double enemyLevel)
        {
            enemyType = "skeleton";
            setLevel(enemyLevel);
            setMaxHealth((int)(10 * (0.5 * enemyLevel)));
            setHealth((int)(10 * (0.5 * enemyLevel)));
            setStrength((int)(2 * (0.5 * enemyLevel)));
            setMagic(0);
            setDefense((int)(1 * (0.5 * enemyLevel)));
            setResistance((int)(1 * (0.5 * enemyLevel)));
            exp = ran.Next(5 * (int)enemyLevel, 10 * (int)enemyLevel + 1);
            money = ran.Next(1 * (int)enemyLevel, 5 * (int)enemyLevel + 1);

            randomItem = ran.Next(1, 4);
            if (randomItem == 1)
            {
                item = new Castle_Weapon("sword", new Point(ran.Next(50, 1436), ran.Next(50, 764)), (int)enemyLevel);
            }
            else if (randomItem == 2)
            {
                item = new Castle_Armor("plate", new Point(ran.Next(50, 1436), ran.Next(50, 764)), (int)enemyLevel);
            }
            else if (randomItem == 3)
            {
                item = new Castle_Jewlery("amulet", new Point(ran.Next(50, 1436), ran.Next(50, 764)), (int)enemyLevel);
            }
        }
    }
}
