using System;
using System.Collections.Generic;
using System.Drawing;

namespace Dungeon_Crawl
{
    internal class Chest : Item
    {
        public List<Item> chestContents = new List<Item>();
        public bool IsOpen { get; set; }
        int num = 0;
        bool anotherItem = true;

        public Chest(int dificulty, Point location)
        {
            ran = new Random();
            itemType = "chest";
            this.location = location;
            IsOpen = false;
            image = Image.FromFile("../../Image/Items/Chest_DungeonCrawl.png");

            num = ran.Next(0, 4);

            if (num + dificulty < 3)
            {
                rarity = 0;
            }
            else if (num + dificulty < 5)
            {
                rarity = 1;
            }
            else if (num + dificulty < 7)
            {
                rarity = 2;
            }
            else
            {
                rarity = 3;
            }

            FillChest(location.X, location.Y);
        }

        public void FillChest(int pX, int pY)
        {
            chestContents.Add(new Money(rarity, new Point(pX - 50, pY)));

            if (rarity == 0)
            {
                num = ran.Next(0, 4);

                if (num == 0)
                {
                    chestContents.Add(new Castle_Armor("plate", new Point(pX, pY - 50), rarity));
                }
                else if (num == 1)
                {
                    chestContents.Add(new Castle_Weapon("sword", new Point(pX, pY - 50), rarity));
                }
                else if (num == 2)
                {
                    chestContents.Add(new Castle_Staff("novice", new Point(pX, pY - 50), rarity));
                }
                else if (num == 3)
                {
                    chestContents.Add(new Castle_Jewlery("amulet", new Point(pX, pY - 50), rarity));
                }
            }
            else if (rarity == 1)
            {
                while (anotherItem)
                {
                    num = ran.Next(0, 4);

                    if (num == 0)
                    {
                        if (chestContents.Count == 2)
                        {
                            chestContents.Add(new Castle_Armor("plate", new Point(pX + 50, pY), rarity));
                        }
                        else
                        {
                            chestContents.Add(new Castle_Armor("plate", new Point(pX, pY - 50), rarity));
                        }

                    }
                    else if (num == 1)
                    {
                        if (chestContents.Count == 2)
                        {
                            chestContents.Add(new Castle_Weapon("sword", new Point(pX + 50, pY), rarity));
                        }
                        else
                        {
                            chestContents.Add(new Castle_Weapon("sword", new Point(pX, pY - 50), rarity));
                        }
                    }
                    else if (num == 2)
                    {
                        if (chestContents.Count == 2)
                        {
                            chestContents.Add(new Castle_Staff("novice", new Point(pX + 50, pY), rarity));
                        }
                        else
                        {
                            chestContents.Add(new Castle_Staff("novice", new Point(pX, pY - 50), rarity));
                        }
                    }
                    else if (num == 3)
                    {
                        if (chestContents.Count == 2)
                        {
                            chestContents.Add(new Castle_Jewlery("amulet", new Point(pX + 50, pY), rarity));
                        }
                        else
                        {
                            chestContents.Add(new Castle_Jewlery("amulet", new Point(pX, pY - 50), rarity));
                        }
                    }

                    if (chestContents.Count < 3)
                    {
                        num = ran.Next(0, 4);

                        if (num == 0)
                        {
                            anotherItem = true;
                        }
                        else
                        {
                            anotherItem = false;
                        }
                    }
                    else
                    {
                        anotherItem = false;
                    }

                }
            }
            else if (rarity == 2)
            {
                while (anotherItem)
                {
                    num = ran.Next(0, 4);

                    if (num == 0)
                    {
                        if (chestContents.Count == 2)
                        {
                            chestContents.Add(new Castle_Armor("plate", new Point(pX + 50, pY), rarity));
                        }
                        else if (chestContents.Count == 3)
                        {
                            chestContents.Add(new Castle_Armor("plate", new Point(pX, pY + 50), rarity));
                        }
                        else
                        {
                            chestContents.Add(new Castle_Armor("plate", new Point(pX, pY - 50), rarity));
                        }
                    }
                    else if (num == 1)
                    {
                        if (chestContents.Count == 2)
                        {
                            chestContents.Add(new Castle_Weapon("sword", new Point(pX + 50, pY), rarity));
                        }
                        else if (chestContents.Count == 3)
                        {
                            chestContents.Add(new Castle_Weapon("sword", new Point(pX, pY + 50), rarity));
                        }
                        else
                        {
                            chestContents.Add(new Castle_Weapon("sword", new Point(pX, pY - 50), rarity));
                        }
                    }
                    else if (num == 2)
                    {
                        if (chestContents.Count == 2)
                        {
                            chestContents.Add(new Castle_Staff("novice", new Point(pX + 50, pY), rarity));
                        }
                        else if (chestContents.Count == 3)
                        {
                            chestContents.Add(new Castle_Staff("novice", new Point(pX, pY + 50), rarity));
                        }
                        else
                        {
                            chestContents.Add(new Castle_Staff("novice", new Point(pX, pY - 50), rarity));
                        }
                    }
                    else if (num == 3)
                    {
                        if (chestContents.Count == 2)
                        {
                            chestContents.Add(new Castle_Jewlery("amulet", new Point(pX + 50, pY), rarity));
                        }
                        else if (chestContents.Count == 3)
                        {
                            chestContents.Add(new Castle_Jewlery("amulet", new Point(pX, pY + 50), rarity));
                        }
                        else
                        {
                            chestContents.Add(new Castle_Jewlery("amulet", new Point(pX, pY - 50), rarity));
                        }
                    }

                    if (chestContents.Count < 3)
                    {
                        anotherItem = true;
                    }
                    else if (chestContents.Count < 4)
                    {
                        num = ran.Next(0, 4);

                        if (num == 0)
                        {
                            anotherItem = true;
                        }
                        else
                        {
                            anotherItem = false;
                        }
                    }
                    else
                    {
                        anotherItem = false;
                    }
                }
            }
            else if (rarity == 3)
            {
                num = ran.Next(0, 4);

                if (num == 0)
                {
                    if (chestContents.Count == 2)
                    {
                        chestContents.Add(new Castle_Armor("plate", new Point(pX + 50, pY), rarity));
                    }
                    else if (chestContents.Count == 3)
                    {
                        chestContents.Add(new Castle_Armor("plate", new Point(pX, pY + 50), rarity));
                    }
                    else
                    {
                        chestContents.Add(new Castle_Armor("plate", new Point(pX, pY - 50), rarity));
                    }
                }
                else if (num == 1)
                {
                    if (chestContents.Count == 2)
                    {
                        chestContents.Add(new Castle_Weapon("sword", new Point(pX + 50, pY), rarity));
                    }
                    else if (chestContents.Count == 3)
                    {
                        chestContents.Add(new Castle_Weapon("sword", new Point(pX, pY + 50), rarity));
                    }
                    else
                    {
                        chestContents.Add(new Castle_Weapon("sword", new Point(pX, pY - 50), rarity));
                    }
                }
                else if (num == 2)
                {
                    if (chestContents.Count == 2)
                    {
                        chestContents.Add(new Castle_Staff("novice", new Point(pX + 50, pY), rarity));
                    }
                    else if (chestContents.Count == 3)
                    {
                        chestContents.Add(new Castle_Staff("novice", new Point(pX, pY + 50), rarity));
                    }
                    else
                    {
                        chestContents.Add(new Castle_Staff("novice", new Point(pX, pY - 50), rarity));
                    }
                }
                else if (num == 3)
                {
                    if (chestContents.Count == 2)
                    {
                        chestContents.Add(new Castle_Jewlery("amulet", new Point(pX + 50, pY), rarity));
                    }
                    else if (chestContents.Count == 3)
                    {
                        chestContents.Add(new Castle_Jewlery("amulet", new Point(pX, pY + 50), rarity));
                    }
                    else
                    {
                        chestContents.Add(new Castle_Jewlery("amulet", new Point(pX, pY - 50), rarity));
                    }
                }

                if (chestContents.Count < 4)
                {
                    anotherItem = true;
                }
                else
                {
                    anotherItem = false;
                }
            }
        }
        public override List<Item> Open()
        {
            if (!IsOpen)
            {
                IsOpen = true;
                image = Image.FromFile("../../Image/Items/ChestOpen_DungeonCrawl.png");
                return chestContents;
            }
            else
            {
                return new List<Item>();
            }
        }
    }
}