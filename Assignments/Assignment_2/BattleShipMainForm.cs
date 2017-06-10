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
        int robotDiscoveredShipButtonIndex = 0;
        int robotDiscoveredExceptionShipButtonIndex = 0;
        //List<int> robotXDiscover = new List<int>() { 0, 1, 2, 3, 0, 1, 2, 3, 0, 1, 2, 3 };
        //List<int> robotYDiscover = new List<int>() { 0, 1, 2, 0, 1, 2, 0, 1, 2, 0, 1, 2 };
        List<Point> robotDiscoverMatrix = new List<Point>() { new Point(0, 0), new Point(0, 1), new Point(0, 2), new Point(3,0),
                                                            new Point(1, 0), new Point(1, 1), new Point(1, 2), new Point(3,1),
                                                            new Point(2, 0), new Point(2, 1), new Point(2, 2), new Point(3,2)};
        int playerDiscover = 0;
        Ship robotFindShip = null;
        Ship robotFindWhiteExceptionShip = null;
        Ship robotFindRedExceptionShip = null;
        List<Ship> robotFindShips = new List<Ship>();
        //Instance Variables
        History history = new History(0);
        Ship[,] playerDeployment_ = new Ship[3, 4];
        Ship[,] robotDeployment_ = new Ship[3, 4];
        int[,] robotDiscoveredMatrix = new int[3, 4];
        Player human_;
        Player robot_;
        bool robothavingWhite = true;
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

        private void robotPlay()
        {
            if(robotFindShips.Count!=0)
            {
                Random rand = new Random();
                Ship targetShip = robotFindShips[rand.Next(robotFindShips.Count)];
                Peg currentCard = (Peg)robotPlay_ChooseOneCardAttack(targetShip);
                if(currentCard!=null)
                {
                    currentCard.useCard(targetShip);
                    if (targetShip.Name != "Sea")
                    {
                        tableLayoutPanel3_PlayerSea.Controls[targetShip.DeploymentY * 4 + targetShip.DeploymentX].Text = playerDeployment_[targetShip.DeploymentY, targetShip.DeploymentX].Name + "\n(Health:" + playerDeployment_[targetShip.DeploymentY, targetShip.DeploymentX].HealthNum + ")";
                    }
                    if (!targetShip.Name.Contains("Sea")&& targetShip.HealthNum<=0)
                    {
                        tableLayoutPanel3_PlayerSea.Controls[targetShip.DeploymentY * 4 + targetShip.DeploymentX].Enabled = false;
                        updateHistory("Player's " + targetShip.Name + " is now sunk.");
                        robotFindShips.Remove(targetShip);
                        robotDiscover++;
                    }
                }
                else
                {
                    robotPlay_FindNewShip();
                }
            }
            else
            {
                robotPlay_FindNewShip();
            }
            if (robotDiscover == 5)
            {
                updateHistory("Robot Wins The Game.");
                MessageBox.Show(":-(\nSad... You Lose...");
            }
            if (robot_.MyCards.InHandCards.Count < 5)
            {
                robot_.MyCards.drawCards(5 - robot_.MyCards.InHandCards.Count);
            }
        }
        private void robotPlay_FindNewShip()
        {
            Random rand = new Random();
            Peg currentCard = (Peg)robot_.MyCards.InHandCards[rand.Next(5)];
            if (currentCard.Color != "White")
            {
                for (int i = 0; i < robot_.MyCards.InHandCards.Count; i++)
                {
                    if (robot_.MyCards.InHandCards[i].Name.Contains("White"))
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
                updateHistory("Robot use " + currentCard.Name + " to find " + human_.Name + "'s " + targetShip.Name);
                robot_.MyCards.InHandCards.Remove(currentCard);
                tableLayoutPanel3_PlayerSea.Controls[targetShip.DeploymentY*4+targetShip.DeploymentX].Enabled = true;
                if (targetShip.Name != "Sea")
                {
                    tableLayoutPanel3_PlayerSea.Controls[targetShip.DeploymentY * 4 + targetShip.DeploymentX].Text = playerDeployment_[playerSea.Y, playerSea.X].Name + "\n(Health:" + playerDeployment_[playerSea.Y, playerSea.X].HealthNum + ")";
                }
                if(targetShip.HealthNum<=0 && !targetShip.Name.Contains("Sea"))
                {
                    tableLayoutPanel3_PlayerSea.Controls[targetShip.DeploymentY * 4 + targetShip.DeploymentX].Enabled = false;
                    updateHistory("Player's " + robotFindWhiteExceptionShip.Name + " is now sunk.");
                    robotFindShips.Remove(targetShip);
                    robotDiscover++;
                }
                robotDiscoveredMatrix[playerSea.Y, playerSea.X] = 1;
            }
        }

        private HandCard robotPlay_ChooseOneCardAttack(Ship targerShip)
        {
            if(targerShip.Name!="Submarine")
            {
                Dictionary<int, HandCard> choosedCardWithDamage = new Dictionary<int, HandCard>();
                for(int i=0;i<robot_.MyCards.InHandCards.Count;i++)
                {
                    if(robot_.MyCards.InHandCards[i].Name.Contains("Red"))
                    {
                        Peg choosedPeg = (Peg)robot_.MyCards.InHandCards[i];
                        try
                        {
                            choosedCardWithDamage.Add(choosedPeg.AttackNum - targerShip.HealthNum, choosedPeg);
                        }
                        catch
                        {

                        }
                    }
                }
                int maxDamage = choosedCardWithDamage.Keys.Max();
                HandCard attack = choosedCardWithDamage[maxDamage];
                return attack;               
            }
            else
            {
                for(int i=0;i<robot_.MyCards.InHandCards.Count;i++)
                {
                    if(robot_.MyCards.InHandCards[i].Name.Contains("White"))
                    {
                        return robot_.MyCards.InHandCards[i];
                    }
                }
                robotPlay_FindNewShip();
                return null;
            }
        }

        private void robotAutoPlay()
        {
            if (robotFindShip == null || robotFindShip.Name == "Sea")
            {
                Random rand = new Random();
                int cardIndex = rand.Next(5);
                Peg currentCard = (Peg)robot_.MyCards.InHandCards[cardIndex];
                if (currentCard.Color != "White" && robothavingWhite != false)
                {
                    for (int i = 0; i < robot_.MyCards.InHandCards.Count; i++)
                    {
                        if (robot_.MyCards.InHandCards[i].Name.Contains("White"))
                        {
                            currentCard = (Peg)robot_.MyCards.InHandCards[i];
                            break;
                        }
                        robothavingWhite = false;
                    }
                }
                //int playerSeaX = robotXDiscover[rand.Next(robotXDiscover.Count)];
                //robotXDiscover.Remove(playerSeaX);
                //int playerSeaY = robotYDiscover[rand.Next(robotYDiscover.Count)];
                //robotYDiscover.Remove(playerSeaY);
                Point playerSea = robotDiscoverMatrix[rand.Next(robotDiscoverMatrix.Count)];
                robotDiscoverMatrix.Remove(playerSea);
                if (robotDiscoveredMatrix[playerSea.Y, playerSea.X] != 1)
                {
                    Ship targerShip = playerDeployment_[playerSea.Y, playerSea.X];
                    robotFindShip = targerShip;
                    currentCard.useCard(targerShip);
                    updateHistory("Robot use " + currentCard.Name + " to find " + human_.Name + "'s " + targerShip.Name);
                    robot_.MyCards.InHandCards.Remove(currentCard);
                    int playerShipButtonIndex = playerSea.Y * 4 + playerSea.X;
                    robotDiscoveredShipButtonIndex = playerShipButtonIndex;
                    tableLayoutPanel3_PlayerSea.Controls[playerShipButtonIndex].Enabled = true;
                    if (robotFindShip.Name != "Sea")
                    {
                        tableLayoutPanel3_PlayerSea.Controls[playerShipButtonIndex].Text = playerDeployment_[playerSea.Y, playerSea.X].Name + "\n(Health:" + playerDeployment_[playerSea.Y, playerSea.X].HealthNum + ")";
                    }
                    else
                    {
                        //robotDiscover++;
                    }
                    robotDiscoveredMatrix[playerSea.Y, playerSea.X] = 1;
                }
                else
                {
                    robotDiscoverMatrix.Add(playerSea);
                    robotAutoPlay();
                }
            }
            else
            {
                if (robotFindShip != null)
                {
                    if (robotFindShip.Name != "Submarine")
                    {
                        for (int i = 0; i < robot_.MyCards.InHandCards.Count; i++)
                        {
                            if (robot_.MyCards.InHandCards[i].Name.Contains("Red"))
                            {
                                Peg hit = (Peg)robot_.MyCards.InHandCards[i];
                                if (hit.AttackNum >= robotFindShip.HealthNum)
                                {
                                    hit.useCard(robotFindShip);
                                    updateHistory("Robot use " + hit.Name + " to attack " + human_.Name + "'s " + robotFindShip.Name + ". Damage is " + hit.AttackNum + ".");
                                    tableLayoutPanel3_PlayerSea.Controls[robotDiscoveredShipButtonIndex].Text = robotFindShip.Name + "\n(Health:" + robotFindShip.HealthNum + ")";
                                    robot_.MyCards.InHandCards.Remove(hit);
                                    break;
                                }
                                else
                                {
                                    hit.useCard(robotFindShip);
                                    updateHistory("Robot use " + hit.Name + " to attack " + human_.Name + "'s " + robotFindShip.Name + ". Damage is " + hit.AttackNum + ".");
                                    tableLayoutPanel3_PlayerSea.Controls[robotDiscoveredShipButtonIndex].Text = robotFindShip.Name + "\n(Health:" + robotFindShip.HealthNum + ")";
                                    robot_.MyCards.InHandCards.Remove(hit);
                                    break;
                                }
                            }
                            if (i == 4)
                            {
                                robotExceptionPlayWithoutRedPeg();
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < robot_.MyCards.InHandCards.Count; i++)
                        {
                            if (robot_.MyCards.InHandCards[i].Name.Contains("White"))
                            {
                                Peg hit = (Peg)robot_.MyCards.InHandCards[i];
                                hit.useCard(robotFindShip);
                                updateHistory("Robot use " + hit.Name + " to attack  " + human_.Name + "'s " + robotFindShip.Name + ". Damage is " + hit.AttackNum + ".");
                                tableLayoutPanel3_PlayerSea.Controls[robotDiscoveredShipButtonIndex].Text = robotFindShip.Name + "\n(Health:" + robotFindShip.HealthNum + ")";
                                robot_.MyCards.InHandCards.Remove(hit);
                                break;
                            }
                            //if(i==4)
                            //{
                            //    robotAutoPlay();
                            //    break;
                            //}
                            //如果没有白弹且存在潜艇时AI将不做任何事情了
                            //此时，我们要让AI用红弹任意射击其他目标实验
                            if (i == 4)
                            {
                                robotExceptionPlayWithoutWhitePeg();
                                break;
                            }
                        }

                    }
                }
            }
            if (robotFindShip.HealthNum <= 0 && robotFindShip.Name!="Sea")
            {
                tableLayoutPanel3_PlayerSea.Controls[robotDiscoveredShipButtonIndex].Enabled = false;
                updateHistory("Player's "+robotFindShip.Name+" is now sunk.");
                robotFindShip = null;
                //robotDiscover++;
            }
            if(robotFindWhiteExceptionShip != null && robotFindWhiteExceptionShip.HealthNum<=0 &&robotFindWhiteExceptionShip.Name!="Sea")
            {
                tableLayoutPanel3_PlayerSea.Controls[robotDiscoveredExceptionShipButtonIndex].Enabled = false;
                updateHistory("Player's "+ robotFindWhiteExceptionShip.Name + " is now sunk.");
                robotFindWhiteExceptionShip = null;
               // robotDiscover++;
            }
            if(robotFindRedExceptionShip!=null&&robotFindRedExceptionShip.HealthNum<=0&&robotFindRedExceptionShip.Name!="Sea")
            {
                tableLayoutPanel3_PlayerSea.Controls[robotDiscoveredExceptionShipButtonIndex].Enabled = false;
                updateHistory("Player's " + robotFindWhiteExceptionShip.Name + " is now sunk.");
                robotFindWhiteExceptionShip = null;
                //robotDiscover++;
            }
            if (robot_.MyCards.InHandCards.Count < 5)
            {
                robot_.MyCards.drawCards(5-robot_.MyCards.InHandCards.Count);
            }
        }

        private void robotExceptionPlayWithoutRedPeg()
        {
            Random rand = new Random();
            int cardIndex = rand.Next(5);
            Peg currentCard = (Peg)robot_.MyCards.InHandCards[cardIndex];
            Point playerSea = robotDiscoverMatrix[rand.Next(robotDiscoverMatrix.Count)];
            robotDiscoverMatrix.Remove(playerSea);
            if (robotDiscoveredMatrix[playerSea.Y, playerSea.X] != 1)
            {
                Ship targerShip = playerDeployment_[playerSea.Y, playerSea.X];
                robotFindRedExceptionShip = targerShip;
                currentCard.useCard(targerShip);
                updateHistory("Robot use " + currentCard.Name + " to find " + human_.Name + "'s " + targerShip.Name + ".");
                robot_.MyCards.InHandCards.Remove(currentCard);
                int playerShipButtonIndex = playerSea.Y * 4 + playerSea.X;
                robotDiscoveredExceptionShipButtonIndex = playerShipButtonIndex;
                tableLayoutPanel3_PlayerSea.Controls[playerShipButtonIndex].Enabled = true;
                if (robotFindRedExceptionShip.Name != "Sea")
                {
                    tableLayoutPanel3_PlayerSea.Controls[playerShipButtonIndex].Text = playerDeployment_[playerSea.Y, playerSea.X].Name + "\n(Health:" + playerDeployment_[playerSea.Y, playerSea.X].HealthNum + ")";
                }
                if (robotFindRedExceptionShip.HealthNum <= 0)
                {
                    tableLayoutPanel3_PlayerSea.Controls[robotDiscoveredExceptionShipButtonIndex].Enabled = false;
                    updateHistory("Player's " + robotFindRedExceptionShip.Name + " is now sunk.");
                    robotFindRedExceptionShip = null;
                    //robotDiscover++;
                }
                robotDiscoveredMatrix[playerSea.Y, playerSea.X] = 1;
            }
            else
            {
                robotExceptionPlayWithoutWhitePeg();
            }
        }

        private void robotExceptionPlayWithoutWhitePeg()
        {
            Random rand = new Random();
            int cardIndex = rand.Next(5);
            Peg currentCard = (Peg)robot_.MyCards.InHandCards[cardIndex];
            //int playerSeaX = robotXDiscover[rand.Next(robotXDiscover.Count)];
            //robotXDiscover.Remove(playerSeaX);
            //int playerSeaY = robotYDiscover[rand.Next(robotYDiscover.Count)];
            //robotYDiscover.Remove(playerSeaY);
            Point playerSea = robotDiscoverMatrix[rand.Next(robotDiscoverMatrix.Count)];
            robotDiscoverMatrix.Remove(playerSea);
            if (robotDiscoveredMatrix[playerSea.Y, playerSea.X] != 1)
            {
                Ship targerShip = playerDeployment_[playerSea.Y, playerSea.X];
                robotFindWhiteExceptionShip = targerShip;
                currentCard.useCard(targerShip);
                updateHistory("Robot use " + currentCard.Name + " to find "+human_.Name+"'s " + targerShip.Name+".");
                robot_.MyCards.InHandCards.Remove(currentCard);
                int playerShipButtonIndex = playerSea.Y * 4 + playerSea.X;
                robotDiscoveredExceptionShipButtonIndex = playerShipButtonIndex;
                tableLayoutPanel3_PlayerSea.Controls[playerShipButtonIndex].Enabled = true;
                if (robotFindWhiteExceptionShip.Name != "Sea")
                {
                    tableLayoutPanel3_PlayerSea.Controls[playerShipButtonIndex].Text = playerDeployment_[playerSea.Y, playerSea.X].Name + "\n(Health:" + playerDeployment_[playerSea.Y, playerSea.X].HealthNum + ")";
                }
                if(robotFindWhiteExceptionShip.HealthNum<=0)
                {
                    tableLayoutPanel3_PlayerSea.Controls[robotDiscoveredExceptionShipButtonIndex].Enabled = false;
                    updateHistory("Player's "+ robotFindWhiteExceptionShip.Name + " is now sunk.");
                    robotFindWhiteExceptionShip = null;
                    //robotDiscover++;
                }
                robotDiscoveredMatrix[playerSea.Y, playerSea.X] = 1;
            }
            else
            {
                robotExceptionPlayWithoutWhitePeg();
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
                updateHistory("Robot's "+robotDeployment_[y,x].Name+" is now sunk.");
                playerDiscover++;
            }
            if (playerDiscover == 12)
            {
                updateHistory("Player Wins The Game.");
                MessageBox.Show(":-)\nGreat! You Win!");
            }
        }

       

        private void updateHistory(string addHistory)
        {
            history.Add(history.HistoryCounter++, addHistory);
            label_GameStatus.Text = history.HistoryList[history.HistoryList.Count - 1];
            listBox_GameHistory.DataSource = null;
            listBox_GameHistory.DataSource = history.HistoryList;
            listBox_GameHistory.SetSelected(history.HistoryCounter-1, true);
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
                updateHistory("Player uses " + currentCard.Name + " to attack robot's " + robotDeployment_[0, 0].Name);
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
                
                robotPlay();
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
                updateHistory("Player uses " + currentCard.Name + " to attack robot's " + robotDeployment_[0, 1].Name);
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
                robotPlay();
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
                updateHistory("Player uses " + currentCard.Name + " to attack robot's " + robotDeployment_[0, 2].Name);
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
                robotPlay();
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
                updateHistory("Player uses " + currentCard.Name + " to attack robot's " + robotDeployment_[0, 3].Name);
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
                robotPlay();
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
                updateHistory("Player uses " + currentCard.Name + " to attack robot's " + robotDeployment_[1, 0].Name);
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
                robotPlay();
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
                updateHistory("Player uses " + currentCard.Name + " to attack robot's " + robotDeployment_[1, 1].Name);
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
                robotPlay();
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
                updateHistory("Player uses " + currentCard.Name + " to attack robot's " + robotDeployment_[1, 2].Name);
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
                robotPlay();
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
                updateHistory("Player uses " + currentCard.Name + " to attack robot's " + robotDeployment_[1, 3].Name);
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
                robotPlay();
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
                updateHistory("Player uses " + currentCard.Name + " to attack robot's " + robotDeployment_[2, 0].Name);
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
                robotPlay();
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
                updateHistory("Player uses " + currentCard.Name + " to attack robot's " + robotDeployment_[2,1].Name);
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
                robotPlay();
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
                updateHistory("Player uses " + currentCard.Name + " to attack robot's " + robotDeployment_[2,2].Name);
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
                robotPlay();
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
                updateHistory("Player uses " + currentCard.Name + " to attack robot's " + robotDeployment_[2,3].Name);
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
                robotPlay();
                robotMatchShip(button_RobotShip12);
            }
            else
            {
                MessageBox.Show("Please play one card to robot sea!");
            }
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
            for(int i=0;i<5;i++)
            {
                    Peg card = (Peg)robot_.MyCards.InHandCards[i];
                outputData += robot_.MyCards.InHandCards[i].Name + "   "+card.AttackNum+"\n";
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
    }
}
