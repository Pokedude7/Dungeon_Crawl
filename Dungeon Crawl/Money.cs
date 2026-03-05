using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawl
{
    internal class Money:Item
    {
        public Money(int rarity)
        {
            itemType = "money";
            statIncreases = "mon";
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
        }
    }
}
