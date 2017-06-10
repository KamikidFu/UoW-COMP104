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

namespace Task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //set up a list to store names
        List<string> name = new List<string>();
        /// <summary>
        /// Read a file button open and read
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_ReadFile_Click(object sender, EventArgs e)
        {
            //Set dialog filter
            openFileDialog1.Filter = "TXT Files|*.txt";
            //If user choose a file
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Receive the address of file
                string fileAddress = openFileDialog1.FileName.ToString();
                //Show on textbox
                textBox1.Text = fileAddress;
                //Reader starts reading
                StreamReader reader = new StreamReader(fileAddress);
                //While it is not the end of file
                while(!reader.EndOfStream)
                {
                    //Read date line by line
                    string oneLineName = reader.ReadLine();
                    //Save the data to list
                    name.Add(oneLineName);
                }
            }
            
        }
        /// <summary>
        /// Analyse to go
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Analyse_Click(object sender, EventArgs e)
        {
            //Add header to list box
            listBox1.Items.Add("Name".PadRight(15) + "Num Occurances");
            //Set up new list to analyse names
            List<string> listName = new List<string>();
            //Set up a counter to count how many names appear
            int count = 0;
            //For each name in name list
            for (int i = 0; i < name.Count(); i++) 
            {
                //Check does it contains any new names
                if (!listName.Contains(name[i]))
                {
                    //Add to analysing name list
                    listName.Add(name[i]);
                }
            }
            //For each name in analysing name list
            for (int j = 0; j < listName.Count(); j++)
            {
                //For each name in name list to count
                for (int k = 0; k < name.Count(); k++)
                {
                    //IF have the same name
                    if (listName[j] == name[k])
                    {
                        //Counting up
                        count++;
                    }
                }
                //Show the result 
                listBox1.Items.Add(listName[j].PadRight(15) + count.ToString());
                //Reset the count to zero
                count = 0;
            }
            
        }
    }
}
