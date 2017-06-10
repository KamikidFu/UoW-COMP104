using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_Framework_with_Classes
{
    public partial class DisplayForm : Form
    {
        public DisplayForm()
        {
            InitializeComponent();
        }

        //**************
        //Instance Varibles
        private Recipe printRecipe_;

        //*****************
        //Constructor
        public DisplayForm(Recipe item)
        {
            InitializeComponent();
            printRecipe_ = item;
            yield_textBox1.Text = printRecipe_.Yield.ToString()+"\n";
            Print_richTextBox1.Text += "Recipe Name:" + printRecipe_.Name + " Feed Yield:" + yield_textBox1.Text + "\n" + "Ingredients:\n";
            for(int i =0;i<printRecipe_.Requirements_.Count;i++)
            {
                Print_richTextBox1.Text += printRecipe_.Requirements_[i].IngredientName + "   " +
                                        printRecipe_.Requirements_[i].Quantity + "   " +
                                        printRecipe_.Requirements_[i].Unit + "\n";
            }
            Print_richTextBox1.Text += "\nInstruction:\n";
            Print_richTextBox1.Text += printRecipe_.Instruction;
        }

        private void update_button1_Click(object sender, EventArgs e)
        {
            Print_richTextBox1.Clear();
            //uint changedYield = Convert.ToUInt32(yield_textBox1.Text);
            uint changedYield = 0;
            bool canChange = uint.TryParse(yield_textBox1.Text, out changedYield);
            if(canChange)
            {
                //Need method in recipe
                printRecipe_.changeQuantity(changedYield);
                yield_textBox1.Text = changedYield.ToString();
                Print_richTextBox1.Text += "Recipe Name:" + printRecipe_.Name + " Feed Yield:" + yield_textBox1.Text + "\n" + "Ingredients:\n";
                for (int i = 0; i < printRecipe_.Requirements_.Count; i++)
                {
                    Print_richTextBox1.Text += printRecipe_.Requirements_[i].IngredientName + "   " +
                                            printRecipe_.Requirements_[i].Quantity + "   " +
                                            printRecipe_.Requirements_[i].Unit + "\n";
                }
                Print_richTextBox1.Text += "\nInstruction:\n";
                Print_richTextBox1.Text += printRecipe_.Instruction;
            }
            else
            {
                MessageBox.Show(":-(\nUnexpected yield value in textbox!");
            }

        }
    }
}
