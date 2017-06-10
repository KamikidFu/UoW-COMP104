using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //Initialize the list box with a header
            listBox1.Items.Add("Increment".PadRight(15) + "String");
        }
        //Set up an array with 52 letters
        string[] array = new string[52] { "A", "B", "C", "D", "E", "F", "G", "H","I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z",
                                          "a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r","s","t","u","v","w","x","y","z"};
        /// <summary>
        /// Output process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Output_Click(object sender, EventArgs e)
        {
            //Try catch structure
            try
            {
                //Set up variables and initialize their values
                int parameter = int.Parse(textBox1_Parameter.Text);
                string output = "";
                int num = 0;
                //For each line to go
                for (int i = 0; i <= parameter; i++)
                {                    
                    //IF it is Line one                    
                    if (i == 0)
                    {
                        //Do something special, directly add to output with a A
                        output = array[i];
                    }
                    else
                    {
                        //For each letters in Line 
                        for (int j = 0; j <= i; j ++)
                        {                          
                                //Where the letter should be in array  
                                num = num % 52;
                                //Add to output string
                                output += array[num];
                                //Add up the locating number
                                num += i;                                                                                
                        }
                        //Reset the locating number
                        num = 0;
                               
                    }
                    //List box add up the output line
                    listBox1.Items.Add(("+" + i).PadRight(15) + output);
                    //Reset the output value
                    output = "";


                }
            }
            catch
            {
                //Any error catched
                MessageBox.Show("Error!");
            }
        }
    }
}
