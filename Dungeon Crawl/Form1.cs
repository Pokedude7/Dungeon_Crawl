using System;
using System.Drawing;
using System.Windows.Forms;

namespace Dungeon_Crawl
{
    public partial class Form1 : Form
    {
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
        bool inGame = false;
        bool inventoryOpen = false;
        int pX = 100;
        int pY = 100;

        int upDownMove = 0;
        int sideMove = 0;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
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
            Invalidate();
        }

        private void OpenPauseMenu()
        {
            //Sets the buttons to visible and then calls the method to open the pause menu
            inGame = false;
            Movement.Enabled = false;
            resumeButton.Visible = true;
            settingsButton.Visible = true;
            quitButton.Visible = true;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    Console.WriteLine("Escape key pressed");
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
                    if (!inventoryOpen)
                    {
                        OpenInventory();
                    }
                    else if (inventoryOpen)
                    {
                        CloseInventory();
                    }
                        break;
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
            inGame = true;
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
                //Draws the character sprite where the player is located on the screen
                e.Graphics.DrawImage(CS, pX, pY);
            }
            else if (inventoryOpen)
            {
                e.Graphics.DrawImage(ISq, 800, 200);
                e.Graphics.DrawImage(ISq, 800, 325);
                e.Graphics.DrawImage(ISq, 800, 450);
                e.Graphics.DrawImage(ISc, 625, 200);
            }
        }

        private void Movement_Tick(object sender, EventArgs e)
        {
            pY += upDownMove;
            pX += sideMove;
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
            inventoryOpen = true;
        }
        private void CloseInventory()
        {
            inGame = true;
            inventoryOpen = false;
        }
    }
}
