using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dungeon_Crawl
{
    internal class Item
    {
        Random ran = new Random();
        string itemType = null;
        string statIncreases = null;
        int rarity = 0;
        int amountIncrease = 0;
        Point location;

        public Item(string itemType, int rarity)
        {
            if (itemType == "armor")
            {
                statIncreases = "def";
                if (rarity == 0)
                {
                    amountIncrease = ran.Next(1, 2);
                }
                else if (rarity == 1)
                {
                    amountIncrease = ran.Next(2, 5);
                }
                else if (rarity == 2)
                {
                    amountIncrease = ran.Next(5, 8);
                }
            }
            else if (itemType == "weapon")
            {
                statIncreases = "str";
                if (rarity == 0)
                {
                    amountIncrease = ran.Next(1, 2);
                }
                else if (rarity == 1)
                {
                    amountIncrease = ran.Next(2, 5);
                }
                else if (rarity == 2)
                {
                    amountIncrease = ran.Next(5, 8);
                }
            }
            else if (itemType == "staff")
            {
                statIncreases = "magic";
                if (rarity == 0)
                {
                    amountIncrease = ran.Next(1, 2);
                }
                else if (rarity == 1)
                {
                    amountIncrease = ran.Next(2, 5);
                }
                else if (rarity == 2)
                {
                    amountIncrease = ran.Next(5, 8);
                }
            }
            else if (itemType == "jewlery")
            {
                statIncreases = "resistance";
                if (rarity == 0)
                {
                    amountIncrease = ran.Next(1, 2);
                }
                else if (rarity == 1)
                {
                    amountIncrease = ran.Next(2, 5);
                }
                else if (rarity == 2)
                {
                    amountIncrease = ran.Next(5, 8);
                }
            }
            else if (itemType == "money")
            {
                statIncreases = "mon";
                statIncreases = "resistance";
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

                location = new Point(ran.Next(50, 1300), ran.Next(50, 1000));
        }

        public void setRarity(int newRarity)
        {
            rarity = newRarity;
            if (rarity == 0)
            {
                amountIncrease = ran.Next(1, 2);
            }
            else if (rarity == 1)
            {
                amountIncrease = ran.Next(2, 5);
            }
            else if (rarity == 2)
            {
                amountIncrease = ran.Next(5, 8);
            }
        }
        public string getStat()
        {
            return statIncreases;
        }
        public int getAmount()
        {
            return amountIncrease; 
        }
        public int getRarity()
        {
            return rarity; 
        }
        public string getType()
        {
            return itemType;
        }
        public int getXLoc()
        {
            return location.X;
        }
        public int getYLoc()
        {
            return location.Y;
        }
    }
}
