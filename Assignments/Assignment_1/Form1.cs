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
        internal BindingList<Recipe> recipes_;
        /// <summary>
        /// The list of all papers. We like to use datagrid view to show things.
        /// </summary>
        internal BindingList<Ingredient> ingredients_;
        public Form1()
        {
            InitializeComponent();

            //Create recipes list and objects and save to this list
            recipes_ = new BindingList<Recipe>();
            recipes_.Add(new Recipe("Chocolate Ricotta Cheesecake", 10, "Prepare graham crust and set aside. Place Ricotta cheese, sugar and eggs in food processor or blender container; process until smooth. \nAdd cream, cocoa, flour, salt and vanilla; process until smooth. \nPour into prepared crust. Bake at 350 degrees about 1 hour and 15 minutes or until set. \nTurn off oven; open door and let cheesecake remain in oven 1 hour. \nCool completely; chill thoroughly. "));
            recipes_.Add(new Recipe("Basic Brownie", 16, "Melt butter and cook until brown and fragrant. Take off the heat and cool for 10 minutes. \nAdd chocolate and stir until chocolate is melted. \nAdd sugar. Add eggs one at a time stirring until mixture is glossy. \nMix in vanilla essence Mix in chopped Nuts and / or soaked raisins if desired. \nAdd flour and Salt and stir to combine. Bake in 150°C oven for 25 - 30 minutes."));
            recipes_.Add(new Recipe("Pancakes", 3, "Whisk together milk and eggs. Stir in flour and sugar. \nRest mixture for 30 minutes. Heat some butter in pan. \nAdd one large spoonful of mixture to pan, fry on both sides until golden brown. \nRepeat for each pancake."));
            

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
                            double quantity = double.Parse(splitedData[1]);
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

            //Add ingredients to recipe
            //RecipeItems r1 = new RecipeItems("Graham crust", 1, "");
            //RecipeItems r2 = new RecipeItems("Ricotta", 750, "g");
            //RecipeItems r3 = new RecipeItems("Sugar", 250, "g");
            //RecipeItems r4 = new RecipeItems("Eggs", 4, "");
            //RecipeItems r5 = new RecipeItems("Cream", 240, "ml");
            //RecipeItems r6 = new RecipeItems("Cocoa", 40, "g");
            //RecipeItems r7 = new RecipeItems("Flour", 25, "g");
            
            string[] initialRecipes = new string[] { @"choc_ricotta_cheesecake.txt", @"brownie.txt", @"pancakes.txt" };
            int lineCounter = 0;
            for(int i=0;i<initialRecipes.Length; i++)
            {                
                StreamReader reader = new StreamReader(initialRecipes[i]);
                while (!reader.EndOfStream)
                {
                    lineCounter++;
                    string oneLineData = reader.ReadLine();
                    string[] splitedData = oneLineData.Split(',');
                    if (oneLineData == "#Instructions")
                    {
                        break;
                    }
                    else if (splitedData[0].Contains('#'))
                    {
                        continue;
                    }
                    else if (splitedData[0] == recipes_[i].Name)
                    {
                        continue;
                    }                    
                    else if (splitedData.Length == 2)
                    {
                        recipes_[i].Requirements_.Add(new RecipeItems(splitedData[0], double.Parse(splitedData[1]), ""));
                    }
                    else if (splitedData.Length == 3)
                    {
                        recipes_[i].Requirements_.Add(new RecipeItems(splitedData[0], double.Parse(splitedData[1]), splitedData[2]));
                    }                   
                    else {
                        MessageBox.Show("Bad Line Catched at " + lineCounter.ToString() + ".");
                    }
                }
                lineCounter = 0;
            }



            //Bind list to data grid
            Recipes_dataGridView1.DataSource = recipes_;
            //Remove the instruction columns in Recipes_dataGridView1
            Recipes_dataGridView1.Columns.RemoveAt(2);
            Ingredients_dataGridView2.DataSource = ingredients_;
            Require_dataGridView3.DefaultCellStyle.Format = "N2";
            Ingredients_dataGridView2.DefaultCellStyle.Format = "N2";

            radioButton_Metic.Checked = true;
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
                if (recipeIndex >= 0 && recipeIndex<(recipes_.Count))
                {
                    Instructions_richTextBox1.Enabled = true;
                    Recipe rep = recipes_[recipeIndex];
                    Instructions_richTextBox1.Text = rep.Instruction;
                    Require_dataGridView3.DataSource = rep.Requirements_;
                    cost_label.Text = rep.calculateCost(ingredients_).ToString("c");
                    energy_label.Text = rep.calculateEnergy(ingredients_).ToString("f2");
                }
                else
                {
                    Instructions_richTextBox1.Enabled = false;
                }
            }
            catch
            {
                Require_dataGridView3.DataSource = null; 
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

        private void Require_dataGridView3_KeyDown(object sender, KeyEventArgs e)
        {
            int recipeIndex = Recipes_dataGridView1.CurrentCell.RowIndex;
            int recipeItemIndex = Require_dataGridView3.CurrentCell.RowIndex;
            if (recipeIndex >= 0 && recipeItemIndex>=0 && e.KeyCode == Keys.Delete)
            {
                Recipe rep = recipes_[recipeIndex];
                rep.Requirements_.RemoveAt(recipeItemIndex);
                Require_dataGridView3.DataSource = null;
                Require_dataGridView3.DataSource = rep.Requirements_;
                Recipes_dataGridView1.DataSource = null;
                Recipes_dataGridView1.DataSource = recipes_;
            }
        }

        private void Require_dataGridView3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int recipeIndex = Recipes_dataGridView1.CurrentCell.RowIndex;
            int recipeItemIndex = Require_dataGridView3.CurrentCell.RowIndex;
            if (recipeIndex >= 0 && recipeItemIndex >= 0)
            {
                Recipe rep = recipes_[recipeIndex];
                Require_dataGridView3.DataSource = rep.Requirements_;
                cost_label.Text = rep.calculateCost(ingredients_).ToString("c");
                energy_label.Text = rep.calculateEnergy(ingredients_).ToString("f2");
            }
        }
              

        private void RemoveItem_button2_Click(object sender, EventArgs e)
        {
            int recipeIndex = Recipes_dataGridView1.CurrentCell.RowIndex;
            int recipeItemIndex = Require_dataGridView3.CurrentCell.RowIndex;
            if (recipeIndex >= 0 && recipeItemIndex >= 0)
            {
                Recipe rep = recipes_[recipeIndex];
                rep.Requirements_.RemoveAt(recipeItemIndex);
                Require_dataGridView3.DataSource = null;
                Require_dataGridView3.DataSource = rep.Requirements_;
                Recipes_dataGridView1.DataSource = null;
                Recipes_dataGridView1.DataSource = recipes_;
            }
        }

        private void AddItem_button1_Click(object sender, EventArgs e)
        {
            int recipeIndex = Recipes_dataGridView1.CurrentCell.RowIndex;
            int ingredientIndex = Ingredients_dataGridView2.CurrentCell.RowIndex;
            int quantity = 0;
            if (int.TryParse(quantity_textBox1.Text, out quantity))
            {
                if (recipeIndex >= 0 && ingredientIndex >= 0)
                {
                    Recipe rep = recipes_[recipeIndex];
                    Ingredient ing = ingredients_[ingredientIndex];
                    RecipeItems newItems = new RecipeItems(ing.Name, quantity, ing.Unit);

                    bool isFind = false;
                    foreach (RecipeItems repICheck in rep.Requirements_)
                    {
                        if (newItems.IngredientName == repICheck.IngredientName)
                        {
                            MessageBox.Show("Recipe has the same ingredient, the quantity will add to previous value. :-)");
                            repICheck.Quantity += quantity;
                            isFind = true;
                            break;
                        }
                    }
                    if (!isFind) rep.Add(newItems);

                    Require_dataGridView3.DataSource = null;
                    Require_dataGridView3.DataSource = rep.Requirements_;
                    cost_label.Text = rep.calculateCost(ingredients_).ToString("c");
                    energy_label.Text = rep.calculateEnergy(ingredients_).ToString("f2");
                }
            }
            else
            {
                MessageBox.Show("Unexpected value in quantity textbox!");
            }
        }

        private void ChangeInstruction_button3_Click(object sender, EventArgs e)
        {
            string newInstruction = Instructions_richTextBox1.Text;
            int recipeIndex = Recipes_dataGridView1.CurrentCell.RowIndex;
            if(recipeIndex>=0)
            {
                Recipe rep = recipes_[recipeIndex];
                if (rep.Instruction != newInstruction)
                {
                    rep.Instruction = "";
                    rep.Instruction = newInstruction;
                    Instructions_richTextBox1.Text = rep.Instruction;
                    MessageBox.Show(":-) \nBravo~ New Instruction is saved!");
                }
                else
                {
                    MessageBox.Show("There is no changes in instruction.");
                }
            }
            else
            {
                MessageBox.Show("Wrong Recipe Index Catched!");
            }
        }

        private void Recipes_dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            int recipeIndex = Recipes_dataGridView1.CurrentCell.RowIndex;
            if (recipeIndex >= 0)
            {
                try
                {
                    Recipe rep = recipes_[recipeIndex];
                    rep.changeQuantity(rep.Yield);
                    rep.updateUnit();
                    Require_dataGridView3.DataSource = null;
                    Require_dataGridView3.DataSource = rep.Requirements_;
                    cost_label.Text = rep.calculateCost(ingredients_).ToString("c");
                    energy_label.Text = rep.calculateEnergy(ingredients_).ToString("N2");
                    //if(metric_radioButton1.Checked)
                    //{
                    //    rep.changeUnit(imperial_radioButton2.Text);
                    //        }
                    //else if(imperial_radioButton2.Checked)
                    //{
                    //    rep.changeUnit(imperial_radioButton2.Text);
                    //}
                    //Need a update method in recipe*
                }
                catch
                {
                    MessageBox.Show("Unexpected error happen!");
                }
                
            }

        }

        private void Read_button4_Click(object sender, EventArgs e)
        {
            StreamReader reader;
            Recipe_openFileDialog1.Filter = "TXT Files| *.txt";
            
                if (Recipe_openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    reader = File.OpenText(Recipe_openFileDialog1.FileName);
                    Recipe newRecipe = new Recipe();
                int lineCounter = 0;
                string errorLine = "";
                try
                {
                    while (!reader.EndOfStream)
                    {
                        lineCounter++;
                        string oneLineData = reader.ReadLine();
                        errorLine = oneLineData;
                        string[] splitedData = oneLineData.Split(',');
                        if (oneLineData == "#Name,Servings")
                        {
                            oneLineData = reader.ReadLine();
                            lineCounter++;
                            errorLine = oneLineData;
                            splitedData = oneLineData.Split(',');
                            newRecipe.Name = splitedData[0];
                            newRecipe.Yield=uint.Parse(splitedData[1]);
                            newRecipe.PreviousYield = uint.Parse(splitedData[1]);
                            recipes_.Add(newRecipe);
                            continue;
                        }else if (oneLineData == "#Ingredients")
                        {
                            continue;
                        }
                        else if(oneLineData=="#Name,Quantity,Unit"||oneLineData=="#Name,quantity,unit")
                        {
                            while (oneLineData != "#Instructions")
                            {
                                oneLineData = reader.ReadLine();
                                lineCounter++;
                                errorLine = oneLineData;
                                splitedData = oneLineData.Split(',');
                                RecipeItems newItems;
                                if (splitedData.Length == 2)
                                {
                                    //foreach(Ingredient ing in ingredients_)
                                    //{
                                    //    if(ing.Name==splitedData[0])
                                    //    {
                                    //        newItems = new RecipeItems(ing.Name, double.Parse(splitedData[1]), "");
                                    //        newRecipe.Requirements_.Add(newItems);
                                    //        break;
                                    //    }
                                    //}
                                    bool newIngredient = false;
                                    for(int i=0;i<ingredients_.Count;i++)
                                    {
                                        if(ingredients_[i].Name==splitedData[0])
                                        {
                                            newIngredient = false;
                                            break;
                                        }
                                        else
                                        {
                                            newIngredient = true;
                                        }
                                    }
                                    if(newIngredient)
                                    {
                                        ingredients_.Add(new Ingredient(splitedData[0], double.Parse(splitedData[1]), "", 0, 0));
                                    }
                                    newItems = new RecipeItems(splitedData[0], double.Parse(splitedData[1]), "");
                                    newRecipe.Requirements_.Add(newItems);
                                }
                                else if (splitedData.Length == 3)
                                {
                                    //newRecipe.Requirements_.Add(new RecipeItems(splitedData[0], double.Parse(splitedData[1]), splitedData[2]));
                                    //Ingredient newIng = new Ingredient(splitedData[0], double.Parse(splitedData[1]), splitedData[2], 0, 0);
                                    //ingredients_.Add(newIng);
                                    bool newIngredient = false;
                                    for (int i = 0; i < ingredients_.Count; i++)
                                    {
                                        if (ingredients_[i].Name == splitedData[0])
                                        {
                                            newIngredient = false;
                                            break;
                                        }
                                        else
                                        {
                                            newIngredient = true;
                                        }
                                    }
                                    if (newIngredient)
                                    {
                                        ingredients_.Add(new Ingredient(splitedData[0], double.Parse(splitedData[1]), splitedData[2], 0, 0));
                                    }
                                    newItems = new RecipeItems(splitedData[0], double.Parse(splitedData[1]), splitedData[2]);
                                    newRecipe.Requirements_.Add(newItems);
                                }
                            }
                            while(!reader.EndOfStream)
                            {
                                oneLineData = reader.ReadLine();
                                lineCounter++;
                                errorLine = oneLineData;
                                newRecipe.Instruction += oneLineData + "\n";
                            }
                            break;
                        }
                        else
                        {
                            MessageBox.Show(":-( \nFailed to read, because this recipe file has incorrect syntax at line " + lineCounter.ToString()+"."+
                                            "\nThe line content is "+oneLineData+"\nNormal syntax needs to be any of:"+"\n#Name,Servings, this should be Line 1"+"\n#Ingredients"
                                            +"\n#Name,Quantity,Unit"+"\n#Instrctuions");
                            recipes_.Remove(newRecipe);
                            break;
                        }

                        //if(lineCounter==1||lineCounter==2 || oneLineData == "#Name,Servings")
                        //{
                        //    if(oneLineData== "#Name,Servings")
                        //    {
                        //        continue;
                        //    }
                        //    else if(splitedData.Length==2)
                        //    {
                        //        newRecipe.Name = splitedData[0];
                        //        newRecipe.Yield = uint.Parse(splitedData[1]);
                        //        recipes_.Add(newRecipe);
                        //        continue;
                        //    }
                        //}
                        //if(oneLineData=="#Ingredients")
                        //{
                        //    continue;
                        //}
                        //if(oneLineData == "#Name,Quantity,Unit" || oneLineData == "#Name,quantity,unit")
                        //{
                        //    while (oneLineData != "#Instructions")
                        //    {
                        //        oneLineData = reader.ReadLine();
                        //        splitedData = oneLineData.Split(',');
                        //        if (splitedData.Length == 2)
                        //        {
                        //            newRecipe.Requirements_.Add(new RecipeItems(splitedData[0], double.Parse(splitedData[1]), ""));
                        //        }
                        //        else if (splitedData.Length == 3)
                        //        {
                        //            newRecipe.Requirements_.Add(new RecipeItems(splitedData[0], double.Parse(splitedData[1]), splitedData[2]));
                        //        }
                        //    }
                        //    continue;
                        //}
                        //else
                        //{
                        //    newRecipe.Instruction += oneLineData + "\n";
                        //}
                        //if (oneLineData == "#Name,Servings")
                        //{
                        ////    //if (splitedData.Length == 2)
                        //    //{
                        //    //    newRecipe.Name = splitedData[0];
                        //    //    newRecipe.Yield = uint.Parse(splitedData[1]);
                        //    //    recipes_.Add(newRecipe);
                        //    //}
                        //    continue;
                        //} else if (lineCounter == 0 ||lineCounter==1)
                        // {
                        //    if(splitedData[0].Contains('#'))
                        //    {
                        //        continue;
                        //    }
                        //    else if(splitedData.Length == 2)
                        //    {
                        //        newRecipe.Name = splitedData[0];
                        //        newRecipe.Yield = uint.Parse(splitedData[1]);
                        //        recipes_.Add(newRecipe);
                        //        continue;
                        //    }
                        //}
                        //else if(oneLineData== "#Ingredients")
                        //{
                        //    continue;
                        //}
                        //else if(oneLineData== "#Name,Quantity,Unit" || oneLineData== "#Name,quantity,unit")
                        //{
                        //    string IngredientLineData = "";
                        //    IngredientLineData = reader.ReadLine();
                        //    while (IngredientLineData != "#Instructions")
                        //    {
                        //        string[] splitedNewLineData = IngredientLineData.Split(',');
                        //        if (splitedNewLineData.Length == 2)
                        //        {
                        //            newRecipe.Requirements_.Add(new RecipeItems(splitedNewLineData[0], double.Parse(splitedNewLineData[1]), ""));
                        //        }
                        //        else if (splitedData.Length == 3)
                        //        {
                        //            newRecipe.Requirements_.Add(new RecipeItems(splitedNewLineData[0], double.Parse(splitedNewLineData[1]), splitedNewLineData[2]));
                        //        }
                        //        IngredientLineData = reader.ReadLine();
                        //    }
                        //    continue;                            
                        //}
                        //else if(oneLineData.Contains('#'))
                        //{
                        //    continue;
                        //}
                        //else
                        //{
                        //    newRecipe.Instruction += oneLineData;
                        //}
                    }
                    reader.Close();

                    if(radioButton_Imperial.Checked)
                    {
                        newRecipe.changeUnit("Metric");
                    }
                    else if(radioButton_Imperial.Checked)
                    {
                        newRecipe.changeUnit("Imperial");
                    }

                    Recipes_dataGridView1.DataSource = null;
                    Recipes_dataGridView1.DataSource = recipes_;
                    Ingredients_dataGridView2.DataSource = null;
                    Ingredients_dataGridView2.DataSource = ingredients_;
                }
                catch 
                {
                    MessageBox.Show(":-( \nFailed to read, because this recipe file has incorrect syntax at line " + lineCounter.ToString() + "." +
                                            "\nThe line content is " + errorLine + "\nNormal syntax needs to be any of:" + "\n#Name,Servings, this should be Line 1" + "\n#Ingredients"
                                            + "\n#Name,Quantity,Unit" + "\n#Instrctuions");
                    recipes_.Remove(newRecipe);
                }
            }
        }

        private void Print_button5_Click(object sender, EventArgs e)
        {
            Recipe retRecipe;
            int recipeIndex = Recipes_dataGridView1.CurrentCell.RowIndex;
            if (recipeIndex >= 0)
            {
                retRecipe = recipes_[recipeIndex];
                DisplayForm printIt = new DisplayForm(retRecipe);
                printIt.Show();
            }
            else
            {
                MessageBox.Show("Is there no recipe selected to be shown?");
            }
        }

        private void metric_radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string toUnit = "Metric";
                foreach (Recipe unit in recipes_)
                {
                    unit.changeUnit(toUnit);
                }
                int recipeIndex = Recipes_dataGridView1.CurrentCell.RowIndex;
                if (recipeIndex >= 0)
                {
                    Recipe retRecipe = recipes_[recipeIndex];
                    Require_dataGridView3.DataSource = null;
                    Require_dataGridView3.DataSource = retRecipe.Requirements_;
                }
                foreach (Ingredient unit in ingredients_)
                {
                    unit.changeUnit(toUnit);
                }
                Ingredients_dataGridView2.DataSource = null;
                Ingredients_dataGridView2.DataSource = ingredients_;
            }
            catch
            { }
        }

        private void imperial_radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string toUnit = "Imperial";
                foreach (Recipe unit in recipes_)
                {
                    unit.changeUnit(toUnit);
                }
                int recipeIndex = Recipes_dataGridView1.CurrentCell.RowIndex;
                if (recipeIndex >= 0)
                {
                    Recipe retRecipe = recipes_[recipeIndex];
                    Require_dataGridView3.DataSource = null;
                    Require_dataGridView3.DataSource = retRecipe.Requirements_;
                }

                foreach (Ingredient unit in ingredients_)
                {
                    unit.changeUnit(toUnit);
                }
                Ingredients_dataGridView2.DataSource = null;
                Ingredients_dataGridView2.DataSource = ingredients_;
            }
            catch
            { }
        }

        //public Recipe callRecipe()
        //{
        //    Recipe retRecipe;
        //    int recipeIndex = Recipes_dataGridView1.CurrentCell.RowIndex;
        //    if (recipeIndex >= 0)
        //    {
        //        retRecipe = recipes_[recipeIndex];
        //        return retRecipe;
        //    }
        //    else
        //    {
        //        return retRecipe = null;
        //    }
        //}
    }
}
