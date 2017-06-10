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

namespace Task3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        // Set up list for saving info 
        List<int> age = new List<int>();
        List<string> gender = new List<string>();
        List<string> brand = new List<string>();

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Start reading
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button_Read_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "*.csv files|*.csv";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Note: this file is in the Task3 solution folder
                string filename = openFileDialog1.FileName.ToString();
                textBox1.Text = filename;
                // Open the file
                StreamReader infile = new StreamReader(filename);
                // Read sentences ...
                while (!infile.EndOfStream)
                {
                    // Read a line from the file, as a whole string
                    string line = infile.ReadLine();
                    // Split string into 'info', separated by spaces
                    string[] info = line.Split(',');
                    if (info.Length == 3)
                    {
                        try
                        {
                            //Add information to list
                            age.Add(int.Parse(info[0]));
                            gender.Add(info[1]);
                            brand.Add(info[2]);
                        }
                        catch
                        {
                            //Catch error
                            Console.WriteLine("Error Line!");
                        }
                    }
                    else
                    {
                        //Catch error
                        Console.WriteLine("Error Line!");
                    }
                }
            }
            //Check the length of each lists
            if (age.Count == gender.Count && gender.Count == brand.Count)
                label1.Text = "Total " + age.Count + " groups of data is read. And ready to anlyse!";
        }
        /// <summary>
        /// Start analysing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button_Analyse_Click(object sender, EventArgs e)
        {
            //Call methods
            ShowTotalPercentages();
            string findGender = "";
            string findAge = "";
            findGender = FindGenderPreference();
            //Output both in console and listbox
            listBox1.Items.Add(findGender);
            findAge =FindAgePreference();
            listBox1.Items.Add(findAge);
        }
        /// <summary>
        /// Show the total percentages once read file
        /// </summary>
        private void ShowTotalPercentages()
        {
            ///Percentage Analyse
            int coke = 0;
            int pepsi = 0;
            int pams = 0;
            int phoenix = 0;
            int other = 0;
            //For every brand to go
            for (int i = 0; i < brand.Count; i++)
            {
                if (brand[i] == "Coke")
                {
                    coke++;
                }
                else if (brand[i] == "Pepsi")
                {
                    pepsi++;
                }
                else if (brand[i] == "Pams")
                {
                    pams++;
                }
                else if (brand[i] == "Phoenix")
                {
                    phoenix++;
                }
                else { other++; }
            }
            //Calculate the percentage
            coke = (coke * 100) / brand.Count;
            pepsi = (pepsi * 100) / brand.Count;
            pams = (pams * 100) / brand.Count;
            phoenix = (phoenix * 100) / brand.Count;
            other = (other * 100) / brand.Count;
            //Show result
            Console.WriteLine("Percentage of Total: Coke " + coke.ToString() + "%, Pepsi " + pepsi.ToString() +
                "%, Pams " + pams.ToString() + "%, Phoenix " + phoenix.ToString() + "%, Other " + other.ToString() + "%");
            listBox1.Items.Add(("Percentage of Total: Coke " + coke.ToString() + "%, Pepsi " + pepsi.ToString() +
                "%, Pams " + pams.ToString() + "%, Phoenix " + phoenix.ToString() + "%, Other " + other.ToString() + "%"));
        }
        /// <summary>
        /// Find gender preference
        /// </summary>
        private string FindGenderPreference()
        {
            ///Gender and Brand
            int cokeF = 0, cokeM = 0, pepsiF = 0, pepsiM = 0, pamsF = 0, pamsM = 0, phoF = 0, phoM = 0, othF = 0, othM = 0;
            //For every gender recorded in lists
            for (int i = 0; i < gender.Count; i++)
            {
                if (gender[i] == "f")
                {
                    if (brand[i] == "Coke")
                    {
                        cokeF++;
                    }
                    else if (brand[i] == "Pepsi")
                    {
                        pepsiF++;
                    }
                    else if (brand[i] == "Pams")
                    {
                        pamsF++;
                    }
                    else if (brand[i] == "Phoenix")
                    {
                        phoF++;
                    }
                    else { othF++; }
                }
                else
                {
                    if (brand[i] == "Coke")
                    {
                        cokeM++;
                    }
                    else if (brand[i] == "Pepsi")
                    {
                        pepsiM++;
                    }
                    else if (brand[i] == "Pams")
                    {
                        pamsM++;
                    }
                    else if (brand[i] == "Phoenix")
                    {
                        phoM++;
                    }
                    else { othM++; }
                }
            }
            //Compare these four brand
            int bigF = cokeF, bigM = cokeM;
            string preF = "Coke", preM = "Coke";
            if (bigF < pepsiF) { bigF = pepsiF; preF = "Pepsi"; }
            if (bigF < pamsF) { bigF = pamsF; preF = "Pams"; }
            if (bigF < phoF) { bigF = phoF; preF = "Phoenix"; }
            if (bigF < othF) { bigF = othF; preF = "Other"; }
            if (bigM < pepsiM) { bigM = pepsiM; preM = "Pepsi"; }
            if (bigM < pamsM) { bigM = pamsM; preM = "Pams"; }
            if (bigM < phoM) { bigM = phoM; preM = "Phoenix"; }
            if (bigM < othM) { bigM = othM; preM = "Other"; }
            Console.WriteLine("Prefered cola brand of male: " + preM);
            Console.WriteLine("Prefered cola brand of female: " + preF);
            return ("Prefered cola brand of male: " + preM + "Prefered cola brand of female: " + preF);

        }
        /// <summary>
        /// Find age method to return cola for ages
        /// </summary>
        /// <returns></returns>
        private string FindAgePreference()
        {
            ///Age range
            int cokeA = 0, cokeB = 0, pepsiA = 0, pepsiB = 0, pamsA = 0, pamsB = 0, phoA = 0, phoB = 0, othA = 0, othB = 0;
            int min = int.Parse(textBox2.Text);
            int max = int.Parse(textBox3.Text);
            //For every age to go
            for (int i = 0; i < age.Count; i++)
            {
                if (age[i] <=max )
                {
                    if (brand[i] == "Coke")
                    {
                        cokeA++;
                    }
                    else if (brand[i] == "Pepsi")
                    {
                        pepsiA++;
                    }
                    else if (brand[i] == "Pams")
                    {
                        pamsA++;
                    }
                    else if (brand[i] == "Phoenix")
                    {
                        phoA++;
                    }
                    else { othA++; }
                }
                else if(age[i]>=min)
                {
                    if (brand[i] == "Coke")
                    {
                        cokeB++;
                    }
                    else if (brand[i] == "Pepsi")
                    {
                        pepsiB++;
                    }
                    else if (brand[i] == "Pams")
                    {
                        pamsB++;
                    }
                    else if (brand[i] == "Phoenix")
                    {
                        phoB++;
                    }
                    else { othB++; }
                }

            }
            //Compare these four brand and show result
            int bigA = cokeA, bigB = cokeB;
            string preA = "Coke", preB = "Coke";
            if (bigA < pepsiA) { bigA = pepsiA; preA = "Pepsi"; }
            if (bigA < pamsA) { bigA = pamsA; preA = "Pams"; }
            if (bigA < phoA) { bigA = phoA; preA = "Phoenix"; }
            if (bigA < othA) { bigA = othA; preA = "Other"; }
            if (bigB < pepsiB) { bigB = pepsiB; preB = "Pepsi"; }
            if (bigB < pamsB) { bigB = pamsB; preB = "Pams"; }
            if (bigB < phoB) { bigB = phoB; preB = "Phoenix"; }
            if (bigB < othB) { bigB = othB; preB = "Other"; }
            Console.WriteLine("Prefered cola brand of {0} to " + max.ToString() + ": " + preA, age.Min().ToString());
            Console.WriteLine("Prefered cola brand of "+min.ToString() + " to {0}: " + preB,age.Max().ToString());
            return "Prefered cola brand of " + age.Min().ToString() + " to " + max.ToString() + ": " + preA + "Prefered cola brand of" + min.ToString() + "to " + age.Max().ToString() + ": " + preB;
            
        }
    }
}
