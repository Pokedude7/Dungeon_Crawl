using System.Drawing;

namespace Dungeon_Crawl
{
    internal class Ogre:Enemy
    {
        public Ogre(double enemyLevel)
        {
            enemyType = "ogre";
            setLevel(enemyLevel);
            setEnemyType(enemyType);
            setHealth((int)(15 * (0.5 * enemyLevel)));
            setMaxHealth((int)(15 * (0.5 * enemyLevel)));
            setStrength((int)(4 * (0.5 * enemyLevel)));
            setMagic(0);
            setDefense(0);
            setResistance(0);
            exp = ran.Next(8 * (int)enemyLevel, 16 * (int)enemyLevel + 1);
            money = ran.Next(8 * (int)enemyLevel, 15 * (int)enemyLevel + 1);

            item = new Castle_Weapon("sword", new Point(ran.Next(50, 1436), ran.Next(50, 764)), (int)enemyLevel);
        }
    }
}
