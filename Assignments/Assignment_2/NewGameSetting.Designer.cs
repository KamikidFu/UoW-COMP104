namespace BattleshipHiddenThreat
{
    partial class NewGameSetting
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
            this.label1_PlayerName = new System.Windows.Forms.Label();
            this.textBox1_PlayerName = new System.Windows.Forms.TextBox();
            this.button1_StartGame = new System.Windows.Forms.Button();
            this.groupBox2_Mode = new System.Windows.Forms.GroupBox();
            this.radioButton4_Mode_Easy = new System.Windows.Forms.RadioButton();
            this.radioButton3_Mode_Full = new System.Windows.Forms.RadioButton();
            this.groupBox1_Team = new System.Windows.Forms.GroupBox();
            this.radioButton2_Team_Blue = new System.Windows.Forms.RadioButton();
            this.radioButton1_Team_Red = new System.Windows.Forms.RadioButton();
            this.button2_Close = new System.Windows.Forms.Button();
            this.groupBox2_Mode.SuspendLayout();
            this.groupBox1_Team.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1_PlayerName
            // 
            this.label1_PlayerName.AutoSize = true;
            this.label1_PlayerName.Location = new System.Drawing.Point(12, 13);
            this.label1_PlayerName.Name = "label1_PlayerName";
            this.label1_PlayerName.Size = new System.Drawing.Size(70, 13);
            this.label1_PlayerName.TabIndex = 0;
            this.label1_PlayerName.Text = "Player Name:";
            // 
            // textBox1_PlayerName
            // 
            this.textBox1_PlayerName.Location = new System.Drawing.Point(95, 10);
            this.textBox1_PlayerName.Name = "textBox1_PlayerName";
            this.textBox1_PlayerName.Size = new System.Drawing.Size(100, 20);
            this.textBox1_PlayerName.TabIndex = 3;
            // 
            // button1_StartGame
            // 
            this.button1_StartGame.Location = new System.Drawing.Point(18, 155);
            this.button1_StartGame.Name = "button1_StartGame";
            this.button1_StartGame.Size = new System.Drawing.Size(75, 25);
            this.button1_StartGame.TabIndex = 8;
            this.button1_StartGame.Text = "Start";
            this.button1_StartGame.UseVisualStyleBackColor = true;
            this.button1_StartGame.Click += new System.EventHandler(this.button1_StartGame_Click);
            // 
            // groupBox2_Mode
            // 
            this.groupBox2_Mode.Controls.Add(this.radioButton4_Mode_Easy);
            this.groupBox2_Mode.Controls.Add(this.radioButton3_Mode_Full);
            this.groupBox2_Mode.Location = new System.Drawing.Point(14, 98);
            this.groupBox2_Mode.Name = "groupBox2_Mode";
            this.groupBox2_Mode.Size = new System.Drawing.Size(179, 51);
            this.groupBox2_Mode.TabIndex = 9;
            this.groupBox2_Mode.TabStop = false;
            this.groupBox2_Mode.Text = "Mode";
            // 
            // radioButton4_Mode_Easy
            // 
            this.radioButton4_Mode_Easy.AutoSize = true;
            this.radioButton4_Mode_Easy.ForeColor = System.Drawing.Color.Lime;
            this.radioButton4_Mode_Easy.Location = new System.Drawing.Point(110, 22);
            this.radioButton4_Mode_Easy.Name = "radioButton4_Mode_Easy";
            this.radioButton4_Mode_Easy.Size = new System.Drawing.Size(48, 17);
            this.radioButton4_Mode_Easy.TabIndex = 1;
            this.radioButton4_Mode_Easy.TabStop = true;
            this.radioButton4_Mode_Easy.Text = "Easy";
            this.radioButton4_Mode_Easy.UseVisualStyleBackColor = true;
            // 
            // radioButton3_Mode_Full
            // 
            this.radioButton3_Mode_Full.AutoSize = true;
            this.radioButton3_Mode_Full.ForeColor = System.Drawing.Color.Goldenrod;
            this.radioButton3_Mode_Full.Location = new System.Drawing.Point(34, 22);
            this.radioButton3_Mode_Full.Name = "radioButton3_Mode_Full";
            this.radioButton3_Mode_Full.Size = new System.Drawing.Size(41, 17);
            this.radioButton3_Mode_Full.TabIndex = 0;
            this.radioButton3_Mode_Full.TabStop = true;
            this.radioButton3_Mode_Full.Text = "Full";
            this.radioButton3_Mode_Full.UseVisualStyleBackColor = true;
            // 
            // groupBox1_Team
            // 
            this.groupBox1_Team.Controls.Add(this.radioButton2_Team_Blue);
            this.groupBox1_Team.Controls.Add(this.radioButton1_Team_Red);
            this.groupBox1_Team.Location = new System.Drawing.Point(12, 39);
            this.groupBox1_Team.Name = "groupBox1_Team";
            this.groupBox1_Team.Size = new System.Drawing.Size(181, 52);
            this.groupBox1_Team.TabIndex = 10;
            this.groupBox1_Team.TabStop = false;
            this.groupBox1_Team.Text = "Team";
            // 
            // radioButton2_Team_Blue
            // 
            this.radioButton2_Team_Blue.AutoSize = true;
            this.radioButton2_Team_Blue.ForeColor = System.Drawing.Color.Blue;
            this.radioButton2_Team_Blue.Location = new System.Drawing.Point(112, 22);
            this.radioButton2_Team_Blue.Name = "radioButton2_Team_Blue";
            this.radioButton2_Team_Blue.Size = new System.Drawing.Size(46, 17);
            this.radioButton2_Team_Blue.TabIndex = 1;
            this.radioButton2_Team_Blue.TabStop = true;
            this.radioButton2_Team_Blue.Text = "Blue";
            this.radioButton2_Team_Blue.UseVisualStyleBackColor = true;
            // 
            // radioButton1_Team_Red
            // 
            this.radioButton1_Team_Red.AutoSize = true;
            this.radioButton1_Team_Red.ForeColor = System.Drawing.Color.Red;
            this.radioButton1_Team_Red.Location = new System.Drawing.Point(36, 22);
            this.radioButton1_Team_Red.Name = "radioButton1_Team_Red";
            this.radioButton1_Team_Red.Size = new System.Drawing.Size(45, 17);
            this.radioButton1_Team_Red.TabIndex = 0;
            this.radioButton1_Team_Red.TabStop = true;
            this.radioButton1_Team_Red.Text = "Red";
            this.radioButton1_Team_Red.UseVisualStyleBackColor = true;
            // 
            // button2_Close
            // 
            this.button2_Close.Location = new System.Drawing.Point(114, 156);
            this.button2_Close.Name = "button2_Close";
            this.button2_Close.Size = new System.Drawing.Size(75, 23);
            this.button2_Close.TabIndex = 11;
            this.button2_Close.Text = "Exit";
            this.button2_Close.UseVisualStyleBackColor = true;
            this.button2_Close.Click += new System.EventHandler(this.button2_Close_Click);
            // 
            // NewGameSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 191);
            this.Controls.Add(this.button2_Close);
            this.Controls.Add(this.groupBox1_Team);
            this.Controls.Add(this.groupBox2_Mode);
            this.Controls.Add(this.button1_StartGame);
            this.Controls.Add(this.textBox1_PlayerName);
            this.Controls.Add(this.label1_PlayerName);
            this.Name = "NewGameSetting";
            this.Text = "New Game";
            this.groupBox2_Mode.ResumeLayout(false);
            this.groupBox2_Mode.PerformLayout();
            this.groupBox1_Team.ResumeLayout(false);
            this.groupBox1_Team.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1_PlayerName;
        private System.Windows.Forms.TextBox textBox1_PlayerName;
        private System.Windows.Forms.Button button1_StartGame;
        private System.Windows.Forms.GroupBox groupBox2_Mode;
        private System.Windows.Forms.RadioButton radioButton4_Mode_Easy;
        private System.Windows.Forms.RadioButton radioButton3_Mode_Full;
        private System.Windows.Forms.GroupBox groupBox1_Team;
        private System.Windows.Forms.RadioButton radioButton2_Team_Blue;
        private System.Windows.Forms.RadioButton radioButton1_Team_Red;
        private System.Windows.Forms.Button button2_Close;
    }
}