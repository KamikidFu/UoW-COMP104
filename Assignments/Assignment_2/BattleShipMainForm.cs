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
        *#############################################################################*
        Variables  Name       ||Explanation
        -------------------------------------------------------------------------------
        robotDiscover         ||The ships number that AI attacked and make it sunk
        robotDiscoverMatrix   ||The deployment (in points) of player
        playerDiscover        ||The ships number that player attacked and make it sunk
        history               ||The feedback of things happen step by step
        playerDeployment_     ||The deployment of player
        robotDeployment_      ||The deployment of AI
        robotDiscoveredMatrix ||Use as a list of bool variables, if AI discovered one area,
                              ||it will record the area, so next time AI will ignore it
        human_                ||One object of Player, the user who plays this game
        robot_                ||One object of Player, AI, who the user is against
        playerRepair          ||For implement Repair one ship power
        robotWin              ||Winning flag of robot
        humanWin              ||Winning flag of player
        baseMode              ||The current mode playing, true, base game, false, full game
        robot_Des             ||The ability of Destroyer in robot team
        robot_Bat             ||The ability of Battleship in robot team
        player_Des            ||The ability of Destroyer in user team
        player_Bat            ||The ability of Battleship in user team
        player_PT             ||The ability of PT Boat in user team
        rand                  ||The random number generator
        ***Robot does not have robot_PT because the ability in robot team will automatically***
        ***be used when there having a dameged ship:-)                                      ***
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
        Player human_;
        Player robot_;
        bool playerRepair = false;
        bool robotWin = false;
        bool humanWin = false;
        bool baseMode = false;
        bool robot_Des = false;
        bool robot_Bat = false;
        bool player_Des = false;
        bool player_Bat = false;
        bool player_PT = false;
        Random rand = new Random();

        /*#############################################################################
        * This part of code is form constructor
        * ############################################################################*/
        /// <summary>
        /// The basic constructor of main form
        /// </summary>
        public BattleShipMainForm()
        {
            //Initial component in this form
            InitializeComponent();
            //Add new information to title
            this.Text += "  [Not Start Game - No Mode Info]";
            //Other controls' status to define
            if (this.Text.Contains("Not Start Game"))
            {
                //A loop for looping controls
                for (int i = 0; i < groupBox1_Robot.Controls.Count; i++)
                {
                    //Not enable this control
                    groupBox1_Robot.Controls[i].Enabled = false;
                    groupBox2_Player.Controls[i].Enabled = false;
                }
                //A loop for looping controls
                for (int i = 0; i < groupBox3_HandCard.Controls.Count; i++)
                {
                    //Not enable radiobuttons
                    groupBox3_HandCard.Controls[i].Enabled = false;
                }
            }
            //Add history and show the current status in label
            history.Add(history.HistoryCounter++, "Application running.");
            history.Add(history.HistoryCounter++, "Waiting for game starts!");
            label_GameStatus.Text = history.HistoryList[history.HistoryList.Count - 1];
            listBox_GameHistory.DataSource = history.HistoryList;
        }

        /// <summary>
        /// This constructor is to initial the game in both base or full mode
        /// </summary>
        /// <param name="playerName">The player's name</param>
        /// <param name="playerTeam">Which team the player is in</param>
        /// <param name="playMode">What gaming mode the player choose</param>
        /// <param name="currentHistory">The current history of the whole game application</param>
        /// <param name="playerDeployment">The deployment of player</param>
        /// <param name="robotDeployment">The deployment of robot</param>
        public BattleShipMainForm(string playerName, string playerTeam, string playMode, History currentHistory
            , Ship[,] playerDeployment, Ship[,] robotDeployment)
        {
            //Initial component in this form
            InitializeComponent();
            //Is this base game or full game?
            if (playMode == "Base")
            {
                baseMode = true;
            }
            else
            {
                baseMode = false;
            }
            //Construct the player, human_, with name, team and game mode
            human_ = new Player(playerName, playerTeam, playMode);
            //Local variable to store robot team
            string robotTeam = "";
            //Pass values like the current history to this new form's instance variables.
            history = currentHistory;            
            playerDeployment_ = playerDeployment;
            robotDeployment_ = robotDeployment;
            //Update history
            history.Add(history.HistoryCounter++, playerName + " starts a new game. Mode: " + playMode);
            //Update the title
            this.Text += " [Welcome " + playerName + " Team: " + playerTeam + " Mode: " + playMode + "]";
            //Update the groupBox title
            groupBox2_Player.Text += ": " + playerName;
            //Stylize the playing area
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
            //Construct the AI, robot_, with its name, team, and game mode
            if (playMode == "Full")
            {
                robot_ = new Player("NameMaxLengthOfHumanIs16", robotTeam, "Full");
            }
            else
            {
                robot_ = new Player("NameMaxLengthOfHumanIs16", robotTeam, "Base");
            }
            //Call initialDeployShips method for make ships and buttons ready
            initialDeployShips(tableLayoutPanel3_PlayerSea, playerDeployment_);
            //Hide robot ships and enable all buttons in robot sea
            for (int j = 0; j < tableLayoutPanel2_RobotSea.Controls.Count; j++)
            {
                tableLayoutPanel2_RobotSea.Controls[j].Name = "Robot Ship";
                tableLayoutPanel2_RobotSea.Controls[j].Enabled = true;
            }
            //Initialize hand cards in different radiobuttons
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
            //To record the deployment x and y axis values of robot ships
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
            //Who get first round? Use rand to generate a number and make different player play
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
            //Force to update listBox and show current status in label
            listBox_GameHistory.DataSource = null;
            history.Add((history.HistoryCounter++), "Game Start." + playerName + " joins game. Team is " + playerTeam + ".");
            listBox_GameHistory.DataSource = history.HistoryList;
            label_GameStatus.Text = history.HistoryList[history.HistoryList.Count - 1];
        }

        /*#############################################################################
         * This part of code is general private method for any function need
         * ############################################################################*/
         /// <summary>
         /// This method is to check any abilities is currently on or need to be off
         /// </summary>
         /// <param name="whichCheck">The deployment of player or robot which need to be checked</param>
         /// <param name="whoCheck">The player or robot need to be checked</param>
         /// <param name="whickPanelCheck">The table layout panel to check enability</param>
        private void checkAbility(Ship[,] whichCheck, Player whoCheck, TableLayoutPanel whickPanelCheck)
        {
            //We have at most 12 ships objects, loop them all for checking
            for (int i = 0; i < 12; i++)
            {
                //the current ship is not a sea
                if (whichCheck[i / 4, i % 4].Name != "Sea")
                {
                    //It is Aircraft carrier, and having more than 0 health, the control is enable, or, do the ability
                    if (whichCheck[i / 4, i % 4].Name == "Aircraft Carrier" && whichCheck[i / 4, i % 4].HealthNum > 0 && whickPanelCheck.Controls[i].Enabled==true)
                    {
                        whoCheck.Full_RestOfCard = 7;
                    }
                    //else not do the ability
                    else if (whichCheck[i / 4, i % 4].Name == "Aircraft Carrier" && whichCheck[i / 4, i % 4].HealthNum <= 0)
                    {
                        whoCheck.Full_RestOfCard = 5;
                    }
                    //As similar as above code
                    if (whichCheck[i / 4, i % 4].Name == "Destroyer" && whichCheck[i / 4, i % 4].HealthNum > 0 && whickPanelCheck.Controls[i].Enabled == true)
                    {
                        if (whoCheck.Name == "NameMaxLengthOfHumanIs16")
                        {
                            robot_Des = true;
                        }
                        else
                        {
                            player_Des = true;
                        }
                    }
                    else if (whichCheck[i / 4, i % 4].Name == "Destroyer" && whichCheck[i / 4, i % 4].HealthNum <= 0)
                    {
                        if (whoCheck.Name == "NameMaxLengthOfHumanIs16")
                        {
                            robot_Des = false;
                        }
                        else
                        {
                            player_Des = false;
                        }
                    }
                    //As similar as above code
                    if (whichCheck[i / 4, i % 4].Name == "Battleship" && whichCheck[i / 4, i % 4].HealthNum > 0 && whickPanelCheck.Controls[i].Enabled == true)
                    {
                        if (whoCheck.Name == "NameMaxLengthOfHumanIs16")
                        {
                            robot_Bat = true;
                        }
                        else
                        {
                            player_Bat = true;
                        }
                    }
                    else if (whichCheck[i / 4, i % 4].Name == "Battleship" && whichCheck[i / 4, i % 4].HealthNum <= 0)
                    {
                        if (whoCheck.Name == "NameMaxLengthOfHumanIs16")
                        {
                            robot_Bat = false;
                        }
                        else
                        {
                            player_Bat = false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Exit this application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Close the application
            this.Close();
        }

        /// <summary>
        /// Whenever start a new game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startNewGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Update the statu
            label_GameStatus.Text = history.HistoryList[history.HistoryList.Count - 1];
            //This form is hidden
            this.Hide();
            //New form constructed
            NewGameSetting gameSetting = new NewGameSetting(this, history);
            //Show that form
            gameSetting.Show();
        }

        /// <summary>
        /// Check the robot deployment
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void robotDeploymentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if this game starts
            if (!this.Text.Contains("No Mode"))
            {
                //Local variable
                string outputData = "";
                //For 12 ships to loop
                for (int i = 0; i < 12; i++)
                {
                    //Different ship
                    Ship currentRobotShip = robotDeployment_[i / 4, i % 4];
                    //Add to variable
                    outputData += currentRobotShip.Name.PadRight(16);
                    //Just put other values into new line
                    if (i == 3 || i == 7)
                    {
                        outputData += "\n";
                    }
                }
                //Show the message
                MessageBox.Show(outputData);
            }
            //Game is not ready
            else
            {
                //Show message
                MessageBox.Show("Not Ready!");
            }
        }

        /// <summary>
        /// Check the current robot hand cards
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void robotHandCardsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //No mode means this is the original form
            if (!this.Text.Contains("No Mode"))
            {
                //Output variable
                string outputData = "";
                //For each hand cards to loop
                for (int i = 0; i < robot_.MyCards.InHandCards.Count; i++)
                {
                    //If it is peg
                    if (robot_.MyCards.InHandCards[i] is Peg)
                    {
                        //Add to string variable
                        Peg card = (Peg)robot_.MyCards.InHandCards[i];
                        outputData += robot_.MyCards.InHandCards[i].Name + "   " + card.AttackNum + "\n";
                    }
                    //If it is Power
                    else if (robot_.MyCards.InHandCards[i] is Power)
                    {
                        //Add to string variable
                        Power card = (Power)robot_.MyCards.InHandCards[i];
                        outputData += robot_.MyCards.InHandCards[i].Name + "\n";
                    }
                }
                //Show the message
                MessageBox.Show(outputData);
            }
            //If it is the original form
            else
            {
                //Show message not ready
                MessageBox.Show("Not Ready!");
            }
        }

        /// <summary>
        /// Output all the history currently recorded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void outputHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //No mode means the original form
            if (!this.Text.Contains("No Mode"))
            {
                //output variable
                string output = "";
                //Writer for writting a file
                StreamWriter wr;
                //Choosed a path
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    //Writer set up
                    wr = File.CreateText(saveFileDialog1.FileName);
                    //Add to string variable
                    for (int i = 0; i < history.HistoryList.Count; i++)
                    {
                        output += history.HistoryList[i] + "\n";
                    }
                    //Write things
                    wr.Write(output);
                    //Close writer
                    wr.Close();
                }
            }
            //If not ready
            else
            {
                MessageBox.Show("Not Ready!");
            }
        }
        /// <summary>
        /// Once the form is closed, exit the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BattleShipMainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Exit application
            Application.Exit();
        }
        /// <summary>
        /// Initial the deployment of ships for every buttons in tablelayoutpanel
        /// </summary>
        /// <param name="targetControl">Which tablelayoutpanel to initial</param>
        /// <param name="playerDeploy">The player deployment</param>
        private void initialDeployShips(TableLayoutPanel targetControl, Ship[,] playerDeploy)
        {
            //int variables for locating
            int arrayX = 0;
            int arrayY = 0;
            //For each buttons to loop
            for (int i = 0; i < targetControl.Controls.Count; i++)
            {
                //If it is button
                if (targetControl.Controls[i] is Button)
                {
                    //Set the button text to the ship object name
                    targetControl.Controls[i].Text = playerDeploy[arrayX, arrayY].Name;
                    //Calculate next locating point
                    arrayY++;
                    if (arrayY == 4)
                    {
                        arrayY = 0;
                        arrayX++;
                    }
                    //Close the button
                    targetControl.Controls[i].Enabled = false;
                }
            }
        }
        /// <summary>
        /// Update the current history
        /// </summary>
        /// <param name="addHistory">Text history to update</param>
        private void updateHistory(string addHistory)
        {
            //Call add method to add in history object
            history.Add(history.HistoryCounter++, addHistory);
            //Update listbox and show the current status
            label_GameStatus.Text = history.HistoryList[history.HistoryList.Count - 1];
            listBox_GameHistory.DataSource = null;
            listBox_GameHistory.DataSource = history.HistoryList;
            listBox_GameHistory.SetSelected(history.HistoryCounter - 1, true);
        }
        /// <summary>
        /// Update the text of each button
        /// </summary>
        /// <param name="whichTableLayoutPanel">Which tablelayoutpanel to update the buttons text</param>
        private void updateButtonText(TableLayoutPanel whichTableLayoutPanel)
        {
            //For each buttons to loop
            for (int i = 0; i < 12; i++)
            {
                //If the button is now enabled
                if (whichTableLayoutPanel.Controls[i].Enabled == true)
                {
                    //If the text is not Sea
                    if (whichTableLayoutPanel.Controls[i].Text != "Sea")
                    {
                        //Update the button text with ship object
                        Ship updateShip = (Ship)robotDeployment_[i / 4, i % 4];
                        if (updateShip.ShieldNum > 0)
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
        /// <summary>
        /// The main method of player playing the game
        /// This method includes find the card the player use
        /// and the target area in robot sea and does the card
        /// at the area
        /// </summary>
        /// <param name="robotY">The Y-axis of robot deployment</param>
        /// <param name="robotX">The X-axis of robot deployment</param>
        private void playerPlay(int robotY, int robotX)
        {
            //Minus player rest round
            human_.Full_RestOfRound--;
            //find the card variable
            int playerCardIndex = -1;
            //For each hand card to loop
            for (int i = 0; i < tableLayoutPanel4_PlayerHandCards.Controls.Count; i++)
            {
                //Cast the controls to radiobutton
                RadioButton r = (RadioButton)tableLayoutPanel4_PlayerHandCards.Controls[i];
                //If the radiobutton is checked
                if (r.Checked)
                {
                    //Pass value to playerCardIndex
                    playerCardIndex = i;
                    //Break loop
                    break;
                }
            }
            //If the index is great than -1, this means player do select a card
            if (playerCardIndex > -1)
            {
                //Pass the value to variable like reference
                HandCard currentCard = human_.MyCards.InHandCards[playerCardIndex];
                //Call check ability if there any ability changed in FULL GAME
                if(!baseMode)
                    checkAbility(playerDeployment_, human_, tableLayoutPanel3_PlayerSea);
                //If it is peg
                if (currentCard is Peg)
                {
                    //Cast the hand card to peg
                    Peg pegCurrent = (Peg)currentCard;
                    //If the color is white and destroy is appear, then white card use as red peg
                    if (pegCurrent.Color == "White" && player_Des)
                    {
                        //Set up a new peg to attack
                        Peg changedToRed = new Peg(pegCurrent.Name, pegCurrent.AttackNum, "Red");
                        changedToRed.usePegCard(robotDeployment_[robotY, robotX], human_.Mode);
                    }
                    else
                    {
                        //Else just use the original peg
                        pegCurrent.usePegCard(robotDeployment_[robotY, robotX], human_.Mode);
                    }
                    //If the battleship is appear and the peg is Red
                    if (player_Bat && pegCurrent.Name.Contains("Red"))
                    {
                        //Additional attack +1
                        Peg addition = new Peg("Red Peg", 1, "Red");
                        addition.usePegCard(robotDeployment_[robotY, robotX], human_.Mode);
                    }
                    //Any new ship appear and record it for the ability
                    if (robotDeployment_[robotY, robotX].Name == "Aircraft Carrier")
                    {
                        if (robotDeployment_[robotY, robotX].HealthNum > 0)
                        {
                            robot_.Full_RestOfCard = 7;
                        }
                        else
                        {
                            robot_.Full_RestOfCard = 5;
                        }
                    }
                    else if (robotDeployment_[robotY, robotX].Name == "Battleship")
                    {
                        if (robotDeployment_[robotY, robotX].HealthNum > 0)
                        {
                            robot_Bat = true;
                        }
                        else
                        {
                            robot_Bat = false;
                        }
                    }
                    else if (robotDeployment_[robotY, robotX].Name == "Destroyer")
                    {
                        if (robotDeployment_[robotY, robotX].HealthNum > 0)
                        {
                            robot_Des = true;
                        }
                        else
                        {
                            robot_Des = false;
                        }
                    }
                    //Discard the peg card
                    human_.disCards(pegCurrent);
                    human_.MyCards.InHandCards.Remove(pegCurrent);
                    //update the history
                    updateHistory("Player uses " + pegCurrent.Name + " " + pegCurrent.AttackNum + " to attack robot's " + robotDeployment_[robotY, robotX].Name);
                    //Update hand cards
                    playerUpdateHandCard();
                }
                else if (currentCard is Power)
                {
                    //not necessary to apply anythings
                    //Because there is no power related with AI ship
                }
            }
            //Draw cards for player
            if (baseMode)
            {
                human_.drawCards(1);
            }
            else
            {
                if ((human_.MyCards.InHandCards.Count) < human_.Full_RestOfCard && human_.Full_RestOfRound <= 0)
                {
                    human_.drawCards(human_.Full_RestOfCard - human_.MyCards.InHandCards.Count);
                }
            }
            //Update hand card
            playerUpdateHandCard();
            //Update the button text
            updateButtonText(tableLayoutPanel3_PlayerSea);
        }

        /// <summary>
        /// The method is like to summary the act of player done before.
        /// It update the text of controls, the status of abilities
        /// </summary>
        /// <param name="targetButton">The button in robot sea</param>
        private void playerMatchRobotShip(Button targetButton)
        {
            //If the robot win, it is not necessary to continue game
            if (!robotWin)
            {
                //Variables need for locating
                int buttonIndex = tableLayoutPanel2_RobotSea.Controls.GetChildIndex(targetButton);
                int x = buttonIndex % 4;
                int y = buttonIndex / 4;
                //change the targetButton text
                targetButton.Text = robotDeployment_[y, x].Name;
                //If it is Sea
                if (targetButton.Text == "Sea")
                {
                    targetButton.Enabled = false;
                }
                else
                {
                    //Else it is others, add the health info
                    targetButton.Text += "\n(Health:" + robotDeployment_[y, x].HealthNum + ")";
                    if (robotDeployment_[y, x].ShieldNum > 0)
                    {
                        //Having shield? add the shield info
                        targetButton.Text += "(Shield:" + robotDeployment_[y, x].ShieldNum + ")";
                    }
                }
                //Is the ship sunk?
                if (robotDeployment_[y, x].HealthNum <= 0 && robotDeployment_[y, x].Name != "Sea")
                {
                    //target not enable
                    targetButton.Enabled = false;
                    //Update history
                    updateHistory("Robot's " + robotDeployment_[y, x].Name + " is now sunk.");
                    //Play discovered one more
                    playerDiscover++;
                    //Change the ability
                    if (robotDeployment_[y, x].Name == "Aircraft Carrier")
                    {
                        robot_.Full_RestOfCard = 5;
                    }
                    else if (robotDeployment_[y, x].Name == "Battleship")
                    {
                        robot_Bat = false;
                    }
                    else if (robotDeployment_[y, x].Name == "Destroyer")
                    {
                        robot_Des = false;
                    }
                }
                //If you discover 5 ships, you win!
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

        /// <summary>
        /// In full game, the player acts abilities or power in player-self ships
        /// This method is to use shield and PT Boat ability
        /// </summary>
        /// <param name="targetShipButton">The button in robot sea</param>
        private void playerShipsAct(Button targetShipButton)
        {
            //Minus player rest round
            human_.Full_RestOfRound--;
            //player card index
            int playerCardIndex = -1;
            //For each controls, radiobutton, to go
            for (int i = 0; i < tableLayoutPanel4_PlayerHandCards.Controls.Count; i++)
            {
                //Ready to cast
                if (tableLayoutPanel4_PlayerHandCards.Controls[i] is RadioButton)
                {
                    //Cast it
                    RadioButton r = (RadioButton)tableLayoutPanel4_PlayerHandCards.Controls[i];
                    //get index
                    if (r.Checked)
                    {
                        playerCardIndex = i;
                        break;
                    }
                }
            }
            //index is 0 or above
            if (playerCardIndex > -1)
            {
                //Get a reference
                HandCard currentCard = human_.MyCards.InHandCards[playerCardIndex];
                //Current card is power and not a peg
                if (currentCard is Power && !currentCard.Name.Contains("Peg"))
                {
                    //Cast to power
                    Power usePower = (Power)currentCard;
                    //button index
                    int index = 0;
                    //If it the shield
                    if (usePower.Name == "Shield")
                    {
                        //Foreach buttons to loop
                        foreach (Button b in tableLayoutPanel3_PlayerSea.Controls)
                        {
                            //if the b is our target ship button
                            if (b == targetShipButton)
                            {
                                break;
                            }
                            index++;
                        }
                        //Referce a targetship
                        Ship targetShip = playerDeployment_[index / 4, index % 4];
                        //Use the power card, shield
                        usePower.useCard(targetShip, targetShipButton);
                        //Update history
                        updateHistory("Player use Shield on " + targetShip.Name);
                        //ShieldOn get the usePower card, shield
                        targetShip.ShieldOn = usePower;
                        //Player discard usepower and remove it
                        human_.MyCards.InHandCards.Remove(usePower);
                        human_.disCards(usePower);
                        //Restyle it
                        if (human_.Team == "Red")
                        { targetShipButton.ForeColor = Color.Red; targetShipButton.BackColor = Control.DefaultBackColor; }
                        else
                        { targetShipButton.ForeColor = Color.Blue; targetShipButton.BackColor = Control.DefaultBackColor; }
                        //human draw one more card
                        human_.drawCards(1);
                        //Update hand card
                        playerUpdateHandCard();
                    }
                    //Player can repair a ship
                    else if (playerRepair)
                    {
                        //Minus rest of round of player
                        human_.Full_RestOfRound--;
                        //Foreach buttons in tablelayoutpanel
                        foreach (Button b in tableLayoutPanel3_PlayerSea.Controls)
                        {
                            //The button is target button
                            if (b == targetShipButton)
                            {
                                break;
                            }
                            index++;
                        }
                        //Reference the ship
                        Ship targetShip = playerDeployment_[index / 4, index % 4];
                        //use the repair power
                        usePower.useCard(usePower, "1", human_, targetShip);
                        //Update history
                        updateHistory("Player repaired the " + targetShip.Name+" by "+usePower.Name);
                        //reenable the radiobuttons
                        tableLayoutPanel4_PlayerHandCards.Enabled = true;
                        //Player discard the power
                        human_.disCards(usePower);
                        human_.MyCards.InHandCards.Remove(usePower);
                        //Restyle it
                        if (human_.Team == "Red")
                        { targetShipButton.ForeColor = Color.Red; targetShipButton.BackColor = Control.DefaultBackColor; }
                        else
                        { targetShipButton.ForeColor = Color.Blue; targetShipButton.BackColor = Control.DefaultBackColor; }
                        //repair bool comes false
                        playerRepair = false;
                        //Update button text
                        updateButtonText(tableLayoutPanel4_PlayerHandCards);
                    }
                }
                else
                {
                    //If the PT Boat is clicked as using a power
                    if (targetShipButton.Text.Contains("PT") && !player_PT)
                    {
                        //Rest of round comes 1
                        human_.Full_RestOfRound = 1;
                        //PT bool comes to true
                        player_PT = true;
                        //For each buttons in tablelayoutpanel for stylizing
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
                        //Message box shows up
                        MessageBox.Show("Now Choose a ship to repair!");
                    }
                    else if (player_PT)
                    {
                        //Using ability of PT Boat
                        int index = 0;
                        //Search target ship button
                        foreach (Button b in tableLayoutPanel3_PlayerSea.Controls)
                        {
                            if (b == targetShipButton)
                            {
                                break;
                            }
                            index++;
                        }
                        //Reference the target ship
                        Ship target = playerDeployment_[index / 4, index % 4];
                        //Repair it
                        target.HealthNum += 1;
                        //Update history
                        updateHistory("Player repaired the " + target.Name + " by PT Boat ability");
                        //Update button text
                        updateButtonText(tableLayoutPanel3_PlayerSea);
                        //PT bool get back to false
                        player_PT = false;
                        //Restyle it
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
                        //If human round is end
                        if (human_.Full_RestOfRound <= 0)
                        {
                            robotPlay_Full();
                        }
                    }
                }
            }
            else if (playerCardIndex == -1)
            {
                //Same as above PT Boat using as power, here is just to be a case that player not select
                //radiobutton and directly click PT Boat for repair
                if (targetShipButton.Text.Contains("PT") && !player_PT)
                {
                    player_PT = true;
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
                    MessageBox.Show("Now Choose a ship to repair!");
                }
                else if (player_PT)
                {
                    int index = 0;
                    foreach (Button b in tableLayoutPanel3_PlayerSea.Controls)
                    {
                        if (b == targetShipButton)
                        {
                            break;
                        }
                        index++;
                    }
                    Ship target = playerDeployment_[index / 4, index % 4];
                    target.HealthNum += 1;
                    updateButtonText(tableLayoutPanel3_PlayerSea);
                    playerUpdateHandCard();
                    if (human_.Full_RestOfRound <= 0)
                    {
                        robotPlay_Full();
                    }
                    player_PT = false;
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

        }

        /// <summary>
        /// Update current hand cards to radiobuttons
        /// </summary>
        private void playerUpdateHandCard()
        {
            //For each radiobutton to loop, check the in hand card count with the loop counter
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

        /// <summary>
        /// Player uses power card, like repair a ship then play 1
        /// </summary>
        /// <param name="selected">The current power card selected</param>
        private void playerPowerUse(RadioButton selected)
        {
            //Search for radiobutton clicked
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
            //The power name checking
            if (selected.Text == "Discard White Peg or Play 2 Cards")
            {
                //Show message box for asking what power to go
                DialogResult dr =
                    MessageBox.Show("There are two function to select.\nA.Discard White\nB.Play 2 Cards\nThe default is to use A. Click Yes if you agree or No to use the another.", "Power Card", MessageBoxButtons.YesNoCancel);
                //Yes is the first power
                if (dr == DialogResult.Yes)
                {
                    //Update history
                    updateHistory("Player use power card to Discard White Peg");
                    //minus human rest round
                    human_.Full_RestOfRound--;
                    //Cast the hand card to power
                    Power disWhite = (Power)human_.MyCards.InHandCards[playerCardIndex];
                    //Set up a list for collecting white cards
                    List<Peg> whites = new List<Peg>();
                    //Collect white cards
                    for (int i = 0; i < human_.MyCards.InHandCards.Count; i++)
                    {
                        if (human_.MyCards.InHandCards[i].Name == "White Peg")
                        {
                            whites.Add((Peg)human_.MyCards.InHandCards[i]);
                        }
                    }
                    //Discard white cards one by one
                    for (int i = 0; i < whites.Count; i++)
                    {
                        human_.disCards(whites[i]);
                        human_.MyCards.InHandCards.Remove(whites[i]);
                    }
                    //Then discard the power
                    human_.disCards(disWhite);
                    human_.MyCards.InHandCards.Remove(disWhite);
                    //If the player round is end
                    if (human_.Full_RestOfRound <= 0)
                    {
                        if ((human_.MyCards.InHandCards.Count) < human_.Full_RestOfCard)
                        {
                            human_.drawCards(human_.Full_RestOfCard - human_.MyCards.InHandCards.Count);
                        }
                        playerUpdateHandCard();
                        robotPlay_Full();
                    }
                }
                else if (dr == DialogResult.No)
                {
                    //Update history
                    updateHistory("Player use power card to play two more times");
                    //else if using the second power
                    human_.Full_RestOfRound--;
                    //The rest round is less than 0
                    if (human_.Full_RestOfRound <= 0)
                    {
                        //Then make it to 2
                        human_.Full_RestOfRound = 2;
                    }
                    else
                    {
                        //else add 2 to rest round
                        human_.Full_RestOfRound += 2;
                    }
                    //Discard the power
                    human_.disCards(human_.MyCards.InHandCards[playerCardIndex]);
                    human_.MyCards.InHandCards.RemoveAt(playerCardIndex);
                    //Update hand cards
                    playerUpdateHandCard();
                }

            }
            else if (selected.Text == "Repair a ship or Draw 3 Cards, then Play 1")
            {
                //if it is the other power card
                DialogResult dr =
                    MessageBox.Show("There are two function to select.\nA.Repair a ship then play 1\nB.Draw 3 Cards then play 1\nThe default is to use A. Click Yes if you agree or No to use the another.", "Power Card", MessageBoxButtons.YesNoCancel);
                if (dr == DialogResult.Yes)
                {
                    //Update history
                    updateHistory("Player use power card to Repair a ship.");
                    //repair bool to true
                    playerRepair = true;
                    //minus human rest round
                    human_.Full_RestOfRound--;
                    //player discard the power
                    human_.disCards(human_.MyCards.InHandCards[playerCardIndex]);                    
                    human_.MyCards.InHandCards.RemoveAt(playerCardIndex);
                    //Restyle it
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
                    //Show the message to repair
                    MessageBox.Show("Now choose a ship for repair");
                    //Not enable other cards for using
                    tableLayoutPanel4_PlayerHandCards.Enabled = false;
                }
                else if (dr == DialogResult.No)
                {
                    //Update history
                    updateHistory("Player use power card to Draw 3 cards");
                    //Minus rest round
                    human_.Full_RestOfRound--;
                    //discard the power
                    human_.disCards(human_.MyCards.InHandCards[playerCardIndex]);
                    human_.MyCards.InHandCards.RemoveAt(playerCardIndex);
                    //Draw 3 new cards
                    human_.drawCards(3);
                    //Update hand card
                    playerUpdateHandCard();
                }
            }
            else if (selected.Text == "Shield")
            {
                //If it is shield, stylize button for using shield
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
                //If it is choosing others, restylizing
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
        /* The main logic is
        / 1. Check dameged ships and if AI can repair
        /     1.1 Yes, AI can repair.So just repair the dameged ship, round end.
        /     1.2 No, AI cannot repair.So,
        /         1.2.1 Does AI find any ships in player sea? Yes, then go to 2
        /         1.2.2 No? AI is going to check new area, then go to 3
        / 2. AI found ships before, and if AI can attack
        /     2.1 Yes, AI can attack.So just use peg to attack it, round end.
        /     2.2 No, AI cannot attack.So go to 3, let AI find any thing new.
        / 3. AI use peg to find/attack a new place in player sea OR play a Power
        /     3.1 Yes, there is a ship, so AI record the ship, round end.
        /     3.2 NO, any way, round end.
        / 4. If round end, check does AI win? 
        /     4.1 Yes, AI win! Stop the game and show messageBox
        /     4.2 No, pick up a new card to go*/

        /// <summary>
        /// This method is robot play its round in full game mode
        /// Use a loop if AI have more than 1 round to go
        /// Pick up new cards in this method as well
        /// </summary>
        private void robotPlay_Full()
        {
            //While loop for any rest round is not negative
            while (robot_.Full_RestOfRound > 0)
            {
                //If human is not won
                if (!humanWin)
                {
                    //Call main method of robotplay
                    robotPlay_Full_Main();
                }
                else
                {
                    //Human win? break the loop
                    break;
                }
            }
            //Card cards
            if (robot_.MyCards.InHandCards.Count < robot_.Full_RestOfCard)
            {
                robot_.MyCards.drawCards(robot_.Full_RestOfCard - robot_.MyCards.InHandCards.Count);
            }
            //Recover the rest round
            robot_.Full_RestOfRound = 1;
        }

        /// <summary>
        /// The main method robot will use, just follow the logic before
        /// </summary>
        private void robotPlay_Full_Main()
        {
            //Full Game
            if (!humanWin)
            {
                //Minus round
                robot_.Full_RestOfRound--;
                //Check logic NO.1
                if (robotPlay_Full_FindDamegedShip() != null)
                {
                    //Any dameged ships?
                    Ship damegedShip = robotPlay_Full_FindDamegedShip();
                    //hasShield bool to store if AI has shield
                    bool hasShield = false;
                    //Shield index for locating
                    int shieldIndex = 0;
                    //For each hand card in AI and check Shield
                    foreach (HandCard h in robot_.MyCards.InHandCards)
                    {
                        if (h.Name == "Shield")
                        {
                            hasShield = true;
                            break;
                        }
                        shieldIndex++;
                    }
                    //If AI has shield then use shiled to dameged ship
                    if (hasShield)
                    {
                        Power shield = (Power)robot_.MyCards.InHandCards[shieldIndex];
                        robotPlay_Full_Shield(shield, damegedShip);
                        robot_.MyCards.InHandCards.Remove(shield);
                        robot_.disCards(shield);
                        updateHistory("Robot uses Shield card on " + damegedShip.Name);
                    }
                    //Else to check if having PT Boat then use PT Boat for recover health
                    else if (robotPlay_Full_FindAppearedShip("PT Boat") != null)
                    {
                        Ship pt = robotPlay_Full_FindAppearedShip("PT Boat");
                        pt.useCard(damegedShip);
                        updateHistory("Robot repair " + damegedShip.Name + " by PT Boat");
                        if (damegedShip.Name != "Sea")
                        {
                            tableLayoutPanel2_RobotSea.Controls[damegedShip.DeploymentY * 4 + damegedShip.DeploymentX].Text = robotDeployment_[damegedShip.DeploymentY, damegedShip.DeploymentX].Name + "\n(Health:" + robotDeployment_[damegedShip.DeploymentY, damegedShip.DeploymentX].HealthNum + ")";
                            if (damegedShip.ShieldNum > 0)
                            {
                                tableLayoutPanel3_PlayerSea.Controls[damegedShip.DeploymentY * 4 + damegedShip.DeploymentX].Text = playerDeployment_[damegedShip.DeploymentY, damegedShip.DeploymentX].Name + "\n(Health:" + playerDeployment_[damegedShip.DeploymentY, damegedShip.DeploymentX].HealthNum + ")" +
                                    "(Shield:" + damegedShip.ShieldNum + ")";
                            }
                            else if (damegedShip.ShieldNum <= 0 && damegedShip.ShieldOn != null)
                            {
                                Power Shield = damegedShip.ShieldOn;
                                human_.MyCards.discards(Shield);
                                damegedShip.ShieldOn = null;
                            }
                        }
                    }
                    else
                    {
                        //Else not help to do, then check AI having found other ships before
                        if (robotFindShips.Count != 0)
                        {
                            //If having ships, then call the Full_Attackship method to attack
                            robotPlay_Full_AttackShip();
                        }
                        else
                        {
                            //Else to find new ship
                            robotPlay_Full_FindNewShipOrOtherAct();
                        }
                    }
                }
                else if (robotFindShips.Count != 0)
                {
                    //If having ship found, then attack
                    robotPlay_Full_AttackShip();
                }
                else
                {
                    //If not having ship found, then to find one new
                    robotPlay_Full_FindNewShipOrOtherAct();
                }
                //Update button text
                updateButtonText(tableLayoutPanel2_RobotSea);
                //Check if robot is winning
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

        /// <summary>
        /// Method of finding any dameged ships, robotPlay_Full_Main() will use this method
        /// </summary>
        /// <returns>A dameged ship</returns>
        private Ship robotPlay_Full_FindDamegedShip()
        {
            //For each ships to loop for checking if it is dameged
            foreach (Ship s in robotDeployment_)
            {
                if ((s.Name == "Submarine" && 0 < s.HealthNum && s.HealthNum < 3) || (s.Name == "PT Boat" && 0 < s.HealthNum && s.HealthNum < 2) || (s.Name == "Destroyer" && 0 < s.HealthNum && s.HealthNum < 3)
                    || (s.Name == "Battleship" && 0 < s.HealthNum && s.HealthNum < 4) || (s.Name == "Aircraft Carrier" && 0 < s.HealthNum && s.HealthNum < 5))
                {
                    return s;
                }
            }
            return null;
        }

        /// <summary>
        /// Method of finding an appeared ship by its name, robotPlay_Full_Main() will call this method
        /// </summary>
        /// <param name="needFindShip">The name of ship wants to be found</param>
        /// <returns></returns>
        private Ship robotPlay_Full_FindAppearedShip(string needFindShip)
        {
            //For each ships to loop for finding appeared ship
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

        /// <summary>
        /// Shield add-on method in Full game mode
        /// Easily use shield card to add shield to targetship
        /// </summary>
        /// <param name="Shield">The Shield Power Card</param>
        /// <param name="targetShip">The ship which add the shield</param>
        private void robotPlay_Full_Shield(Power Shield, Ship targetShip)
        {
            //Use the shield by AI
            Button targetButton = (Button)tableLayoutPanel2_RobotSea.Controls[targetShip.DeploymentY * 4 + targetShip.DeploymentX];
            Shield.useCard(targetShip, targetButton);
            targetShip.ShieldOn = Shield;
        }

        /// <summary>
        /// This method to achieve logic NO.3, to find a new place in player sea
        /// </summary>
        private void robotPlay_Full_FindNewShipOrOtherAct()
        {            
            //Three cards reference ready
            Card currentCard;
            Peg pegCurrentCard;
            Power powerCurrentCard;
            //Get the current card by chance
            currentCard = robot_.MyCards.InHandCards[rand.Next(robot_.MyCards.InHandCards.Count)];
            //If it is peg
            if (currentCard is Peg)
            {
                //Cast to peg
                pegCurrentCard = (Peg)currentCard;
                //Check the current ability
                checkAbility(robotDeployment_, robot_,tableLayoutPanel2_RobotSea);
                //Find if AI has white peg to find ships
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
                //DiscoverMatrix remove this point
                robotDiscoverMatrix.Remove(playerSea);
                //Check if this point is searched before
                if (robotDiscoveredMatrix[playerSea.Y, playerSea.X] != 1)
                {
                    //reference the ship
                    Ship targetShip = playerDeployment_[playerSea.Y, playerSea.X];
                    //Get the Deployment location
                    targetShip.DeploymentX = playerSea.X;
                    targetShip.DeploymentY = playerSea.Y;
                    //Use peg card to attack
                    pegCurrentCard.usePegCard(targetShip, robot_.Mode);
                    //Robot dis card
                    robot_.disCards(pegCurrentCard);
                    robot_.MyCards.InHandCards.Remove(pegCurrentCard);
                    //Update history
                    updateHistory("Robot use " + pegCurrentCard.Name + " to find " + human_.Name + "'s " + targetShip.Name);
                    //Enable the button
                    tableLayoutPanel3_PlayerSea.Controls[targetShip.DeploymentY * 4 + targetShip.DeploymentX].Enabled = true;
                    //If the target ship is not sea, then update the text of button and changing the ability
                    if (targetShip.Name != "Sea")
                    {
                        tableLayoutPanel3_PlayerSea.Controls[targetShip.DeploymentY * 4 + targetShip.DeploymentX].Text = playerDeployment_[playerSea.Y, playerSea.X].Name + "\n(Health:" + playerDeployment_[playerSea.Y, playerSea.X].HealthNum + ")";
                        if (targetShip.ShieldNum > 0 && targetShip.ShieldOn != null)
                        {
                            tableLayoutPanel3_PlayerSea.Controls[targetShip.DeploymentY * 4 + targetShip.DeploymentX].Text = playerDeployment_[playerSea.Y, playerSea.X].Name + "\n(Health:" + playerDeployment_[playerSea.Y, playerSea.X].HealthNum + ")" +
                                "(Shield:" + targetShip.ShieldNum + ")";
                        }
                        else if (targetShip.ShieldNum <= 0 && targetShip.ShieldOn != null)
                        {
                            Power Shield = targetShip.ShieldOn;
                            human_.MyCards.discards(Shield);
                            targetShip.ShieldOn = null;
                        }
                        robotFindShips.Add(targetShip);
                        if (targetShip.Name == "Aircraft Carrier")
                        {
                            if (targetShip.HealthNum > 0)
                            {
                                human_.Full_RestOfCard = 7;
                            }
                            else
                            {
                                human_.Full_RestOfCard = 5;
                            }
                        }
                        else if (targetShip.Name == "Battleship")
                        {
                            if (targetShip.HealthNum > 0)
                            {
                                player_Bat = true;
                            }
                            else
                            {
                                player_Bat = false;
                            }
                        }
                        else if (targetShip.Name == "Destroyer")
                        {
                            if (targetShip.HealthNum > 0)
                            {
                                player_Des = true;
                            }
                            else
                            {
                                player_Des = false;
                            }
                        }
                    }
                    //if one target ship is sunk, then update history and update the ability
                    if (targetShip.HealthNum <= 0 && targetShip.Name != "Sea")
                    {
                        tableLayoutPanel3_PlayerSea.Controls[targetShip.DeploymentY * 4 + targetShip.DeploymentX].Enabled = false;
                        updateHistory("Player's " + targetShip.Name + " is now sunk.");
                        robotFindShips.Remove(targetShip);
                        robotDiscover++;
                        if (targetShip.Name == "Aircraft Carrier")
                        {
                            human_.Full_RestOfCard = 5;
                        }
                        else if (targetShip.Name == "Battleship")
                        {
                            player_Bat = false;
                        }
                        else if (targetShip.Name == "Destroyer")
                        {
                            player_Des = false;
                        }
                    }
                    //Flag that AI check the area
                    robotDiscoveredMatrix[playerSea.Y, playerSea.X] = 1;
                }

            }
            else
            {
                //If it is power
                powerCurrentCard = (Power)currentCard;
                //If it is not the shield
                if (powerCurrentCard.Name != "Shield")
                {
                    //Call the method for using power
                    if (powerCurrentCard.Name == "Discard White Peg or Play 2 Cards")
                    {
                        int functionnum = rand.Next() % 2;
                        powerCurrentCard.useCard(powerCurrentCard, functionnum.ToString(), robot_, null);
                        if (functionnum == 1)
                        {
                            //update history
                            updateHistory("AI use the power card - discard white peg");
                        }
                        else
                        {
                            updateHistory("AI use the power card - play 2 cards");
                        }
                    }
                    else if (powerCurrentCard.Name == "Repair a ship or Draw 3 Cards, then Play 1")
                    {
                        //If want to use Repair a ship or draw 3 card
                        Ship ship = robotPlay_Full_FindDamegedShip();
                        int functionnum = 0;
                        if (ship!=null)
                        {
                            functionnum = 1;
                        }
                        if (functionnum == 1)
                        {
                            powerCurrentCard.useCard(powerCurrentCard, functionnum.ToString(), robot_, ship);
                            updateHistory("AI use the power card - Repair a ship " + ship.Name);
                        }
                        else
                        {
                            powerCurrentCard.useCard(powerCurrentCard, 0.ToString(), robot_, null);
                            updateHistory("AI use the power card - Draw 3 cards");
                        }
                    }
                    //Remove the power card
                    robot_.MyCards.InHandCards.Remove(powerCurrentCard);
                    robot_.disCards(powerCurrentCard);
                }
            }

        }

        /// <summary>
        /// This method to achieve logic NO.2, to attack a ship which is found before
        /// </summary>
        private void robotPlay_Full_AttackShip()
        {
            //Set up reference
            Ship targetShip = robotFindShips[rand.Next(robotFindShips.Count)];
            Peg currentCard = (Peg)robotPlay_ChooseOneCardAttack(targetShip);
            //If the card is not null
            if (currentCard != null)
            {
                //Check the ability
                checkAbility(robotDeployment_, robot_,tableLayoutPanel2_RobotSea);
                //Attacking with abilities
                if (currentCard.Color == "White" && robot_Des)
                {
                    Peg changedToRed = new Peg(currentCard.Name, currentCard.AttackNum, "Red");
                    changedToRed.usePegCard(targetShip, robot_.Mode);
                }
                else
                {
                    currentCard.usePegCard(targetShip, robot_.Mode);
                }
                if (robot_Bat)
                {
                    Peg addition = new Peg("Red Peg", 1, "Red");
                    addition.usePegCard(targetShip, robot_.Mode);
                }
                //AI discard card
                robot_.MyCards.InHandCards.Remove(currentCard);
                robot_.disCards(currentCard);
                //Update button text and shield stuff
                if (targetShip.Name != "Sea")
                {
                    tableLayoutPanel3_PlayerSea.Controls[targetShip.DeploymentY * 4 + targetShip.DeploymentX].Text = playerDeployment_[targetShip.DeploymentY, targetShip.DeploymentX].Name + "\n(Health:" + playerDeployment_[targetShip.DeploymentY, targetShip.DeploymentX].HealthNum + ")";
                    if (targetShip.ShieldNum > 0)
                    {
                        tableLayoutPanel3_PlayerSea.Controls[targetShip.DeploymentY * 4 + targetShip.DeploymentX].Text = playerDeployment_[targetShip.DeploymentY, targetShip.DeploymentX].Name + "\n(Health:" + playerDeployment_[targetShip.DeploymentY, targetShip.DeploymentX].HealthNum + ")" +
                            "(Shield:" + targetShip.ShieldNum + ")";
                    }
                    else if (targetShip.ShieldNum <= 0 && targetShip.ShieldOn != null)
                    {
                        Power Shield = targetShip.ShieldOn;
                        human_.MyCards.discards(Shield);
                        targetShip.ShieldNum = 0;
                        targetShip.ShieldOn = null;
                    }
                }
                //Any ship is sunk?
                if (!targetShip.Name.Contains("Sea") && targetShip.HealthNum <= 0)
                {
                    //Update the history and disable the button and change ability
                    tableLayoutPanel3_PlayerSea.Controls[targetShip.DeploymentY * 4 + targetShip.DeploymentX].Enabled = false;
                    updateHistory("Player's " + targetShip.Name + " is now sunk.");
                    robotFindShips.Remove(targetShip);
                    robotDiscover++;
                    if (targetShip.Name == "Aircraft Carrier")
                    {
                        robot_.Full_RestOfCard = 5;
                    }
                    else if (targetShip.Name == "Battleship")
                    {
                        robot_Bat = false;
                    }
                    else if (targetShip.Name == "Destroyer")
                    {
                        robot_Des = false;
                    }
                }
            }
            else
            {
                //Do other search
                robotPlay_Full_FindNewShipOrOtherAct();
            }
        }

        /// <summary>
        /// Base mode game
        /// The logic is much simple than Full game, in short
        /// 1. Any ships found before?
        ///     1.1 Yes, AI found at least one ship before, then attack it, round end
        ///     1.2 No, Ai did not. Then go to 2
        /// 2. AI find a new place
        ///     2.1 Oh, there is a ship in this place, record it and round end
        ///     2.2 Em..No ship, any way, round end
        /// 3. If round end, check does AI win? 
        ///     3.1 AI win, stop game and show message
        ///     3.2 Not win, continue game
        /// </summary>
        private void robotPlay_Base()
        {
            //Is human not won?
            if (!humanWin)
            {
                //Find any ships
                if (robotFindShips.Count != 0)
                {
                    //Reference set up
                    Ship targetShip = robotFindShips[rand.Next(robotFindShips.Count)];
                    //Cast peg
                    Peg currentCard = (Peg)robotPlay_ChooseOneCardAttack(targetShip);
                    //If the card is not null
                    if (currentCard != null)
                    {
                        //Use current card to attack ship
                        currentCard.usePegCard(targetShip, robot_.Mode);
                        //AI discard card
                        robot_.MyCards.InHandCards.Remove(currentCard);
                        robot_.disCards(currentCard);
                        //Update the button text
                        if (targetShip.Name != "Sea")
                        {
                            tableLayoutPanel3_PlayerSea.Controls[targetShip.DeploymentY * 4 + targetShip.DeploymentX].Text = playerDeployment_[targetShip.DeploymentY, targetShip.DeploymentX].Name + "\n(Health:" + playerDeployment_[targetShip.DeploymentY, targetShip.DeploymentX].HealthNum + ")";
                        }
                        //Any ship is sunk, update the button text and history
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
                        //Else do search for something new
                        robotPlay_Base_FindNewShipOrOtherAct();
                    }
                }
                else
                {
                    //Else do search for something new
                    robotPlay_Base_FindNewShipOrOtherAct();
                }
                //Draw new cards
                if (robot_.MyCards.InHandCards.Count < 5)
                {
                    robot_.MyCards.drawCards(5 - robot_.MyCards.InHandCards.Count);
                }
                //If robot discover is 5, then AI win
                if (robotDiscover == 5)
                {
                    //Disable all controls
                    for (int i = 0; i < tableLayoutPanel2_RobotSea.Controls.Count; i++)
                    {
                        tableLayoutPanel2_RobotSea.Controls[i].Enabled = false;
                        tableLayoutPanel3_PlayerSea.Controls[i].Enabled = false;
                    }
                    for (int i = 0; i < tableLayoutPanel4_PlayerHandCards.Controls.Count; i++)
                    {
                        tableLayoutPanel4_PlayerHandCards.Controls[i].Enabled = false;
                    }
                    //Update history and show message box
                    updateHistory("Robot Wins The Game.");
                    MessageBox.Show(":-(\nSad... You Lose...");
                    robotWin = true;
                }
            }
        }

        /// <summary>
        /// This a base-mode version of find a new ship or other act, to achieve logic NO.2
        /// </summary>
        private void robotPlay_Base_FindNewShipOrOtherAct()
        {
            //Set up reference
            Card currentCard;
            Peg pegCurrentCard;
            //If the card is 5
            if (robot_.MyCards.InHandCards.Count == 5)
            {
                //Random a card to use
                currentCard = robot_.MyCards.InHandCards[rand.Next(5)];
                if (currentCard is Peg)
                {
                    //Cast the card
                    pegCurrentCard = (Peg)currentCard;
                    //If it is not white, then find a white one
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
                    //Point stuff
                    Point playerSea = robotDiscoverMatrix[rand.Next(robotDiscoverMatrix.Count)];
                    robotDiscoverMatrix.Remove(playerSea);
                    //If it is not 1, it is a new place
                    if (robotDiscoveredMatrix[playerSea.Y, playerSea.X] != 1)
                    {
                        //Reference the ship
                        Ship targetShip = playerDeployment_[playerSea.Y, playerSea.X];
                        targetShip.DeploymentX = playerSea.X;
                        targetShip.DeploymentY = playerSea.Y;
                        //If it is not sea, then add to ship
                        if (targetShip.Name != "Sea")
                        {
                            robotFindShips.Add(targetShip);
                        }
                        //Use peg card
                        pegCurrentCard.usePegCard(targetShip, robot_.Mode);
                        //Discard peg
                        robot_.disCards(pegCurrentCard);
                        robot_.MyCards.InHandCards.Remove(pegCurrentCard);
                        //Update history
                        updateHistory("Robot use " + currentCard.Name + " to find " + human_.Name + "'s " + targetShip.Name);
                        //Enable button
                        tableLayoutPanel3_PlayerSea.Controls[targetShip.DeploymentY * 4 + targetShip.DeploymentX].Enabled = true;
                        //Update button text
                        if (targetShip.Name != "Sea")
                        {
                            tableLayoutPanel3_PlayerSea.Controls[targetShip.DeploymentY * 4 + targetShip.DeploymentX].Text = playerDeployment_[playerSea.Y, playerSea.X].Name + "\n(Health:" + playerDeployment_[playerSea.Y, playerSea.X].HealthNum + ")";
                        }
                        //Any ship is sunk? update history and disable button
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
        /// <summary>
        /// Both base and full game will call this method
        /// This method is to offer a hand card which is suitable to attack target
        /// The "suitable" means, which peg can attack more health or even kill target at once
        /// </summary>
        /// <param name="targerShip">The target ship which AI wants to attack</param>
        /// <returns>A suitable hand card</returns>
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
         * ############################################################################
         * The following is to call different playing method of both player and robot
         * The idea is that Different game mode call different methods
         * 1. Check the current game mode
         *  1.1 base game
         *      1.1.1 call playerPlay() with the X and Y axis value
         *      1.1.2 then call playerMatchRobotShip() with the button value to summary
         *      1.1.3 at last call robotPlay_Base() to let AI do it round
         *  1.2 Full game
         *      1.2.1 check the rest round of player
         *          1.2.1.1 player have rest round then player plays again
         *          1.2.1.2 player does not have rest round, then robot play
         *############################################################################*/         
        private void button_RobotShip1_Click(object sender, EventArgs e)
        {
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
            else
            {
                MessageBox.Show("Please play a card");                
            }
        }
        private void button_RobotShip2_Click(object sender, EventArgs e)
        {
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
            else
            {
                MessageBox.Show("Please play a card");
            }
        }
        private void button_RobotShip3_Click(object sender, EventArgs e)
        {
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
            else
            {
                MessageBox.Show("Please play a card");
            }
        }
        private void button_RobotShip4_Click(object sender, EventArgs e)
        {
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
            else
            {
                MessageBox.Show("Please play a card");
            }
        }
        private void button_RobotShip5_Click(object sender, EventArgs e)
        {
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
            else
            {
                MessageBox.Show("Please play a card");
            }
        }
        private void button_RobotShip6_Click(object sender, EventArgs e)
        {
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
            else
            {
                MessageBox.Show("Please play a card");
            }
        }
        private void button_RobotShip7_Click(object sender, EventArgs e)
        {
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
            else
            {
                MessageBox.Show("Please play a card");
            }
        }
        private void button_RobotShip8_Click(object sender, EventArgs e)
        {
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
            else
            {
                MessageBox.Show("Please play a card");
            }
        }
        private void button_RobotShip9_Click(object sender, EventArgs e)
        {
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
            else
            {
                MessageBox.Show("Please play a card");
            }
        }
        private void button_RobotShip10_Click(object sender, EventArgs e)
        {
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
            else
            {
                MessageBox.Show("Please play a card");
            }
        }
        private void button_RobotShip11_Click(object sender, EventArgs e)
        {
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
            else
            { MessageBox.Show("Please play a card"); }
        }
        private void button_RobotShip12_Click(object sender, EventArgs e)
        {
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
            }else
            {
                MessageBox.Show("Please play a card");
            }
        }

        /*#############################################################################
        * This part of code is tp implement Player Sea/Hand Cards function
        * ############################################################################
        * Here is for full game only
        * Any radio button checked to use a power card and make it happen to ships
        * 1. Radiobutton checked means player use power, message box offers further selection to different power
        * 2. If the power need to work with a ship, then click the ship buttons to what ship use, 
        *       then check the rest round of player and let AI go
        * ############################################################################*/
        private void button_PlayerShip1_Click(object sender, EventArgs e)
        {
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
                if (!baseMode)
                {
                    playerShipsAct(button_PlayerShip1);
                    if (human_.Full_RestOfRound <= 0)
                    {
                        robotPlay_Full();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please play a card");
            }
        }
        private void button_PlayerShip2_Click(object sender, EventArgs e)
        {
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
                if (!baseMode)
                {
                    playerShipsAct(button_PlayerShip2);
                    if (human_.Full_RestOfRound <= 0)
                    {
                        robotPlay_Full();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please play a card");
            }
        }
        private void button_PlayerShip3_Click(object sender, EventArgs e)
        {
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
                if (!baseMode)
                {
                    playerShipsAct(button_PlayerShip3);
                    if (human_.Full_RestOfRound <= 0)
                    {
                        robotPlay_Full();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please play a card");
            }
        }
        private void button_PlayerShip4_Click(object sender, EventArgs e)
        {
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
                if (!baseMode)
                {
                    playerShipsAct(button_PlayerShip4);
                    if (human_.Full_RestOfRound <= 0)
                    {
                        robotPlay_Full();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please play a card");
            }
        }
        private void button_PlayerShip5_Click(object sender, EventArgs e)
        {
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
                if (!baseMode)
                {
                    playerShipsAct(button_PlayerShip5);
                    if (human_.Full_RestOfRound <= 0)
                    {
                        robotPlay_Full();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please play a card");
            }
        }
        private void button_PlayerShip6_Click(object sender, EventArgs e)
        {
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
                if (!baseMode)
                {
                    playerShipsAct(button_PlayerShip6);
                    if (human_.Full_RestOfRound <= 0)
                    {
                        robotPlay_Full();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please play a card");
            }
        }
        private void button_PlayerShip7_Click(object sender, EventArgs e)
        {
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
                if (!baseMode)
                {
                    playerShipsAct(button_PlayerShip7);
                    if (human_.Full_RestOfRound <= 0)
                    {
                        robotPlay_Full();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please play a card");
            }
        }
        private void button_PlayerShip8_Click(object sender, EventArgs e)
        {
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
                if (!baseMode)
                {
                    playerShipsAct(button_PlayerShip8);
                    if (human_.Full_RestOfRound <= 0)
                    {
                        robotPlay_Full();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please play a card");
            }
        }
        private void button_PlayerShip9_Click(object sender, EventArgs e)
        {
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
                if (!baseMode)
                {
                    playerShipsAct(button_PlayerShip9);
                    if (human_.Full_RestOfRound <= 0)
                    {
                        robotPlay_Full();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please play a card");
            }
        }
        private void button_PlayerShip10_Click(object sender, EventArgs e)
        {
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
                if (!baseMode)
                {
                    playerShipsAct(button_PlayerShip10);
                    if (human_.Full_RestOfRound <= 0)
                    {
                        robotPlay_Full();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please play a card");
            }
        }
        private void button_PlayerShip11_Click(object sender, EventArgs e)
        {
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
                if (!baseMode)
                {
                    playerShipsAct(button_PlayerShip11);
                    if (human_.Full_RestOfRound <= 0)
                    {
                        robotPlay_Full();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please play a card");
            }
        }
        private void button_PlayerShip12_Click(object sender, EventArgs e)
        {
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
                if (!baseMode)
                {
                    playerShipsAct(button_PlayerShip12);
                    if (human_.Full_RestOfRound <= 0)
                    {
                        robotPlay_Full();
                    }
                }
            }
            else
            {
                MessageBox.Show("Please play a card");
            }
        }
        private void radioButton1_MyCard1_Click(object sender, EventArgs e)
        {
            if (!baseMode)
                playerPowerUse(radioButton1_MyCard1);
        }
        private void radioButton2_MyCard2_Click(object sender, EventArgs e)
        {
            if (!baseMode)
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
