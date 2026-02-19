using System;
using System.Drawing;

namespace Dungeon_Crawl
{
    internal class Item
    {
        private static Random ran = new Random();
        string itemType;
        string statIncreases;
        int rarity;
        int amountIncrease;
        Point location;

        public Item(string itemType, int rarity)
        {
            if (itemType == "armor")
            {
                setType(itemType);
                statIncreases = "def";
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
            else if (itemType == "weapon")
            {
                setType(itemType);
                statIncreases = "str";
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
            else if (itemType == "staff")
            {
                setType(itemType);
                statIncreases = "magic";
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
            else if (itemType == "jewlery")
            {
                setType(itemType);
                statIncreases = "resistance";
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
            else if (itemType == "money")
            {
                setType(itemType);
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

            setLocation();
        }

        public void setRarity(int newRarity)
        {
            rarity = newRarity;
            if (rarity == 0)
            {
                amountIncrease = ran.Next(1, 3);
            }
            else if (rarity == 1)
            {
                amountIncrease = ran.Next(3, 6);
            }
            else if (rarity == 2)
            {
                amountIncrease = ran.Next(5, 9);
            }
        }
        public void setType(string newType)
        {
            itemType = newType;
        }
        public void setLocation()
        {
            location = new Point(ran.Next(50, 1436), ran.Next(50, 764));
        }
        public void setLocation(Point newLocation)
        {
            location = newLocation;
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
