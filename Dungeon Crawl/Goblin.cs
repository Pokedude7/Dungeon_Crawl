using System.Drawing;

namespace Dungeon_Crawl
{
    internal class Goblin : Enemy
    {
        Goblin() { }
        public Goblin(double enemyLevel)
        {
            enemyType = "goblin";
            setLevel(enemyLevel);
            setMaxHealth((int)(4 * enemyLevel));
            setHealth((int)(4 * enemyLevel));
            setStrength((int)(2 * (0.5 * enemyLevel)));
            setMagic(0);
            setDefense((int)(0.5 * enemyLevel));
            setResistance(0);
            exp = ran.Next(3 * (int)enemyLevel, 6 * (int)enemyLevel + 1);
            money = ran.Next(2 * (int)enemyLevel, 7 * (int)enemyLevel + 1);

            randomItem = ran.Next(1, 3);
            if (randomItem == 1)
            {
                item = new Castle_Weapon("sword", new Point(ran.Next(50, 1436), ran.Next(50, 764)), (int)enemyLevel);
            }
            else if (randomItem == 2)
            {
                item = new Castle_Jewlery("amulet", new Point(ran.Next(50, 1436), ran.Next(50, 764)), (int)enemyLevel);
            }
        }
    }
}
