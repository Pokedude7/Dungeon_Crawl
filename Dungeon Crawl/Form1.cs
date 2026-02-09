using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dungeon_Crawl
{
    public partial class Form1 : Form
    {
        public char moveUp = 'W';
        public char moveDown = 'S';
        public char moveLeft = 'A';
        public char moveRight = 'D';
        public string reopenMenu = null;
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
            startButton.Visible = false;
            settingsButton.Visible = false;
            quitButton.Visible = false;
            StartGame();
        }

        private void StartGame()
        {
            MessageBox.Show("Game Started");
        }

        private void OpenPauseMenu()
        {
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
            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void resumeButton_Click(object sender, EventArgs e)
        {
            quitButton.Visible = false;
            settingsButton.Visible= false;
            resumeButton.Visible = false;
            Invalidate();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
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
    }
}
