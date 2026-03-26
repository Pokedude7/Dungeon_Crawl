using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Dungeon_Crawl
{
    public partial class Form1 : Form
    {
        Random ran = new Random();
        string reopenMenu = null;

        //Images for the game
        //Character sprites
        readonly Image CS = Image.FromFile("../../Image/Character/PlaceholderCharacter_DungeonCrawl.png");
        readonly Image CSU = Image.FromFile("../../Image/Character/PlaceHolderCharacterUp_DungeonCrawl.png");
        readonly Image CSD = Image.FromFile("../../Image/Character/PlaceHolderCharacterDown_DungeonCrawl.png");
        readonly Image CSL = Image.FromFile("../../Image/Character/PlaceHolderCharacterLeft_DungeonCrawl.png");
        readonly Image CSR = Image.FromFile("../../Image/Character/PlaceHolderCharacterRight_DungeonCrawl.png");
        //Inventory square sprite
        readonly Image ISq = Image.FromFile("../../Image/Inventory/InventorySquareTemp_DungeonCrawl.png");
        //Inventory screen sprite
        readonly Image ISc = Image.FromFile("../../Image/Inventory/InventoryScreenTemp_DungeonCrawl.png");
        //Item sprites
        readonly Image armor = Image.FromFile("../../Image/Items/ArmorTemp_DungeonCrawl.png");
        readonly Image weapon = Image.FromFile("../../Image/Items/WeaponTemp_DungeonCrawl.png");
        readonly Image staff = Image.FromFile("../../Image/Items/StaffTemp_DungeonCrawl.png");
        readonly Image jewlery = Image.FromFile("../../Image/Items/JewleryTemp_DungeonCrawl.png");
        readonly Image money = Image.FromFile("../../Image/Items/MoneyTemp_DungeonCrawl.png");
        readonly Image chest = Image.FromFile("../../Image/Items/ChestTemp_DungeonCrawl.png");
        //Enemy sprites
        readonly Image skeleton = Image.FromFile("../../Image/Enemies/SkeletonTemp_DungeonCrawl.png");
        readonly Image goblin = Image.FromFile("../../Image/Enemies/GoblinTemp_DungeonCrawl.png");
        readonly Image ogre = Image.FromFile("../../Image/Enemies/OgreTemp_DungeonCrawl.png");
        //Title text sprite
        readonly Image titleText = Image.FromFile("../../Image/Start_Screen/TitleTextTemp_DungeonCrawl.png");
        //Button sprites
        readonly Image startB = Image.FromFile("../../Image/Buttons/StartButton_DungeonCrawl.png");
        readonly Image startH = Image.FromFile("../../Image/Buttons/StartButtonHighlighted_DungeonCrawl.png");
        readonly Image settingsB = Image.FromFile("../../Image/Buttons/SettingsButton_DungeonCrawl.png");
        readonly Image settingsH = Image.FromFile("../../Image/Buttons/SettingsButtonHighlighted_DungeonCrawl.png");
        readonly Image quitB = Image.FromFile("../../Image/Buttons/QuitButton_DungeonCrawl.png");
        readonly Image quitH = Image.FromFile("../../Image/Buttons/QuitButtonHighlighted_DungeonCrawl.png");
        readonly Image resumeB = Image.FromFile("../../Image/Buttons/ResumeButton_DungeonCrawl.png");
        readonly Image resumeH = Image.FromFile("../../Image/Buttons/ResumeButtonHighlighted_DungeonCrawl.png");
        readonly Image attackB = Image.FromFile("../../Image/Buttons/AttackButton_DungeonCrawl.png");
        readonly Image attackH = Image.FromFile("../../Image/Buttons/AttackButtonHighlighted_DungeonCrawl.png");
        readonly Image magicB = Image.FromFile("../../Image/Buttons/MagicButton_DungeonCrawl.png");
        readonly Image magicH = Image.FromFile("../../Image/Buttons/MagicButtonHighlighted_DungeonCrawl.png");
        readonly Image runB = Image.FromFile("../../Image/Buttons/RunButton_DungeonCrawl.png");
        readonly Image runH = Image.FromFile("../../Image/Buttons/RunButtonHighlighted_DungeonCrawl.png");
        //Wall sprites
        readonly Image baseWallTL = Image.FromFile("../../Image/Walls/BaseWallsTL_DungeonCrawl.png");
        readonly Image baseWallTR = Image.FromFile("../../Image/Walls/BaseWallsTR_DungeonCrawl.png");
        readonly Image baseWallBL = Image.FromFile("../../Image/Walls/BaseWallsBL_DungeonCrawl.png");
        readonly Image baseWallBR = Image.FromFile("../../Image/Walls/BaseWallsBR_DungeonCrawl.png");
        readonly Image bigWallTL = Image.FromFile("../../Image/Walls/BigWallsTL_DungeonCrawl.png");
        readonly Image bigWallTR = Image.FromFile("../../Image/Walls/BigWallsTR_DungeonCrawl.png");
        readonly Image bigWallBL = Image.FromFile("../../Image/Walls/BigWallsBL_DungeonCrawl.png");
        readonly Image bigWallBR = Image.FromFile("../../Image/Walls/BigWallsBR_DungeonCrawl.png");
        readonly Image pillarWallTL = Image.FromFile("../../Image/Walls/PillarWallsTL_DungeonCrawl.png");
        readonly Image pillarWallTR = Image.FromFile("../../Image/Walls/PillarWallsTR_DungeonCrawl.png");
        readonly Image pillarWallBL = Image.FromFile("../../Image/Walls/PillarWallsBL_DungeonCrawl.png");
        readonly Image pillarWallBR = Image.FromFile("../../Image/Walls/PillarWallsBR_DungeonCrawl.png");

        //General Variables
        bool inGame = false;
        bool inventoryOpen = false;
        bool startScreen = true;
        bool pauseScreen = false;
        int pX = 730;
        int pY = 789;
        int difficulty = 1;
        char enteredFrom = 's';
        string room = "bbbb";

        //Mouse Variables
        bool startHover = false;
        bool settingsHover = false;
        bool quitHover = false;
        bool resumeHover = false;
        bool attackHover = false;
        bool magicHover = false;
        bool runHover = false;

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

        Player pc;

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
        }
        private void HomeScreen()
        {
            startScreen = true;

            Invalidate();
        }
        private void StartGame()
        {
            pc = new Player();
            enemy = null;
            equipedItems = new Item[5] { null, null, null, null, null };
            lastHeld = 'w';
            sideMove = 0;
            upDownMove = 0;
            inGame = true;
            inFight = false;
            inventoryOpen = false;
            startScreen = false;
            pX = 730;
            pY = 789;
            difficulty = 1;
            enteredFrom = 's';
            room = "bbbb";
            encountersInRoom = 0;
            PlayerButtonsVisible();
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
            StrLabel.Visible = false;
            DefLabel.Visible = false;
            MagicLabel.Visible = false;
            ResLabel.Visible = false;
            MonLabel.Visible = false;
            HealthLabel.Visible = false;
            XPLabel.Visible = false;
            LevelLabel.Visible = false;
            pauseScreen = true;
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (!startScreen && !pauseScreen)
            {
                switch (e.KeyCode)
                {
                    case Keys.Escape:
                        if (!inFight)
                        {
                            OpenPauseMenu();
                        }
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
                        if (!inventoryOpen && !pauseScreen && !inFight)
                        {
                            OpenInventory();
                        }
                        else if (inventoryOpen && !pauseScreen && !inFight)
                        {
                            CloseInventory();
                        }
                        break;
                    case Keys.Q:
                        if (inGame)
                        {
                            ItemCheck();
                        }
                        break;
                }
            }
            Invalidate();
        }
        private void quitButtonClick()
        {
            if (pauseScreen)
            {
                HideAll();
                HomeScreen();
            }
            else
            {
                this.Close();
            }
        }
        private void resumeButtonClick()
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
            pauseScreen = false;
            Invalidate();
        }
        private void OpenSettingsMenu()
        {
            //Sets the settings menu and close button to visible and then sets the correct buttons to invisible based on which menu was open before settings
            SettingsMenu.Visible = true;
            CloseButton.Visible = true;
            if (startScreen)
            {
                startScreen = false;
                reopenMenu = "start";
            }
            else if (pauseScreen)
            {
                pauseScreen = false;
                reopenMenu = "pause";
            }
        }
        private void CloseSettingsMenu()
        {
            //Sets the buttons and menus to invisible and then sets the correct buttons to visible based on which menu was open before settings
            CloseButton.Visible = false;
            SettingsMenu.Visible = false;
            if (reopenMenu == "start")
            {
                startScreen = true;
            }
            else if (reopenMenu == "pause")
            {
                pauseScreen = true;
            }
        }
        private void CloseButton_Click(object sender, EventArgs e)
        {
            CloseSettingsMenu();
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (startScreen)
            {
                //Draws the title text on the screen
                e.Graphics.DrawImage(titleText, 396, 100);

                if (startHover)
                {
                    e.Graphics.DrawImage(startH, 468, 300);
                }
                else
                {
                    e.Graphics.DrawImage(startB, 468, 300);
                }

                if (settingsHover)
                {
                    e.Graphics.DrawImage(settingsH, 468, 450);
                }
                else
                {
                    e.Graphics.DrawImage(settingsB, 468, 450);
                }

                if (quitHover)
                {
                    e.Graphics.DrawImage(quitH, 468, 600);
                }
                else
                {
                    e.Graphics.DrawImage(quitB, 468, 600);
                }
            }
            else if (pauseScreen)
            {
                if (resumeHover)
                {
                    e.Graphics.DrawImage(resumeH, 468, 300);
                }
                else
                {
                    e.Graphics.DrawImage(resumeB, 468, 300);
                }

                if (settingsHover)
                {
                    e.Graphics.DrawImage(settingsH, 468, 450);
                }
                else
                {
                    e.Graphics.DrawImage(settingsB, 468, 450);
                }

                if (quitHover)
                {
                    e.Graphics.DrawImage(quitH, 468, 600);
                }
                else
                {
                    e.Graphics.DrawImage(quitB, 468, 600);
                }
            }
            else if (inGame)
            {
                PCHealthLabel.Visible = false;
                EnemyHealthLabel.Visible = false;

                //Draws the walls around the edges of the screen
                if (room[0] == 'b')
                {
                    e.Graphics.DrawImage(baseWallTL, 0, 0);
                }
                else if (room[0] == 'B')
                {
                    e.Graphics.DrawImage(bigWallTL, 0, 0);
                }
                else if (room[0] == 'p')
                {
                    e.Graphics.DrawImage(pillarWallTL, 0, 0);
                }

                if (room[1] == 'b')
                {
                    e.Graphics.DrawImage(baseWallTR, 768, 0);
                }
                else if (room[1] == 'B')
                {
                    e.Graphics.DrawImage(bigWallTR, 768, 0);
                }
                else if (room[1] == 'p')
                {
                    e.Graphics.DrawImage(pillarWallTR, 768, 0);
                }

                if (room[2] == 'b')
                {
                    e.Graphics.DrawImage(baseWallBL, 0, 432);
                }
                else if (room[2] == 'B')
                {
                    e.Graphics.DrawImage(bigWallBL, 0, 432);
                }
                else if (room[2] == 'p')
                {
                    e.Graphics.DrawImage(pillarWallBL, 0, 432);
                }

                if (room[3] == 'b')
                {
                    e.Graphics.DrawImage(baseWallBR, 768, 432);
                }
                else if (room[3] == 'B')
                {
                    e.Graphics.DrawImage(bigWallBR, 768, 432);
                }
                else if (room[3] == 'p')
                {
                    e.Graphics.DrawImage(pillarWallBR, 768, 432);
                }

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
                foreach (Item i in itemsOnScreen)
                {
                    e.Graphics.DrawImage(i.getImage(), i.getXLoc(), i.getYLoc());
                }
            }
            else if (inventoryOpen && !pauseScreen)
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
                PCHealthLabel.Location = new Point(911, 205);
                e.Graphics.DrawImage(CS, 911, 113);
                EnemyHealthLabel.Location = new Point(550, 205);
                if (enemy.getEnemyType() == "skeleton")
                {
                    e.Graphics.DrawImage(skeleton, 550, 100);
                }
                else if (enemy.getEnemyType() == "goblin")
                {
                    e.Graphics.DrawImage(goblin, 550, 100);
                }
                else if (enemy.getEnemyType() == "ogre")
                {
                    e.Graphics.DrawImage(ogre, 550, 100);
                }

                PCHealthLabel.Visible = true;
                EnemyHealthLabel.Visible = true;

                if (attackHover)
                {
                    e.Graphics.DrawImage(attackH, 468, 300);
                }
                else
                {
                    e.Graphics.DrawImage(attackB, 468, 300);
                }

                if (magicHover)
                {
                    e.Graphics.DrawImage(magicH, 468, 450);
                }
                else
                {
                    e.Graphics.DrawImage(magicB, 468, 450);
                }

                if (runHover)
                {
                    e.Graphics.DrawImage(runH, 468, 600);
                }
                else
                {
                    e.Graphics.DrawImage(runB, 468, 600);
                }
            }
        }
        private void Movement_Tick(object sender, EventArgs e)
        {
            //Constantly updates the players position relative to if they are moving or not
            pY += upDownMove;

            if (room[0] == 'b')
            {
                if (pY <= 50 && pY >= 45 && pX <= 660)
                {
                    pY = 50;
                }
            }
            else if (room[0] == 'B')
            {
                if (pY <= 332 && pY >= 327 && pX <= 660)
                {
                    pY = 332;
                }
            }
            else if (room[0] == 'p')
            {
                if (pY <= 50 && pY >= 45 && pX <= 660)
                {
                    pY = 50;
                }

                if (pY >= 157 && pY <= 162 && pX >= 497 && pX <= 768)
                {
                    pY = 157;
                }
            }

            if (room[1] == 'b')
            {
                if (pY <= 50 && pY >= 45 && pX >= 801)
                {
                    pY = 50;
                }
            }
            else if (room[1] == 'B')
            {
                if (pY <= 332 && pY >= 327 && pX >= 801)
                {
                    pY = 332;
                }
            }
            else if (room[1] == 'p')
            {
                if (pY <= 50 && pY >= 45 && pX >= 801)
                {
                    pY = 50;
                }

                if (pY >= 157 && pY <= 162 && pX >= 769 && pX <= 960)
                {
                    pY = 157;
                }
            }

            if (room[2] == 'b')
            {
                if (pY >= 739 && pY <= 744 && pX <= 660)
                {
                    pY = 739;
                }
            }
            else if (room[2] == 'B')
            {
                if (pY >= 458 && pY <= 463 && pX <= 660)
                {
                    pY = 458;
                }
            }
            else if (room[2] == 'p')
            {
                if (pY >= 739 && pY <= 744 && pX <= 660)
                {
                    pY = 739;
                }

                if (pY <= 632 && pY >= 627 && pX >= 497 && pX <= 768)
                {
                    pY = 632;
                }
            }

            if (room[3] == 'b')
            {
                if (pY >= 739 && pY <= 744 && pX >= 801)
                {
                    pY = 739;
                }
            }
            else if (room[3] == 'B')
            {
                if (pY >= 458 && pY <= 463 && pX >= 801)
                {
                    pY = 458;
                }
            }
            else if (room[3] == 'p')
            {
                if (pY >= 739 && pY <= 744 && pX >= 801)
                {
                    pY = 739;
                }

                if (pY <= 632 && pY >= 627 && pX >= 769 && pX <= 960)
                {
                    pY = 632;
                }
            }

            //Always true for any room
            if (pX <= 45 && pY <= 332)
            {
                pY = 332;
            }

            if (pX <= 45 && pY >= 457)
            {
                pY = 457;
            }

            if (pX >= 1416 && pY <= 332)
            {
                pY = 332;
            }

            if (pX >= 1416 && pY >= 457)
            {
                pY = 457;
            }

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

            if (room[0] == 'b')
            {
                if (pX <= 50 && pX >= 45 && pY <= 324)
                {
                    pX = 50;
                }
            }
            else if (room[0] == 'B')
            {
                if (pX <= 668 && pX >= 663 && pY <= 324)
                {
                    pX = 668;
                }
            }
            else if (room[0] == 'p')
            {
                if (pX <= 50 && pX >= 45 && pY <= 324)
                {
                    pX = 50;
                }

                if (pX >= 493 && pX <= 498 && pY >= 161 && pY <= 432)
                {
                    pX = 493;
                }
            }

            if (room[1] == 'b')
            {
                if (pX >= 1411 && pX <= 1416 && pY <= 324)
                {
                    pX = 1411;
                }
            }
            else if (room[1] == 'B')
            {
                if (pX >= 793 && pX <= 798 && pY <= 324)
                {
                    pX = 793;
                }
            }
            else if (room[1] == 'p')
            {
                if (pX >= 1411 && pX <= 1416 && pY <= 324)
                {
                    pX = 1411;
                }

                if (pX <= 968 && pX >= 963 && pY >= 161 && pY <= 432)
                {
                    pX = 968;
                }
            }

            if (room[2] == 'b')
            {
                if (pX <= 50 && pX >= 45 && pY >= 465)
                {
                    pX = 50;
                }
            }
            else if (room[2] == 'B')
            {
                if (pX <= 668 && pX >= 663 && pY >= 465)
                {
                    pX = 668;
                }
            }
            else if (room[2] == 'p')
            {
                if (pX <= 50 && pX >= 45 && pY >= 465)
                {
                    pX = 50;
                }

                if (pX >= 493 && pX <= 498 && pY >= 432 && pY <= 628)
                {
                    pX = 493;
                }
            }

            if (room[3] == 'b')
            {
                if (pX >= 1411 && pX <= 1416 && pY >= 465)
                {
                    pX = 1411;
                }
            }
            else if (room[3] == 'B')
            {
                if (pX >= 793 && pX <= 798 && pY >= 465)
                {
                    pX = 793;
                }
            }
            else if (room[3] == 'p')
            {
                if (pX >= 1411 && pX <= 1416 && pY >= 465)
                {
                    pX = 1411;
                }

                if (pX <= 968 && pX >= 963 && pY >= 432 && pY <= 628)
                {
                    pX = 968;
                }
            }

            //Always true for any room
            if (pY <= 45 && pX <= 668)
            {
                pX = 668;
            }

            if (pY <= 45 && pX >= 793)
            {
                pX = 793;
            }

            if (pY >= 744 && pX <= 668)
            {
                pX = 668;
            }

            if (pY >= 744 && pX >= 793)
            {
                pX = 793;
            }

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
            bool spawnChest = false;
            int itemSpawned = 0;
            int amountOfItems = difficulty;
            int quadrantSpawn;
            int ranX = 0;
            int ranY = 0;

            itemsOnScreen.Clear();

            if (amountOfItems > 4)
            {
                amountOfItems = 4;
            }

            for (int i = 0; i < amountOfItems; i++)
            {
                if (ran.Next(0, 10) == 0)
                {
                    spawnItem = true;
                }
                else if (ran.Next(0, 2) == 0)
                {
                    spawnChest = true;
                }

                spawnItem = true;
                spawnChest = true;

                if (spawnItem)
                {
                    quadrantSpawn = ran.Next(0, 4);

                    if (quadrantSpawn == 0)
                    {
                        if (room[0] == 'b')
                        {
                            ranX = ran.Next(50, 768);
                            ranY = ran.Next(50, 432);
                        }
                        else if (room[0] == 'B')
                        {
                            ranX = ran.Next(50, 768);

                            if (ranX >= 668)
                            {
                                ranY = ran.Next(50, 432);
                            }
                            else
                            {
                                ranY = ran.Next(332, 432);
                            }
                        }
                        else if (room[0] == 'p')
                        {
                            ranX = ran.Next(50, 768);

                            if (ranX <= 518)
                            {
                                ranY = ran.Next(50, 432);
                            }
                            else
                            {
                                ranY = ran.Next(50, 182);
                            }
                        }
                    }
                    else if (quadrantSpawn == 1)
                    {
                        if (room[1] == 'b')
                        {
                            ranX = ran.Next(768, 1436);
                            ranY = ran.Next(50, 432);
                        }
                        else if (room[1] == 'B')
                        {
                            ranX = ran.Next(768, 1436);

                            if (ranX <= 818)
                            {
                                ranY = ran.Next(50, 432);

                            }
                            else
                            {
                                ranY = ran.Next(332, 432);
                            }
                        }
                        else if (room[1] == 'p')
                        {
                            ranX = ran.Next(768, 1436);

                            if (ranX >= 968)
                            {
                                ranY = ran.Next(50, 432);
                            }
                            else
                            {
                                ranY = ran.Next(50, 182);
                            }
                        }
                    }
                    else if (quadrantSpawn == 2)
                    {
                        if (room[2] == 'b')
                        {
                            ranX = ran.Next(50, 768);
                            ranY = ran.Next(432, 764);
                        }
                        else if (room[2] == 'B')
                        {
                            ranX = ran.Next(50, 768);

                            if (ranX >= 668)
                            {
                                ranY = ran.Next(432, 764);
                            }
                            else
                            {
                                ranY = ran.Next(432, 482);
                            }
                        }
                        else if (room[2] == 'p')
                        {
                            ranX = ran.Next(50, 768);

                            if (ranX <= 518)
                            {
                                ranY = ran.Next(432, 764);
                            }
                            else
                            {
                                ranY = ran.Next(632, 764);
                            }
                        }
                    }
                    else if (quadrantSpawn == 3)
                    {
                        if (room[3] == 'b')
                        {
                            ranX = ran.Next(768, 1436);
                            ranY = ran.Next(432, 764);
                        }
                        else if (room[3] == 'B')
                        {
                            ranX = ran.Next(768, 1436);

                            if (ranX <= 818)
                            {
                                ranY = ran.Next(432, 764);
                            }
                            else
                            {
                                ranY = ran.Next(432, 482);
                            }
                        }
                        else if (room[3] == 'p')
                        {
                            ranX = ran.Next(768, 1436);

                            if (ranX >= 968)
                            {
                                ranY = ran.Next(432, 764);
                            }
                            else
                            {
                                ranY = ran.Next(632, 764);
                            }
                        }
                    }

                    itemSpawned = ran.Next(1, 6);

                    if (itemSpawned == 1)
                    {
                        itemsOnScreen.Add(new Castle_Armor("plate", new Point(ranX, ranY), ran.Next(difficulty - 1, difficulty + 1)));
                    }
                    else if (itemSpawned == 2)
                    {
                        itemsOnScreen.Add(new Castle_Weapon("sword", new Point(ranX, ranY), ran.Next(difficulty - 1, difficulty + 1)));
                    }
                    else if (itemSpawned == 3)
                    {
                        itemsOnScreen.Add(new Castle_Staff("novice", new Point(ranX, ranY), ran.Next(difficulty - 1, difficulty + 1)));
                    }
                    else if (itemSpawned == 4)
                    {
                        itemsOnScreen.Add(new Castle_Jewlery("amulet", new Point(ranX, ranY), ran.Next(difficulty - 1, difficulty + 1)));
                    }
                    else if (itemSpawned == 5)
                    {
                        itemsOnScreen.Add(new Money(ran.Next(difficulty - 1, difficulty + 1), new Point(ranX, ranY)));
                    }
                }

                if (spawnChest)
                {
                    quadrantSpawn = ran.Next(0, 4);

                    if (quadrantSpawn == 0)
                    {
                        if (room[0] == 'b' || room[0] == 'p')
                        {
                            ranX = 100;
                            ranY = 100;
                        }
                        else if (room[0] == 'B')
                        {
                            ranX = 743;
                            ranY = 407;
                        }

                    }
                    else if (quadrantSpawn == 1)
                    {
                        if (room[1] == 'b' || room[1] == 'p')
                        {
                            ranX = 1386;
                            ranY = 100;
                        }
                        else if (room[1] == 'B')
                        {
                            ranX = 743;
                            ranY = 407;
                        }
                    }
                    else if (quadrantSpawn == 2)
                    {
                        if (room[2] == 'b' || room[2] == 'p')
                        {
                            ranX = 100;
                            ranY = 714;
                        }
                        else if (room[2] == 'B')
                        {
                            ranX = 743;
                            ranY = 407;
                        }
                    }
                    else if (quadrantSpawn == 3)
                    {
                        if (room[3] == 'b' || room[3] == 'p')
                        {
                            ranX = 1386;
                            ranY = 714;
                        }
                        else if (room[3] == 'B')
                        {
                            ranX = 743;
                            ranY = 407;
                        }
                    }

                    itemsOnScreen.Add(new Chest(difficulty, new Point(ranX, ranY)));

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
                    else if (itemsOnScreen[i].getType() == "chest")
                    {
                        itemsOnScreen.AddRange(itemsOnScreen[i].Open());
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
            Invalidate();
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

            RandomRoom();

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
                Cursor.Show();
            }
            else
            {
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
        private void attackButtonClick()
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
        private void magicButtonClick()
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
        private void runButtonClick()
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
                inFight = false;
                PlayerDied();
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
        private void PlayerDied()
        {
            HideAll();
            Invalidate();
            string message = "You Died.\nHere are your stats:\nLevel: " + pc.getLevel() + "\nStrength: " + pc.getStrength() + "\nDefense: " + pc.getDefense() + "\nMagic: " + pc.getMagic() + "\nResistance: " + pc.getResistance() + "\nMoney: " + pc.getMoney() + "\n\nWould you like to restart?";
            DialogResult result = MessageBox.Show(message, null, MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                StartGame();
            }
            else
            {
                HomeScreen();
            }

            Invalidate();
        }
        private void HideAll()
        {
            //Hides all the buttons and labels on the screen
            StrLabel.Visible = false;
            DefLabel.Visible = false;
            MagicLabel.Visible = false;
            ResLabel.Visible = false;
            MonLabel.Visible = false;
            HealthLabel.Visible = false;
            XPLabel.Visible = false;
            LevelLabel.Visible = false;
            PCHealthLabel.Visible = false;
            EnemyHealthLabel.Visible = false;
            startScreen = false;
            pauseScreen = false;
            inFight = false;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            startHover = false;
            resumeHover = false;
            attackHover = false;
            settingsHover = false;
            magicHover = false;
            quitHover = false;
            runHover = false;

            if (startScreen)
            {
                if (e.Location.Y >= 300 && e.Location.Y <= 400 && e.Location.X >= 468 && e.Location.X <= 1068)
                {
                    startHover = true;
                }
                else
                {
                    startHover = false;
                }

                if (e.Location.Y >= 450 && e.Location.Y <= 550 && e.Location.X >= 468 && e.Location.X <= 1068)
                {
                    settingsHover = true;
                }
                else
                {
                    settingsHover = false;
                }

                if (e.Location.Y >= 600 && e.Location.Y <= 700 && e.Location.X >= 468 && e.Location.X <= 1068)
                {
                    quitHover = true;
                }
                else
                {
                    quitHover = false;
                }
            }
            else if (pauseScreen)
            {
                if (e.Location.Y >= 300 && e.Location.Y <= 400 && e.Location.X >= 468 && e.Location.X <= 1068)
                {
                    resumeHover = true;
                }
                else
                {
                    resumeHover = false;
                }

                if (e.Location.Y >= 450 && e.Location.Y <= 550 && e.Location.X >= 468 && e.Location.X <= 1068)
                {
                    settingsHover = true;
                }
                else
                {
                    settingsHover = false;
                }

                if (e.Location.Y >= 600 && e.Location.Y <= 700 && e.Location.X >= 468 && e.Location.X <= 1068)
                {
                    quitHover = true;
                }
                else
                {
                    quitHover = false;
                }
            }
            else if (inFight)
            {
                if (e.Location.Y >= 300 && e.Location.Y <= 400 && e.Location.X >= 468 && e.Location.X <= 1068)
                {
                    attackHover = true;
                }
                else
                {
                    attackHover = false;
                }

                if (e.Location.Y >= 450 && e.Location.Y <= 550 && e.Location.X >= 468 && e.Location.X <= 1068)
                {
                    magicHover = true;
                }
                else
                {
                    magicHover = false;
                }

                if (e.Location.Y >= 600 && e.Location.Y <= 700 && e.Location.X >= 468 && e.Location.X <= 1068)
                {
                    runHover = true;
                }
                else
                {
                    runHover = false;
                }
            }

            Invalidate();
        }
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (resumeHover)
            {
                resumeButtonClick();
            }
            else if (startHover)
            {
                StartGame();
            }
            else if (settingsHover)
            {
                OpenSettingsMenu();
            }
            else if (quitHover)
            {
                quitButtonClick();
            }
            else if (attackHover)
            {
                attackButtonClick();
            }
            else if (magicHover)
            {
                magicButtonClick();
            }
            else if (runHover)
            {
                runButtonClick();
            }
        }
        private void RandomRoom()
        {
            int roomType = ran.Next(0, 5);

            if (roomType == 0)
            {
                room = "bbbb";
            }
            else if (roomType == 1)
            {
                room = "pppp";
            }
            else if (roomType == 2)
            {
                room = "BBBB";
            }
            else if (roomType == 3)
            {
                roomType = ran.Next(0, 4);

                if (roomType == 0)
                {
                    room = "BBbb";
                }
                else if (roomType == 1)
                {
                    room = "bBBb";
                }
                else if (roomType == 2)
                {
                    room = "bbBB";
                }
                else if (roomType == 3)
                {
                    room = "BbbB";
                }
            }
            else if (roomType == 4)
            {
                roomType = ran.Next(0, 4);

                if (roomType == 0)
                {
                    room = "Bbbb";
                }
                else if (roomType == 1)
                {
                    room = "bBbb";
                }
                else if (roomType == 2)
                {
                    room = "bbBb";
                }
                else if (roomType == 3)
                {
                    room = "bbbB";
                }
            }
        }
    }
}
