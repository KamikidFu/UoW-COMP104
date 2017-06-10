using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleshipHiddenThreat
{
    public partial class BattleShipMainForm : Form
    {
        int robotDiscover = 0;
        int playerDiscover = 0;
        //Instance Variables
        History history = new History(0);
        Ship[,] playerDeployment_ = new Ship[3, 4];
        Ship[,] robotDeployment_ = new Ship[3, 4];
        Player human_;
        Player robot_;
        public BattleShipMainForm()
        {
            InitializeComponent();
            this.Text += "  [Not Start Game - No Mode Info]";
            if (this.Text.Contains("Not Start Game"))
            {
                for (int i = 0; i < groupBox1_Robot.Controls.Count; i++)
                {
                    groupBox1_Robot.Controls[i].Enabled = false;
                    groupBox2_Player.Controls[i].Enabled = false;
                }
                for (int i = 0; i < groupBox3_HandCard.Controls.Count; i++)
                {
                    groupBox3_HandCard.Controls[i].Enabled = false;
                }
            }

            history.Add(history.HistoryCounter++, "Application running.");
            history.Add(history.HistoryCounter++, "Waiting for game starts!");
            label_GameStatus.Text = history.HistoryList[history.HistoryList.Count - 1];
            listBox_GameHistory.DataSource = history.HistoryList;
        }

        public BattleShipMainForm(string playerName, string playerTeam, string playMode, History currentHistory
            , Ship[,] playerDeployment, Ship[,] robotDeployment)
        {
            InitializeComponent();

            human_ = new Player(playerName, playerTeam, playMode);
            string robotTeam = "";
            history = currentHistory;
            playerDeployment_ = playerDeployment;
            robotDeployment_ = robotDeployment;
            history.Add(history.HistoryCounter++, playerName + " starts a new game. Mode: " + playMode);
            this.Text += " [Welcome " + playerName + " Team: " + playerTeam + " Mode: " + playMode + "]";
            groupBox2_Player.Text += ": " + playerName;
            if (playerTeam == "Red")
            {
                groupBox1_Robot.ForeColor = Color.Blue;
                groupBox2_Player.ForeColor = Color.Red;
                groupBox3_HandCard.ForeColor = Color.Red;
                robotTeam = "Blue";
            }
            else
            {
                groupBox1_Robot.ForeColor = Color.Red;
                groupBox2_Player.ForeColor = Color.Blue;
                groupBox3_HandCard.ForeColor = Color.Blue;
                robotTeam = "Red";
            }
            if (playMode == "Full")
            {
                robot_ = new Player("NameMaxLengthOfHumanIs16", robotTeam, "Full");
            }
            else
            {
                robot_ = new Player("NameMaxLengthOfHumanIs16", robotTeam, "Base");
            }

            initialDeployShips(tableLayoutPanel3_PlayerSea, playerDeployment_);

            for (int j = 0; j < tableLayoutPanel2_RobotSea.Controls.Count; j++)
            {
                tableLayoutPanel2_RobotSea.Controls[j].Name = "Robot Ship";
                tableLayoutPanel2_RobotSea.Controls[j].Enabled = true;
            }
            for (int i = 0; i < 5; i++)
            {
                tableLayoutPanel4_PlayerHandCards.Controls[i].Enabled = true;
                if(human_.MyCards.InHandCards[i] is Peg)
                {
                    Peg pegCard = (Peg)human_.MyCards.InHandCards[i];
                    tableLayoutPanel4_PlayerHandCards.Controls[i].Text = pegCard.Name + pegCard.AttackNum;
                }
                
            }
            listBox_GameHistory.DataSource = null;
            history.Add((history.HistoryCounter++), "Game Start." + playerName + " joins game. Team is " + playerTeam + ".");
            listBox_GameHistory.DataSource = history.HistoryList;
            label_GameStatus.Text = history.HistoryList[history.HistoryList.Count - 1];
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void startNewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label_GameStatus.Text = history.HistoryList[history.HistoryList.Count - 1];
            this.Hide();
            NewGameSetting gameSetting = new NewGameSetting(this, history);
            gameSetting.Show();
        }

        private void initialDeployShips(TableLayoutPanel targetControl, Ship[,] playerDeploy)
        {
            int arrayX = 0;
            int arrayY = 0;
            for (int i = 0; i < targetControl.Controls.Count; i++)
            {
                if (targetControl.Controls[i] is Button)
                {

                    targetControl.Controls[i].Text = playerDeploy[arrayX, arrayY].Name;

                    //playerDeployment_[arrayX, arrayY] = playerDeploy[arrayX, arrayY];
                    arrayY++;
                    if (arrayY == 4)
                    {
                        arrayY = 0;
                        arrayX++;
                    }
                    targetControl.Controls[i].Enabled = false;
                }
            }
        }

        private void robotMatchShip(Button targetButton)
        {
            int buttonIndex = tableLayoutPanel2_RobotSea.Controls.GetChildIndex(targetButton);
            int x = buttonIndex % 4;
            int y = buttonIndex / 4;
            targetButton.Text = robotDeployment_[y, x].Name;
            if (targetButton.Text == "Sea")
            {
                targetButton.Enabled = false;
            }
            else
            {
                targetButton.Text += "\n(Health:" + robotDeployment_[y, x].HealthNum + ")";
            }
            if (robotDeployment_[y, x].HealthNum <= 0)
            {
                targetButton.Enabled = false;
                playerDiscover++;
            }
            if (playerDiscover == 12)
            {
                MessageBox.Show(":-)\nGreat! You Win!");
            }
        }

        private void updateHandCards()
        {
            //###############################################################################
            //This following commented codes are trying to add new row to TableLayoutPanel and new button to it
            //However, I try to make it, it do can add button and shift to a new line but it may have trouble 
            //or add difficulty to do further stuff. So I dicide to leave these unenficient code.
            //***This is the latest version I fix these code, may not right doing its works
            //###############################################################################
            //TableLayoutPanel newTableLayoutPanel4_PlayerHandCards = new TableLayoutPanel();
            //int handCardsNum = (tableLayoutPanel4_PlayerHandCards.Controls.Count) + 1;
            //int rowNum = 1;
            //int columnCounter = 0;
            //float columnSize = 100 * ((float)1 / 5);
            //TableLayoutPanelCellPosition pos = new TableLayoutPanelCellPosition(0,0);
            //tableLayoutPanel4_PlayerHandCards.Controls.Clear();
            //groupBox3_HandCard.Controls.RemoveAt(0);
            //groupBox3_HandCard.Controls.Clear();
            //newTableLayoutPanel4_PlayerHandCards.ColumnCount = 5;            
            //if(handCardsNum > 5)
            //{
            //    rowNum *= (int)(handCardsNum / 5) + 1;
            //    newTableLayoutPanel4_PlayerHandCards.RowCount = rowNum;
            //}
            //float rowSize = 100 * ((float)1 / rowNum);
            //for (int j = 0; j < rowNum; j++)
            //{
            //    newTableLayoutPanel4_PlayerHandCards.RowStyles.Add(new RowStyle(SizeType.Percent, rowSize));
            //    while(columnCounter != handCardsNum)
            //    {
            //        columnCounter++;
            //        newTableLayoutPanel4_PlayerHandCards.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, columnSize));
            //        newTableLayoutPanel4_PlayerHandCards.SetColumn(new Button() { Text = "Card No." + columnCounter.ToString() }, pos.Column);
            //        newTableLayoutPanel4_PlayerHandCards.Controls.Add(new Button() { Text = "Card No." + columnCounter.ToString() }, pos.Column, pos.Row);
            //        pos.Column++;
            //        if (columnCounter % 5 == 0) 
            //        {
            //            pos.Column = 0;
            //            break;
            //        }
            //    }
            //    pos.Row++;
            //}           
            //groupBox3_HandCard.Controls.Add(newTableLayoutPanel4_PlayerHandCards);
            //groupBox3_HandCard.Controls[0].Dock = DockStyle.Fill;
            //groupBox3_HandCard.Controls[0].Name = "tableLayoutPanel4_PlayerHandCards";            
        }



        private void BattleShipMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button_RobotShip1_Click(object sender, EventArgs e)
        {
            int playerCardIndex = -1;
            for (int i = 0; i < tableLayoutPanel4_PlayerHandCards.Controls.Count; i++)
            {
                if (tableLayoutPanel4_PlayerHandCards.Controls[i] is RadioButton)
                {
                    RadioButton r = (RadioButton)tableLayoutPanel4_PlayerHandCards.Controls[i];
                    if (r.Checked)
                    {
                        playerCardIndex = i;
                    }
                }
            }
            if (playerCardIndex > -1)
            {
                HandCard currentCard = human_.MyCards.InHandCards[playerCardIndex];
                currentCard.useCard(robotDeployment_[0, 0]);
                human_.MyCards.InHandCards.Remove(currentCard);
                human_.MyCards.drawCards(1);
                for (int i = 0; i < 5; i++)
                {
                    tableLayoutPanel4_PlayerHandCards.Controls[i].Enabled = true;
                    if (human_.MyCards.InHandCards[i] is Peg)
                    {
                        Peg pegCard = (Peg)human_.MyCards.InHandCards[i];
                        tableLayoutPanel4_PlayerHandCards.Controls[i].Text = pegCard.Name + pegCard.AttackNum;
                    }
                }
                robotMatchShip(button_RobotShip1);
            }
            else
            {
                MessageBox.Show("Please play one card to robot sea!");
            }
        }

        private void button_RobotShip2_Click(object sender, EventArgs e)
        {
            int playerCardIndex = -1;
            for (int i = 0; i < tableLayoutPanel4_PlayerHandCards.Controls.Count; i++)
            {
                if (tableLayoutPanel4_PlayerHandCards.Controls[i] is RadioButton)
                {
                    RadioButton r = (RadioButton)tableLayoutPanel4_PlayerHandCards.Controls[i];
                    if (r.Checked)
                    {
                        playerCardIndex = i;
                    }
                }
            }
            if (playerCardIndex > -1)
            {
                HandCard currentCard = human_.MyCards.InHandCards[playerCardIndex];
                currentCard.useCard(robotDeployment_[0, 1]);
                human_.MyCards.InHandCards.Remove(currentCard);
                human_.MyCards.drawCards(1);
                for (int i = 0; i < 5; i++)
                {
                    tableLayoutPanel4_PlayerHandCards.Controls[i].Enabled = true;
                    if (human_.MyCards.InHandCards[i] is Peg)
                    {
                        Peg pegCard = (Peg)human_.MyCards.InHandCards[i];
                        tableLayoutPanel4_PlayerHandCards.Controls[i].Text = pegCard.Name + pegCard.AttackNum;
                    }
                }
                robotMatchShip(button_RobotShip2);
            }
            else
            {
                MessageBox.Show("Please play one card to robot sea!");
            }
        }

        private void button_RobotShip3_Click(object sender, EventArgs e)
        {
            int playerCardIndex = -1;
            for (int i = 0; i < tableLayoutPanel4_PlayerHandCards.Controls.Count; i++)
            {
                if (tableLayoutPanel4_PlayerHandCards.Controls[i] is RadioButton)
                {
                    RadioButton r = (RadioButton)tableLayoutPanel4_PlayerHandCards.Controls[i];
                    if (r.Checked)
                    {
                        playerCardIndex = i;
                    }
                }
            }
            if (playerCardIndex > -1)
            {
                HandCard currentCard = human_.MyCards.InHandCards[playerCardIndex];
                currentCard.useCard(robotDeployment_[0, 2]);
                human_.MyCards.InHandCards.Remove(currentCard);
                human_.MyCards.drawCards(1);
                for (int i = 0; i < 5; i++)
                {
                    tableLayoutPanel4_PlayerHandCards.Controls[i].Enabled = true;
                    if (human_.MyCards.InHandCards[i] is Peg)
                    {
                        Peg pegCard = (Peg)human_.MyCards.InHandCards[i];
                        tableLayoutPanel4_PlayerHandCards.Controls[i].Text = pegCard.Name + pegCard.AttackNum;
                    }
                }
                robotMatchShip(button_RobotShip3);
            }
            else
            {
                MessageBox.Show("Please play one card to robot sea!");
            }
        }

        private void button_RobotShip4_Click(object sender, EventArgs e)
        {
            int playerCardIndex = -1;
            for (int i = 0; i < tableLayoutPanel4_PlayerHandCards.Controls.Count; i++)
            {
                if (tableLayoutPanel4_PlayerHandCards.Controls[i] is RadioButton)
                {
                    RadioButton r = (RadioButton)tableLayoutPanel4_PlayerHandCards.Controls[i];
                    if (r.Checked)
                    {
                        playerCardIndex = i;
                    }
                }
            }
            if (playerCardIndex > -1)
            {
                HandCard currentCard = human_.MyCards.InHandCards[playerCardIndex];
                currentCard.useCard(robotDeployment_[0, 3]);
                human_.MyCards.InHandCards.Remove(currentCard);
                human_.MyCards.drawCards(1);
                for (int i = 0; i < 5; i++)
                {
                    tableLayoutPanel4_PlayerHandCards.Controls[i].Enabled = true;
                    if (human_.MyCards.InHandCards[i] is Peg)
                    {
                        Peg pegCard = (Peg)human_.MyCards.InHandCards[i];
                        tableLayoutPanel4_PlayerHandCards.Controls[i].Text = pegCard.Name + pegCard.AttackNum;
                    }
                }
                robotMatchShip(button_RobotShip4);
            }
            else
            {
                MessageBox.Show("Please play one card to robot sea!");
            }
        }

        private void button_RobotShip5_Click(object sender, EventArgs e)
        {
            int playerCardIndex = -1;
            for (int i = 0; i < tableLayoutPanel4_PlayerHandCards.Controls.Count; i++)
            {
                if (tableLayoutPanel4_PlayerHandCards.Controls[i] is RadioButton)
                {
                    RadioButton r = (RadioButton)tableLayoutPanel4_PlayerHandCards.Controls[i];
                    if (r.Checked)
                    {
                        playerCardIndex = i;
                    }
                }
            }
            if (playerCardIndex > -1)
            {
                HandCard currentCard = human_.MyCards.InHandCards[playerCardIndex];
                currentCard.useCard(robotDeployment_[1, 0]);
                human_.MyCards.InHandCards.Remove(currentCard);
                human_.MyCards.drawCards(1);
                for (int i = 0; i < 5; i++)
                {
                    tableLayoutPanel4_PlayerHandCards.Controls[i].Enabled = true;
                    if (human_.MyCards.InHandCards[i] is Peg)
                    {
                        Peg pegCard = (Peg)human_.MyCards.InHandCards[i];
                        tableLayoutPanel4_PlayerHandCards.Controls[i].Text = pegCard.Name + pegCard.AttackNum;
                    }
                }
                robotMatchShip(button_RobotShip5);
            }
            else
            {
                MessageBox.Show("Please play one card to robot sea!");
            }
        }

        private void button_RobotShip6_Click(object sender, EventArgs e)
        {
            int playerCardIndex = -1;
            for (int i = 0; i < tableLayoutPanel4_PlayerHandCards.Controls.Count; i++)
            {
                if (tableLayoutPanel4_PlayerHandCards.Controls[i] is RadioButton)
                {
                    RadioButton r = (RadioButton)tableLayoutPanel4_PlayerHandCards.Controls[i];
                    if (r.Checked)
                    {
                        playerCardIndex = i;
                    }
                }
            }
            if (playerCardIndex > -1)
            {
                HandCard currentCard = human_.MyCards.InHandCards[playerCardIndex];
                currentCard.useCard(robotDeployment_[1, 1]);
                human_.MyCards.InHandCards.Remove(currentCard);
                human_.MyCards.drawCards(1);
                for (int i = 0; i < 5; i++)
                {
                    tableLayoutPanel4_PlayerHandCards.Controls[i].Enabled = true;
                    if (human_.MyCards.InHandCards[i] is Peg)
                    {
                        Peg pegCard = (Peg)human_.MyCards.InHandCards[i];
                        tableLayoutPanel4_PlayerHandCards.Controls[i].Text = pegCard.Name + pegCard.AttackNum;
                    }
                }
                robotMatchShip(button_RobotShip6);
            }
            else
            {
                MessageBox.Show("Please play one card to robot sea!");
            }
        }

        private void button_RobotShip7_Click(object sender, EventArgs e)
        {
            int playerCardIndex = -1;
            for (int i = 0; i < tableLayoutPanel4_PlayerHandCards.Controls.Count; i++)
            {
                if (tableLayoutPanel4_PlayerHandCards.Controls[i] is RadioButton)
                {
                    RadioButton r = (RadioButton)tableLayoutPanel4_PlayerHandCards.Controls[i];
                    if (r.Checked)
                    {
                        playerCardIndex = i;
                    }
                }
            }
            if (playerCardIndex > -1)
            {
                HandCard currentCard = human_.MyCards.InHandCards[playerCardIndex];
                currentCard.useCard(robotDeployment_[1, 2]);
                human_.MyCards.InHandCards.Remove(currentCard);
                human_.MyCards.drawCards(1);
                for (int i = 0; i < 5; i++)
                {
                    tableLayoutPanel4_PlayerHandCards.Controls[i].Enabled = true;
                    if (human_.MyCards.InHandCards[i] is Peg)
                    {
                        Peg pegCard = (Peg)human_.MyCards.InHandCards[i];
                        tableLayoutPanel4_PlayerHandCards.Controls[i].Text = pegCard.Name + pegCard.AttackNum;
                    }
                }
                robotMatchShip(button_RobotShip7);
            }
            else
            {
                MessageBox.Show("Please play one card to robot sea!");
            }
        }

        private void button_RobotShip8_Click(object sender, EventArgs e)
        {
            int playerCardIndex = -1;
            for (int i = 0; i < tableLayoutPanel4_PlayerHandCards.Controls.Count; i++)
            {
                if (tableLayoutPanel4_PlayerHandCards.Controls[i] is RadioButton)
                {
                    RadioButton r = (RadioButton)tableLayoutPanel4_PlayerHandCards.Controls[i];
                    if (r.Checked)
                    {
                        playerCardIndex = i;
                    }
                }
            }
            if (playerCardIndex > -1)
            {
                HandCard currentCard = human_.MyCards.InHandCards[playerCardIndex];
                currentCard.useCard(robotDeployment_[1, 3]);
                human_.MyCards.InHandCards.Remove(currentCard);
                human_.MyCards.drawCards(1);
                for (int i = 0; i < 5; i++)
                {
                    tableLayoutPanel4_PlayerHandCards.Controls[i].Enabled = true;
                    if (human_.MyCards.InHandCards[i] is Peg)
                    {
                        Peg pegCard = (Peg)human_.MyCards.InHandCards[i];
                        tableLayoutPanel4_PlayerHandCards.Controls[i].Text = pegCard.Name + pegCard.AttackNum;
                    }
                }
                robotMatchShip(button_RobotShip8);
            }
            else
            {
                MessageBox.Show("Please play one card to robot sea!");
            }
        }

        private void button_RobotShip9_Click(object sender, EventArgs e)
        {
            int playerCardIndex = -1;
            for (int i = 0; i < tableLayoutPanel4_PlayerHandCards.Controls.Count; i++)
            {
                if (tableLayoutPanel4_PlayerHandCards.Controls[i] is RadioButton)
                {
                    RadioButton r = (RadioButton)tableLayoutPanel4_PlayerHandCards.Controls[i];
                    if (r.Checked)
                    {
                        playerCardIndex = i;
                    }
                }
            }
            if (playerCardIndex > -1)
            {
                HandCard currentCard = human_.MyCards.InHandCards[playerCardIndex];
                currentCard.useCard(robotDeployment_[2, 0]);
                human_.MyCards.InHandCards.Remove(currentCard);
                human_.MyCards.drawCards(1);
                for (int i = 0; i < 5; i++)
                {
                    tableLayoutPanel4_PlayerHandCards.Controls[i].Enabled = true;
                    if (human_.MyCards.InHandCards[i] is Peg)
                    {
                        Peg pegCard = (Peg)human_.MyCards.InHandCards[i];
                        tableLayoutPanel4_PlayerHandCards.Controls[i].Text = pegCard.Name + pegCard.AttackNum;
                    }
                }
                robotMatchShip(button_RobotShip9);
            }
            else
            {
                MessageBox.Show("Please play one card to robot sea!");
            }
        }

        private void button_RobotShip10_Click(object sender, EventArgs e)
        {
            int playerCardIndex = -1;
            for (int i = 0; i < tableLayoutPanel4_PlayerHandCards.Controls.Count; i++)
            {
                if (tableLayoutPanel4_PlayerHandCards.Controls[i] is RadioButton)
                {
                    RadioButton r = (RadioButton)tableLayoutPanel4_PlayerHandCards.Controls[i];
                    if (r.Checked)
                    {
                        playerCardIndex = i;
                    }
                }
            }
            if (playerCardIndex > -1)
            {
                HandCard currentCard = human_.MyCards.InHandCards[playerCardIndex];
                currentCard.useCard(robotDeployment_[2, 1]);
                human_.MyCards.InHandCards.Remove(currentCard);
                human_.MyCards.drawCards(1);
                for (int i = 0; i < 5; i++)
                {
                    tableLayoutPanel4_PlayerHandCards.Controls[i].Enabled = true;
                    if (human_.MyCards.InHandCards[i] is Peg)
                    {
                        Peg pegCard = (Peg)human_.MyCards.InHandCards[i];
                        tableLayoutPanel4_PlayerHandCards.Controls[i].Text = pegCard.Name + pegCard.AttackNum;
                    }
                }
                robotMatchShip(button_RobotShip10);
            }
            else
            {
                MessageBox.Show("Please play one card to robot sea!");
            }
        }

        private void button_RobotShip11_Click(object sender, EventArgs e)
        {
            int playerCardIndex = -1;
            for (int i = 0; i < tableLayoutPanel4_PlayerHandCards.Controls.Count; i++)
            {
                if (tableLayoutPanel4_PlayerHandCards.Controls[i] is RadioButton)
                {
                    RadioButton r = (RadioButton)tableLayoutPanel4_PlayerHandCards.Controls[i];
                    if (r.Checked)
                    {
                        playerCardIndex = i;
                    }
                }
            }
            if (playerCardIndex > -1)
            {
                HandCard currentCard = human_.MyCards.InHandCards[playerCardIndex];
                currentCard.useCard(robotDeployment_[2, 2]);
                human_.MyCards.InHandCards.Remove(currentCard);
                human_.MyCards.drawCards(1);
                for (int i = 0; i < 5; i++)
                {
                    tableLayoutPanel4_PlayerHandCards.Controls[i].Enabled = true;
                    if (human_.MyCards.InHandCards[i] is Peg)
                    {
                        Peg pegCard = (Peg)human_.MyCards.InHandCards[i];
                        tableLayoutPanel4_PlayerHandCards.Controls[i].Text = pegCard.Name + pegCard.AttackNum;
                    }
                }
                robotMatchShip(button_RobotShip11);
            }
            else
            {
                MessageBox.Show("Please play one card to robot sea!");
            }
        }

        private void button_RobotShip12_Click(object sender, EventArgs e)
        {
            int playerCardIndex = -1;
            for (int i = 0; i < tableLayoutPanel4_PlayerHandCards.Controls.Count; i++)
            {
                if (tableLayoutPanel4_PlayerHandCards.Controls[i] is RadioButton)
                {
                    RadioButton r = (RadioButton)tableLayoutPanel4_PlayerHandCards.Controls[i];
                    if (r.Checked)
                    {
                        playerCardIndex = i;
                    }
                }
            }
            if (playerCardIndex > -1)
            {
                HandCard currentCard = human_.MyCards.InHandCards[playerCardIndex];
                currentCard.useCard(robotDeployment_[2, 3]);
                human_.MyCards.InHandCards.Remove(currentCard);
                human_.MyCards.drawCards(1);
                for (int i = 0; i < 5; i++)
                {
                    tableLayoutPanel4_PlayerHandCards.Controls[i].Enabled = true;
                    if (human_.MyCards.InHandCards[i] is Peg)
                    {
                        Peg pegCard = (Peg)human_.MyCards.InHandCards[i];
                        tableLayoutPanel4_PlayerHandCards.Controls[i].Text = pegCard.Name + pegCard.AttackNum;
                    }
                }
                robotMatchShip(button_RobotShip12);
            }
            else
            {
                MessageBox.Show("Please play one card to robot sea!");
            }
        }
    }
}
