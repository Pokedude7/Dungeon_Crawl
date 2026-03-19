using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawl
{
    internal class Castle_Weapon:Weapon
    {
        public Castle_Weapon(string weaponType, Point point, int rarity)
        {
            ran = new Random();
            this.weaponType = weaponType;
            if(weaponType == "sword")
            {
                image = Image.FromFile("../../Image/Items/WeaponTemp_DungeonCrawl.png");
            }

            if (rarity == 0)
            {
                amountIncrease = ran.Next(1, 2);
            }
            else if (rarity == 1)
            {
                amountIncrease = ran.Next(2, 3);
            }
            else if (rarity == 2)
            {
                amountIncrease = ran.Next(3, 6);
            }

            setLocation(point);
        }
    }
}
