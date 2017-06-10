using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class Form1 : Form
    {
        //Set up Constant Int varibles
        const int SEED_SIZE = 20;
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Click to run
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void drawButton__Click(object sender, EventArgs e)
        {
            //Set up varibles
            int seedNum = 0;
            int x = 0;
            int y = 0;
            Graphics paper = pictureBoxBowl_.CreateGraphics();
            Pen pen1 = new Pen(Color.Green, 3);
            SolidBrush br = new SolidBrush(Color.Green);
            //Try Catch
            try
            {
                //Picture Box Refresh
                pictureBoxBowl_.Refresh();
                //Get the Seed Number
                seedNum = int.Parse(textBoxNumSeeds_.Text);
                //Loop for drawing seed
                for(int i =0;i<seedNum;i++)
                {
                    //IF it is not oversized
                    if(x<(pictureBoxBowl_.Width-SEED_SIZE))
                    {
                        //Draw Ellipse and fill it and shift X to next one
                        paper.DrawEllipse(pen1, x, y, SEED_SIZE, SEED_SIZE);
                        paper.FillEllipse(br, x, y, SEED_SIZE, SEED_SIZE);
                        x += SEED_SIZE;
                    }
                    else
                    {
                        //Shift Y to next line and reset X to 0 and draw, fill the Ellipse
                        y += SEED_SIZE;
                        x = 0;
                        paper.DrawEllipse(pen1, x, y, SEED_SIZE, SEED_SIZE);
                        paper.FillEllipse(br, x, y, SEED_SIZE, SEED_SIZE);
                        x += SEED_SIZE;
                    }
                }
            }
            catch
            {
                //Error Catched 
                MessageBox.Show("Error! Number is not correct!");
                pictureBoxBowl_.Refresh();
                textBoxNumSeeds_.Refresh();
            }
        }
    }
}
