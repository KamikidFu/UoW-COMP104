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

            /*
             * These part is to add three initial recipes to the programme
             * Our choice is Chocolate Ricotta Cheesecake, Basic Brownie and Pancakes
             */
            //Create recipes list and objects and save to this list
            recipes_ = new BindingList<Recipe>();
            recipes_.Add(new Recipe("Chocolate Ricotta Cheesecake", 10, "Prepare graham crust and set aside. Place Ricotta cheese, sugar and eggs in food processor or blender container; process until smooth. \nAdd cream, cocoa, flour, salt and vanilla; process until smooth. \nPour into prepared crust. Bake at 350 degrees about 1 hour and 15 minutes or until set. \nTurn off oven; open door and let cheesecake remain in oven 1 hour. \nCool completely; chill thoroughly. "));
            recipes_.Add(new Recipe("Basic Brownie", 16, "Melt butter and cook until brown and fragrant. Take off the heat and cool for 10 minutes. \nAdd chocolate and stir until chocolate is melted. \nAdd sugar. Add eggs one at a time stirring until mixture is glossy. \nMix in vanilla essence Mix in chopped Nuts and / or soaked raisins if desired. \nAdd flour and Salt and stir to combine. Bake in 150°C oven for 25 - 30 minutes."));
            recipes_.Add(new Recipe("Pancakes", 3, "Whisk together milk and eggs. Stir in flour and sugar. \nRest mixture for 30 minutes. Heat some butter in pan. \nAdd one large spoonful of mixture to pan, fry on both sides until golden brown. \nRepeat for each pancake."));

            /*
             * These part is to add ingredients to the programme
             * We try to read the file by code and if catch any errors it will fair show
             */
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
                            //Store any information into seperate varibles
                            string name = splitedData[0];
                            double quantity = double.Parse(splitedData[1]);
                            string unit = splitedData[2];
                            uint energy = uint.Parse(splitedData[3]);
                            decimal price = decimal.Parse(splitedData[4]);
                            //Add a new ingredient to ingredient list
                            ingredients_.Add(new Ingredient(name, quantity, unit, energy, price));
                        }
                        else
                        {
                            //If there having a #, directly continue to next line
                            continue;
                        }
                    }
                    else
                    {
                        //Any line is not having 5 units length
                        MessageBox.Show("Bad Line");
                    }
                }
                //Try...catch...
                catch (Exception ex)
                {
                    //Catch any other errors
                    MessageBox.Show(ex.Message);
                }
            }

            /*
             * These part of programme is to add any ingredients to our three recipe above
             * It will read these three files and do its work to add required ingredients to recipe.
             */
            //This string array is stored the relative paths for three files
            string[] initialRecipes = new string[] { @"choc_ricotta_cheesecake.txt", @"brownie.txt", @"pancakes.txt" };
            //Any error will show in its line, so here is the lineCounter
            int lineCounter = 0;
            //For each files to read
            for (int i = 0; i < initialRecipes.Length; i++)
            {
                //Set up new stream reader for each files
                StreamReader reader = new StreamReader(initialRecipes[i]);
                //While it is not the end of file
                while (!reader.EndOfStream)
                {
                    //Line counter add up
                    lineCounter++;
                    //Read one line data
                    string oneLineData = reader.ReadLine();
                    //Split the data
                    string[] splitedData = oneLineData.Split(',');
                    //If the data is #Instructions
                    if (oneLineData == "#Instructions")
                    {
                        //Break whole loop
                        break;
                    }
                    else if (splitedData[0].Contains('#'))
                    {
                        //Else if there having # in one line, then continue to next line
                        continue;
                    }
                    else if (splitedData[0] == recipes_[i].Name)
                    {
                        //Else if it is the name,serving line, continue
                        continue;
                    }
                    else if (splitedData.Length == 2)
                    {
                        //Only other lines length is 2 or 3 could add for new required ingredients
                        recipes_[i].Requirements_.Add(new RecipeItems(splitedData[0], double.Parse(splitedData[1]), ""));
                    }
                    else if (splitedData.Length == 3)
                    {
                        //Only other lines length is 2 or 3 could add for new required ingredients
                        recipes_[i].Requirements_.Add(new RecipeItems(splitedData[0], double.Parse(splitedData[1]), splitedData[2]));
                    }
                    else
                    {
                        //Any bad line catched at that line
                        MessageBox.Show("Bad Line Catched at " + lineCounter.ToString() + ".");
                    }
                }
                //Reset the line counter
                lineCounter = 0;
            }


            /*
             * These part is for the final preparation to show the initial programme
             * Set any datasource to its bindinglist
             * Set the default value for datagridview cells (2 decimal places) and radiobutton(metric unit system)
             */
            //Bind list to data grid
            Recipes_dataGridView1.DataSource = recipes_;
            Ingredients_dataGridView2.DataSource = ingredients_;
            //Set 2 decimal places to cell
            Require_dataGridView3.DefaultCellStyle.Format = "N2";
            Ingredients_dataGridView2.DefaultCellStyle.Format = "N2";
            //Set default radio button value
            metric_radioButton1.Checked = true;
        }



        /// <summary>
        /// These following methods are for DataGridViews
        /// </summary>
        /// <param name="sender">Automatically pass to methods</param>
        /// <param name="e">Automatically pass to methods</param>

        // This method is for showing required items in Require_dataGridView3 and instruction in richBox
        // And recalculate the Cost and Energy for this recipe
        private void Recipes_dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //Try..catch..any errors
            try
            {
                //Get the index of recipe in datagridview
                int recipeIndex = Recipes_dataGridView1.CurrentCell.RowIndex;
                //If the user right chooses any recipe
                if (recipeIndex >= 0 && recipeIndex < (recipes_.Count))
                {
                    //Enable the richTextBox for editing
                    Instructions_richTextBox1.Enabled = true;
                    //Creat the object for the recipe
                    Recipe rep = recipes_[recipeIndex];
                    //Get the information where the controls need
                    Instructions_richTextBox1.Text = rep.Instruction;
                    Require_dataGridView3.DataSource = rep.Requirements_;
                    //Call the methods for calculating cost and energy, and pass value to labels
                    CostLabel.Text = rep.calculateCost(ingredients_).ToString("c");
                    EnergyLabel.Text = rep.calculateEnergy(ingredients_).ToString("f2");
                    RecipeLabel.Text = rep.Name;
                }
                else
                {
                    //If user does not choose any recipe
                    Instructions_richTextBox1.Enabled = false;
                }
            }
            catch
            {
                //Make the require datagridview to nothings
                Require_dataGridView3.DataSource = null;
                //Show the message for user to generate a new one
                MessageBox.Show(":-) \nNow, there is no recipes. \nPlease edit a new one for all functionality.", "Information");
            }
        }

        //This method is for using Delete key to remove any recipes in datagridview
        private void Recipes_dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            //Get the index of recipe
            int recipeIndex = Recipes_dataGridView1.CurrentCell.RowIndex;
            //If the index is greater than 0 and user press Delete key
            if (recipeIndex >= 0 && e.KeyCode == Keys.Delete)
            {
                //Create the object
                Recipe rep = recipes_[recipeIndex];
                //Remove it from list
                recipes_.Remove(rep);
                //Force to update the datasource
                Recipes_dataGridView1.DataSource = null;
                Recipes_dataGridView1.DataSource = recipes_;
            }
        }

        //This method is for when the user finishes editing one cell, they triger the method for
        //update any changes related to the recipe or cell
        private void Recipes_dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Get the recipe Index
            int recipeIndex = Recipes_dataGridView1.CurrentCell.RowIndex;
            //If the users right choose a recipe
            if (recipeIndex >= 0)
            {
                //Try..catch.. any errors
                try
                {
                    //Create the object
                    Recipe rep = recipes_[recipeIndex];
                    //Call the change the quantity method in Recipe class
                    rep.changeQuantity(rep.Yield);
                    //Call the update method in Recipe class
                    rep.updateUnit();
                    //Force to update dataGridView
                    Require_dataGridView3.DataSource = null;
                    Require_dataGridView3.DataSource = rep.Requirements_;
                    //Show the new value of cost and energy
                    CostLabel.Text = rep.calculateCost(ingredients_).ToString("c");
                    EnergyLabel.Text = rep.calculateEnergy(ingredients_).ToString("N2");
                }
                catch
                {
                    //Catched any errors
                    MessageBox.Show("Unexpected error happen!");
                }

            }
        }

        //This method is for selection happened in Ingredients dataGridView and show it to label
        private void Ingredients_dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            //Get the index of ingredient
            int ingredientIndex = Ingredients_dataGridView2.CurrentCell.RowIndex;
            //If it is great or equal to 0
            if (ingredientIndex >= 0)
            {
                //Creat the ingredient object
                Ingredient ing = ingredients_[ingredientIndex];
                //Show its name to label
                IngredientLabel.Text = ing.Name;
            }
        }

        //This method is for when user presses Delete key in dataGridView3, require items list
        private void Require_dataGridView3_KeyDown(object sender, KeyEventArgs e)
        {
            //Get the recipe index
            int recipeIndex = Recipes_dataGridView1.CurrentCell.RowIndex;
            //Get the requried item index
            int recipeItemIndex = Require_dataGridView3.CurrentCell.RowIndex;
            //If user choose the right recipe and items and the key is delete key pressed
            if (recipeIndex >= 0 && recipeItemIndex >= 0 && e.KeyCode == Keys.Delete)
            {
                //Creat the object
                Recipe rep = recipes_[recipeIndex];
                //Remove the item in list
                rep.Requirements_.RemoveAt(recipeItemIndex);
                //Force to update two datagridview datasource
                Require_dataGridView3.DataSource = null;
                Require_dataGridView3.DataSource = rep.Requirements_;
                Recipes_dataGridView1.DataSource = null;
                Recipes_dataGridView1.DataSource = recipes_;
            }
        }

        //This method is for when user finishes editing require datagridview cell for update any changeds 
        //related to the recipe or cell
        private void Require_dataGridView3_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //Get the recipe index
            int recipeIndex = Recipes_dataGridView1.CurrentCell.RowIndex;
            //Get the required item index
            int recipeItemIndex = Require_dataGridView3.CurrentCell.RowIndex;
            //If the user choose the right index of recipe and its item
            if (recipeIndex >= 0 && recipeItemIndex >= 0)
            {
                //Create the object
                Recipe rep = recipes_[recipeIndex];
                //Bind to datasour to itself for update changes
                Require_dataGridView3.DataSource = rep.Requirements_;
                //Recalculate the cost and energy
                CostLabel.Text = rep.calculateCost(ingredients_).ToString("c");
                EnergyLabel.Text = rep.calculateEnergy(ingredients_).ToString("f2");
            }
        }



        /// <summary>
        /// These following is for button methods
        /// </summary>
        /// <param name="sender">Automatically pass to methods</param>
        /// <param name="e">Automatically pass to methods</param>
        //Add new recipe button click is to open a dialog and read the file and add the new recipe to programme
        private void button1_Add_Click(object sender, EventArgs e)
        {
            //Set a streamreader
            StreamReader reader;
            //Set the filter to *.txt file recipe
            Recipe_openFileDialog1.Filter = "TXT Files| *.txt";
            //The bool varible for checking if it is a new recipe
            bool isNewRecipe = false;
            //The bool varible to catch if it is a new ingredient
            bool isnewIngredient = false;
            //The has is to locate the already exist recipe in programme
            int hasRepIndex = 0;
            //Line counter is for catch any error in the file
            int lineCounter = 0;
            //Error line will store in this varible and show if there having an error
            string errorLine = "";

            //If user choose one file
            if (Recipe_openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Reader starts reading files
                reader = File.OpenText(Recipe_openFileDialog1.FileName);
                //Initially create a new object of recipe
                Recipe newRecipe = new Recipe();
                //Try..catch.. any errors
                try
                {
                    //While it is not the end of stream
                    while (!reader.EndOfStream)
                    {
                        //Linecounter add up
                        lineCounter++;
                        //Read one line data from reader to varible
                        string oneLineData = reader.ReadLine();
                        //Errorline is now the current line
                        errorLine = oneLineData;
                        //Split the line into array
                        string[] splitedData = oneLineData.Split(',');
                        //If it is #Name,Servings, the 1st line
                        if (oneLineData == "#Name,Servings")
                        {
                            //Read one more time
                            oneLineData = reader.ReadLine();
                            lineCounter++;
                            errorLine = oneLineData;
                            splitedData = oneLineData.Split(',');
                            //For each exist recipe to check if it is a new recipe
                            foreach (Recipe rep in recipes_)
                            {
                                //If the name of recipe is the same as any recipes in list
                                if (rep.Name == splitedData[0])
                                {
                                    //Show the message to user that we have a same recipe
                                    MessageBox.Show(":-(\nThis recipe " + splitedData[0] + " has already in programme.\nIt is at the No." + (hasRepIndex + 1) + " row in Recipes DataGridView.\nSorry, it is failed to read.");
                                    //Set the bool varible to false, means it is not a new recipe
                                    isNewRecipe = false;
                                    //Break the foreach
                                    break;
                                }
                                //Set to true if once the name is not match
                                isNewRecipe = true;
                                //Add up the counter for locating which recipe
                                hasRepIndex++;
                            }
                            //If it is a new recipe
                            if (isNewRecipe)
                            {
                                //Read the name, yield and add the list
                                newRecipe.Name = splitedData[0];
                                newRecipe.Yield = uint.Parse(splitedData[1]);
                                newRecipe.PreviousYield = uint.Parse(splitedData[1]);
                                recipes_.Add(newRecipe);
                                continue;
                            }
                            else
                            {
                                //Break the while loop to stop read rest of file
                                break;
                            }

                        }
                        //If it the line is #Ingredients
                        else if (oneLineData == "#Ingredients")
                        {
                            //Add up linecounter
                            lineCounter++;
                            //Countinue to next line anyway
                            continue;
                        }
                        //If it the line is #Name,Quantity,Unit
                        else if (oneLineData == "#Name,Quantity,Unit" || oneLineData == "#Name,quantity,unit")
                        {
                            //Use the other loop for reading the rest of file
                            //Here if the onelinedata is not the #Instructions
                            //So to read the ingredients needed in this new recipe
                            while (oneLineData != "#Instructions")
                            {
                                //Read one line
                                oneLineData = reader.ReadLine();
                                //Add up linecounter
                                lineCounter++;
                                //Error line value is the onelinedata
                                errorLine = oneLineData;
                                //Split the line
                                splitedData = oneLineData.Split(',');
                                //Create one object to handle the items
                                RecipeItems newItems;
                                //If the length is 2
                                if (splitedData.Length == 2)
                                {
                                    //For each ingredient in programme to check
                                    for (int i = 0; i < ingredients_.Count; i++)
                                    {
                                        //If the name matched
                                        if (ingredients_[i].Name == splitedData[0])
                                        {
                                            //It is not a new ingredient
                                            isnewIngredient = false;
                                            //Break the for loop
                                            break;
                                        }
                                        //otherwise, it is a new ingredient
                                        isnewIngredient = true;
                                    }
                                    //If it is a new ingredient
                                    if (isnewIngredient)
                                    {
                                        //Add to our list in programme with zero price and energy and no unit
                                        ingredients_.Add(new Ingredient(splitedData[0], double.Parse(splitedData[1]), "", 0, 0));
                                    }
                                    //Edit the required item object to requirements list of the new recipe
                                    newItems = new RecipeItems(splitedData[0], double.Parse(splitedData[1]), "");
                                    //Add new objects to requirements list
                                    newRecipe.Requirements_.Add(newItems);
                                }
                                //If the lengh is 3
                                else if (splitedData.Length == 3)
                                {
                                    //Same idea as above where the length is 2
                                    for (int i = 0; i < ingredients_.Count; i++)
                                    {
                                        if (ingredients_[i].Name == splitedData[0])
                                        {
                                            isnewIngredient = false;
                                            break;
                                        }

                                        isnewIngredient = true;
                                    }
                                    if (isnewIngredient)
                                    {
                                        ingredients_.Add(new Ingredient(splitedData[0], double.Parse(splitedData[1]), splitedData[2], 0, 0));
                                    }
                                    newItems = new RecipeItems(splitedData[0], double.Parse(splitedData[1]), splitedData[2]);
                                    newRecipe.Requirements_.Add(newItems);
                                }
                            }
                            //Here it is in instruction paragraphs, read it to recipe
                            while (!reader.EndOfStream)
                            {
                                //read oneline data
                                oneLineData = reader.ReadLine();
                                //Add up linecounter
                                lineCounter++;
                                //The errorline become current one
                                errorLine = oneLineData;
                                //Add to recipe
                                newRecipe.Instruction += oneLineData + "\n";
                            }
                            //Break reading file loop
                            break;
                        }
                        //Any error catched
                        else
                        {
                            //Show the reason and where it is false to read the file
                            MessageBox.Show(":-( \nFailed to read, because this recipe file is abnormal and has incorrect syntax at line " + lineCounter.ToString() + "." +
                                            "\n\nThe line content is \n" + oneLineData + "\n\nNormal syntax needs to be the structure of:" + "\n#Name,Servings(This must be Line 1)\n..." + "\n#Ingredients"
                                            + "\n#Name,Quantity,Unit\n..." + "\n#Instrctuions\n...");
                            //Remove the new recipe object
                            recipes_.Remove(newRecipe);
                            //Break reading file loop to stop reading
                            break;
                        }
                    }
                    //Close the streamreader
                    reader.Close();

                    //What unit system we current in
                    if (metric_radioButton1.Checked)
                    {
                        //Change the unit to metric if radio button is checked
                        newRecipe.changeUnit("Metric");
                    }
                    else if (imperial_radioButton2.Checked)
                    {
                        //Or change to the other unit system imperial
                        newRecipe.changeUnit("Imperial");
                    }
                    //Force to update datasource
                    Recipes_dataGridView1.DataSource = null;
                    Recipes_dataGridView1.DataSource = recipes_;
                    Ingredients_dataGridView2.DataSource = null;
                    Ingredients_dataGridView2.DataSource = ingredients_;
                }
                catch
                {
                    //Show the reason and where it is false to read the file
                    MessageBox.Show(":-( \nFailed to read, because this recipe file has incorrect syntax at line " + lineCounter.ToString() + "." +
                                            "\nThe line content is " + errorLine + "\nNormal syntax needs to be any of:" + "\n#Name,Servings, this should be Line 1" + "\n#Ingredients"
                                            + "\n#Name,Quantity,Unit" + "\n#Instrctuions");
                    //Remove the new recipe object
                    recipes_.Remove(newRecipe);
                }
            }
        }

        //This method is for remove any recipe by click the button
        private void button2_RemoveRecipe_Click(object sender, EventArgs e)
        {
            //Get the index of recipe
            int recipeIndex = Recipes_dataGridView1.CurrentCell.RowIndex;
            //If the recipe index is great or equal to 0
            if (recipeIndex >= 0)
            {
                //Create the object
                Recipe rep = recipes_[recipeIndex];
                //Remove it from list
                recipes_.Remove(rep);
                //Force to update datasource
                Recipes_dataGridView1.DataSource = null;
                Recipes_dataGridView1.DataSource = recipes_;
            }
        }

        //This method is for remove any items in recipes
        private void button3_RemoveItems_Click(object sender, EventArgs e)
        {
            //Get the index of recipe
            int recipeIndex = Recipes_dataGridView1.CurrentCell.RowIndex;
            //Get the index of item
            int recipeItemIndex = Require_dataGridView3.CurrentCell.RowIndex;
            //Both are correct
            if (recipeIndex >= 0 && recipeItemIndex >= 0)
            {
                //Create the object
                Recipe rep = recipes_[recipeIndex];
                //Remove the item at requirement list
                rep.Requirements_.RemoveAt(recipeItemIndex);
                //Force to update datasource
                Require_dataGridView3.DataSource = null;
                Require_dataGridView3.DataSource = rep.Requirements_;
                Recipes_dataGridView1.DataSource = null;
                Recipes_dataGridView1.DataSource = recipes_;
            }
        }

        //This method is for changing the instruction 
        private void button4_ChangeInstruction_Click(object sender, EventArgs e)
        {
            //Get the new instruction from the richTextBox
            string newInstruction = Instructions_richTextBox1.Text;
            //Get the index of recipe
            int recipeIndex = Recipes_dataGridView1.CurrentCell.RowIndex;
            //If the recipe is okay to change
            if (recipeIndex >= 0)
            {
                //Create the object
                Recipe rep = recipes_[recipeIndex];
                //If the instruction is changed and different from the old one
                if (rep.Instruction != newInstruction)
                {
                    //Force to update the instruction
                    rep.Instruction = "";
                    rep.Instruction = newInstruction;
                    //Show the new instruction
                    Instructions_richTextBox1.Text = rep.Instruction;
                    //Message to user the programme is changed the instruction
                    MessageBox.Show(":-)\nNew Instruction is saved!");
                }
                else
                {
                    //Show the message box that there is no changes because they are the same
                    MessageBox.Show(":-(\nThere is no changes in instruction.");
                }
            }
            else
            {
                //Any error catched
                MessageBox.Show(":-(\nWrong Recipe Index Catched!");
            }
        }

        //This method is for adding ingredient to recipe
        private void button5_AddIngredient_Click(object sender, EventArgs e)
        {
            //Get the recipe index
            int recipeIndex = Recipes_dataGridView1.CurrentCell.RowIndex;
            //Get the ingredient index
            int ingredientIndex = Ingredients_dataGridView2.CurrentCell.RowIndex;
            //Initial the quantity
            int quantity = 0;
            //Try to parse the value to quantity
            if (int.TryParse(QuantityAdd_textBox1.Text, out quantity))
            {
                //If the both index are correct
                if (recipeIndex >= 0 && ingredientIndex >= 0)
                {
                    //Create the object
                    Recipe rep = recipes_[recipeIndex];
                    Ingredient ing = ingredients_[ingredientIndex];
                    //Create a new object of recipeitems to add in recipe
                    RecipeItems newItems = new RecipeItems(ing.Name, quantity, ing.Unit);
                    //Is there already having the same items
                    bool isFind = false;
                    //Foreach required items to check
                    foreach (RecipeItems repICheck in rep.Requirements_)
                    {
                        //If the name is the same
                        if (newItems.IngredientName == repICheck.IngredientName)
                        {
                            //Show to user we have one same item
                            MessageBox.Show(":-)\nRecipe has the same ingredient, the quantity will change to what you want to add.");
                            //Add the quantity to what the user wants to add
                            repICheck.Quantity = quantity;
                            //isFind is true to stop the next if statement
                            isFind = true;
                            //break the foreach loop
                            break;
                        }
                    }
                    //If it is a new ingredient item, then add to it.
                    if (!isFind) rep.Add(newItems);
                    //Force to update the datasource
                    Require_dataGridView3.DataSource = null;
                    Require_dataGridView3.DataSource = rep.Requirements_;
                    //Recalculate the cost and energy for any changes
                    CostLabel.Text = rep.calculateCost(ingredients_).ToString("c");
                    EnergyLabel.Text = rep.calculateEnergy(ingredients_).ToString("f2");
                }
            }
            else
            {
                //Any error in textbox
                MessageBox.Show(":-(\nUnexpected value in quantity textbox!");
            }
        }

        //This method is for print the recipe into a new form
        private void button6_PrintMe_Click(object sender, EventArgs e)
        {
            //Create one recipe object
            Recipe retRecipe;
            //Get the index
            int recipeIndex = Recipes_dataGridView1.CurrentCell.RowIndex;
            //If the index is right
            if (recipeIndex >= 0)
            {
                //Create that object
                retRecipe = recipes_[recipeIndex];
                //Call constructor in new form
                DisplayForm printIt = new DisplayForm(retRecipe);
                //Show the new form
                printIt.Show();
            }
            else
            {
                //Otherwise, if there is no recipe selected
                MessageBox.Show("Is there no recipe selected to be shown?");
            }
        }

        /// <summary>
        /// These following methods are for radioButton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        // This is to change the unit system to metric when the radio button is checked
        private void Metric_radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //The toUnit is Metric
                string toUnit = "Metric";
                //Get the recipe Index for show the current selected recipe
                int recipeIndex = Recipes_dataGridView1.CurrentCell.RowIndex;
                //Foreach ingredients to change the unit
                foreach (Ingredient unit in ingredients_)
                {
                    //Call the method in ingreidnet
                    unit.changeUnit(toUnit);
                }
                //Force to update the datasource
                Ingredients_dataGridView2.DataSource = null;
                Ingredients_dataGridView2.DataSource = ingredients_;
                //Foreach recipe in recipes list
                foreach (Recipe unit in recipes_)
                {
                    //Call the method in recipe to change unit
                    unit.changeUnit(toUnit);
                }
                //If currently having a selected recipe
                if (recipeIndex >= 0)
                {
                    //Create that obejct
                    Recipe retRecipe = recipes_[recipeIndex];
                    //Force to update datasource
                    Require_dataGridView3.DataSource = null;
                    Require_dataGridView3.DataSource = retRecipe.Requirements_;
                    //Recalculate the cost
                    CostLabel.Text = retRecipe.calculateCost(ingredients_).ToString("c");
                }
            }
            catch
            {
                //For initial default setting, to run the programme directly
            }
        }
        // This
        private void Imperial_radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //The toUnit is Imperial
                string toUnit = "Imperial";
                //Get the recipe Index for show the current selected recipe
                int recipeIndex = Recipes_dataGridView1.CurrentCell.RowIndex;
                //Foreach ingredients to change the unit
                foreach (Ingredient unit in ingredients_)
                {
                    //Call the method in ingreidnet
                    unit.changeUnit(toUnit);
                }
                //Force to update the datasource
                Ingredients_dataGridView2.DataSource = null;
                Ingredients_dataGridView2.DataSource = ingredients_;
                //Foreach recipe in recipes list
                foreach (Recipe unit in recipes_)
                {
                    //Call the method in recipe
                    unit.changeUnit(toUnit);
                }
                //If currently having a selected recipe
                if (recipeIndex >= 0)
                {
                    //Create that obejct
                    Recipe retRecipe = recipes_[recipeIndex];
                    //Force to update datasource
                    Require_dataGridView3.DataSource = null;
                    Require_dataGridView3.DataSource = retRecipe.Requirements_;
                    //Recalculate the cost
                    CostLabel.Text = retRecipe.calculateCost(ingredients_).ToString("c");
                }
            }
            catch
            {
                //For initial default setting, to run the programme directly}
            }


        }
    }
}
