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
            //Initially set up component
            InitializeComponent();
            //printRecipe is the passed in Recipe object
            printRecipe_ = item;
            //Fill the yield amount into textbox
            yield_textBox1.Text = printRecipe_.Yield.ToString()+"\n";
            //Fill the richTextBox with the Recipe Name, Feed yield, Ingredients required and instrcution
            Print_richTextBox1.Text += "Recipe Name:" + printRecipe_.Name + "\nFeed Yield:" + yield_textBox1.Text + "\n" + "Ingredients:\n";
            for(int i =0;i<printRecipe_.Requirements_.Count;i++)
            {
                Print_richTextBox1.Text += printRecipe_.Requirements_[i].IngredientName + "   " +
                                        printRecipe_.Requirements_[i].Quantity.ToString("n2") + "   " +
                                        printRecipe_.Requirements_[i].Unit + "\n";
            }
            Print_richTextBox1.Text += "\nInstruction:\n";
            Print_richTextBox1.Text += printRecipe_.Instruction;
        }

        //Update the yield by click button
        private void update_button1_Click(object sender, EventArgs e)
        {
            //Clear the richTextBox
            Print_richTextBox1.Clear();
            //Get the new yield
            printRecipe_.Yield = uint.Parse(yield_textBox1.Text);
            //uint changedYield = Convert.ToUInt32(yield_textBox1.Text);
            uint changedYield = 0;
            //Can prase the yield value
            bool canChange = uint.TryParse(yield_textBox1.Text, out changedYield);
            if(canChange)
            {
                //Need method in recipe
                printRecipe_.changeQuantity(changedYield);
                //New yield shown in textBox
                yield_textBox1.Text = changedYield.ToString();
                //Fill the richTextBox with information
                Print_richTextBox1.Text += "Recipe Name:" + printRecipe_.Name + "\nFeed Yield:" + yield_textBox1.Text + "\n" + "Ingredients:\n";
                for (int i = 0; i < printRecipe_.Requirements_.Count; i++)
                {
                    Print_richTextBox1.Text += printRecipe_.Requirements_[i].IngredientName + "   " +
                                            printRecipe_.Requirements_[i].Quantity.ToString("n2")+ "   " +
                                            printRecipe_.Requirements_[i].Unit + "\n";
                }
                Print_richTextBox1.Text += "\nInstruction:\n";
                Print_richTextBox1.Text += printRecipe_.Instruction;
            }
            else
            {
                //Any error in textbox
                MessageBox.Show(":-(\nUnexpected yield value in textbox!");
            }

        }
    }
}
