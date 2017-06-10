using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace PracP3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //lots of plants!
        List<Plant> garden = new List<Plant>();
        decimal totalCost = 0.0m;
        int changeIndex = 0;

        private void buttonFinish_Click(object sender, EventArgs e)
        {
            StreamWriter writer;
            saveFileDialog1.Filter = "TXT Files|*.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                writer = File.CreateText(saveFileDialog1.FileName);
                for(int i=0;i<garden.Count;i++)
                {
                    string oneLineData = "";
                    oneLineData = garden[i].ToString();
                    writer.WriteLine(oneLineData);
                }
                writer.WriteLine("Total Cost:".PadRight(52) + totalCost.ToString("c"));
                writer.Close();
                MessageBox.Show("Your exported file is saved at" + "\n" + saveFileDialog1.FileName.ToString());
            }

        }

        private void pictureBoxGarden_MouseClick(object sender, MouseEventArgs e)
        {
            int mouseX = e.X;
            int mouseY = e.Y;
            int plantNum = FindPlant(mouseX, mouseY);
            Graphics paper = pictureBoxGarden.CreateGraphics();
            if (e.Button == MouseButtons.Left)
                try
                {                
                    
                    
                    if (plantNum >= 0) //-1 means null, no plant here and call Mouse Down method to draw plant, greater than 0 means there having a plant and retrive its infomation
                    {
                        textBoxCost.Text = garden[plantNum].Cost.ToString();
                        textBoxSize.Text = garden[plantNum].Size.ToString();
                        textBoxName.Text = garden[plantNum].Name.ToString();
                        pictureBoxGarden.Refresh();
                        for (int i = 0; i < garden.Count; i++)
                        {
                            garden[i].DrawPlant(paper);
                        }
                        garden[plantNum].selected_ = true;
                        garden[plantNum].DrawPlant(paper, garden[plantNum].selected_);
                        changeIndex = plantNum;
                    }
                    //Problem: I want to draw like if there is one plant, stop the Mouse down method to not drawing any plants. if there is no plant, call the method and draw it.
                    //Solution: Easy, if there is no plant, make the method work. Otherwise, why not do it? Use it with IF statement in MouseDown method.
                }
                catch
                {
                    MessageBox.Show("Error");
                }
            else if(e.Button==MouseButtons.Right)
            {
                garden.RemoveAt(plantNum);
                pictureBoxGarden.Refresh();
                for (int i = 0; i < garden.Count; i++)
                {
                    garden[i].DrawPlant(paper);
                }
            }
            listBoxPlants.DataSource = null;
            listBoxPlants.DataSource = garden;
        }

        /// <summary>
        /// add a plant at x,y position of mouse.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBoxGarden_MouseDown(object sender, MouseEventArgs e)
        {
            int mouseX = e.X;
            int mouseY = e.Y;
            int plantNum = FindPlant(mouseX, mouseY);
            if (plantNum == -1)
            {
                try
                {


                    string name = textBoxName.Text;
                    int size = Convert.ToInt32(textBoxSize.Text);
                    decimal cost = Convert.ToDecimal(textBoxCost.Text);

                    Plant plant = new Plant(name, size, cost, mouseX, mouseY);
                    garden.Add(plant); //add new plant to list

                    Graphics paper = pictureBoxGarden.CreateGraphics();
                    plant.DrawPlant(paper);

                    //update listbox
                    listBoxPlants.DataSource = null;
                    listBoxPlants.DataSource = garden;

                    totalCost += cost;

                }
                catch
                {
                    MessageBox.Show("Please enter plant details first");
                }
            }
        }

        private int FindPlant(int x, int y)
        {
            bool clicked = false;
            int plantNo = -1;
            for(int i =0;i<garden.Count;i++)
            {
                clicked = garden[i].IsClicked(x, y);
                if (clicked) { plantNo = i; break; }
            }
            return plantNo;
        }

        private void change_button_Click(object sender, EventArgs e)
        {
            try {
                string name = textBoxName.Text;
                int size = Convert.ToInt32(textBoxSize.Text);
                decimal cost = Convert.ToDecimal(textBoxCost.Text);
                garden[changeIndex].Name = name;
                garden[changeIndex].Size = size;
                garden[changeIndex].Cost = cost;
                Graphics paper = pictureBoxGarden.CreateGraphics();
                pictureBoxGarden.Refresh();
                for (int i = 0; i < garden.Count; i++)
                {
                    garden[i].DrawPlant(paper);
                }
                garden[changeIndex].selected_ = true;
                garden[changeIndex].DrawPlant(paper, garden[changeIndex].selected_);
                listBoxPlants.DataSource = null;
                listBoxPlants.DataSource = garden;
            }
            catch
            { MessageBox.Show("ERROR!"); }
        }
    }
}
