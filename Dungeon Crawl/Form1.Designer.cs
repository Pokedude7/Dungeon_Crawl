namespace Dungeon_Crawl
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.startButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.resumeButton = new System.Windows.Forms.Button();
            this.SettingsMenu = new System.Windows.Forms.TableLayoutPanel();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.Movement = new System.Windows.Forms.Timer(this.components);
            this.StrLabel = new System.Windows.Forms.Label();
            this.DefLabel = new System.Windows.Forms.Label();
            this.MagicLabel = new System.Windows.Forms.Label();
            this.ResLabel = new System.Windows.Forms.Label();
            this.MonLabel = new System.Windows.Forms.Label();
            this.ItemCheck = new System.Windows.Forms.Timer(this.components);
            this.SettingsMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(290, 132);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(159, 54);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Location = new System.Drawing.Point(290, 192);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(159, 54);
            this.settingsButton.TabIndex = 1;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Location = new System.Drawing.Point(290, 252);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(159, 54);
            this.quitButton.TabIndex = 2;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // resumeButton
            // 
            this.resumeButton.Location = new System.Drawing.Point(290, 132);
            this.resumeButton.Name = "resumeButton";
            this.resumeButton.Size = new System.Drawing.Size(159, 54);
            this.resumeButton.TabIndex = 3;
            this.resumeButton.Text = "Resume";
            this.resumeButton.UseVisualStyleBackColor = true;
            this.resumeButton.Visible = false;
            this.resumeButton.Click += new System.EventHandler(this.resumeButton_Click);
            // 
            // SettingsMenu
            // 
            this.SettingsMenu.ColumnCount = 4;
            this.SettingsMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.25547F));
            this.SettingsMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.74453F));
            this.SettingsMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.SettingsMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 68F));
            this.SettingsMenu.Controls.Add(this.textBox4, 3, 1);
            this.SettingsMenu.Controls.Add(this.label2, 0, 0);
            this.SettingsMenu.Controls.Add(this.textBox1, 0, 1);
            this.SettingsMenu.Controls.Add(this.textBox2, 1, 1);
            this.SettingsMenu.Controls.Add(this.label1, 1, 0);
            this.SettingsMenu.Controls.Add(this.textBox3, 2, 1);
            this.SettingsMenu.Controls.Add(this.label3, 2, 0);
            this.SettingsMenu.Controls.Add(this.label4, 3, 0);
            this.SettingsMenu.Location = new System.Drawing.Point(239, 192);
            this.SettingsMenu.Name = "SettingsMenu";
            this.SettingsMenu.RowCount = 2;
            this.SettingsMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SettingsMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SettingsMenu.Size = new System.Drawing.Size(260, 71);
            this.SettingsMenu.TabIndex = 4;
            this.SettingsMenu.Visible = false;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(194, 38);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(59, 22);
            this.textBox4.TabIndex = 6;
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 35);
            this.label2.TabIndex = 1;
            this.label2.Text = "Walk Forward";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 38);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(54, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(63, 38);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(67, 22);
            this.textBox2.TabIndex = 2;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Walk Backward";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(136, 38);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(52, 22);
            this.textBox3.TabIndex = 4;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 32);
            this.label3.TabIndex = 3;
            this.label3.Text = "Walk Right";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(194, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Walk Left";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(330, 258);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 5;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Visible = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // Movement
            // 
            this.Movement.Enabled = true;
            this.Movement.Interval = 10;
            this.Movement.Tick += new System.EventHandler(this.Movement_Tick);
            // 
            // StrLabel
            // 
            this.StrLabel.AutoSize = true;
            this.StrLabel.Location = new System.Drawing.Point(72, 60);
            this.StrLabel.Name = "StrLabel";
            this.StrLabel.Size = new System.Drawing.Size(44, 16);
            this.StrLabel.TabIndex = 6;
            this.StrLabel.Text = "label5";
            this.StrLabel.Visible = false;
            // 
            // DefLabel
            // 
            this.DefLabel.AutoSize = true;
            this.DefLabel.Location = new System.Drawing.Point(75, 90);
            this.DefLabel.Name = "DefLabel";
            this.DefLabel.Size = new System.Drawing.Size(44, 16);
            this.DefLabel.TabIndex = 7;
            this.DefLabel.Text = "label6";
            this.DefLabel.Visible = false;
            // 
            // MagicLabel
            // 
            this.MagicLabel.AutoSize = true;
            this.MagicLabel.Location = new System.Drawing.Point(75, 110);
            this.MagicLabel.Name = "MagicLabel";
            this.MagicLabel.Size = new System.Drawing.Size(44, 16);
            this.MagicLabel.TabIndex = 8;
            this.MagicLabel.Text = "label7";
            this.MagicLabel.Visible = false;
            // 
            // ResLabel
            // 
            this.ResLabel.AutoSize = true;
            this.ResLabel.Location = new System.Drawing.Point(78, 132);
            this.ResLabel.Name = "ResLabel";
            this.ResLabel.Size = new System.Drawing.Size(44, 16);
            this.ResLabel.TabIndex = 9;
            this.ResLabel.Text = "label8";
            this.ResLabel.Visible = false;
            // 
            // MonLabel
            // 
            this.MonLabel.AutoSize = true;
            this.MonLabel.Location = new System.Drawing.Point(82, 163);
            this.MonLabel.Name = "MonLabel";
            this.MonLabel.Size = new System.Drawing.Size(44, 16);
            this.MonLabel.TabIndex = 10;
            this.MonLabel.Text = "label9";
            this.MonLabel.Visible = false;
            // 
            // ItemCheck
            // 
            this.ItemCheck.Enabled = true;
            this.ItemCheck.Interval = 10;
            this.ItemCheck.Tick += new System.EventHandler(this.ItemCheck_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.MonLabel);
            this.Controls.Add(this.ResLabel);
            this.Controls.Add(this.MagicLabel);
            this.Controls.Add(this.DefLabel);
            this.Controls.Add(this.StrLabel);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.SettingsMenu);
            this.Controls.Add(this.resumeButton);
            this.Controls.Add(this.quitButton);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.startButton);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.SettingsMenu.ResumeLayout(false);
            this.SettingsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button resumeButton;
        private System.Windows.Forms.TableLayoutPanel SettingsMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Timer Movement;
        private System.Windows.Forms.Label StrLabel;
        private System.Windows.Forms.Label DefLabel;
        private System.Windows.Forms.Label MagicLabel;
        private System.Windows.Forms.Label ResLabel;
        private System.Windows.Forms.Label MonLabel;
        private System.Windows.Forms.Timer ItemCheck;
    }
}

