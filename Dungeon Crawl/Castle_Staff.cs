using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawl
{
    internal class Castle_Staff:Staff
    {
        public Castle_Staff(string staffType, Point point, int rarity)
        {
            ran = new Random();
            this.staffType = staffType;
            if (staffType == "novice")
            {
                image = Image.FromFile("../../Image/Items/Staff_DungeonCrawl.png");
            }

            if (rarity <= 2)
            {
                amountIncrease = 1;
            }
            else if (rarity <= 5)
            {
                amountIncrease = 2;
            }
            else if (rarity <= 8)
            {
                amountIncrease = ran.Next(3, 5);
            }

            setLocation(point);
        }
    }
}
