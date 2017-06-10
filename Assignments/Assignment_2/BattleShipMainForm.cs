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
        /*#############################################################################
        * This part of code is instance variales for the main form use
        * ############################################################################*/
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
        bool playerRepair = false;
        Player human_;
        Player robot_;
        bool robotWin = false;
        bool humanWin = false;
        bool baseMode = false;
        Random rand = new Random();

        /*#############################################################################
        * This part of code is form constructor
        * ############################################################################*/
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

            if (playMode == "Base")
            {
                baseMode = true;
            }
            else
            {
                baseMode = false;
            }
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
                else if (human_.MyCards.InHandCards[i] is Power)
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
            if (first % 2 == 0)
            {
                MessageBox.Show("Cool! You get first round!");
            }
            else
            {
                MessageBox.Show("Robot gets first round!");
                if (baseMode)
                {
                    robotPlay_Base();
                }
                else
                {
                    robotPlay_Full();
                }
            }
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (robotDeployment_[j, i].Name != "Sea")
                    {
                        robotDeployment_[j, i].DeploymentY = j;
                        robotDeployment_[j, i].DeploymentX = i;
                    }
                }
            }


        }

        /*#############################################################################
         * This part of code is general private method for any function need
         * ############################################################################*/
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
                    else if (robot_.MyCards.InHandCards[i] is Power)
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
        private void initialDeployShips(TableLayoutPanel targetControl, Ship[,] playerDeploy)
        {
            int arrayX = 0;
            int arrayY = 0;
            for (int i = 0; i < targetControl.Controls.Count; i++)
            {
                if (targetControl.Controls[i] is Button)
                {

                    targetControl.Controls[i].Text = playerDeploy[arrayX, arrayY].Name;
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
        private void updateHistory(string addHistory)
        {
            history.Add(history.HistoryCounter++, addHistory);
            label_GameStatus.Text = history.HistoryList[history.HistoryList.Count - 1];
            listBox_GameHistory.DataSource = null;
            listBox_GameHistory.DataSource = history.HistoryList;
            listBox_GameHistory.SetSelected(history.HistoryCounter - 1, true);
        }
        private void updateButtonText(TableLayoutPanel whichTableLayoutPanel)
        {
            for (int i = 0; i < 12; i++)
            {
                if (whichTableLayoutPanel.Controls[i].Enabled == true)
                {
                    if (whichTableLayoutPanel.Controls[i].Text != "Sea")
                    {
                        Ship updateShip = (Ship)robotDeployment_[i / 4, i % 4];
                        if(updateShip.ShieldNum > 0)
                        {
                            whichTableLayoutPanel.Controls[i].Text = updateShip.Name + "\n(Health:" + updateShip.HealthNum + ")(Shield:" + updateShip.ShieldNum + ")";
                        }
                    }
                }
            }
        }

        /*#############################################################################
         * This part of code is for do player playing function
         * ############################################################################*/
        private void playerPlay(int robotY, int robotX)
        {
            human_.Full_RestOfRound--;
            int playerCardIndex = -1;
            for (int i = 0; i < tableLayoutPanel4_PlayerHandCards.Controls.Count; i++)
            {
                
                    RadioButton r = (RadioButton)tableLayoutPanel4_PlayerHandCards.Controls[i];
                    if (r.Checked)
                    {
                        playerCardIndex = i;
                        break;
                    }
                
            }
            if (playerCardIndex > -1)
            {
                HandCard currentCard = human_.MyCards.InHandCards[playerCardIndex];
                if (currentCard is Peg)
                {
                    Peg pegCurrent = (Peg)currentCard;
                    pegCurrent.usePegCard(robotDeployment_[robotY, robotX], human_.Mode);
                    human_.disCards(pegCurrent);
                    human_.MyCards.InHandCards.Remove(pegCurrent);
                    updateHistory("Player uses " + pegCurrent.Name + " " + pegCurrent.AttackNum + " to attack robot's " + robotDeployment_[robotY, robotX].Name);
                    playerUpdateHandCard();
                }
                else if (currentCard is Power)
                {
                    //NEED APPLY
                    //But there is no power for attack AI ship
                }
            }
            else
            {
                MessageBox.Show("Please play one card to robot sea!");
            }
            if (baseMode)
            {
                human_.drawCards(1);
            }
            else
            {
                if ((human_.MyCards.InHandCards.Count) < human_.Full_RestOfCard && human_.Full_RestOfRound<=0)
                {
                    human_.drawCards(human_.Full_RestOfCard - human_.MyCards.InHandCards.Count);
                }
            }
            playerUpdateHandCard();
            updateButtonText(tableLayoutPanel3_PlayerSea);
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
        private void playerShipsAct(Button targetShipButton)
        {
            human_.Full_RestOfRound--;
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
                if (currentCard is Power)
                {
                    Power usePower = (Power)currentCard;
                    int index = 0;
                    if (usePower.Name == "Shield")
                    {
                        human_.Full_RestOfRound--;
                        foreach (Button b in tableLayoutPanel3_PlayerSea.Controls)
                        {
                            if (b == targetShipButton)
                            {
                                break;
                            }
                            index++;
                        }
                        Ship targetShip = playerDeployment_[index / 4, index % 4];
                        usePower.useCard(targetShip,targetShipButton);
                        targetShip.ShieldOn = usePower;
                        human_.MyCards.InHandCards.Remove(usePower);
                        human_.disCards(usePower);
                        if (human_.Team == "Red")
                        { targetShipButton.ForeColor = Color.Red; targetShipButton.BackColor = Control.DefaultBackColor; }
                        else
                        { targetShipButton.ForeColor = Color.Blue; targetShipButton.BackColor = Control.DefaultBackColor; }
                        human_.MyCards.InHandCards.Remove(currentCard);
                        human_.disCards(currentCard);
                        human_.drawCards(1);
                        playerUpdateHandCard();
                    }    
                    else if(playerRepair)
                    {
                        human_.Full_RestOfRound--;
                        foreach (Button b in tableLayoutPanel3_PlayerSea.Controls)
                        {
                            if (b == targetShipButton)
                            {
                                break;
                            }
                            index++;
                        }
                        Ship targetShip = playerDeployment_[index / 4, index % 4];
                        usePower.useCard(usePower, "1", human_, targetShip);
                        tableLayoutPanel4_PlayerHandCards.Enabled = true;
                        human_.disCards(usePower);
                        human_.MyCards.InHandCards.Remove(usePower);
                        if (human_.Team == "Red")
                        { targetShipButton.ForeColor = Color.Red; targetShipButton.BackColor = Control.DefaultBackColor; }
                        else
                        { targetShipButton.ForeColor = Color.Blue; targetShipButton.BackColor = Control.DefaultBackColor; }
                        playerRepair = false;
                        updateButtonText(tableLayoutPanel4_PlayerHandCards);
                    }
                }
            }

        }
        private void playerUpdateHandCard()
        {
            for (int i = 0; i < tableLayoutPanel4_PlayerHandCards.Controls.Count; i++)
            {
                if (i < human_.MyCards.InHandCards.Count)
                {
                    tableLayoutPanel4_PlayerHandCards.Controls[i].Visible = true;
                    if (human_.MyCards.InHandCards[i] is Peg)
                    {
                        Peg card = (Peg)human_.MyCards.InHandCards[i];
                        tableLayoutPanel4_PlayerHandCards.Controls[i].Text = card.Name + card.AttackNum;
                    }
                    else
                    {
                        Power card = (Power)human_.MyCards.InHandCards[i];
                        tableLayoutPanel4_PlayerHandCards.Controls[i].Text = card.Name;
                    }
                }
                else
                { tableLayoutPanel4_PlayerHandCards.Controls[i].Visible = false; }
            }
        }
        private void playerPowerUse(RadioButton selected)
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
            if (selected.Text == "Discard White Peg or Play 2 Cards")
            {
                DialogResult dr =
                    MessageBox.Show("There are two function to select.\nA.Discard White\nB.Play 2 Cards\nThe default is to use A. Click Yes if you agree or No to use the another.", "Power Card", MessageBoxButtons.YesNo);
                if(dr == DialogResult.Yes)
                {                   
                    human_.Full_RestOfRound--;
                    Power disWhite = (Power)human_.MyCards.InHandCards[playerCardIndex];
                    List<Peg> whites = new List<Peg>();
                    for (int i = 0; i < human_.MyCards.InHandCards.Count; i++)
                    {
                        if (human_.MyCards.InHandCards[i].Name == "White Peg")
                        {
                            whites.Add((Peg)human_.MyCards.InHandCards[i]);
                        }
                    }
                    for(int i=0;i<whites.Count;i++)
                    {
                        human_.disCards(whites[i]);
                        human_.MyCards.InHandCards.Remove(whites[i]);
                    }
                    human_.disCards(disWhite);
                    human_.MyCards.InHandCards.Remove(disWhite);
                    if(human_.Full_RestOfRound<=0)
                    {
                        if ((human_.MyCards.InHandCards.Count) < human_.Full_RestOfCard)
                        {
                            human_.drawCards(human_.Full_RestOfCard - human_.MyCards.InHandCards.Count);
                        }
                        playerUpdateHandCard();
                        robotPlay_Full();
                    }
                }
                else
                {
                    human_.Full_RestOfRound--;
                    if (human_.Full_RestOfRound <= 0)
                    {
                        human_.Full_RestOfRound = 2;
                    }
                    else
                    {
                        human_.Full_RestOfRound += 2;
                    }
                    human_.disCards(human_.MyCards.InHandCards[playerCardIndex]);
                    human_.MyCards.InHandCards.RemoveAt(playerCardIndex);
                    playerUpdateHandCard();
                }

            }
            else if (selected.Text == "Repair a ship or Draw 3 Cards, then Play 1")
            {
                DialogResult dr =
                    MessageBox.Show("There are two function to select.\nA.Repair a ship then play 1\nB.Draw 3 Cards then play 1\nThe default is to use A. Click Yes if you agree or No to use the another.", "Power Card", MessageBoxButtons.YesNo);
                if (dr == DialogResult.Yes)
                {
                    playerRepair = true;
                    human_.Full_RestOfRound--;
                    human_.disCards(human_.MyCards.InHandCards[playerCardIndex]);
                    human_.MyCards.InHandCards.RemoveAt(playerCardIndex);
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
                    MessageBox.Show("Now choose a ship for repair");
                    tableLayoutPanel4_PlayerHandCards.Enabled = false;
                }
                else
                {
                    human_.Full_RestOfRound--;
                    human_.disCards(human_.MyCards.InHandCards[playerCardIndex]);
                    human_.MyCards.InHandCards.RemoveAt(playerCardIndex);
                    human_.drawCards(3);
                    playerUpdateHandCard();
                }
            }
            else if (selected.Text == "Shield")
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
            else
            {
                for (int i = 0; i < tableLayoutPanel3_PlayerSea.Controls.Count; i++)
                {
                    if (tableLayoutPanel3_PlayerSea.Controls[i].Text != "Sea" && tableLayoutPanel3_PlayerSea.Controls[i].Enabled == true)
                    {
                        tableLayoutPanel3_PlayerSea.Controls[i].BackColor = Control.DefaultBackColor;
                        if (human_.Team == "Red")
                        {
                            tableLayoutPanel3_PlayerSea.Controls[i].ForeColor = Color.Red;
                        }
                        else
                        {
                            tableLayoutPanel3_PlayerSea.Controls[i].ForeColor = Color.Blue;
                        }
                    }
                }
            }
        }        




        /*#############################################################################
        * This part of code is to implement AI
        * ############################################################################*/
        private void robotPlay_Full()
        {
            while(robot_.Full_RestOfRound>0)
            {
                robotPlay_Full_Main();
            }
            if (robot_.MyCards.InHandCards.Count < robot_.Full_RestOfCard)
            {
                robot_.MyCards.drawCards(robot_.Full_RestOfCard - robot_.MyCards.InHandCards.Count);
            }
            robot_.Full_RestOfRound = 1;
        }
        private void robotPlay_Full_Main()
        {
            //Full Game
            if (!humanWin)
            {
                robot_.Full_RestOfRound--;
                if (robotPlay_Full_FindDamegedShip() != null)
                {
                    Ship damegedShip = robotPlay_Full_FindDamegedShip();
                    bool hasShield = false;
                    int shieldIndex = 0;
                    foreach (HandCard h in robot_.MyCards.InHandCards)
                    {
                        if (h.Name == "Shield")
                        {
                            hasShield = true;
                            break;
                        }
                        shieldIndex++;
                    }
                    if (hasShield)
                    {
                        Power shield = (Power)robot_.MyCards.InHandCards[shieldIndex];
                        robotPlay_Full_Shield(shield, damegedShip);
                        robot_.MyCards.InHandCards.Remove(shield);
                        robot_.disCards(shield);
                    }
                    else if (robotPlay_Full_FindAppearedShip("PT Boat") != null)
                    {
                        Ship pt = robotPlay_Full_FindAppearedShip("PT Boat");
                        pt.useCard(damegedShip);
                        if (damegedShip.Name != "Sea")
                        {
                            tableLayoutPanel2_RobotSea.Controls[damegedShip.DeploymentY * 4 + damegedShip.DeploymentX].Text = robotDeployment_[damegedShip.DeploymentY, damegedShip.DeploymentX].Name + "\n(Health:" + robotDeployment_[damegedShip.DeploymentY, damegedShip.DeploymentX].HealthNum + ")";
                            if (damegedShip.ShieldNum > 0 && damegedShip.ShieldOn != null)
                            {
                                tableLayoutPanel3_PlayerSea.Controls[damegedShip.DeploymentY * 4 + damegedShip.DeploymentX].Text = playerDeployment_[damegedShip.DeploymentY, damegedShip.DeploymentX].Name + "\n(Health:" + playerDeployment_[damegedShip.DeploymentY, damegedShip.DeploymentX].HealthNum + ")" +
                                    "(Shield:" + damegedShip.ShieldNum + ")";
                            }
                            else
                            {
                                Power Shield = damegedShip.ShieldOn;
                                human_.MyCards.discards(Shield);
                                damegedShip.ShieldOn = null;
                            }
                        }
                    }
                    else
                    {
                        if (robotFindShips.Count != 0)
                        {
                            robotPlay_Full_AttackShip();
                        }
                        else
                        {
                            robotPlay_Full_FindNewShipOrOtherAct();
                        }
                    }
                }
                else if (robotFindShips.Count != 0)
                {
                    robotPlay_Full_AttackShip();
                }
                else
                {
                    robotPlay_Full_FindNewShipOrOtherAct();
                }
                updateButtonText(tableLayoutPanel2_RobotSea);
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
            }
        }
        private Ship robotPlay_Full_FindDamegedShip()
        {
            foreach (Ship s in robotDeployment_)
            {
                if ((s.Name == "Submarine" && s.HealthNum < 3) || (s.Name == "PT Boat" && s.HealthNum < 2) || (s.Name == "Destroyer" && s.HealthNum < 3)
                    || (s.Name == "Battleship" && s.HealthNum < 4) || (s.Name == "Aircraft Carrier" && s.HealthNum < 5))
                {
                    return s;
                }
            }
            return null;
        }
        private Ship robotPlay_Full_FindAppearedShip(string needFindShip)
        {
            for (int i = 0; i < robotDeployment_.Length; i++)
            {
                if (tableLayoutPanel2_RobotSea.Controls[i].Text.Contains(needFindShip)
                    && tableLayoutPanel2_RobotSea.Controls[i].Enabled == true)
                {
                    return (Ship)robotDeployment_[i / 4, i % 4];
                }
            }
            return null;
        }
        private void robotPlay_Full_Shield(Power Shield, Ship targetShip)
        {
            Button targetButton = (Button)tableLayoutPanel2_RobotSea.Controls[targetShip.DeploymentY * 4 + targetShip.DeploymentX];
            Shield.useCard(targetShip, targetButton);
            targetShip.ShieldOn = Shield;
        }
        private void robotPlay_Full_FindNewShipOrOtherAct()
        {
            Random rand = new Random();
            Card currentCard;
            Peg pegCurrentCard;
            Power powerCurrentCard;
            if (robot_.MyCards.InHandCards.Count == 5)
            {
                currentCard = robot_.MyCards.InHandCards[rand.Next(5)];
                if (currentCard is Peg)
                {
                    pegCurrentCard = (Peg)currentCard;
                    if (pegCurrentCard.Color != "White")
                    {
                        for (int i = 0; i < robot_.MyCards.InHandCards.Count; i++)
                        {
                            if (robot_.MyCards.InHandCards[i] is Peg && robot_.MyCards.InHandCards[i].Name.Contains("White"))
                            {
                                pegCurrentCard = (Peg)robot_.MyCards.InHandCards[i];
                                break;
                            }
                        }
                    }
                    //Use white or red peg to find/attack ships
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
                        pegCurrentCard.usePegCard(targetShip, robot_.Mode);
                        robot_.disCards(pegCurrentCard);
                        updateHistory("Robot use " + pegCurrentCard.Name + " to find " + human_.Name + "'s " + targetShip.Name);
                        robot_.MyCards.InHandCards.Remove(pegCurrentCard);
                        tableLayoutPanel3_PlayerSea.Controls[targetShip.DeploymentY * 4 + targetShip.DeploymentX].Enabled = true;
                        if (targetShip.Name != "Sea")
                        {
                            tableLayoutPanel3_PlayerSea.Controls[targetShip.DeploymentY * 4 + targetShip.DeploymentX].Text = playerDeployment_[playerSea.Y, playerSea.X].Name + "\n(Health:" + playerDeployment_[playerSea.Y, playerSea.X].HealthNum + ")";
                            if (targetShip.ShieldNum > 0 && targetShip.ShieldOn!=null)
                            {
                                tableLayoutPanel3_PlayerSea.Controls[targetShip.DeploymentY * 4 + targetShip.DeploymentX].Text = playerDeployment_[playerSea.Y, playerSea.X].Name + "\n(Health:" + playerDeployment_[playerSea.Y, playerSea.X].HealthNum + ")"+
                                    "(Shield:" + targetShip.ShieldNum + ")";
                            }
                            else
                            {
                                Power Shield = targetShip.ShieldOn;
                                human_.MyCards.discards(Shield);
                                targetShip.ShieldOn = null;
                            }
                        }

                        if (targetShip.HealthNum <= 0 && targetShip.Name != "Sea")
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
                    if (powerCurrentCard.Name != "Shield")
                    {
                        if (powerCurrentCard.Name == "Discard White Peg or Play 2 Cards")
                        {
                            powerCurrentCard.useCard(powerCurrentCard, (rand.Next() % 2).ToString(), robot_, null);
                        }
                        else if (powerCurrentCard.Name == "Repair a ship or Draw 3 Cards, then Play 1") 
                        {
                            Ship ship = robotPlay_Full_FindDamegedShip();
                            int randNum = rand.Next() % 2;
                            if (randNum == 1)
                            {
                                powerCurrentCard.useCard(powerCurrentCard, randNum.ToString(),robot_,ship);
                            }
                            else
                            {
                                powerCurrentCard.useCard(powerCurrentCard,randNum.ToString(),robot_,null);
                            }
                        }
                        robot_.MyCards.InHandCards.Remove(powerCurrentCard);
                        robot_.disCards(powerCurrentCard);
                    }
                }
            }
            else
            {
                robot_.drawCards(1);
                robotPlay_Full_FindNewShipOrOtherAct();
            }
        }
        private void robotPlay_Full_AttackShip()
        {
            Random rand = new Random();
            Ship targetShip = robotFindShips[rand.Next(robotFindShips.Count)];
            Peg currentCard = (Peg)robotPlay_ChooseOneCardAttack(targetShip);
            if (currentCard != null)
            {
                currentCard.usePegCard(targetShip, robot_.Mode);
                robot_.MyCards.InHandCards.Remove(currentCard);
                robot_.disCards(currentCard);
                if (targetShip.Name != "Sea")
                {
                    tableLayoutPanel3_PlayerSea.Controls[targetShip.DeploymentY * 4 + targetShip.DeploymentX].Text = playerDeployment_[targetShip.DeploymentY, targetShip.DeploymentX].Name + "\n(Health:" + playerDeployment_[targetShip.DeploymentY, targetShip.DeploymentX].HealthNum + ")";
                    if (targetShip.ShieldNum > 0 && targetShip.ShieldOn != null)
                    {
                        tableLayoutPanel3_PlayerSea.Controls[targetShip.DeploymentY * 4 + targetShip.DeploymentX].Text = playerDeployment_[targetShip.DeploymentY, targetShip.DeploymentX].Name + "\n(Health:" + playerDeployment_[targetShip.DeploymentY, targetShip.DeploymentX].HealthNum + ")" +
                            "(Shield:" + targetShip.ShieldNum + ")";
                    }
                    else
                    {
                        Power Shield = targetShip.ShieldOn;
                        human_.MyCards.discards(Shield);
                        targetShip.ShieldOn = null;
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
                robotPlay_Full_FindNewShipOrOtherAct();
            }
        }
        private void robotPlay_Base()
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
                        currentCard.usePegCard(targetShip, robot_.Mode);
                        robot_.MyCards.InHandCards.Remove(currentCard);
                        robot_.disCards(currentCard);
                        if (targetShip.Name != "Sea")
                        {
                            tableLayoutPanel3_PlayerSea.Controls[targetShip.DeploymentY * 4 + targetShip.DeploymentX].Text = playerDeployment_[targetShip.DeploymentY, targetShip.DeploymentX].Name + "\n(Health:" + playerDeployment_[targetShip.DeploymentY, targetShip.DeploymentX].HealthNum + ")";                            
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
                        robotPlay_Base_FindNewShipOrOtherAct();
                    }
                }
                else
                {
                    robotPlay_Base_FindNewShipOrOtherAct();
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
        private void robotPlay_Base_FindNewShipOrOtherAct()
        {
            Random rand = new Random();
            Card currentCard;
            Peg pegCurrentCard;
            if (robot_.MyCards.InHandCards.Count == 5)
            {
                currentCard = robot_.MyCards.InHandCards[rand.Next(5)];
                if (currentCard is Peg)
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
                        pegCurrentCard.usePegCard(targetShip, robot_.Mode);
                        robot_.disCards(pegCurrentCard);
                        updateHistory("Robot use " + currentCard.Name + " to find " + human_.Name + "'s " + targetShip.Name);
                        robot_.MyCards.InHandCards.Remove(pegCurrentCard);
                        tableLayoutPanel3_PlayerSea.Controls[targetShip.DeploymentY * 4 + targetShip.DeploymentX].Enabled = true;
                        if (targetShip.Name != "Sea")
                        {
                            tableLayoutPanel3_PlayerSea.Controls[targetShip.DeploymentY * 4 + targetShip.DeploymentX].Text = playerDeployment_[playerSea.Y, playerSea.X].Name + "\n(Health:" + playerDeployment_[playerSea.Y, playerSea.X].HealthNum + ")";
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
            }
            else
            {
                robot_.drawCards(1);
                robotPlay_Base_FindNewShipOrOtherAct();
            }
        }
        private HandCard robotPlay_ChooseOneCardAttack(Ship targerShip)
        {
            if (targerShip.Name != "Submarine")
            {
                Dictionary<int, HandCard> choosedCardWithDamage = new Dictionary<int, HandCard>();
                for (int i = 0; i < robot_.MyCards.InHandCards.Count; i++)
                {
                    if (robot_.MyCards.InHandCards[i].Name.Contains("Red") && robot_.MyCards.InHandCards[i] is Peg)
                    {
                        Peg choosedPeg = (Peg)robot_.MyCards.InHandCards[i];
                        try
                        {
                            choosedCardWithDamage.Add(choosedPeg.AttackNum - targerShip.HealthNum, choosedPeg);
                        }
                        catch
                        {
                            Console.WriteLine("Dictionary find an object with same property, just ignore it");
                        }
                    }
                }
                try
                {
                    int maxDamage = choosedCardWithDamage.Keys.Max();
                    HandCard attack = choosedCardWithDamage[maxDamage];
                    return attack;
                }
                catch
                {
                    return null;
                }
            }
            else
            {
                for (int i = 0; i < robot_.MyCards.InHandCards.Count; i++)
                {
                    if (robot_.MyCards.InHandCards[i].Name == ("White Peg"))
                    {
                        return robot_.MyCards.InHandCards[i];
                    }
                }
                return null;
            }
        }




        /*#############################################################################
         * This part of code is to implement Robot Sea function
         * ############################################################################*/
        private void button_RobotShip1_Click(object sender, EventArgs e)
        {
            if (baseMode)
            {

                playerPlay(0, 0);
                playerMatchRobotShip(button_RobotShip1);                
                    robotPlay_Base();                
            }
            else
            {
                playerPlay(0, 0);
                playerMatchRobotShip(button_RobotShip1);
                if (human_.Full_RestOfRound <= 0)
                {
                    robotPlay_Full();
                }
            }
        }
        private void button_RobotShip2_Click(object sender, EventArgs e)
        {
            if (baseMode)
            {
                playerPlay(0, 1);
                playerMatchRobotShip(button_RobotShip2);
                robotPlay_Base();
            }
            else
            {
                playerPlay(0, 1);
                playerMatchRobotShip(button_RobotShip2);
                if (human_.Full_RestOfRound <= 0)
                {
                    robotPlay_Full();
                }
            }
        }
        private void button_RobotShip3_Click(object sender, EventArgs e)
        {
            if (baseMode)
            {
                playerPlay(0, 2);
                playerMatchRobotShip(button_RobotShip3);
                robotPlay_Base();
            }
            else
            {
                playerPlay(0, 2);
                playerMatchRobotShip(button_RobotShip3);
                if (human_.Full_RestOfRound <= 0)
                {
                    robotPlay_Full();
                }
            }
        }
        private void button_RobotShip4_Click(object sender, EventArgs e)
        {
            if (baseMode)
            {
                playerPlay(0, 3);
                playerMatchRobotShip(button_RobotShip4);
                robotPlay_Base();
            }
            else
            {
                playerPlay(0, 3);
                playerMatchRobotShip(button_RobotShip4);
                if (human_.Full_RestOfRound <= 0)
                {
                    robotPlay_Full();
                }
            }
        }
        private void button_RobotShip5_Click(object sender, EventArgs e)
        {
            if (baseMode)
            {
                playerPlay(1, 0);
                playerMatchRobotShip(button_RobotShip5);
                robotPlay_Base();
            }
            else
            {
                playerPlay(1, 0);
                playerMatchRobotShip(button_RobotShip5);
                if (human_.Full_RestOfRound <= 0)
                {
                    robotPlay_Full();
                }
            }
        }
        private void button_RobotShip6_Click(object sender, EventArgs e)
        {
            if (baseMode)
            {
                playerPlay(1, 1);
                playerMatchRobotShip(button_RobotShip6);
                robotPlay_Base();
            }
            else
            {
                playerPlay(1, 1);
                playerMatchRobotShip(button_RobotShip6);
                if (human_.Full_RestOfRound <= 0)
                {
                    robotPlay_Full();
                }
            }
        }
        private void button_RobotShip7_Click(object sender, EventArgs e)
        {
            if (baseMode)
            {
                playerPlay(1, 2);
                playerMatchRobotShip(button_RobotShip7);
                robotPlay_Base();
            }
            else
            {
                playerPlay(1, 2);
                playerMatchRobotShip(button_RobotShip7);
                if (human_.Full_RestOfRound <= 0)
                {
                    robotPlay_Full();
                }
            }
        }
        private void button_RobotShip8_Click(object sender, EventArgs e)
        {
            if (baseMode)
            {
                playerPlay(1, 3);
                playerMatchRobotShip(button_RobotShip8);
                robotPlay_Base();
            }
            else
            {
                playerPlay(1, 3);
                playerMatchRobotShip(button_RobotShip8);
                if (human_.Full_RestOfRound <= 0)
                {
                    robotPlay_Full();
                }
            }
        }
        private void button_RobotShip9_Click(object sender, EventArgs e)
        {
            if (baseMode)
            {
                playerPlay(2, 0);
                playerMatchRobotShip(button_RobotShip9);
                robotPlay_Base();
            }
            else
            {
                playerPlay(2, 0);
                playerMatchRobotShip(button_RobotShip9);
                if (human_.Full_RestOfRound <= 0)
                {
                    robotPlay_Full();
                }
            }
        }
        private void button_RobotShip10_Click(object sender, EventArgs e)
        {
            if (baseMode)
            {
                playerPlay(2, 1);
                playerMatchRobotShip(button_RobotShip10);
                robotPlay_Base();
            }
            else
            {
                playerPlay(2, 1);
                playerMatchRobotShip(button_RobotShip10);
                if (human_.Full_RestOfRound <= 0)
                {
                    robotPlay_Full();
                }
            }
        }
        private void button_RobotShip11_Click(object sender, EventArgs e)
        {
            if (baseMode)
            {
                playerPlay(2, 2);
                playerMatchRobotShip(button_RobotShip11);
                robotPlay_Base();
            }
            else
            {
                playerPlay(2, 2);
                playerMatchRobotShip(button_RobotShip11);
                if (human_.Full_RestOfRound <= 0)
                {
                    robotPlay_Full();
                }
            }
        }
        private void button_RobotShip12_Click(object sender, EventArgs e)
        {
            if (baseMode)
            {
                playerPlay(2, 3);
                playerMatchRobotShip(button_RobotShip12);
                robotPlay_Base();
            }
            else
            {
                playerPlay(2, 3);
                playerMatchRobotShip(button_RobotShip12);
                if (human_.Full_RestOfRound <= 0)
                {
                    robotPlay_Full();
                }
                human_.Full_RestOfRound = 1;
            }
        }


        /*#############################################################################
        * This part of code is tp implement Player Sea/Hand Cards function
        * ############################################################################*/
        private void button_PlayerShip1_Click(object sender, EventArgs e)
        {
            if (!baseMode)
            {
                playerShipsAct(button_PlayerShip1);
                if (human_.Full_RestOfRound <= 0)
                {
                    robotPlay_Full();
                }
            }
        }
        private void button_PlayerShip2_Click(object sender, EventArgs e)
        {
            if (!baseMode)
            {
                playerShipsAct(button_PlayerShip2);
                if (human_.Full_RestOfRound <= 0)
                {
                    robotPlay_Full();
                }
            }
        }
        private void button_PlayerShip3_Click(object sender, EventArgs e)
        {
            if (!baseMode)
            {
                playerShipsAct(button_PlayerShip3);
                if (human_.Full_RestOfRound <= 0)
                {
                    robotPlay_Full();
                }
            }
        }
        private void button_PlayerShip4_Click(object sender, EventArgs e)
        {
            if (!baseMode)
            {
                playerShipsAct(button_PlayerShip4);
                if (human_.Full_RestOfRound <= 0)
                {
                    robotPlay_Full();
                }
            }
        }
        private void button_PlayerShip5_Click(object sender, EventArgs e)
        {
            if (!baseMode)
            {
                playerShipsAct(button_PlayerShip5);
                if (human_.Full_RestOfRound <= 0)
                {
                    robotPlay_Full();
                }
            }
        }
        private void button_PlayerShip6_Click(object sender, EventArgs e)
        {
            if (!baseMode)
            {
                playerShipsAct(button_PlayerShip6);
                if (human_.Full_RestOfRound <= 0)
                {
                    robotPlay_Full();
                }
            }
        }
        private void button_PlayerShip7_Click(object sender, EventArgs e)
        {
            if (!baseMode)
            {
                playerShipsAct(button_PlayerShip7);
                if (human_.Full_RestOfRound <= 0)
                {
                    robotPlay_Full();
                }
            }
        }
        private void button_PlayerShip8_Click(object sender, EventArgs e)
        {
            if (!baseMode)
            {
                playerShipsAct(button_PlayerShip8);
                if (human_.Full_RestOfRound <= 0)
                {
                    robotPlay_Full();
                }
            }
        }
        private void button_PlayerShip9_Click(object sender, EventArgs e)
        {
            if (!baseMode)
            {
                playerShipsAct(button_PlayerShip9);
                if (human_.Full_RestOfRound <= 0)
                {
                    robotPlay_Full();
                }
            }
        }
        private void button_PlayerShip10_Click(object sender, EventArgs e)
        {
            if (!baseMode)
            {
                playerShipsAct(button_PlayerShip10);
                if (human_.Full_RestOfRound <= 0)
                {
                    robotPlay_Full();
                }
            }
        }
        private void button_PlayerShip11_Click(object sender, EventArgs e)
        {
            if (!baseMode)
            {
                playerShipsAct(button_PlayerShip11);
                if (human_.Full_RestOfRound <= 0)
                {
                    robotPlay_Full();
                }
            }
        }
        private void button_PlayerShip12_Click(object sender, EventArgs e)
        {
            if (!baseMode)
            {
                playerShipsAct(button_PlayerShip12);
                if (human_.Full_RestOfRound <= 0)
                {
                    robotPlay_Full();
                }
            }
        }
        private void radioButton1_MyCard1_Click(object sender, EventArgs e)
        {
            if(!baseMode)
            playerPowerUse(radioButton1_MyCard1);
        }
        private void radioButton2_MyCard2_Click(object sender, EventArgs e)
        {
            if(!baseMode)
            playerPowerUse(radioButton2_MyCard2);
        }       
        private void radioButton3_MyCard3_Click(object sender, EventArgs e)
        {
            if (!baseMode)
                playerPowerUse(radioButton3_MyCard3);
        }
        private void radioButton4_MyCard4_Click(object sender, EventArgs e)
        {
            if (!baseMode)
                playerPowerUse(radioButton4_MyCard4);
        }
        private void radioButton5_MyCard5_Click(object sender, EventArgs e)
        {
            if (!baseMode)
                playerPowerUse(radioButton5_MyCard5);
        }
        private void radioButton6_MyCard6_Click(object sender, EventArgs e)
        {
            if (!baseMode)
                playerPowerUse(radioButton6_MyCard6);
        }
        private void radioButton7_MyCard7_Click(object sender, EventArgs e)
        {
            if (!baseMode)
                playerPowerUse(radioButton7_MyCard7);
        }
        private void radioButton8_MyCard8_Click(object sender, EventArgs e)
        {
            if (!baseMode)
                playerPowerUse(radioButton8_MyCard8);
        }
        private void radioButton9_MyCard9_Click(object sender, EventArgs e)
        {
            if (!baseMode)
                playerPowerUse(radioButton9_MyCard9);
        }
        private void radioButton10_MyCard10_Click(object sender, EventArgs e)
        {
            if (!baseMode)
                playerPowerUse(radioButton10_MyCard10);
        }
    }
}
