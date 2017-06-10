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
    public partial class NewGameSetting : Form
    {
        //Variables     ||Explanation
        //PreviousForm_ ||The previous form where click the start new game
        //history_      ||History record
        //playershipList_||A list to store the player's ships
        //robotshipList_||A list to store the robot's ships
        //playershipDeployment_||This is a 2D array for recording where player deploy ships
        //robotshipDeployment_||This is a 2D array for recording where robot deploy ship
        //rand          ||Random number generator
        private Form PreviousForm_ = null;
        private  History history_;
        private List<Ship> playershipList_;
        private List<Ship> robotshipList_;
        private Ship[,] playershipDeployment_ = new Ship[3, 4];
        private Ship[,] robotshipDeployment_ = new Ship[3, 4];
        private Random rand = new Random();
        public NewGameSetting()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="previousForm">Previous form where comes to here</param>
        /// <param name="currentHistory">Current history to keep record</param>
        public NewGameSetting(Form previousForm, History currentHistory)
        {
            InitializeComponent();
            PreviousForm_ = previousForm;
            history_ = currentHistory;
            playershipList_ = new List<Ship>();
            robotshipList_ = new List<Ship>();
            ShipsReady(playershipList_, robotshipList_);
            listBox1_Ships.DataSource = playershipList_;            
        }

        /// <summary>
        /// ShipsReady method is to add all the ships to list for deploying
        /// </summary>
        /// <param name="playerlistOfShips"></param>
        /// <param name="robotlistOfShips"></param>
        private void ShipsReady(List<Ship> playerlistOfShips,List<Ship> robotlistOfShips)
        {
            //7 sea
            for(int i=0;i<7;i++)
            {
                playerlistOfShips.Add(new Ship("Sea", 0));
                robotlistOfShips.Add(new Ship("Sea", 0));
            }
            //5 other ship
            playerlistOfShips.Add(new Ship("Submarine", 3));
            robotlistOfShips.Add(new Ship("Submarine", 3));
            playerlistOfShips.Add(new Ship("PT Boat", 2));
            robotlistOfShips.Add(new Ship("PT Boat", 2));
            playerlistOfShips.Add(new Ship("Destroyer", 3));
            robotlistOfShips.Add(new Ship("Destroyer", 3));
            playerlistOfShips.Add(new Ship("Battleship", 4));
            robotlistOfShips.Add(new Ship("Battleship", 4));
            playerlistOfShips.Add(new Ship("Aircraft Carrier", 5));
            robotlistOfShips.Add(new Ship("Aircraft Carrier", 5));
        }

        /// <summary>
        /// deployShips method is to get the current ship to deploy it to different button
        /// </summary>
        /// <param name="whereToDeploy">The button to deploy</param>
        /// <param name="whatToDeploy">The 2D array to store the deployment</param>
        /// <param name="arrayX">X-axis in array</param>
        /// <param name="arrayY">Y-axis in array</param>
        private void deployShips(Button whereToDeploy, Ship[,] whatToDeploy,int arrayX, int arrayY)
        {
            //"Add Ship" button means there is no ship deployed
            if (whereToDeploy.Text == "Add Ship")
            {
                //Deploy the ship to button
                int shipIndex = listBox1_Ships.SelectedIndex;
                if (shipIndex >= 0)
                {
                    whatToDeploy[arrayX,arrayY] = playershipList_[shipIndex];
                    whereToDeploy.Text = playershipList_[shipIndex].Name;
                    playershipList_.RemoveAt(shipIndex);
                    listBox1_Ships.DataSource = null;
                    listBox1_Ships.DataSource = playershipList_;
                }
            }
            else
            {
                //Else to dis-deploy the ship to list
                playershipList_.Add(whatToDeploy[arrayX, arrayY]);
                whatToDeploy[arrayX, arrayY] = null;
                whereToDeploy.Text = "Add Ship";
                listBox1_Ships.DataSource = null;
                listBox1_Ships.DataSource = playershipList_;
            }
        }

        /// <summary>
        /// This method is to make robot randomly deploy its ship
        /// </summary>
        private void robotDeployShips()
        {
            List<int> indexGroup = new List<int>();
            int randIndexOfShip = 0;
            int shipCounter = 0;
            //Get random position of ship(Here is just the index)
            while(indexGroup.Count!=12)
            {
                randIndexOfShip = rand.Next(12);
                if(!indexGroup.Contains(randIndexOfShip))
                {
                    indexGroup.Add(randIndexOfShip);
                }
            }
            //For 4x3 matrix to deploy
            for (int i=0;i<4;i++)
            {
                for(int j=0;j<3;j++)
                {
                    robotshipDeployment_[j, i] = robotshipList_[indexGroup[shipCounter]];
                    shipCounter++;
                }
            }
            
        }

        /// <summary>
        /// All the information that the game need is deployed, then start the game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_StartGame_Click(object sender, EventArgs e)
        {
            //Check all the information is ready to start a new game
            if (textBox1_PlayerName.Text != "" && (radioButton1_Team_Red.Checked || radioButton2_Team_Blue.Checked)
                && (radioButton3_Mode_Full.Checked || radioButton4_Mode_Easy.Checked)&& playershipList_.Count==0)
            {
                //Local variables
                string playName = textBox1_PlayerName.Text;
                string playTeam = "";
                string playMode = "";
                //Stylizing information and gaming mode information
                if (radioButton1_Team_Red.Checked) playTeam = radioButton1_Team_Red.Text;
                else playTeam = radioButton2_Team_Blue.Text;
                if (radioButton3_Mode_Full.Checked) playMode = radioButton3_Mode_Full.Text;
                else playMode = radioButton4_Mode_Easy.Text;
                //Deployment information to show
                string deployment = "";
                for(int i=0;i<3;i++)
                {
                    for (int j=0;j<4;j++)
                    {
                        deployment += playershipDeployment_[i, j].Name.PadRight(20);
                    }
                    deployment += "\n";
                }
                //Robot deploy its ships
                robotDeployShips();
                //Final message to show
                DialogResult dr = MessageBox.Show("Current Game Information:\nPlayer Name: " + playName + " Player Team: " + playTeam + " Play Mode: " + playMode
                    + "\n\nDeployment:\n" + deployment,"Information:", MessageBoxButtons.OKCancel);
                if (dr == DialogResult.OK)
                {
                    //Hide the setting form and then show the playing form
                    this.Hide();
                    BattleShipMainForm newBattle = new BattleShipMainForm(playName, playTeam, playMode, history_, playershipDeployment_, robotshipDeployment_);
                    newBattle.Show();
                }
            }
            else
            {
                MessageBox.Show("Please input all the things to start your game!");                
            }
        }

        /// <summary>
        /// Close the setting form and show the previous form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Close_Click(object sender, EventArgs e)
        {
            this.Close();
            PreviousForm_.Show();
        }

        //Private methods for implement functions in setting form
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listBox1_Ships_SelectedIndexChanged(object sender, EventArgs e)
        {
            int shipIndex = listBox1_Ships.SelectedIndex;
            if(shipIndex>=0)
            {
                label_CurrentShip.Text = playershipList_[shipIndex].Name;
            }
        }

        /// <summary>
        /// Select the team
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton1_Team_Red_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < this.Controls.Count; i++)
            {
                this.Controls[i].ForeColor = Color.Red;
            }
        }

        /// <summary>
        /// Select the team
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void radioButton2_Team_Blue_CheckedChanged(object sender, EventArgs e)
        {
            for(int i=0;i<this.Controls.Count;i++)
            {
                this.Controls[i].ForeColor = Color.Blue;
            }
        }

        //Deployment button clicking
        /// <summary>
        /// Deploy button assigning codes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Deploy1_Click(object sender, EventArgs e)
        {
            deployShips(button_Deploy1, playershipDeployment_, 0, 0);
        }

        private void button_Deploy2_Click(object sender, EventArgs e)
        {
            deployShips(button_Deploy2, playershipDeployment_, 0, 1);
        }

        private void button_Deploy3_Click(object sender, EventArgs e)
        {
            deployShips(button_Deploy3, playershipDeployment_, 0, 2);
        }

        private void button_Deploy4_Click(object sender, EventArgs e)
        {
            deployShips(button_Deploy4, playershipDeployment_, 0, 3);
        }

        private void button_Deploy5_Click(object sender, EventArgs e)
        {
            deployShips(button_Deploy5, playershipDeployment_, 1, 0);
        }

        private void button_Deploy6_Click(object sender, EventArgs e)
        {
            deployShips(button_Deploy6, playershipDeployment_, 1, 1);
        }

        private void button_Deploy7_Click(object sender, EventArgs e)
        {
            deployShips(button_Deploy7, playershipDeployment_, 1, 2);
        }

        private void button_Deploy8_Click(object sender, EventArgs e)
        {
            deployShips(button_Deploy8, playershipDeployment_, 1, 3);
        }

        private void button_Deploy9_Click(object sender, EventArgs e)
        {
            deployShips(button_Deploy9, playershipDeployment_, 2, 0);
        }

        private void button_Deploy10_Click(object sender, EventArgs e)
        {
            deployShips(button_Deploy10, playershipDeployment_, 2, 1);
        }

        private void button_Deploy11_Click(object sender, EventArgs e)
        {
            deployShips(button_Deploy11, playershipDeployment_, 2, 2);
        }

        private void button_Deploy12_Click(object sender, EventArgs e)
        {
            deployShips(button_Deploy12, playershipDeployment_, 2, 3);
        }

        /// <summary>
        /// If the form is closed, previous form show up
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NewGameSetting_FormClosed(object sender, FormClosedEventArgs e)
        {
            PreviousForm_.Show();
        }
    }
}
