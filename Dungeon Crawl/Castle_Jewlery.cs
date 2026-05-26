using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawl
{
    internal class Castle_Jewlery:Jewlery
    {
        public Castle_Jewlery(string jewleryType, Point point, int rarity)
        {
            ran = new Random();
            this.jewleryType = jewleryType;
            if (jewleryType == "amulet")
            {
                image = Image.FromFile("../../Image/Items/Jewlery_DungeonCrawl.png");
            }

            if (rarity <= 2)
            {
                amountIncrease = ran.Next(1, 2);
                healIncrease = ran.Next(1, 2);
            }
            else if (rarity <= 5)
            {
                amountIncrease = ran.Next(2, 3);
                healIncrease = ran.Next(2, 3);
            }
            else if (rarity <= 8)
            {
                amountIncrease = ran.Next(3, 6);
                healIncrease = ran.Next(3, 6);
            }

            setLocation(point);
        }
    }
}
