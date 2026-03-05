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
        public Castle_Staff(string staffType, int rarity)
        {
            this.staffType = staffType;
            if (staffType == "novice")
            {
                image = Image.FromFile("../../StaffTemp_DungeonCrawl.png");
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
