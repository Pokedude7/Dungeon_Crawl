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
            this.Movement = new System.Windows.Forms.Timer(this.components);
            this.StrLabel = new System.Windows.Forms.Label();
            this.DefLabel = new System.Windows.Forms.Label();
            this.MagicLabel = new System.Windows.Forms.Label();
            this.ResLabel = new System.Windows.Forms.Label();
            this.MonLabel = new System.Windows.Forms.Label();
            this.PCHealthLabel = new System.Windows.Forms.Label();
            this.EnemyHealthLabel = new System.Windows.Forms.Label();
            this.ShutOff = new System.Windows.Forms.Timer(this.components);
            this.HealthLabel = new System.Windows.Forms.Label();
            this.XPLabel = new System.Windows.Forms.Label();
            this.LevelLabel = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SettingsMenu = new System.Windows.Forms.TableLayoutPanel();
            this.HealLabel = new System.Windows.Forms.Label();
            this.SettingsMenu.SuspendLayout();
            this.SuspendLayout();
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
            this.StrLabel.BackColor = System.Drawing.Color.Transparent;
            this.StrLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StrLabel.ForeColor = System.Drawing.Color.White;
            this.StrLabel.Location = new System.Drawing.Point(72, 60);
            this.StrLabel.Name = "StrLabel";
            this.StrLabel.Size = new System.Drawing.Size(92, 32);
            this.StrLabel.TabIndex = 6;
            this.StrLabel.Text = "label5";
            this.StrLabel.Visible = false;
            // 
            // DefLabel
            // 
            this.DefLabel.AutoSize = true;
            this.DefLabel.BackColor = System.Drawing.Color.Transparent;
            this.DefLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefLabel.ForeColor = System.Drawing.Color.White;
            this.DefLabel.Location = new System.Drawing.Point(75, 90);
            this.DefLabel.Name = "DefLabel";
            this.DefLabel.Size = new System.Drawing.Size(92, 32);
            this.DefLabel.TabIndex = 7;
            this.DefLabel.Text = "label6";
            this.DefLabel.Visible = false;
            // 
            // MagicLabel
            // 
            this.MagicLabel.AutoSize = true;
            this.MagicLabel.BackColor = System.Drawing.Color.Transparent;
            this.MagicLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MagicLabel.ForeColor = System.Drawing.Color.White;
            this.MagicLabel.Location = new System.Drawing.Point(75, 110);
            this.MagicLabel.Name = "MagicLabel";
            this.MagicLabel.Size = new System.Drawing.Size(92, 32);
            this.MagicLabel.TabIndex = 8;
            this.MagicLabel.Text = "label7";
            this.MagicLabel.Visible = false;
            // 
            // ResLabel
            // 
            this.ResLabel.AutoSize = true;
            this.ResLabel.BackColor = System.Drawing.Color.Transparent;
            this.ResLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ResLabel.ForeColor = System.Drawing.Color.White;
            this.ResLabel.Location = new System.Drawing.Point(78, 132);
            this.ResLabel.Name = "ResLabel";
            this.ResLabel.Size = new System.Drawing.Size(92, 32);
            this.ResLabel.TabIndex = 9;
            this.ResLabel.Text = "label8";
            this.ResLabel.Visible = false;
            // 
            // MonLabel
            // 
            this.MonLabel.AutoSize = true;
            this.MonLabel.BackColor = System.Drawing.Color.Transparent;
            this.MonLabel.Location = new System.Drawing.Point(82, 163);
            this.MonLabel.Name = "MonLabel";
            this.MonLabel.Size = new System.Drawing.Size(44, 16);
            this.MonLabel.TabIndex = 10;
            this.MonLabel.Text = "label9";
            this.MonLabel.Visible = false;
            // 
            // PCHealthLabel
            // 
            this.PCHealthLabel.AutoSize = true;
            this.PCHealthLabel.Location = new System.Drawing.Point(100, 274);
            this.PCHealthLabel.Name = "PCHealthLabel";
            this.PCHealthLabel.Size = new System.Drawing.Size(44, 16);
            this.PCHealthLabel.TabIndex = 14;
            this.PCHealthLabel.Text = "label5";
            this.PCHealthLabel.Visible = false;
            // 
            // EnemyHealthLabel
            // 
            this.EnemyHealthLabel.AutoSize = true;
            this.EnemyHealthLabel.Location = new System.Drawing.Point(106, 345);
            this.EnemyHealthLabel.Name = "EnemyHealthLabel";
            this.EnemyHealthLabel.Size = new System.Drawing.Size(44, 16);
            this.EnemyHealthLabel.TabIndex = 15;
            this.EnemyHealthLabel.Text = "label6";
            this.EnemyHealthLabel.Visible = false;
            // 
            // ShutOff
            // 
            this.ShutOff.Enabled = true;
            this.ShutOff.Interval = 10;
            this.ShutOff.Tick += new System.EventHandler(this.ShutOff_Tick);
            // 
            // HealthLabel
            // 
            this.HealthLabel.AutoSize = true;
            this.HealthLabel.BackColor = System.Drawing.Color.Transparent;
            this.HealthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HealthLabel.ForeColor = System.Drawing.Color.White;
            this.HealthLabel.Location = new System.Drawing.Point(79, 164);
            this.HealthLabel.Name = "HealthLabel";
            this.HealthLabel.Size = new System.Drawing.Size(92, 32);
            this.HealthLabel.TabIndex = 16;
            this.HealthLabel.Text = "label8";
            this.HealthLabel.Visible = false;
            // 
            // XPLabel
            // 
            this.XPLabel.AutoSize = true;
            this.XPLabel.BackColor = System.Drawing.Color.Transparent;
            this.XPLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.XPLabel.ForeColor = System.Drawing.Color.White;
            this.XPLabel.Location = new System.Drawing.Point(79, 198);
            this.XPLabel.Name = "XPLabel";
            this.XPLabel.Size = new System.Drawing.Size(92, 32);
            this.XPLabel.TabIndex = 17;
            this.XPLabel.Text = "label8";
            this.XPLabel.Visible = false;
            // 
            // LevelLabel
            // 
            this.LevelLabel.AutoSize = true;
            this.LevelLabel.BackColor = System.Drawing.Color.Transparent;
            this.LevelLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LevelLabel.ForeColor = System.Drawing.Color.White;
            this.LevelLabel.Location = new System.Drawing.Point(72, 230);
            this.LevelLabel.Name = "LevelLabel";
            this.LevelLabel.Size = new System.Drawing.Size(92, 32);
            this.LevelLabel.TabIndex = 18;
            this.LevelLabel.Text = "label8";
            this.LevelLabel.Visible = false;
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(330, 302);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(111, 54);
            this.CloseButton.TabIndex = 5;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Visible = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "Walk Left";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(160, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 29);
            this.label3.TabIndex = 3;
            this.label3.Text = "Walk Right";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Walk Backward";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 29);
            this.label2.TabIndex = 1;
            this.label2.Text = "Walk Forward";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SettingsMenu
            // 
            this.SettingsMenu.ColumnCount = 4;
            this.SettingsMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.25547F));
            this.SettingsMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.74453F));
            this.SettingsMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.SettingsMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.SettingsMenu.Controls.Add(this.label2, 0, 0);
            this.SettingsMenu.Controls.Add(this.label1, 1, 0);
            this.SettingsMenu.Controls.Add(this.label3, 2, 0);
            this.SettingsMenu.Controls.Add(this.label4, 3, 0);
            this.SettingsMenu.Location = new System.Drawing.Point(239, 280);
            this.SettingsMenu.Name = "SettingsMenu";
            this.SettingsMenu.RowCount = 2;
            this.SettingsMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SettingsMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.SettingsMenu.Size = new System.Drawing.Size(296, 58);
            this.SettingsMenu.TabIndex = 4;
            this.SettingsMenu.Visible = false;
            // 
            // HealLabel
            // 
            this.HealLabel.AutoSize = true;
            this.HealLabel.BackColor = System.Drawing.Color.Transparent;
            this.HealLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HealLabel.ForeColor = System.Drawing.Color.White;
            this.HealLabel.Location = new System.Drawing.Point(177, 188);
            this.HealLabel.Name = "HealLabel";
            this.HealLabel.Size = new System.Drawing.Size(53, 20);
            this.HealLabel.TabIndex = 19;
            this.HealLabel.Text = "label8";
            this.HealLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.HealLabel);
            this.Controls.Add(this.LevelLabel);
            this.Controls.Add(this.XPLabel);
            this.Controls.Add(this.HealthLabel);
            this.Controls.Add(this.EnemyHealthLabel);
            this.Controls.Add(this.PCHealthLabel);
            this.Controls.Add(this.MonLabel);
            this.Controls.Add(this.ResLabel);
            this.Controls.Add(this.MagicLabel);
            this.Controls.Add(this.DefLabel);
            this.Controls.Add(this.StrLabel);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.SettingsMenu);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseClick);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseMove);
            this.SettingsMenu.ResumeLayout(false);
            this.SettingsMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer Movement;
        private System.Windows.Forms.Label StrLabel;
        private System.Windows.Forms.Label DefLabel;
        private System.Windows.Forms.Label MagicLabel;
        private System.Windows.Forms.Label ResLabel;
        private System.Windows.Forms.Label MonLabel;
        private System.Windows.Forms.Label PCHealthLabel;
        private System.Windows.Forms.Label EnemyHealthLabel;
        private System.Windows.Forms.Timer ShutOff;
        private System.Windows.Forms.Label HealthLabel;
        private System.Windows.Forms.Label XPLabel;
        private System.Windows.Forms.Label LevelLabel;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel SettingsMenu;
        private System.Windows.Forms.Label HealLabel;
    }
}

