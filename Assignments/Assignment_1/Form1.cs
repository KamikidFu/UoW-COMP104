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

namespace Assignment_1
{
    public partial class Assignment_1 : Form
    {
        /// <summary>
        /// The list of all recipes. We like to use datagrid view to show things.
        /// </summary>
        private BindingList<Recipe> recipes_;
        /// <summary>
        /// The list of all papers. We like to use datagrid view to show things.
        /// </summary>
        private BindingList<Ingredient> ingredients_;

        public Assignment_1()
        {
            InitializeComponent();
            //Create recipes list and objects and save to this list
            recipes_ = new BindingList<Recipe>();
            recipes_.Add(new Recipe("choc_ricotta_cheesecake", 10, "Prepare graham crust and set aside. Place Ricotta cheese, sugar and eggs in food processor or blender container; process until smooth. Add cream, cocoa, flour, salt and vanilla; process until smooth. Pour into prepared crust. Bake at 350 degrees about 1 hour and 15 minutes or until set. Turn off oven; open door and let cheesecake remain in oven 1 hour. Cool completely; chill thoroughly. "));
            recipes_.Add(new Recipe("brownie", 16, "Melt butter and cook until brown and fragrant. Take off the heat and cool for 10 minutes. Add chocolate and stir until chocolate is melted. Add sugar. Add eggs one at a time stirring until mixture is glossy. Mix in vanilla essence Mix in chopped Nuts and / or soaked raisins if desired. Add flour and Salt and stir to combine. Bake in 150°C oven for 25 - 30 minutes."));
            recipes_.Add(new Recipe("pancakes", 3, "Whisk together milk and eggs. Stir in flour and sugar. Rest mixture for 30 minutes. Heat some butter in pan. Add one large spoonful of mixture to pan, fry on both sides until golden brown. Repeat for each pancake."));

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
                        if (splitedData[0] != "#Name")
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

            Recipes_dataGridView.DataSource = recipes_;
            Ingredients_dataGridView.DataSource = ingredients_;


        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Recipes_dataGridView_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewCell cell = Recipes_dataGridView.CurrentCell;
            if(cell!=null)
            {
                int recipesIndex = cell.RowIndex;
                Recipe rep = recipes_[recipesIndex];
                Instruction_richTextBox.Text = rep.Instruction;
            }
        }
    }
}
