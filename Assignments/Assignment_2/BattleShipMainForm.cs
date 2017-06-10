using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BattleshipHiddenThreat
{
    public partial class BattleShipMainForm : Form
    {
        int robotDiscover = 0;
        List<Point> robotDiscoverMatrix = new List<Point>() { new Point(0, 0), new Point(0, 1), new Point(0, 2), new Point(3,0),
                                                            new Point(1, 0), new Point(1, 1), new Point(1, 2), new Point(3,1),
                                                            new Point(2, 0), new Point(2, 1), new Point(2, 2), new Point(3,2)};
        int playerDiscover = 0;
        List<Ship> robotFindShips = new List<Ship>();
        History history = new History(0);
        Ship[,] playerDeployment_ = new Ship[3, 4];
        Ship[,] robotDeployment_ = new Ship[3, 4];
        int[,] robotDiscoveredMatrix = new int[3, 4];
        Player human_;
        Player robot_;
        bool robotWin = false;
        bool humanWin = false;
        Random rand = new Random();

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
                if (human_.MyCards.InHandCards[i] is Peg)
                {
                    Peg pegCard = (Peg)human_.MyCards.InHandCards[i];
                    tableLayoutPanel4_PlayerHandCards.Controls[i].Text = pegCard.Name + pegCard.AttackNum;
                }
                else if(human_.MyCards.InHandCards[i] is Power)
                {
                    Power powerCard = (Power)human_.MyCards.InHandCards[i];
                    tableLayoutPanel4_PlayerHandCards.Controls[i].Text = powerCard.Name;
                }

            }
            listBox_GameHistory.DataSource = null;
            history.Add((history.HistoryCounter++), "Game Start." + playerName + " joins game. Team is " + playerTeam + ".");
            listBox_GameHistory.DataSource = history.HistoryList;
            label_GameStatus.Text = history.HistoryList[history.HistoryList.Count - 1];

            int first = rand.Next();
            if(first%2==0)
            {
                MessageBox.Show("Cool! You get first round!");
            }
            else
            {
                MessageBox.Show("Robot gets first round!");
                robotPlay();
            }
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
        private void robotDeploymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.Text.Contains("No Mode"))
            {
                string outputData = "";
                for (int i = 0; i < 12; i++)
                {
                    Ship currentRobotShip = robotDeployment_[i / 4, i % 4];
                    outputData += currentRobotShip.Name.PadRight(16);
                    if (i == 3 || i == 7)
                    {
                        outputData += "\n";
                    }
                }
                MessageBox.Show(outputData);
            }
            else
            {
                MessageBox.Show("Not Ready!");
            }
        }
        private void robotHandCardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!this.Text.Contains("No Mode"))
            {
                string outputData = "";
                for (int i = 0; i < 5; i++)
                {
                    if (robot_.MyCards.InHandCards[i] is Peg)
                    {
                        Peg card = (Peg)robot_.MyCards.InHandCards[i];
                        outputData += robot_.MyCards.InHandCards[i].Name + "   " + card.AttackNum + "\n";
                    }
                    else if(robot_.MyCards.InHandCards[i] is Power)
                    {
                        Power card = (Power)robot_.MyCards.InHandCards[i];
                        outputData += robot_.MyCards.InHandCards[i].Name + "\n";
                    }
                }
                MessageBox.Show(outputData);
            }
            else
            {
                MessageBox.Show("Not Ready!");
            }
        }
        private void outputHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (!this.Text.Contains("No Mode"))
            {
                string output = "";
                StreamWriter wr;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    wr = File.CreateText(saveFileDialog1.FileName);
                    for (int i = 0; i < history.HistoryList.Count; i++)
                    {
                        output += history.HistoryList[i] + "\n";
                    }
                    wr.Write(output);
                    wr.Close();
                }
            }
            else
            {
                MessageBox.Show("Not Ready!");
            }
        }
        private void BattleShipMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
                       
        private void button_RobotShip1_Click(object sender, EventArgs e)
        {
            playerPlay(0, 0);
            playerMatchRobotShip(button_RobotShip1);
            robotPlay();            
        }
        private void button_RobotShip2_Click(object sender, EventArgs e)
        {
            playerPlay(0, 1);
            playerMatchRobotShip(button_RobotShip2);
            robotPlay();
        }
        private void button_RobotShip3_Click(object sender, EventArgs e)
        {
            playerPlay(0, 2);
            playerMatchRobotShip(button_RobotShip3);
            robotPlay();
        }
        private void button_RobotShip4_Click(object sender, EventArgs e)
        {
            playerPlay(0, 3);
            playerMatchRobotShip(button_RobotShip4);
            robotPlay();
        }
        private void button_RobotShip5_Click(object sender, EventArgs e)
        {
            playerPlay(1, 0);
            playerMatchRobotShip(button_RobotShip5);
            robotPlay();
        }
        private void button_RobotShip6_Click(object sender, EventArgs e)
        {
            playerPlay(1, 1);
            playerMatchRobotShip(button_RobotShip6);
            robotPlay();
        }
        private void button_RobotShip7_Click(object sender, EventArgs e)
        {
            playerPlay(1, 2);
            playerMatchRobotShip(button_RobotShip7);
            robotPlay();
        }
        private void button_RobotShip8_Click(object sender, EventArgs e)
        {
            playerPlay(1, 3);
            playerMatchRobotShip(button_RobotShip8);
            robotPlay();
        }
        private void button_RobotShip9_Click(object sender, EventArgs e)
        {
            playerPlay(2, 0);
            playerMatchRobotShip(button_RobotShip9);
            robotPlay();
        }
        private void button_RobotShip10_Click(object sender, EventArgs e)
        {
            playerPlay(2, 1);
            playerMatchRobotShip(button_RobotShip10);
            robotPlay();
        }
        private void button_RobotShip11_Click(object sender, EventArgs e)
        {
            playerPlay(2, 2);
            playerMatchRobotShip(button_RobotShip11);
            robotPlay();
        }
        private void button_RobotShip12_Click(object sender, EventArgs e)
        {
            playerPlay(2, 3);
            playerMatchRobotShip(button_RobotShip12);
            robotPlay();
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
        private void robotPlay()
        {
            if (!humanWin)
            {
                if (robotFindShips.Count != 0)
                {
                    Random rand = new Random();
                    Ship targetShip = robotFindShips[rand.Next(robotFindShips.Count)];
                    Peg currentCard = (Peg)robotPlay_ChooseOneCardAttack(targetShip);
                    if (currentCard != null)
                    {
                        currentCard.useCard(targetShip);
                        robot_.MyCards.InHandCards.Remove(currentCard);
                        robot_.disCards(currentCard);
                        if (targetShip.Name != "Sea")
                        {
                            tableLayoutPanel3_PlayerSea.Controls[targetShip.DeploymentY * 4 + targetShip.DeploymentX].Text = playerDeployment_[targetShip.DeploymentY, targetShip.DeploymentX].Name + "\n(Health:" + playerDeployment_[targetShip.DeploymentY, targetShip.DeploymentX].HealthNum + ")";
                            if (targetShip.ShieldNum > 0)
                            {
                                tableLayoutPanel3_PlayerSea.Controls[targetShip.DeploymentY * 4 + targetShip.DeploymentX].Text +=
                                    "(Shield:" + targetShip.ShieldNum + ")";
                            }
                        }
                        if (!targetShip.Name.Contains("Sea") && targetShip.HealthNum <= 0)
                        {
                            tableLayoutPanel3_PlayerSea.Controls[targetShip.DeploymentY * 4 + targetShip.DeploymentX].Enabled = false;
                            updateHistory("Player's " + targetShip.Name + " is now sunk.");
                            robotFindShips.Remove(targetShip);
                            robotDiscover++;
                        }
                    }
                    else
                    {
                        robotPlay_FindNewShipOrOtherAct();
                    }
                }
                else
                {
                    robotPlay_FindNewShipOrOtherAct();
                }
                if (robotDiscover == 5)
                {
                    for (int i = 0; i < tableLayoutPanel2_RobotSea.Controls.Count; i++)
                    {
                        tableLayoutPanel2_RobotSea.Controls[i].Enabled = false;
                        tableLayoutPanel3_PlayerSea.Controls[i].Enabled = false;
                    }
                    for (int i = 0; i < tableLayoutPanel4_PlayerHandCards.Controls.Count; i++)
                    {
                        tableLayoutPanel4_PlayerHandCards.Controls[i].Enabled = false;
                    }
                    updateHistory("Robot Wins The Game.");
                    MessageBox.Show(":-(\nSad... You Lose...");
                    robotWin = true;
                }
                if (robot_.MyCards.InHandCards.Count < 5)
                {
                    robot_.MyCards.drawCards(5 - robot_.MyCards.InHandCards.Count);
                }
            }
        }
        private void robotPlay_FindNewShipOrOtherAct()
        {
            Random rand = new Random();
            Card currentCard;
            Peg pegCurrentCard;
            Power powerCurrentCard;
            if (robot_.MyCards.InHandCards.Count == 5)
            {                 
                currentCard = robot_.MyCards.InHandCards[rand.Next(5)];
                if(currentCard is Peg)
                {
                   pegCurrentCard = (Peg)currentCard;
                    if (pegCurrentCard.Color != "White")
                    {
                        for (int i = 0; i < robot_.MyCards.InHandCards.Count; i++)
                        {
                            if (robot_.MyCards.InHandCards[i] is Peg && robot_.MyCards.InHandCards[i].Name.Contains("White"))
                            {
                                currentCard = (Peg)robot_.MyCards.InHandCards[i];
                                break;
                            }
                        }
                    }
                    Point playerSea = robotDiscoverMatrix[rand.Next(robotDiscoverMatrix.Count)];
                    robotDiscoverMatrix.Remove(playerSea);
                    if (robotDiscoveredMatrix[playerSea.Y, playerSea.X] != 1)
                    {
                        Ship targetShip = playerDeployment_[playerSea.Y, playerSea.X];
                        targetShip.DeploymentX = playerSea.X;
                        targetShip.DeploymentY = playerSea.Y;
                        if (targetShip.Name != "Sea")
                        {
                            robotFindShips.Add(targetShip);
                        }
                        currentCard.useCard(targetShip);
                        robot_.disCards(pegCurrentCard);
                        updateHistory("Robot use " + currentCard.Name + " to find " + human_.Name + "'s " + targetShip.Name);
                        robot_.MyCards.InHandCards.Remove(pegCurrentCard);
                        tableLayoutPanel3_PlayerSea.Controls[targetShip.DeploymentY * 4 + targetShip.DeploymentX].Enabled = true;
                        if (targetShip.Name != "Sea")
                        {
                            tableLayoutPanel3_PlayerSea.Controls[targetShip.DeploymentY * 4 + targetShip.DeploymentX].Text = playerDeployment_[playerSea.Y, playerSea.X].Name + "\n(Health:" + playerDeployment_[playerSea.Y, playerSea.X].HealthNum + ")";
                            if (targetShip.ShieldNum > 0)
                            {
                                tableLayoutPanel3_PlayerSea.Controls[targetShip.DeploymentY * 4 + targetShip.DeploymentX].Text +=
                                    "(Shield:" + targetShip.ShieldNum + ")";
                            }
                        }
                        if (targetShip.HealthNum <= 0 && !targetShip.Name.Contains("Sea"))
                        {
                            tableLayoutPanel3_PlayerSea.Controls[targetShip.DeploymentY * 4 + targetShip.DeploymentX].Enabled = false;
                            updateHistory("Player's " + targetShip.Name + " is now sunk.");
                            robotFindShips.Remove(targetShip);
                            robotDiscover++;
                        }
                        robotDiscoveredMatrix[playerSea.Y, playerSea.X] = 1;
                    }
                }
                else
                {
                   powerCurrentCard = (Power)currentCard;
                    MessageBox.Show("Sorry, Power Card is not implemented yet!");
                    robot_.MyCards.InHandCards.Remove(powerCurrentCard);
                    robot_.disCards(powerCurrentCard);
                }
            }
            else
            {
                robot_.drawCards(1);
                robotPlay_FindNewShipOrOtherAct();
            }
            
        }
        private HandCard robotPlay_ChooseOneCardAttack(Ship targerShip)
        {
            if (targerShip.Name != "Submarine")
            {
                Dictionary<int, HandCard> choosedCardWithDamage = new Dictionary<int, HandCard>();
                for (int i = 0; i < robot_.MyCards.InHandCards.Count; i++)
                {
                    if (robot_.MyCards.InHandCards[i].Name.Contains("Red"))
                    {
                        Peg choosedPeg = (Peg)robot_.MyCards.InHandCards[i];
                        try
                        {
                            choosedCardWithDamage.Add(choosedPeg.AttackNum - targerShip.HealthNum, choosedPeg);
                        }
                        catch
                        {
                            Console.WriteLine("Dictionary find the same object, just ignore it");
                        }
                    }
                }
                int maxDamage = choosedCardWithDamage.Keys.Max();
                HandCard attack = choosedCardWithDamage[maxDamage];
                return attack;
            }
            else
            {
                for (int i = 0; i < robot_.MyCards.InHandCards.Count; i++)
                {
                    if (robot_.MyCards.InHandCards[i].Name==("White Peg"))
                    {
                        return robot_.MyCards.InHandCards[i];
                    }
                }
                //robotPlay_FindNewShipOrOtherAct();
                return null;
            }
        }
        private void playerMatchRobotShip(Button targetButton)
        {
            if (!robotWin)
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
                    if (robotDeployment_[y, x].ShieldNum > 0)
                    {
                        targetButton.Text += "(Shield:" + robotDeployment_[y, x].ShieldNum + ")";
                    }
                }
                if (robotDeployment_[y, x].HealthNum <= 0 && robotDeployment_[y, x].Name != "Sea")
                {
                    targetButton.Enabled = false;
                    updateHistory("Robot's " + robotDeployment_[y, x].Name + " is now sunk.");
                    playerDiscover++;
                }
                if (playerDiscover == 5)
                {
                    for (int i = 0; i < tableLayoutPanel2_RobotSea.Controls.Count; i++)
                    {
                        tableLayoutPanel2_RobotSea.Controls[i].Enabled = false;
                        tableLayoutPanel3_PlayerSea.Controls[i].Enabled = false;
                    }
                    for (int i = 0; i < tableLayoutPanel4_PlayerHandCards.Controls.Count; i++)
                    {
                        tableLayoutPanel4_PlayerHandCards.Controls[i].Enabled = false;
                    }
                    updateHistory("Player Wins The Game.");
                    MessageBox.Show(":-)\nGreat! You Win!");
                    humanWin = true;
                }
            }
        }
        private void playerPlay(int robotY, int robotX)
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
                        break;
                    }
                }
            }
            if (playerCardIndex > -1)
            {
                HandCard currentCard = human_.MyCards.InHandCards[playerCardIndex];
                currentCard.useCard(robotDeployment_[robotY, robotX]);
                human_.disCards(currentCard);
                human_.MyCards.InHandCards.Remove(currentCard);
                updateHistory("Player uses " + currentCard.Name + " to attack robot's " + robotDeployment_[robotY, robotX].Name);
                human_.MyCards.drawCards(1);
                for (int i = 0; i < 5; i++)
                {
                    tableLayoutPanel4_PlayerHandCards.Controls[i].Enabled = true;
                    if (human_.MyCards.InHandCards[i] is Peg)
                    {
                        Peg pegCard = (Peg)human_.MyCards.InHandCards[i];
                        tableLayoutPanel4_PlayerHandCards.Controls[i].Text = pegCard.Name + pegCard.AttackNum;
                    }
                    else if(human_.MyCards.InHandCards[i] is Power)
                    {
                        Power powerCard = (Power)human_.MyCards.InHandCards[i];
                        tableLayoutPanel4_PlayerHandCards.Controls[i].Text = powerCard.Name;
                    }
                }
            }
            else
            {
                MessageBox.Show("Please play one card to robot sea!");
            }
        }
        private void updateHistory(string addHistory)
        {
            history.Add(history.HistoryCounter++, addHistory);
            label_GameStatus.Text = history.HistoryList[history.HistoryList.Count - 1];
            listBox_GameHistory.DataSource = null;
            listBox_GameHistory.DataSource = history.HistoryList;
            listBox_GameHistory.SetSelected(history.HistoryCounter - 1, true);
        }
        private void playerShieldUse(RadioButton shieldCard)
        {
            if (shieldCard.Text == "Shield")
            {
                for (int i = 0; i < tableLayoutPanel3_PlayerSea.Controls.Count; i++)
                {
                    if (tableLayoutPanel3_PlayerSea.Controls[i].Text != "Sea" && tableLayoutPanel3_PlayerSea.Controls[i].Enabled == true)
                    {
                        tableLayoutPanel3_PlayerSea.Controls[i].ForeColor = Color.Yellow;
                        if (human_.Team == "Red")
                        {
                            tableLayoutPanel3_PlayerSea.Controls[i].BackColor = Color.Red;
                        }
                        else
                        {
                            tableLayoutPanel3_PlayerSea.Controls[i].BackColor = Color.Blue;
                        }
                    }
                }
            }
        }
        private void playerShipsAct(Button targetShip)
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
                if (currentCard.Name == "Shield")
                {
                    Ship myShip = playerDeployment_[0, 0];
                    myShip.ShieldNum += 2;
                    targetShip.Text += "(Shield:" + myShip.ShieldNum + ")";
                    if (human_.Team == "Red")
                    { targetShip.ForeColor = Color.Red; targetShip.BackColor = Control.DefaultBackColor; }
                    else
                    { targetShip.ForeColor = Color.Blue; targetShip.BackColor = Control.DefaultBackColor; }
                    human_.MyCards.InHandCards.Remove(currentCard);
                    human_.disCards(currentCard);
                    human_.drawCards(1);
                }
            }
        }

        private void radioButton1_MyCard1_CheckedChanged(object sender, EventArgs e)
        {
            playerShieldUse(radioButton1_MyCard1);
        }

        private void radioButton3_MyCard3_CheckedChanged(object sender, EventArgs e)
        {
            playerShieldUse(radioButton3_MyCard3);
        }

        private void radioButton4_MyCard4_CheckedChanged(object sender, EventArgs e)
        {
            playerShieldUse(radioButton4_MyCard4);
        }

        private void radioButton5_MyCard5_CheckedChanged(object sender, EventArgs e)
        {
            playerShieldUse(radioButton5_MyCard5);
        }

        private void button_PlayerShip1_Click(object sender, EventArgs e)
        {
            playerShipsAct(button_PlayerShip1);
            robotPlay();
        }
        private void button_PlayerShip2_Click(object sender, EventArgs e)
        {
            playerShipsAct(button_PlayerShip2);
            robotPlay();
        }

        private void button_PlayerShip3_Click(object sender, EventArgs e)
        {
            playerShipsAct(button_PlayerShip3);
            robotPlay();
        }

        private void button_PlayerShip4_Click(object sender, EventArgs e)
        {
            playerShipsAct(button_PlayerShip4);
            robotPlay();
        }

        private void button_PlayerShip5_Click(object sender, EventArgs e)
        {
            playerShipsAct(button_PlayerShip5);
            robotPlay();
        }

        private void button_PlayerShip6_Click(object sender, EventArgs e)
        {
            playerShipsAct(button_PlayerShip6);
            robotPlay();
        }

        private void button_PlayerShip7_Click(object sender, EventArgs e)
        {
            playerShipsAct(button_PlayerShip7);
            robotPlay();
        }

        private void button_PlayerShip8_Click(object sender, EventArgs e)
        {
            playerShipsAct(button_PlayerShip8);
            robotPlay();
        }

        private void button_PlayerShip9_Click(object sender, EventArgs e)
        {
            playerShipsAct(button_PlayerShip9);
            robotPlay();
        }

        private void button_PlayerShip10_Click(object sender, EventArgs e)
        {
            playerShipsAct(button_RobotShip10);
            robotPlay();
        }

        private void button_PlayerShip11_Click(object sender, EventArgs e)
        {
            playerShipsAct(button_RobotShip11);
            robotPlay();
        }

        private void button_PlayerShip12_Click(object sender, EventArgs e)
        {
            playerShipsAct(button_RobotShip12);
            robotPlay();
        }

        private void radioButton2_MyCard2_Click(object sender, EventArgs e)
        {
            playerShieldUse(radioButton2_MyCard2);
        }

        private void radioButton1_MyCard1_Click(object sender, EventArgs e)
        {
            playerShieldUse(radioButton1_MyCard1);
        }

        private void radioButton3_MyCard3_Click(object sender, EventArgs e)
        {
            playerShieldUse(radioButton3_MyCard3);
        }

        private void radioButton4_MyCard4_Click(object sender, EventArgs e)
        {
            playerShieldUse(radioButton4_MyCard4);
        }

        private void radioButton5_MyCard5_Click(object sender, EventArgs e)
        {
            playerShieldUse(radioButton5_MyCard5);
        }

        private void radioButton6_MyCard6_Click(object sender, EventArgs e)
        {
            playerShieldUse(radioButton6_MyCard6);
        }

        private void radioButton7_MyCard7_Click(object sender, EventArgs e)
        {
            playerShieldUse(radioButton7_MyCard7);
        }

        private void radioButton8_MyCard8_Click(object sender, EventArgs e)
        {
            playerShieldUse(radioButton8_MyCard8);
        }

        private void radioButton9_MyCard9_Click(object sender, EventArgs e)
        {
            playerShieldUse(radioButton9_MyCard9);
        }

        private void radioButton10_MyCard10_Click(object sender, EventArgs e)
        {
            playerShieldUse(radioButton10_MyCard10);
        }
    }
}
