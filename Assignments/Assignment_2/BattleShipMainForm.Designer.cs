namespace BattleshipHiddenThreat
{
    partial class BattleShipMainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1_MainForm = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2_Player = new System.Windows.Forms.GroupBox();
            this.groupBox3_HandCard = new System.Windows.Forms.GroupBox();
            this.groupBox1_Robot = new System.Windows.Forms.GroupBox();
            this.menuStrip1_SettingMenu = new System.Windows.Forms.MenuStrip();
            this.gamePlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startNewGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tableLayoutPanel2_RobotSea = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3_PlayerSea = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4_PlayerHandCards = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5_PlayerFunctionArea = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox4_Function = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1_MainForm.SuspendLayout();
            this.groupBox2_Player.SuspendLayout();
            this.groupBox3_HandCard.SuspendLayout();
            this.groupBox1_Robot.SuspendLayout();
            this.menuStrip1_SettingMenu.SuspendLayout();
            this.tableLayoutPanel5_PlayerFunctionArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1_MainForm
            // 
            this.tableLayoutPanel1_MainForm.ColumnCount = 1;
            this.tableLayoutPanel1_MainForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1_MainForm.Controls.Add(this.groupBox2_Player, 0, 2);
            this.tableLayoutPanel1_MainForm.Controls.Add(this.groupBox3_HandCard, 0, 3);
            this.tableLayoutPanel1_MainForm.Controls.Add(this.groupBox1_Robot, 0, 1);
            this.tableLayoutPanel1_MainForm.Controls.Add(this.menuStrip1_SettingMenu, 0, 0);
            this.tableLayoutPanel1_MainForm.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1_MainForm.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1_MainForm.Name = "tableLayoutPanel1_MainForm";
            this.tableLayoutPanel1_MainForm.RowCount = 4;
            this.tableLayoutPanel1_MainForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5.882353F));
            this.tableLayoutPanel1_MainForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.29412F));
            this.tableLayoutPanel1_MainForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35.29412F));
            this.tableLayoutPanel1_MainForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.52941F));
            this.tableLayoutPanel1_MainForm.Size = new System.Drawing.Size(483, 457);
            this.tableLayoutPanel1_MainForm.TabIndex = 0;
            // 
            // groupBox2_Player
            // 
            this.groupBox2_Player.Controls.Add(this.tableLayoutPanel3_PlayerSea);
            this.groupBox2_Player.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2_Player.Location = new System.Drawing.Point(3, 194);
            this.groupBox2_Player.Name = "groupBox2_Player";
            this.groupBox2_Player.Size = new System.Drawing.Size(468, 137);
            this.groupBox2_Player.TabIndex = 1;
            this.groupBox2_Player.TabStop = false;
            this.groupBox2_Player.Text = "Player";
            // 
            // groupBox3_HandCard
            // 
            this.groupBox3_HandCard.Controls.Add(this.tableLayoutPanel4_PlayerHandCards);
            this.groupBox3_HandCard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3_HandCard.Location = new System.Drawing.Point(3, 361);
            this.groupBox3_HandCard.Name = "groupBox3_HandCard";
            this.groupBox3_HandCard.Size = new System.Drawing.Size(468, 90);
            this.groupBox3_HandCard.TabIndex = 2;
            this.groupBox3_HandCard.TabStop = false;
            this.groupBox3_HandCard.Text = "Hand Cards";
            // 
            // groupBox1_Robot
            // 
            this.groupBox1_Robot.Controls.Add(this.tableLayoutPanel2_RobotSea);
            this.groupBox1_Robot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1_Robot.Location = new System.Drawing.Point(3, 27);
            this.groupBox1_Robot.Name = "groupBox1_Robot";
            this.groupBox1_Robot.Size = new System.Drawing.Size(468, 138);
            this.groupBox1_Robot.TabIndex = 0;
            this.groupBox1_Robot.TabStop = false;
            this.groupBox1_Robot.Text = "Robot";
            // 
            // menuStrip1_SettingMenu
            // 
            this.menuStrip1_SettingMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gamePlayToolStripMenuItem});
            this.menuStrip1_SettingMenu.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1_SettingMenu.Name = "menuStrip1_SettingMenu";
            this.menuStrip1_SettingMenu.Size = new System.Drawing.Size(483, 23);
            this.menuStrip1_SettingMenu.TabIndex = 3;
            this.menuStrip1_SettingMenu.Text = "menuStrip1_SettingMenu";
            // 
            // gamePlayToolStripMenuItem
            // 
            this.gamePlayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startNewGameToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.gamePlayToolStripMenuItem.Name = "gamePlayToolStripMenuItem";
            this.gamePlayToolStripMenuItem.Size = new System.Drawing.Size(75, 19);
            this.gamePlayToolStripMenuItem.Text = "Game Play";
            // 
            // startNewGameToolStripMenuItem
            // 
            this.startNewGameToolStripMenuItem.Name = "startNewGameToolStripMenuItem";
            this.startNewGameToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.startNewGameToolStripMenuItem.Text = "Start New Game";
            this.startNewGameToolStripMenuItem.Click += new System.EventHandler(this.startNewGameToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // tableLayoutPanel2_RobotSea
            // 
            this.tableLayoutPanel2_RobotSea.ColumnCount = 4;
            this.tableLayoutPanel2_RobotSea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2_RobotSea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2_RobotSea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2_RobotSea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2_RobotSea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2_RobotSea.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2_RobotSea.Name = "tableLayoutPanel2_RobotSea";
            this.tableLayoutPanel2_RobotSea.RowCount = 3;
            this.tableLayoutPanel2_RobotSea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2_RobotSea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2_RobotSea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel2_RobotSea.Size = new System.Drawing.Size(462, 119);
            this.tableLayoutPanel2_RobotSea.TabIndex = 0;
            // 
            // tableLayoutPanel3_PlayerSea
            // 
            this.tableLayoutPanel3_PlayerSea.ColumnCount = 4;
            this.tableLayoutPanel3_PlayerSea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3_PlayerSea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3_PlayerSea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3_PlayerSea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel3_PlayerSea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3_PlayerSea.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3_PlayerSea.Name = "tableLayoutPanel3_PlayerSea";
            this.tableLayoutPanel3_PlayerSea.RowCount = 3;
            this.tableLayoutPanel3_PlayerSea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3_PlayerSea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3_PlayerSea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3_PlayerSea.Size = new System.Drawing.Size(462, 118);
            this.tableLayoutPanel3_PlayerSea.TabIndex = 0;
            // 
            // tableLayoutPanel4_PlayerHandCards
            // 
            this.tableLayoutPanel4_PlayerHandCards.ColumnCount = 5;
            this.tableLayoutPanel4_PlayerHandCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4_PlayerHandCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4_PlayerHandCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4_PlayerHandCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4_PlayerHandCards.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4_PlayerHandCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4_PlayerHandCards.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4_PlayerHandCards.Name = "tableLayoutPanel4_PlayerHandCards";
            this.tableLayoutPanel4_PlayerHandCards.RowCount = 1;
            this.tableLayoutPanel4_PlayerHandCards.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4_PlayerHandCards.Size = new System.Drawing.Size(462, 71);
            this.tableLayoutPanel4_PlayerHandCards.TabIndex = 0;
            // 
            // tableLayoutPanel5_PlayerFunctionArea
            // 
            this.tableLayoutPanel5_PlayerFunctionArea.ColumnCount = 1;
            this.tableLayoutPanel5_PlayerFunctionArea.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5_PlayerFunctionArea.Controls.Add(this.groupBox4_Function, 0, 0);
            this.tableLayoutPanel5_PlayerFunctionArea.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel5_PlayerFunctionArea.Location = new System.Drawing.Point(0, 420);
            this.tableLayoutPanel5_PlayerFunctionArea.Name = "tableLayoutPanel5_PlayerFunctionArea";
            this.tableLayoutPanel5_PlayerFunctionArea.RowCount = 1;
            this.tableLayoutPanel5_PlayerFunctionArea.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5_PlayerFunctionArea.Size = new System.Drawing.Size(483, 100);
            this.tableLayoutPanel5_PlayerFunctionArea.TabIndex = 1;
            // 
            // groupBox4_Function
            // 
            this.groupBox4_Function.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4_Function.Location = new System.Drawing.Point(3, 3);
            this.groupBox4_Function.Name = "groupBox4_Function";
            this.groupBox4_Function.Size = new System.Drawing.Size(477, 94);
            this.groupBox4_Function.TabIndex = 0;
            this.groupBox4_Function.TabStop = false;
            this.groupBox4_Function.Text = "Function";
            // 
            // BattleShipMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 520);
            this.Controls.Add(this.tableLayoutPanel5_PlayerFunctionArea);
            this.Controls.Add(this.tableLayoutPanel1_MainForm);
            this.MaximizeBox = false;
            this.Name = "BattleShipMainForm";
            this.Text = "BattleShip Hidden Threat";
            this.tableLayoutPanel1_MainForm.ResumeLayout(false);
            this.tableLayoutPanel1_MainForm.PerformLayout();
            this.groupBox2_Player.ResumeLayout(false);
            this.groupBox3_HandCard.ResumeLayout(false);
            this.groupBox1_Robot.ResumeLayout(false);
            this.menuStrip1_SettingMenu.ResumeLayout(false);
            this.menuStrip1_SettingMenu.PerformLayout();
            this.tableLayoutPanel5_PlayerFunctionArea.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1_MainForm;
        private System.Windows.Forms.GroupBox groupBox2_Player;
        private System.Windows.Forms.GroupBox groupBox3_HandCard;
        private System.Windows.Forms.GroupBox groupBox1_Robot;
        private System.Windows.Forms.MenuStrip menuStrip1_SettingMenu;
        private System.Windows.Forms.ToolStripMenuItem gamePlayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startNewGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3_PlayerSea;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4_PlayerHandCards;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2_RobotSea;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5_PlayerFunctionArea;
        private System.Windows.Forms.GroupBox groupBox4_Function;
    }
}

