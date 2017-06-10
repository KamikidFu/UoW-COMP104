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
            listBox1_letter.Items.Add("Sender".PadRight(10) + "Height".PadRight(10) + "Length".PadRight(10) + "Stamp".ToString().PadRight(10) + "Cost".ToString());
            listBox2_parcel.Items.Add("Sender".PadRight(10) + "Height".PadRight(8) + "Length".PadRight(8)+ "Weight".PadRight(8) + "Thick".PadRight(8) + "Stamp".ToString().PadRight(10) + "Cost".ToString());
        }

        BindingList<Letter> letter = new BindingList<Letter>();
        BindingList<Parcel> parcel = new BindingList<Parcel>();
        /// <summary>
        /// Add a letter to data source
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_addLetter_Click(object sender, EventArgs e)
        {
            try {
                int height = int.Parse(letterHeight_textBox1.Text);
                int length = int.Parse(letterLength_textBox2.Text);
                bool urgent = letterUrgent_checkBox1.Checked;
                string senderName = LetterSender_textBox.Text;
                Letter l1 = new Letter("Waikato Uni",senderName, height, length, urgent);
                letter.Add(l1);
                listBox1_letter.DataSource = letter;
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        /// <summary>
        /// Add a parcel to data source
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_addParcel_Click(object sender, EventArgs e)
        {
            try
            {
                int height = int.Parse(parcelHeight_textBox3.Text);
                int length = int.Parse(parcelLength_textBox4.Text);
                int thickness = int.Parse(parcelThickness_textBox5.Text);
                int weight = int.Parse(parcelWeight_textBox6.Text);
                bool urgent = parcelUrgent_checkBox2.Checked;
                string senderName = ParcelsSender_textBox.Text;
                Parcel p1 = new Parcel("Waikato Uni", senderName, height, length, thickness, weight, urgent);
                parcel.Add(p1);
                listBox2_parcel.DataSource = parcel;
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }

        private void LetterSearch_button_Click(object sender, EventArgs e)
        {
            string searchSender = LetterSearch_textBox.Text;
            int counterOfItems = 0;
            int counterOfStamps = 0;
            decimal adderOfCost = 0.0m;
            for (int i = 0; i < letter.Count; i++)
            {
                if(letter[i].SenderName_==searchSender)
                {
                    counterOfItems++;
                    counterOfStamps += letter[i].StampNum_;
                    adderOfCost += letter[i].GetCost();
                }
            }
            MessageBox.Show(searchSender + " sent " + counterOfItems.ToString() + " items needing " + counterOfStamps.ToString() + " stamps costing " + adderOfCost.ToString("c"));
        }

        private void PaecelSearch_button_Click(object sender, EventArgs e)
        {
            string searchSender = PacelSearch_textBox.Text;
            int counterOfItems = 0;
            int counterOfStamps = 0;
            decimal adderOfCost = 0.0m;
            for (int i = 0; i < parcel.Count; i++)
            {
                if (parcel[i].SenderName_ == searchSender)
                {
                    counterOfItems++;
                    counterOfStamps += parcel[i].StampNum_;
                    adderOfCost += parcel[i].GetCost();
                }
            }
            MessageBox.Show(searchSender + " sent " + counterOfItems.ToString() + " items needing " + counterOfStamps.ToString() + " stamps costing " + adderOfCost.ToString("c"));
        }
    }
}
