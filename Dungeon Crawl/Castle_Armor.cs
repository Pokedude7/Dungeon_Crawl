using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawl
{
    internal class Castle_Armor:Armor
    {
        public Castle_Armor(string armorType, int rarity)
        {
            this.armorType = armorType;
            if (armorType == "plate")
            {
                image = Image.FromFile("../../ArmorTemp_DungeonCrawl.png");
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
        }
    }
}
