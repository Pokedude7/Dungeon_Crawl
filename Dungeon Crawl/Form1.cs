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
        //This is a test comment
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
        }
    }
}
