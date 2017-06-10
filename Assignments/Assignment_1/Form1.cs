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

namespace Assignment_Framework_with_Classes
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// The list of all recipes. We like to use datagrid view to show things.
        /// </summary>
        private BindingList<Recipe> recipes_;
        /// <summary>
        /// The list of all papers. We like to use datagrid view to show things.
        /// </summary>
        private BindingList<Ingredient> ingredients_;
        public Form1()
        {
            InitializeComponent();

            //Create recipes list and objects and save to this list
            recipes_ = new BindingList<Recipe>();
            recipes_.Add(new Recipe("choc ricotta cheesecake", 10, "Prepare graham crust and set aside. Place Ricotta cheese, sugar and eggs in food processor or blender container; process until smooth. \nAdd cream, cocoa, flour, salt and vanilla; process until smooth. \nPour into prepared crust. Bake at 350 degrees about 1 hour and 15 minutes or until set. \nTurn off oven; open door and let cheesecake remain in oven 1 hour. \nCool completely; chill thoroughly. "));
            recipes_.Add(new Recipe("brownie", 16, "Melt butter and cook until brown and fragrant. Take off the heat and cool for 10 minutes. \nAdd chocolate and stir until chocolate is melted. \nAdd sugar. Add eggs one at a time stirring until mixture is glossy. \nMix in vanilla essence Mix in chopped Nuts and / or soaked raisins if desired. \nAdd flour and Salt and stir to combine. Bake in 150°C oven for 25 - 30 minutes."));
            recipes_.Add(new Recipe("pancakes", 3, "Whisk together milk and eggs. Stir in flour and sugar. \nRest mixture for 30 minutes. Heat some butter in pan. \nAdd one large spoonful of mixture to pan, fry on both sides until golden brown. \nRepeat for each pancake."));

            //Create ingredients list and objects and save to this list
            ingredients_ = new BindingList<Ingredient>();
            //Note: this file is in the Assignment solution folder
            string filename = @"ingredients.csv";
            //Open the file
            StreamReader file = new StreamReader(filename);
            //Read sentences...
            while (!file.EndOfStream)
            {
                //Read a line into line from the file
                string oneLineData = file.ReadLine();
                //Split one line data to splitedData
                string[] splitedData = oneLineData.Split(',');
                try
                {
                    //Check the length is okay
                    if (splitedData.Length == 5)
                    {
                        //Check it is not the title lines
                        if (!splitedData[0].Contains('#'))
                        {
                            string name = splitedData[0];
                            uint quantity = uint.Parse(splitedData[1]);
                            string unit = splitedData[2];
                            uint energy = uint.Parse(splitedData[3]);
                            decimal price = decimal.Parse(splitedData[4]);
                            ingredients_.Add(new Ingredient(name, quantity, unit, energy, price));
                        }
                        else
                        {
                            continue;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Bad Line");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            //Bind list to data grid
            Recipes_dataGridView1.DataSource = recipes_;
            //Remove the instruction columns in Recipes_dataGridView1
            Recipes_dataGridView1.Columns.RemoveAt(2);
            Ingredients_dataGridView2.DataSource = ingredients_;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Recipes_dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            try {
                int recipeIndex = Recipes_dataGridView1.CurrentCell.RowIndex;
                if (recipeIndex >= 0)
                {
                    Recipe rep = recipes_[recipeIndex];
                    Instructions_richTextBox1.Text = rep.Instruction;
                }
            }
            catch
            {
                MessageBox.Show(":-) \nNow, there is no recipes. \nPlease edit a new one for all functionality.", "Information");
            }
        }

        private void Recipes_dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            int recipeIndex = Recipes_dataGridView1.CurrentCell.RowIndex;
            if (recipeIndex >= 0 && e.KeyCode == Keys.Delete) 
            {
                Recipe rep = recipes_[recipeIndex];
                recipes_.Remove(rep);
                Recipes_dataGridView1.DataSource = null;
                Recipes_dataGridView1.DataSource = recipes_;
            }
        }
    }
}
