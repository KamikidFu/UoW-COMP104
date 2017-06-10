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
        public Form1()
        {
            InitializeComponent();
        }

        BindingList<Student> studentBindingList = new BindingList<Student>();
        List<Student> studentList = new List<Student>();

        /// <summary>
        /// Add new student
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_newStudent_Click(object sender, EventArgs e)
        {
            try
            {
                int idNumber = int.Parse(textBox1_ID.Text);
                string name = textBox2_Name.Text;
                Student s1 = new Student(idNumber,name);
                studentBindingList.Add(s1);
                //studentList.Add(s1);
                //listBox1_Show.DataSource = studentBindingList;
                listBox1_Show.DataSource = studentList;
            }
            catch
            {
                MessageBox.Show("Error!");
            }
        }
    }
}
