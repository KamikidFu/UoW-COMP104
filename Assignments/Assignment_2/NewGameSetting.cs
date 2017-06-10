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
        Form PreviousForm_ = null;
        History history_;
        public NewGameSetting()
        {
            InitializeComponent();
        }

        public NewGameSetting(Form previousForm, History currentHistory)
        {
            InitializeComponent();
            PreviousForm_ = previousForm;
            history_ = currentHistory;
        }

        private void button1_StartGame_Click(object sender, EventArgs e)
        {
            if (textBox1_PlayerName.Text != "" && (radioButton1_Team_Red.Checked || radioButton2_Team_Blue.Checked)
                && (radioButton3_Mode_Full.Checked || radioButton4_Mode_Easy.Checked))
            {
                string playName = textBox1_PlayerName.Text;
                string playTeam = "";
                string playMode = "";
                if (radioButton1_Team_Red.Checked) playTeam = radioButton1_Team_Red.Text;
                else playTeam = radioButton2_Team_Blue.Text;
                if (radioButton3_Mode_Full.Checked) playMode = radioButton3_Mode_Full.Text;
                else playMode = radioButton4_Mode_Easy.Text;
                this.Hide();
                BattleShipMainForm newBattle = new BattleShipMainForm(playName,playTeam,playMode, history_);
                newBattle.Show();
            }
            else
            {
                MessageBox.Show("Please input all the things to start your game!");                
            }
        }

        private void button2_Close_Click(object sender, EventArgs e)
        {
            this.Close();
            PreviousForm_.Show();
        }
    }
}
