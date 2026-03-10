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

        //Images for the game
        //Character sprites
        Image CS = Image.FromFile("../../PlaceholderCharacter_DungeonCrawl.png");
        Image CSU = Image.FromFile("../../PlaceHolderCharacterUp_DungeonCrawl.png");
        Image CSD = Image.FromFile("../../PlaceHolderCharacterDown_DungeonCrawl.png");
        Image CSL = Image.FromFile("../../PlaceHolderCharacterLeft_DungeonCrawl.png");
        Image CSR = Image.FromFile("../../PlaceHolderCharacterRight_DungeonCrawl.png");
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
        Image wallsL = Image.FromFile("../../WallTestLSide_DungeonCrawl.png");
        Image wallsR = Image.FromFile("../../WallTestRSide_DungeonCrawl.png");
        Image skeleton = Image.FromFile("../../SkeletonTemp_DungeonCrawl.png");
        Image goblin = Image.FromFile("../../GoblinTemp_DungeonCrawl.png");
        Image ogre = Image.FromFile("../../OgreTemp_DungeonCrawl.png");
        Image titleText = Image.FromFile("../../TitleTextTemp_DungeonCrawl.png");

        //General Variables
        bool inGame = false;
        bool inventoryOpen = false;
        int pX = 730;
        int pY = 789;
        int difficulty = 1;
        char enteredFrom = 's';

        //Variables for movement
        int upDownMove = 0;
        int sideMove = 0;
        bool WHeld = false;
        bool SHeld = false;
        bool AHeld = false;
        bool DHeld = false;
        char lastHeld = 'w';

        Item[] equipedItems = new Item[5] { null, null, null, null, null };

        List<Item> itemsOnScreen = new List<Item>();

        Player pc = new Player();

        Enemy enemy;

        //Variables for encounters
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

            //Sets the location and visibility of all the buttons and labels on the screen
            MonLabel.Location = new Point(1000, 462);
            StrLabel.Location = new Point(670, 220);
            DefLabel.Location = new Point(670, 270);
            MagicLabel.Location = new Point(660, 320);
            ResLabel.Location = new Point(670, 370);
            HealthLabel.Location = new Point(640, 420);
            XPLabel.Location = new Point(640, 470);
            LevelLabel.Location = new Point(670, 520);

            startButton.Location = new Point(688, 300);
            resumeButton.Location = new Point(688, 300);
            settingsButton.Location = new Point(688, 360);
            quitButton.Location = new Point(688, 420);

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
            HealthLabel.Visible = false;
            XPLabel.Visible = false;
            LevelLabel.Visible = false;
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
                        WHeld = true;
                        lastHeld = 'w';
                        break;
                    case Keys.S:
                        upDownMove = 5;
                        SHeld = true;
                        lastHeld = 's';
                        break;
                    case Keys.A:
                        sideMove = -5;
                        AHeld = true;
                        lastHeld = 'a';
                        break;
                    case Keys.D:
                        sideMove = 5;
                        DHeld = true;
                        lastHeld = 'd';
                        break;
                    case Keys.E:
                        //Checks to see if the inventory is open or not when the E key is pressed
                        if (!inventoryOpen && !resumeButton.Visible && !inFight)
                        {
                            OpenInventory();
                        }
                        else if (inventoryOpen && !resumeButton.Visible && !inFight)
                        {
                            CloseInventory();
                        }
                        break;
                    case Keys.Q:
                        ItemCheck();
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
            //Sets the buttons to invisible and then calls the method to resume the game if the inventory wasn't open prior
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
                HealthLabel.Visible = false;
                XPLabel.Visible = false;
                LevelLabel.Visible = false;
            }
            else
            {
                inventoryOpen = true;
                StrLabel.Visible = true;
                DefLabel.Visible = true;
                MagicLabel.Visible = true;
                ResLabel.Visible = true;
                MonLabel.Visible = true;
                HealthLabel.Visible = true;
                XPLabel.Visible = true;
                LevelLabel.Visible = true;
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

        //Currently these functions do not work and will change during development of the alpha
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
            if (startButton.Visible)
            {
                //Draws the title text on the screen
                e.Graphics.DrawImage(titleText, 396, 100);
            }

            if (inGame)
            {
                PCHealthLabel.Visible = false;
                EnemyHealthLabel.Visible = false;

                //Draws the walls around the edges of the screen
                e.Graphics.DrawImage(wallsL, 0, 0);
                e.Graphics.DrawImage(wallsR, 768, 0);

                //Draws the character sprite where the player is located on the screen and facing the correct direction
                if (DHeld)
                {
                    e.Graphics.DrawImage(CSR, pX, pY);
                }
                else if (AHeld)
                {
                    e.Graphics.DrawImage(CSL, pX, pY);
                }
                else if (SHeld)
                {
                    e.Graphics.DrawImage(CSD, pX, pY);
                }
                else if (WHeld)
                {
                    e.Graphics.DrawImage(CSU, pX, pY);
                }
                else if (lastHeld == 'd')
                {
                    e.Graphics.DrawImage(CSR, pX, pY);
                }
                else if (lastHeld == 'a')
                {
                    e.Graphics.DrawImage(CSL, pX, pY);
                }
                else if (lastHeld == 's')
                {
                    e.Graphics.DrawImage(CSD, pX, pY);
                }
                else if (lastHeld == 'w')
                {
                    e.Graphics.DrawImage(CSU, pX, pY);
                }

                //Draws the various items on the screen from the itemsOnScreen list in their respective locations
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
                //Draws the fight screen and the text of the health labels
                PCHealthLabel.Text = "PC Health: " + pc.getHealth() + "/" + pc.getMaxHealth();
                EnemyHealthLabel.Text = "Enemy Health: " + enemy.getHealth() + "/" + enemy.getMaxHealth();
                PCHealthLabel.Location = new Point(50, 200);
                e.Graphics.DrawImage(CS, 55, 215);
                EnemyHealthLabel.Location = new Point(50, 300);
                if (enemy.getEnemyType() == "skeleton")
                {
                    e.Graphics.DrawImage(skeleton, 50, 315);
                }
                else if (enemy.getEnemyType() == "goblin")
                {
                    e.Graphics.DrawImage(goblin, 50, 315);
                }
                else if (enemy.getEnemyType() == "ogre")
                {
                    e.Graphics.DrawImage(ogre, 50, 315);
                }

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

            //Allows the player to enter the next room through the north corridor if they didn't enter through it
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

            //Allows the player to enter the next room through the south corridor if they didn't enter through it
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

            //Allows the player to enter the next room through the west corridor if they didn't enter through it
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

            //Allows the player to enter the next room through the east corridor if they didn't enter through it
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
                    WHeld = false;
                    break;
                case Keys.S:
                    upDownMove = 0;
                    SHeld = false;
                    break;
                case Keys.A:
                    sideMove = 0;
                    AHeld = false;
                    break;
                case Keys.D:
                    sideMove = 0;
                    DHeld = false;
                    break;
            }
        }
        private void OpenInventory()
        {
            //Sets the lables inside the inventory to the correct information, displays the labels and opens the inventory
            inGame = false;
            StrLabel.Text = "Str: " + pc.getStrength();
            DefLabel.Text = "Def: " + pc.getDefense();
            MagicLabel.Text = "Magic: " + pc.getMagic();
            ResLabel.Text = "Res: " + pc.getResistance();
            MonLabel.Text = Convert.ToString(pc.getMoney());
            HealthLabel.Text = "HP " + pc.getHealth() + "/" + pc.getMaxHealth();
            XPLabel.Text = "XP " + pc.getXP() + "/" + (20 * pc.getLevel());
            LevelLabel.Text = "Lv. " + pc.getLevel();
            inventoryOpen = true;
            StrLabel.Visible = true;
            DefLabel.Visible = true;
            MagicLabel.Visible = true;
            ResLabel.Visible = true;
            MonLabel.Visible = true;
            HealthLabel.Visible = true;
            XPLabel.Visible = true;
            LevelLabel.Visible = true;
        }
        private void CloseInventory()
        {
            //Hides the labels in the inventory and then closes the inventory and returns to the game
            inGame = true;
            inventoryOpen = false;
            StrLabel.Visible = false;
            DefLabel.Visible = false;
            MagicLabel.Visible = false;
            ResLabel.Visible = false;
            MonLabel.Visible = false;
            HealthLabel.Visible = false;
            XPLabel.Visible = false;
            LevelLabel.Visible = false;
        }
        private void SpawnItems()
        {
            //Spawns items at the start of new rooms for the player to pick up and adds them to the itemsOnScreen list
            bool spawnItem = false;
            int itemSpawned = 0;
            int amountOfItems = difficulty;

            itemsOnScreen.Clear();

            if (amountOfItems > 4)
            {
                amountOfItems = 4;
            }

            for (int i = 0; i < amountOfItems; i++)
            {
                if (ran.Next(1, 3) == 1)
                {
                    spawnItem = true;
                }

                spawnItem = true;

                if (spawnItem)
                {
                    itemSpawned = ran.Next(1, 6);

                    if (itemSpawned == 1)
                    {
                        itemsOnScreen.Add(new Castle_Armor("plate", new Point(ran.Next(50, 1436), ran.Next(50, 764)), ran.Next(difficulty - 1, difficulty + 1)));
                    }
                    else if (itemSpawned == 2)
                    {
                        itemsOnScreen.Add(new Castle_Weapon("sword", new Point(ran.Next(50, 1436), ran.Next(50, 764)), ran.Next(difficulty - 1, difficulty + 1)));
                    }
                    else if (itemSpawned == 3)
                    {
                        itemsOnScreen.Add(new Castle_Staff("novice", new Point(ran.Next(50, 1436), ran.Next(50, 764)), ran.Next(difficulty - 1, difficulty + 1)));
                    }
                    else if (itemSpawned == 4)
                    {
                        itemsOnScreen.Add(new Castle_Jewlery("amulet", new Point(ran.Next(50, 1436), ran.Next(50, 764)), ran.Next(difficulty - 1, difficulty + 1)));
                    }
                    else if (itemSpawned == 5)
                    {
                        itemsOnScreen.Add(new Money(ran.Next(difficulty - 1, difficulty + 1), new Point(ran.Next(50, 1436), ran.Next(50, 764))));
                    }
                }
            }
        }
        private void ItemCheck()
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
            //Sets the players stats based on the stats of the items they have equiped
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
                        pc.setArmorAdd(equipedItems[i].getAmount());
                    }
                    else if (i == 1)
                    {
                        pc.setWeaponAdd(equipedItems[i].getAmount());
                    }
                    else if (i == 2)
                    {
                        pc.setStaffAdd(equipedItems[i].getAmount());
                    }
                    else if (i == 3)
                    {
                        pc.setJewleryAdd(equipedItems[i].getAmount());
                    }
                }
            }
        }
        private void compareItems(Item equiped, Item onGround)
        {
            //Compares the stats of the item on the ground to the item equiped and shows a message box dependant on if the item is better or not
            string message = null;
            DialogResult result;

            Cursor.Position = new Point(768, 300);
            Cursor.Show();
            inGame = false;
            upDownMove = 0;
            sideMove = 0;
            if (equiped.getType() == "armor")
            {
                message = "Do you want to equip this item?\nCurrent: +" + equipedItems[0].getAmount() + " --> New: +" + onGround.getAmount() + "\nWARNING: THIS CANNOT BE UNDON. ANY ITEM NOT EQUIPED WILL BE LOST FOREVER";
                result = MessageBox.Show(message, null, MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    equipedItems[0] = onGround;
                    itemsOnScreen.Remove(onGround);
                    setStats();
                    inGame = true;
                    Invalidate();
                }
                else
                {
                    itemsOnScreen.Remove(onGround);
                    setStats();
                    inGame = true;
                    Invalidate();
                }
            }
            else if (equiped.getType() == "weapon")
            {
                message = "Do you want to equip this item?\nCurrent: +" + equipedItems[1].getAmount() + " --> New: +" + onGround.getAmount() + "\nWARNING: THIS CANNOT BE UNDON. ANY ITEM NOT EQUIPED WILL BE LOST FOREVER";
                result = MessageBox.Show(message, null, MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    equipedItems[1] = onGround;
                    itemsOnScreen.Remove(onGround);
                    setStats();
                    inGame = true;
                    Invalidate();
                }
                else
                {
                    itemsOnScreen.Remove(onGround);
                    setStats();
                    inGame = true;
                    Invalidate();
                }
            }
            else if (equiped.getType() == "staff")
            {
                message = "Do you want to equip this item?\nCurrent: +" + equipedItems[2].getAmount() + " --> New: +" + onGround.getAmount() + "\nWARNING: THIS CANNOT BE UNDON. ANY ITEM NOT EQUIPED WILL BE LOST FOREVER";
                result = MessageBox.Show(message, null, MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    equipedItems[2] = onGround;
                    itemsOnScreen.Remove(onGround);
                    setStats();
                    inGame = true;
                    Invalidate();
                }
                else
                {
                    itemsOnScreen.Remove(onGround);
                    setStats();
                    inGame = true;
                    Invalidate();
                }
            }
            else if (equiped.getType() == "jewlery")
            {
                message = "Do you want to equip this item?\nCurrent: +" + equipedItems[3].getAmount() + " --> New: +" + onGround.getAmount() + "\nWARNING: THIS CANNOT BE UNDON. ANY ITEM NOT EQUIPED WILL BE LOST FOREVER";
                result = MessageBox.Show(message, null, MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    equipedItems[3] = onGround;
                    itemsOnScreen.Remove(onGround);
                    setStats();
                    inGame = true;
                    Invalidate();
                }
                else
                {
                    itemsOnScreen.Remove(onGround);
                    setStats();
                    inGame = true;
                    Invalidate();
                }
            }

            Cursor.Hide();
        }
        private void EnterRoom()
        {
            //Sets the players position to the right spot in the new room based on which direction they entered from
            //Then spawns the items in the room and sets the number of encounters in the room
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
            //Spawns an encounter if there are encounters left in the room
            //Then, it randomly decides which enemy to spawn and starts the fight
            int encounterChance = ran.Next(1, 50);
            int enemySpawn = ran.Next(1, 4);
            if (encountersInRoom != 0 && encounterChance == 1)
            {
                if (enemySpawn == 1)
                {
                    if (pc.getLevel() == 1)
                    {
                        enemy = new Skeleton(pc.getLevel());
                    }
                    else
                    {
                        enemy = new Skeleton(ran.Next((int)pc.getLevel() - 1, (int)pc.getLevel() + 1));
                    }

                    StartFight();
                }
                else if (enemySpawn == 2)
                {
                    if (pc.getLevel() == 1)
                    {
                        enemy = new Goblin(pc.getLevel());
                    }
                    else
                    {
                        enemy = new Goblin(ran.Next((int)pc.getLevel() - 1, (int)pc.getLevel() + 1));
                    }

                    StartFight();
                }
                else if (enemySpawn == 3)
                {
                    if (pc.getLevel() == 1)
                    {
                        enemy = new Ogre(pc.getLevel());
                    }
                    else
                    {
                        enemy = new Ogre(ran.Next((int)pc.getLevel() - 1, (int)pc.getLevel() + 1));
                    }

                    StartFight();
                }
            }
        }
        private void StartFight()
        {
            //Starts a fight by setting the correct variables, making the player buttons visible and starts the first turn
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
            //Sets the player buttons to be visible or hidden based on if the player is in a fight or not and shows or hides the cursor based on that as well
            if (inFight)
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
            //Calculates the damage the enemy does to the player based on the enemies strength and the players defense
            //Then applies that damage to the player
            if ((enemy.getStrength() - pc.getDefense()) <= 0)
            {
                pc.TakeDamage(1);
            }
            else
            {
                pc.TakeDamage(enemy.getStrength() - pc.getDefense());
            }

            whoseturn = 1;
            TakeTurn();
        }
        private void attackButton_Click(object sender, EventArgs e)
        {
            //Calculates the damage the player does to the enemy based on the players strength and the enemys defense
            if (((int)pc.getStrength() - enemy.getDefense()) <= 0)
            {
                enemy.TakeDamage(1);
            }
            else
            {
                enemy.TakeDamage((int)pc.getStrength() - enemy.getDefense());
            }
            turnOver = true;
            whoseturn = 2;
            TakeTurn();
        }
        private void magicButton_Click(object sender, EventArgs e)
        {
            //Calculates the damage the player does to the enemy based on the players magic and the enemys resistance
            enemy.TakeDamage((int)pc.getMagic() - (1 / 2 * enemy.getResistance()));
            if (((int)pc.getMagic() - enemy.getResistance()) <= 0)
            {
                enemy.TakeDamage(1);
            }
            else
            {
                enemy.TakeDamage((int)pc.getMagic() - (1 / 2 * enemy.getResistance()));
            }
            turnOver = true;
            whoseturn = 2;
            TakeTurn();
        }
        private void runButton_Click(object sender, EventArgs e)
        {
            //Calculates the chance the player has to run away based on the players level and the enemys level.
            //If the player is higher level than the enemy they automatically get away.
            //If not, they have a chance to get away based on how much lower level they are than the enemy.
            if (pc.getLevel() > enemy.getLevel())
            {
                inFight = false;
                turnOver = true;
                inGame = true;
                PlayerButtonsVisible();
            }
            else
            {
                int n = (int)enemy.getLevel() - (int)pc.getLevel();

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
            //Shuts off the different timers based on if the player is currently in the game or not
            if (!inGame)
            {
                Movement.Enabled = false;
            }
            else
            {
                Movement.Enabled = true;
            }
        }
        private void TakeTurn()
        {
            //Sets the health labels and checks to see whos turn it is
            //If its the enemys turn it runs the EnemyTurn function
            //Then it checks if either the player or the enemy has died. If so, it ends the fight and give the player the rewards if thye won
            if (whoseturn == 2)
            {
                turnOver = true;
            }

            PCHealthLabel.Text = "PC Health: " + pc.getHealth() + "/" + pc.getMaxHealth();
            EnemyHealthLabel.Text = "Enemy Health: " + enemy.getHealth() + "/" + enemy.getMaxHealth();

            if (whoseturn == 2 && inFight && turnOver && pc.getHealth() > 0 && enemy.getHealth() > 0)
            {
                EnemyTurn();
            }
            else if (pc.getHealth() <= 0)
            {
                inGame = false;
                MessageBox.Show("You have died. Game Over.");
                this.Close();
            }
            else if (enemy.getHealth() <= 0)
            {
                if (ran.Next(1, 4) == 1)
                {
                    MessageBox.Show("You won! You gained " + enemy.getXP() + " exp and $" + enemy.getMoney() + "\nYou also find a " + enemy.getItem().getType() + " on its corpse.");
                    pc.addExp(enemy.getXP());
                    pc.addMoney(enemy.getMoney());
                    enemy.getItem().setLocation(new Point(pX, pY));
                    itemsOnScreen.Add(enemy.getItem());
                    ItemCheck();
                }
                else
                {
                    MessageBox.Show("You won! You gained " + enemy.getXP() + " exp and $" + enemy.getMoney());
                    pc.addExp(enemy.getXP());
                    pc.addMoney(enemy.getMoney());
                }

                inFight = false;
                inGame = true;
                turnOver = true;
                PlayerButtonsVisible();
                pc.checkLevelUp();
            }

            if (!inFight)
            {
                difficulty = (int)pc.getLevel();
            }
        }
    }
}
