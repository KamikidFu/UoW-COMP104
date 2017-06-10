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
            int height = int.Parse(letterHeight_textBox1.Text);
            int length = int.Parse(letterLength_textBox2.Text);
            bool urgent = letterUrgent_checkBox1.Checked;
            Letter l1 = new Letter("Waikato Uni","Kamikid",height, length, urgent);
            letter.Add(l1);            
            listBox1_letter.DataSource = letter;
        }

        /// <summary>
        /// Add a parcel to data source
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_addParcel_Click(object sender, EventArgs e)
        {
            int height = int.Parse(parcelHeight_textBox3.Text);
            int length = int.Parse(parcelLength_textBox4.Text);
            int thickness = int.Parse(parcelThickness_textBox5.Text);
            int weight = int.Parse(parcelWeight_textBox6.Text);
            bool urgent = parcelUrgent_checkBox2.Checked;
            Parcel p1 = new Parcel("Waikato Uni", "Kamikid", height, length, thickness, weight, urgent);
            parcel.Add(p1);
            listBox2_parcel.DataSource = parcel;
        }
    }
}
