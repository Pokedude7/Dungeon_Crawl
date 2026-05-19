using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawl
{
    internal class Money:Item
    {
        public Money(int rarity, Point point)
        {
            ran = new Random();
            itemType = "money";
            statIncreases = "mon";
            image = Image.FromFile("../../Image/Items/Money_DungeonCrawl.png");
            if (rarity == 0)
            {
                amountIncrease = ran.Next(1, 5);
            }
            else if (rarity == 1)
            {
                amountIncrease = ran.Next(5, 10);
            }
            else if (rarity == 2)
            {
                amountIncrease = ran.Next(10, 20);
            }

            setLocation(point);
        }
    }
}
