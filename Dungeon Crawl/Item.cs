using System;
using System.Collections.Generic;
using System.Drawing;

namespace Dungeon_Crawl
{
    internal class Item
    {
        protected Random ran;
        protected string itemType;
        protected string statIncreases;
        protected int rarity;
        protected int amountIncrease;
        protected int healIncrease;
        protected Point location;
        protected Image image;
        public Item()
        {
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
        public void setHealIncrease(int healIncrease) { this.healIncrease = healIncrease; }

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
        public int getHealIncrease() { return this.healIncrease; }
        public int getXLoc()
        {
            return location.X;
        }
        public int getYLoc()
        {
            return location.Y;
        }
        public Image getImage()
        {
            return image;
        }
        public virtual List<Item> Open()
        {
            return new List<Item>();
        }
    }
}
