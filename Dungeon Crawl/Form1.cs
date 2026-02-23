using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Dungeon_Crawl
{
    public partial class Form1 : Form
    {
        Random ran = new Random();
        char moveUp = 'W';
        char moveDown = 'S';
        char moveLeft = 'A';
        char moveRight = 'D';
        string reopenMenu = null;
        //Character sprite image
        Image CS = Image.FromFile("../../PlaceholderCharacter_DungeonCrawl.png");
        //Inventory square sprite
        Image ISq = Image.FromFile("../../InventorySquareTemp_DungeonCrawl.png");
        //Inventory screen sprite
        Image ISc = Image.FromFile("../../InventoryScreenTemp_DungeonCrawl.png");
        //Item sprites
        Image armor = Image.FromFile("../../ArmorTemp_DungeonCrawl.png");
        Image weapon = Image.FromFile("../../WeaponTemp_DungeonCrawl.png");
        Image staff = Image.FromFile("../../StaffTemp_DungeonCrawl.png");
        Image jewlery = Image.FromFile("../../JewleryTemp_DungeonCrawl.png");
        Image money = Image.FromFile("../../MoneyTemp_DungeonCrawl.png");
        bool inGame = false;
        bool inventoryOpen = false;
        int pX = 100;
        int pY = 100;
        int difficulty = 1;
        char enteredFrom = 's';

        int upDownMove = 0;
        int sideMove = 0;

        Item[] equipedItems = new Item[5] { null, null, null, null, null };

        List<Item> itemsOnScreen = new List<Item>();

        Player pc = new Player();

        Enemy enemy;

        int encountersInRoom = 0;
        bool inFight = false;
        bool turnOver = false;
        int whoseturn = 0;

        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            Console.WriteLine("Screen Size: " + Screen.PrimaryScreen.Bounds.Width + "," + Screen.PrimaryScreen.Bounds.Height);
            MonLabel.Location = new Point(1000, 462);
            StrLabel.Location = new Point(670, 220);
            DefLabel.Location = new Point(670, 270);
            MagicLabel.Location = new Point(660, 320);
            ResLabel.Location = new Point(670, 370);
            attackButton.Visible = false;
            magicButton.Visible = false;
            runButton.Visible = false;
        }
        private void startButton_Click(object sender, EventArgs e)
        {
            //Sets the buttons to invisible and then calls the method to start the game
            startButton.Visible = false;
            settingsButton.Visible = false;
            quitButton.Visible = false;
            inGame = true;

            StartGame();
        }
        private void StartGame()
        {
            Cursor.Hide();
            SpawnItems();
            Invalidate();
        }
        private void OpenPauseMenu()
        {
            //Sets the buttons to visible and then opens the pause menu
            Cursor.Position = new Point(768, 300);
            Cursor.Show();
            inGame = false;
            Movement.Enabled = false;
            resumeButton.Visible = true;
            settingsButton.Visible = true;
            quitButton.Visible = true;
            StrLabel.Visible = false;
            DefLabel.Visible = false;
            MagicLabel.Visible = false;
            ResLabel.Visible = false;
            MonLabel.Visible = false;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!quitButton.Visible)
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        OpenPauseMenu();
                        break;
                    case Keys.W:
                        upDownMove = -5;
                        break;
                    case Keys.S:
                        upDownMove = 5;
                        break;
                    case Keys.A:
                        sideMove = -5;
                        break;
                    case Keys.D:
                        sideMove = 5;
                        break;
                    case Keys.E:
                        //Checks to see if the inventory is open or not when the E key is pressed
                        if (!inventoryOpen && !resumeButton.Visible)
                        {
                            OpenInventory();
                        }
                        else if (inventoryOpen && !resumeButton.Visible)
                        {
                            CloseInventory();
                        }
                        break;
                }
            }
            Invalidate();
        }
        private void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void resumeButton_Click(object sender, EventArgs e)
        {
            //Sets the buttons to invisible and then calls the method to resume the game
            Cursor.Hide();
            if (!inventoryOpen)
            {
                inGame = true;
                inventoryOpen = false;
                StrLabel.Visible = false;
                DefLabel.Visible = false;
                MagicLabel.Visible = false;
                ResLabel.Visible = false;
                MonLabel.Visible = false;
            }
            else
            {
                inventoryOpen = true;
                StrLabel.Visible = true;
                DefLabel.Visible = true;
                MagicLabel.Visible = true;
                ResLabel.Visible = true;
                MonLabel.Visible = true;
            }
            Movement.Enabled = true;
            quitButton.Visible = false;
            settingsButton.Visible = false;
            resumeButton.Visible = false;
            Invalidate();
        }
        private void settingsButton_Click(object sender, EventArgs e)
        {
            //Sets the settings menu and close button to visible and then sets the correct buttons to invisible based on which menu was open before settings
            SettingsMenu.Visible = true;
            CloseButton.Visible = true;
            if (startButton.Visible == true)
            {
                startButton.Visible = false;
                quitButton.Visible = false;
                settingsButton.Visible = false;
                reopenMenu = "start";
            }
            else if (resumeButton.Visible == true)
            {
                resumeButton.Visible = false;
                quitButton.Visible = false;
                settingsButton.Visible = false;
                reopenMenu = "pause";
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            moveUp = textBox1.Text[0];
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            moveDown = textBox2.Text[0];
        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            moveRight = textBox3.Text[0];
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            moveLeft = textBox4.Text[0];
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            //Sets the buttons and menus to invisible and then sets the correct buttons to visible based on which menu was open before settings
            CloseButton.Visible = false;
            SettingsMenu.Visible = false;
            if (reopenMenu == "start")
            {
                startButton.Visible = true;
                quitButton.Visible = true;
                settingsButton.Visible = true;
            }
            else if (reopenMenu == "pause")
            {
                resumeButton.Visible = true;
                quitButton.Visible = true;
                settingsButton.Visible = true;
            }
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (inGame)
            {
                PCHealthLabel.Visible = false;
                EnemyHealthLabel.Visible = false;

                //Draws the character sprite where the player is located on the screen
                e.Graphics.DrawImage(CS, pX, pY);

                for (int i = 0; i < itemsOnScreen.Count; i++)
                {
                    if (itemsOnScreen[i].getType() == "armor")
                    {
                        e.Graphics.DrawImage(armor, itemsOnScreen[i].getXLoc(), itemsOnScreen[i].getYLoc());
                    }
                    else if (itemsOnScreen[i].getType() == "weapon")
                    {
                        e.Graphics.DrawImage(weapon, itemsOnScreen[i].getXLoc(), itemsOnScreen[i].getYLoc());
                    }
                    else if (itemsOnScreen[i].getType() == "staff")
                    {
                        e.Graphics.DrawImage(staff, itemsOnScreen[i].getXLoc(), itemsOnScreen[i].getYLoc());
                    }
                    else if (itemsOnScreen[i].getType() == "jewlery")
                    {
                        e.Graphics.DrawImage(jewlery, itemsOnScreen[i].getXLoc(), itemsOnScreen[i].getYLoc());
                    }
                    else if (itemsOnScreen[i].getType() == "money")
                    {
                        e.Graphics.DrawImage(money, itemsOnScreen[i].getXLoc(), itemsOnScreen[i].getYLoc());
                    }
                }

            }
            else if (inventoryOpen && !resumeButton.Visible)
            {
                //Draws the inventory screen
                e.Graphics.DrawImage(ISq, 800, 200);
                e.Graphics.DrawImage(ISq, 800, 325);
                e.Graphics.DrawImage(ISq, 800, 450);
                e.Graphics.DrawImage(ISq, 925, 262);
                e.Graphics.DrawImage(ISq, 925, 387);
                e.Graphics.DrawImage(ISc, 625, 200);

                if (equipedItems[0] != null)
                {
                    e.Graphics.DrawImage(armor, 825, 225);
                }

                if (equipedItems[1] != null)
                {
                    e.Graphics.DrawImage(weapon, 825, 350);
                }

                if (equipedItems[2] != null)
                {
                    e.Graphics.DrawImage(staff, 825, 475);
                }

                if (equipedItems[3] != null)
                {
                    e.Graphics.DrawImage(jewlery, 950, 287);
                }

                e.Graphics.DrawImage(money, 950, 412);
            }
            else if (inFight)
            {
                PCHealthLabel.Text = "PC Health: " + pc.getHealth() + "/" + pc.getMaxHealth();
                EnemyHealthLabel.Text = "Enemy Health: " + enemy.getHealth() + "/" + enemy.getMaxHealth();
                PCHealthLabel.Visible = true;
                EnemyHealthLabel.Visible = true;
            }
        }
        private void Movement_Tick(object sender, EventArgs e)
        {
            //Constantly updates the players position relative to if they are moving or not
            pY += upDownMove;

            //Checks to see if the player is trying to move through the top wall and if they are it sets their position to be right next to the wall instead of going through it
            if (pY <= 50 && pY >= 45 && (pX <= 668 || pX >= 793))
            {
                pY = 50;
            }

            //Checks to see if the player is trying to move through the bottom wall and if they are it sets their position to be right next to the wall instead of going through it
            if (pY >= 739 && pY <= 744 && (pX <= 668 || pX >= 793))
            {
                pY = 739;
            }

            //Checks to see if the player is trying to move through the left wall in the top corridor and if they are it sets their position to be right next to the wall instead of going through it
            if (pX <= 45 && pY <= 332)
            {
                pY = 332;
            }

            //Checks to see if the player is trying to move through the right wall in the top corridor and if they are it sets their position to be right next to the wall instead of going through it
            if (pX <= 45 && pY >= 457)
            {
                pY = 457;
            }
            //Checks to see if the player is trying to move through the left wall in the bottom corridor and if they are it sets their position to be right next to the wall instead of going through it
            if (pX >= 1416 && pY <= 332)
            {
                pY = 332;
            }

            //Checks to see if the player is trying to move through the right wall in the bottom corridor and if they are it sets their position to be right next to the wall instead of going through it
            if (pX >= 1416 && pY >= 457)
            {
                pY = 457;
            }

            //Checks to see if the player is trying to move off screen and if they are it sets their position to be right next to the edge of the screen instead of going through it
            if (pY < 0 && enteredFrom != 'n')
            {
                enteredFrom = 's';
                EnterRoom();
            }
            else if (pY < 0)
            {
                pY = 0;
                upDownMove = 0;
            }

            if (pY > 789 && enteredFrom != 's')
            {
                enteredFrom = 'n';
                EnterRoom();
            }
            else if (pY > 789)
            {
                pY = 789;
                upDownMove = 0;
            }

            pX += sideMove;

            //Checks to see if the player is trying to move through the left wall and if they are it sets their position to be right next to the wall instead of going through it
            if (pX <= 50 && pX >= 45 && (pY <= 332 || pY >= 457))
            {
                pX = 50;
            }

            //Checks to see if the player is trying to move through the right wall and if they are it sets their position to be right next to the wall instead of going through it
            if (pX >= 1411 && pX <= 1416 && (pY <= 332 || pY >= 457))
            {
                pX = 1411;
            }

            //Checks to see if the player is trying to move through the top wall in the right corridor and if they are it sets their position to be right next to the wall instead of going through it
            if (pY <= 45 && pX <= 668)
            {
                pX = 668;
            }

            //Checks to see if the player is trying to move through the bottom wall in the right corridor and if they are it sets their position to be right next to the wall instead of going through it
            if (pY <= 45 && pX >= 793)
            {
                pX = 793;
            }

            //Checks to see if the player is trying to move through the top wall in the left corridor and if they are it sets their position to be right next to the wall instead of going through it
            if (pY >= 744 && pX <= 668)
            {
                pX = 668;
            }

            //Checks to see if the player is trying to move through the bottom wall in the left corridor and if they are it sets their position to be right next to the wall instead of going through it
            if (pY >= 744 && pX >= 793)
            {
                pX = 793;
            }

            //Checks to see if the player is trying to move off screen and if they are it sets their position to be right next to the edge of the screen instead of going through it
            if (pX < 0 && enteredFrom != 'w')
            {
                enteredFrom = 'e';
                EnterRoom();
            }
            else if (pX < 0)
            {
                pX = 0;
                sideMove = 0;
            }

            if (pX > 1461 && enteredFrom != 'e')
            {
                enteredFrom = 'w';
                EnterRoom();
            }
            else if (pX > 1461)
            {
                pX = 1461;
                sideMove = 0;
            }

            if (sideMove != 0 || upDownMove != 0)
            {
                SpawnEncounter();
            }

            Invalidate();
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    upDownMove = 0;
                    break;
                case Keys.S:
                    upDownMove = 0;
                    break;
                case Keys.A:
                    sideMove = 0;
                    break;
                case Keys.D:
                    sideMove = 0;
                    break;
            }
        }
        private void OpenInventory()
        {
            inGame = false;
            StrLabel.Text = "Str: " + pc.getStrength();
            DefLabel.Text = "Def: " + pc.getDefense();
            MagicLabel.Text = "Magic: " + pc.getMagic();
            ResLabel.Text = "Res: " + pc.getResistance();
            MonLabel.Text = Convert.ToString(pc.getMoney());
            inventoryOpen = true;
            StrLabel.Visible = true;
            DefLabel.Visible = true;
            MagicLabel.Visible = true;
            ResLabel.Visible = true;
            MonLabel.Visible = true;

        }
        private void CloseInventory()
        {
            inGame = true;
            inventoryOpen = false;
            StrLabel.Visible = false;
            DefLabel.Visible = false;
            MagicLabel.Visible = false;
            ResLabel.Visible = false;
            MonLabel.Visible = false;
        }
        private void SpawnItems()
        {
            //Spawns items at the start of new rooms for the player to pick up and adds them to the itemsOnScreen list
            bool spawnItem = false;
            int itemSpawned = 0;

            itemsOnScreen.Clear();

            for (int i = 0; i < difficulty; i++)
            {
                if (ran.Next(1, 3) == 2)
                {
                    spawnItem = true;
                }

                if (spawnItem)
                {
                    itemSpawned = ran.Next(1, 6);

                    if (itemSpawned == 1)
                    {
                        itemsOnScreen.Add(new Item("armor", ran.Next(difficulty - 1, difficulty + 1)));
                    }
                    else if (itemSpawned == 2)
                    {
                        itemsOnScreen.Add(new Item("weapon", ran.Next(difficulty - 1, difficulty + 1)));
                    }
                    else if (itemSpawned == 3)
                    {
                        itemsOnScreen.Add(new Item("staff", ran.Next(difficulty - 1, difficulty + 1)));
                    }
                    else if (itemSpawned == 4)
                    {
                        itemsOnScreen.Add(new Item("jewlery", ran.Next(difficulty - 1, difficulty + 1)));
                    }
                    else if (itemSpawned == 5)
                    {
                        itemsOnScreen.Add(new Item("money", ran.Next(difficulty - 1, difficulty + 1)));
                    }
                }
            }
        }
        private void ItemCheck_Tick(object sender, EventArgs e)
        {
            for (int i = 0; i < itemsOnScreen.Count; i++)
            {
                if (pX + 75 >= itemsOnScreen[i].getXLoc() && pX < itemsOnScreen[i].getXLoc() + 50 && pY + 75 > itemsOnScreen[i].getYLoc() && pY < itemsOnScreen[i].getYLoc() + 50)
                {
                    if (itemsOnScreen[i].getType() == "armor" && equipedItems[0] == null)
                    {
                        equipedItems[0] = itemsOnScreen[i];
                        itemsOnScreen.RemoveAt(i);
                        setStats();
                    }
                    else if (itemsOnScreen[i].getType() == "weapon" && equipedItems[1] == null)
                    {
                        equipedItems[1] = itemsOnScreen[i];
                        itemsOnScreen.RemoveAt(i);
                        setStats();
                    }
                    else if (itemsOnScreen[i].getType() == "staff" && equipedItems[2] == null)
                    {
                        equipedItems[2] = itemsOnScreen[i];
                        itemsOnScreen.RemoveAt(i);
                        setStats();
                    }
                    else if (itemsOnScreen[i].getType() == "jewlery" && equipedItems[3] == null)
                    {
                        equipedItems[3] = itemsOnScreen[i];
                        itemsOnScreen.RemoveAt(i);
                        setStats();
                    }
                    else if (itemsOnScreen[i].getType() == "money")
                    {
                        pc.addMoney(itemsOnScreen[i].getAmount());
                        itemsOnScreen.RemoveAt(i);
                        setStats();
                    }
                    else if (itemsOnScreen[i].getType() == "armor" && equipedItems[0] != null)
                    {
                        compareItems(equipedItems[0], itemsOnScreen[i]);
                    }
                    else if (itemsOnScreen[i].getType() == "weapon" && equipedItems[1] != null)
                    {
                        compareItems(equipedItems[1], itemsOnScreen[i]);
                    }
                    else if (itemsOnScreen[i].getType() == "staff" && equipedItems[2] != null)
                    {
                        compareItems(equipedItems[2], itemsOnScreen[i]);
                    }
                    else if (itemsOnScreen[i].getType() == "jewlery" && equipedItems[3] != null)
                    {
                        compareItems(equipedItems[3], itemsOnScreen[i]);
                    }

                    Invalidate();
                }
            }
        }
        private void setStats()
        {
            for (int i = 0; i < equipedItems.Length; i++)
            {
                if (equipedItems[i] == null)
                {
                    continue;
                }
                else
                {
                    if (i == 0)
                    {
                        pc.setDefense(equipedItems[i].getAmount());
                    }
                    else if (i == 1)
                    {
                        pc.setStrength(equipedItems[i].getAmount());
                    }
                    else if (i == 2)
                    {
                        pc.setMagic(equipedItems[i].getAmount());
                    }
                    else if (i == 3)
                    {
                        pc.setResistance(equipedItems[i].getAmount());
                    }
                }
            }
        }
        private void compareItems(Item equiped, Item onGround)
        {
            string message = null;
            DialogResult result;

            Cursor.Position = new Point(768, 300);
            Cursor.Show();
            inGame = false;
            upDownMove = 0;
            sideMove = 0;
            ItemCheck.Enabled = false;
            if (equiped.getType() == "armor")
            {
                if (equiped.getAmount() < onGround.getAmount())
                {
                    message = "Do you want to equip this item? It has better stats than your current item. \nWARNING: THIS CANNOT BE UNDON. ANY ITEM NOT EQUIPED WILL BE LOST FOREVER";
                    result = MessageBox.Show(message, null, MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        equipedItems[0] = onGround;
                        itemsOnScreen.Remove(onGround);
                        setStats();
                        inGame = true;
                        ItemCheck.Enabled = true;
                        Invalidate();
                    }
                    else if (result == DialogResult.No)
                    {
                        itemsOnScreen.Remove(onGround);
                        setStats();
                        inGame = true;
                        ItemCheck.Enabled = true;
                        Invalidate();
                    }
                }
                else if (equiped.getAmount() >= onGround.getAmount())
                {
                    message = "Do you want to equip this item? It has the same or worse stats than your current item. \nWARNING: THIS CANNOT BE UNDON. ANY ITEM NOT EQUIPED WILL BE LOST FOREVER";
                    result = MessageBox.Show(message, null, MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        equipedItems[0] = onGround;
                        itemsOnScreen.Remove(onGround);
                        setStats();
                        inGame = true;
                        ItemCheck.Enabled = true;
                        Invalidate();
                    }
                    else if (result == DialogResult.No)
                    {
                        itemsOnScreen.Remove(onGround);
                        setStats();
                        inGame = true;
                        ItemCheck.Enabled = true;
                        Invalidate();
                    }
                }
            }
            else if (equiped.getType() == "weapon")
            {
                if (equiped.getAmount() < onGround.getAmount())
                {
                    message = "Do you want to equip this item? It has better stats than your current item. \nWARNING: THIS CANNOT BE UNDON. ANY ITEM NOT EQUIPED WILL BE LOST FOREVER";
                    result = MessageBox.Show(message, null, MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        equipedItems[1] = onGround;
                        itemsOnScreen.Remove(onGround);
                        setStats();
                        inGame = true;
                        ItemCheck.Enabled = true;
                        Invalidate();
                    }
                    else if (result == DialogResult.No)
                    {
                        itemsOnScreen.Remove(onGround);
                        setStats();
                        inGame = true;
                        ItemCheck.Enabled = true;
                        Invalidate();
                    }
                }
                else if (equiped.getAmount() >= onGround.getAmount())
                {
                    message = "Do you want to equip this item? It has the same or worse stats than your current item. \nWARNING: THIS CANNOT BE UNDON. ANY ITEM NOT EQUIPED WILL BE LOST FOREVER";
                    result = MessageBox.Show(message, null, MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        equipedItems[1] = onGround;
                        itemsOnScreen.Remove(onGround);
                        setStats();
                        inGame = true;
                        ItemCheck.Enabled = true;
                        Invalidate();
                    }
                    else if (result == DialogResult.No)
                    {
                        itemsOnScreen.Remove(onGround);
                        setStats();
                        inGame = true;
                        ItemCheck.Enabled = true;
                        Invalidate();
                    }
                }
            }
            else if (equiped.getType() == "staff")
            {
                if (equiped.getAmount() < onGround.getAmount())
                {
                    message = "Do you want to equip this item? It has better stats than your current item. \nWARNING: THIS CANNOT BE UNDON. ANY ITEM NOT EQUIPED WILL BE LOST FOREVER";
                    result = MessageBox.Show(message, null, MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        equipedItems[1] = onGround;
                        itemsOnScreen.Remove(onGround);
                        setStats();
                        inGame = true;
                        ItemCheck.Enabled = true;
                        Invalidate();
                    }
                    else if (result == DialogResult.No)
                    {
                        itemsOnScreen.Remove(onGround);
                        setStats();
                        inGame = true;
                        ItemCheck.Enabled = true;
                        Invalidate();
                    }
                }
                else if (equiped.getAmount() >= onGround.getAmount())
                {
                    message = "Do you want to equip this item? It has the same or worse stats than your current item. \nWARNING: THIS CANNOT BE UNDON. ANY ITEM NOT EQUIPED WILL BE LOST FOREVER";
                    result = MessageBox.Show(message, null, MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        equipedItems[1] = onGround;
                        itemsOnScreen.Remove(onGround);
                        setStats();
                        inGame = true;
                        ItemCheck.Enabled = true;
                        Invalidate();
                    }
                    else if (result == DialogResult.No)
                    {
                        itemsOnScreen.Remove(onGround);
                        setStats();
                        inGame = true;
                        ItemCheck.Enabled = true;
                        Invalidate();
                    }
                }
            }
            else if (equiped.getType() == "jewlery")
            {
                if (equiped.getAmount() < onGround.getAmount())
                {
                    message = "Do you want to equip this item? It has better stats than your current item. \nWARNING: THIS CANNOT BE UNDON. ANY ITEM NOT EQUIPED WILL BE LOST FOREVER";
                    result = MessageBox.Show(message, null, MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        equipedItems[1] = onGround;
                        itemsOnScreen.Remove(onGround);
                        setStats();
                        inGame = true;
                        ItemCheck.Enabled = true;
                        Invalidate();
                    }
                    else if (result == DialogResult.No)
                    {
                        itemsOnScreen.Remove(onGround);
                        setStats();
                        inGame = true;
                        ItemCheck.Enabled = true;
                        Invalidate();
                    }
                }
                else if (equiped.getAmount() >= onGround.getAmount())
                {
                    message = "Do you want to equip this item? It has the same or worse stats than your current item. \nWARNING: THIS CANNOT BE UNDON. ANY ITEM NOT EQUIPED WILL BE LOST FOREVER";
                    result = MessageBox.Show(message, null, MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        equipedItems[1] = onGround;
                        itemsOnScreen.Remove(onGround);
                        setStats();
                        inGame = true;
                        ItemCheck.Enabled = true;
                        Invalidate();
                    }
                    else if (result == DialogResult.No)
                    {
                        itemsOnScreen.Remove(onGround);
                        setStats();
                        inGame = true;
                        ItemCheck.Enabled = true;
                        Invalidate();
                    }
                }
            }

            Cursor.Hide();
        }
        private void EnterRoom()
        {
            if (enteredFrom == 'n')
            {
                pY = 50;
            }
            else if (enteredFrom == 's')
            {
                pY = 739;
            }
            else if (enteredFrom == 'e')
            {
                pX = 1411;
            }
            else if (enteredFrom == 'w')
            {
                pX = 50;
            }
            SpawnItems();
            encountersInRoom = ran.Next(1, difficulty + 2);
        }
        private void SpawnEncounter()
        {
            int encounterChance = ran.Next(1, 50);
            int enemySpawn = 1;//ran.Next(1, 4);
            if (encountersInRoom != 0 && encounterChance == 1)
            {
                if (enemySpawn == 1)
                {
                    enemy = new Enemy("skeleton", ran.Next(difficulty, difficulty + 2));
                    StartFight();
                }
            }
        }
        private void StartFight()
        {
            inFight = true;
            whoseturn = ran.Next(1, 3);
            turnOver = false;
            encountersInRoom--;

            PlayerButtonsVisible();
            TakeTurn();
            Invalidate();
        }
        private void PlayerButtonsVisible()
        {
            if (!turnOver)
            {
                inGame = false;
                attackButton.Visible = true;
                magicButton.Visible = true;
                runButton.Visible = true;

                Cursor.Show();
            }
            else
            {
                attackButton.Visible = false;
                magicButton.Visible = false;
                runButton.Visible = false;

                Cursor.Hide();
            }
        }
        private void EnemyTurn()
        {
            if (enemy.getEnemyType() == "skeleton")
            {
                if (enemy.getStr() - (1 / 2 * pc.getDefense()) <= 0)
                {
                    pc.TakeDamage(1);
                }
                else
                {
                    pc.TakeDamage((int)(enemy.getStr() - (1 / 2 * pc.getDefense())));
                }
            }

            whoseturn = 1;
            TakeTurn();
        }
        private void attackButton_Click(object sender, EventArgs e)
        {
            if (pc.getStrength() - (1 / 2 * enemy.getDef()) <= 0)
            {
                enemy.TakeDamage(1);
            }
            else
            {
                enemy.TakeDamage((int)pc.getStrength() - (1 / 2 * enemy.getDef()));
            }
            turnOver = true;
            whoseturn = 2;
            TakeTurn();
        }
        private void magicButton_Click(object sender, EventArgs e)
        {
            enemy.TakeDamage((int)pc.getMagic() - (1 / 2 * enemy.getRes()));
            turnOver = true;
            whoseturn = 2;
            TakeTurn();
        }
        private void runButton_Click(object sender, EventArgs e)
        {
            if (pc.getLevel() > enemy.getLevel())
            {
                inFight = false;
                turnOver = true;
                PlayerButtonsVisible();
            }
            else
            {
                int n = enemy.getLevel() - pc.getLevel();

                if (ran.Next(1, n + 3) == 1)
                {
                    inFight = false;
                    turnOver = true;
                    inGame = true;
                    PlayerButtonsVisible();
                }
                else
                {
                    MessageBox.Show("You failed to run away");
                    turnOver = true;
                    whoseturn = 2;
                }
            }

            TakeTurn();
        }
        private void ShutOff_Tick(object sender, EventArgs e)
        {
            if (!inGame)
            {
                Movement.Enabled = false;
                ItemCheck.Enabled = false;
            }
            else
            {
                Movement.Enabled = true;
                ItemCheck.Enabled = true;
            }
        }
        private void TakeTurn()
        {
            if (whoseturn == 2)
            {
                turnOver = true;
            }

            PCHealthLabel.Text = "PC Health: " + pc.getHealth() + "/" + pc.getMaxHealth();
            EnemyHealthLabel.Text = "Enemy Health: " + enemy.getHealth() + "/" + enemy.getMaxHealth();

            if (whoseturn == 2 && inFight && turnOver && pc.getHealth() > 0 && enemy.getHealth() > 0)
            {
                EnemyTurn();
                whoseturn = 1;
            }
            else if (pc.getHealth() <= 0)
            {
                MessageBox.Show("You have died. Game Over.");
                this.Close();
            }
            else if (enemy.getHealth() <= 0)
            {
                MessageBox.Show("You won! You gained " + enemy.getXPReward() + " exp and $" + enemy.getMonReward());
                pc.addExp(enemy.getXPReward());
                pc.addMoney(enemy.getMonReward());
                inFight = false;
                inGame = true;
                turnOver = true;
                PlayerButtonsVisible();
            }
        }
    }
}
