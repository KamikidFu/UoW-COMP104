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
        //Instance Variables
        History history = new History(0);
        Ship[,] playerDeployment_ = new Ship[3, 4];
        Ship[,] robotDeployment_ = new Ship[3, 4];

        public BattleShipMainForm()
        {
            InitializeComponent();
            this.Text += "  [Not Start Game - No Mode Info]";
            if(this.Text.Contains("Not Start Game"))
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
            
            history.Add(history.HistoryCounter++,"Application running.");            
            history.Add(history.HistoryCounter++, "Waiting for game starts!");
            label_GameStatus.Text = history.HistoryList[history.HistoryList.Count - 1];
            listBox_GameHistory.DataSource = history.HistoryList;
        }

        public BattleShipMainForm(string playerName, string playerTeam, string playMode, History currentHistory, Ship[,] playerDeployment)
        {
            InitializeComponent();
            history = currentHistory;
            history.Add(history.HistoryCounter++, playerName + " starts a new game. Mode: "+playMode);
            this.Text += " [Welcome " + playerName + " Team: " + playerTeam + " Mode: " + playMode + "]";
            groupBox2_Player.Text += ": " + playerName;
            if(playerTeam=="Red")
            {
                groupBox1_Robot.ForeColor = Color.Blue;
                groupBox2_Player.ForeColor = Color.Red;
            }
            else
            {
                groupBox1_Robot.ForeColor = Color.Red;
                groupBox2_Player.ForeColor = Color.Blue;
            }

            deployPlayerShips(playerDeployment);

            listBox_GameHistory.DataSource = null;
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

        private void deployPlayerShips(Ship[,] playerDeploy)
        {
            int arrayX = 0;
            int arrayY = 0;
            for (int i = 0; i < tableLayoutPanel3_PlayerSea.Controls.Count; i++)
            {
                if (tableLayoutPanel3_PlayerSea.Controls[i] is Button)
                {
                    tableLayoutPanel3_PlayerSea.Controls[i].Text = playerDeploy[arrayX, arrayY].Name;
                    playerDeployment_[arrayX, arrayY] = playerDeploy[arrayX, arrayY];
                    arrayY++;
                    if (arrayY == 4)
                    {
                        arrayY = 0;
                        arrayX++;
                    }
                    tableLayoutPanel3_PlayerSea.Controls[i].Enabled = false;
                }
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
    }
}
