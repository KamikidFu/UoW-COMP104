namespace Assignment_Framework_with_Classes
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Recipe_openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Require_dataGridView3 = new System.Windows.Forms.DataGridView();
            this.Ingredient_groupBox = new System.Windows.Forms.GroupBox();
            this.Unit_label = new System.Windows.Forms.Label();
            this.button_addIngredient = new System.Windows.Forms.Button();
            this.Ingredient_label = new System.Windows.Forms.Label();
            this.Recipe_label = new System.Windows.Forms.Label();
            this.quantity_textBox1 = new System.Windows.Forms.TextBox();
            this.radioButton_Imperial = new System.Windows.Forms.RadioButton();
            this.radioButton_Metic = new System.Windows.Forms.RadioButton();
            this.label_AddQuantity = new System.Windows.Forms.Label();
            this.label_CurrentIngredients = new System.Windows.Forms.Label();
            this.label_CurrentRecipes = new System.Windows.Forms.Label();
            this.label_Ingredients = new System.Windows.Forms.Label();
            this.Ingredients_dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Recipes_dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Recipes_groupBox = new System.Windows.Forms.GroupBox();
            this.button_printMe = new System.Windows.Forms.Button();
            this.energy_label = new System.Windows.Forms.Label();
            this.cost_label = new System.Windows.Forms.Label();
            this.button_Change_Instrcution = new System.Windows.Forms.Button();
            this.button_Remove_RequiredItem = new System.Windows.Forms.Button();
            this.button_Remove_Recipe = new System.Windows.Forms.Button();
            this.button_Add_Recipe = new System.Windows.Forms.Button();
            this.label_Instruction = new System.Windows.Forms.Label();
            this.label_Required = new System.Windows.Forms.Label();
            this.label_Recipes = new System.Windows.Forms.Label();
            this.label_Energy = new System.Windows.Forms.Label();
            this.label_Cost = new System.Windows.Forms.Label();
            this.Instructions_richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.Require_dataGridView3)).BeginInit();
            this.Ingredient_groupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ingredients_dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Recipes_dataGridView1)).BeginInit();
            this.Recipes_groupBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Recipe_openFileDialog1
            // 
            this.Recipe_openFileDialog1.FileName = "Open New Recipe";
            // 
            // Require_dataGridView3
            // 
            this.Require_dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Require_dataGridView3.Location = new System.Drawing.Point(279, 61);
            this.Require_dataGridView3.Name = "Require_dataGridView3";
            this.Require_dataGridView3.Size = new System.Drawing.Size(570, 231);
            this.Require_dataGridView3.TabIndex = 2;
            // 
            // Ingredient_groupBox
            // 
            this.Ingredient_groupBox.Controls.Add(this.Unit_label);
            this.Ingredient_groupBox.Controls.Add(this.button_addIngredient);
            this.Ingredient_groupBox.Controls.Add(this.Ingredient_label);
            this.Ingredient_groupBox.Controls.Add(this.Recipe_label);
            this.Ingredient_groupBox.Controls.Add(this.quantity_textBox1);
            this.Ingredient_groupBox.Controls.Add(this.radioButton_Imperial);
            this.Ingredient_groupBox.Controls.Add(this.radioButton_Metic);
            this.Ingredient_groupBox.Controls.Add(this.label_AddQuantity);
            this.Ingredient_groupBox.Controls.Add(this.label_CurrentIngredients);
            this.Ingredient_groupBox.Controls.Add(this.label_CurrentRecipes);
            this.Ingredient_groupBox.Controls.Add(this.label_Ingredients);
            this.Ingredient_groupBox.Controls.Add(this.Ingredients_dataGridView2);
            this.Ingredient_groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Ingredient_groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.Ingredient_groupBox.Location = new System.Drawing.Point(3, 349);
            this.Ingredient_groupBox.Name = "Ingredient_groupBox";
            this.Ingredient_groupBox.Size = new System.Drawing.Size(1418, 307);
            this.Ingredient_groupBox.TabIndex = 1;
            this.Ingredient_groupBox.TabStop = false;
            this.Ingredient_groupBox.Text = "Ingredient";
            // 
            // Unit_label
            // 
            this.Unit_label.AutoSize = true;
            this.Unit_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.Unit_label.Location = new System.Drawing.Point(903, 234);
            this.Unit_label.Name = "Unit_label";
            this.Unit_label.Size = new System.Drawing.Size(187, 20);
            this.Unit_label.TabIndex = 12;
            this.Unit_label.Text = "[Choose Unit System]:";
            // 
            // button_addIngredient
            // 
            this.button_addIngredient.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.button_addIngredient.Location = new System.Drawing.Point(965, 191);
            this.button_addIngredient.Name = "button_addIngredient";
            this.button_addIngredient.Size = new System.Drawing.Size(130, 31);
            this.button_addIngredient.TabIndex = 11;
            this.button_addIngredient.Text = "Add to recipe";
            this.button_addIngredient.UseVisualStyleBackColor = true;
            // 
            // Ingredient_label
            // 
            this.Ingredient_label.AutoSize = true;
            this.Ingredient_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Ingredient_label.Location = new System.Drawing.Point(933, 127);
            this.Ingredient_label.Name = "Ingredient_label";
            this.Ingredient_label.Size = new System.Drawing.Size(193, 20);
            this.Ingredient_label.TabIndex = 10;
            this.Ingredient_label.Text = "Not choose any ingredient";
            // 
            // Recipe_label
            // 
            this.Recipe_label.AutoSize = true;
            this.Recipe_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.Recipe_label.Location = new System.Drawing.Point(933, 64);
            this.Recipe_label.Name = "Recipe_label";
            this.Recipe_label.Size = new System.Drawing.Size(166, 20);
            this.Recipe_label.TabIndex = 9;
            this.Recipe_label.Text = "Not choose any recipe";
            // 
            // quantity_textBox1
            // 
            this.quantity_textBox1.Location = new System.Drawing.Point(1049, 151);
            this.quantity_textBox1.Name = "quantity_textBox1";
            this.quantity_textBox1.Size = new System.Drawing.Size(100, 32);
            this.quantity_textBox1.TabIndex = 8;
            // 
            // radioButton_Imperial
            // 
            this.radioButton_Imperial.AutoSize = true;
            this.radioButton_Imperial.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Imperial.Location = new System.Drawing.Point(1036, 262);
            this.radioButton_Imperial.Name = "radioButton_Imperial";
            this.radioButton_Imperial.Size = new System.Drawing.Size(91, 24);
            this.radioButton_Imperial.TabIndex = 7;
            this.radioButton_Imperial.TabStop = true;
            this.radioButton_Imperial.Text = "Imperial";
            this.radioButton_Imperial.UseVisualStyleBackColor = true;
            // 
            // radioButton_Metic
            // 
            this.radioButton_Metic.AutoSize = true;
            this.radioButton_Metic.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_Metic.Location = new System.Drawing.Point(922, 262);
            this.radioButton_Metic.Name = "radioButton_Metic";
            this.radioButton_Metic.Size = new System.Drawing.Size(70, 24);
            this.radioButton_Metic.TabIndex = 6;
            this.radioButton_Metic.TabStop = true;
            this.radioButton_Metic.Text = "Metic";
            this.radioButton_Metic.UseVisualStyleBackColor = true;
            // 
            // label_AddQuantity
            // 
            this.label_AddQuantity.AutoSize = true;
            this.label_AddQuantity.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_AddQuantity.Location = new System.Drawing.Point(903, 159);
            this.label_AddQuantity.Name = "label_AddQuantity";
            this.label_AddQuantity.Size = new System.Drawing.Size(147, 20);
            this.label_AddQuantity.TabIndex = 5;
            this.label_AddQuantity.Text = "[Quantity to add]:";
            // 
            // label_CurrentIngredients
            // 
            this.label_CurrentIngredients.AutoSize = true;
            this.label_CurrentIngredients.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CurrentIngredients.Location = new System.Drawing.Point(903, 100);
            this.label_CurrentIngredients.Name = "label_CurrentIngredients";
            this.label_CurrentIngredients.Size = new System.Drawing.Size(180, 20);
            this.label_CurrentIngredients.TabIndex = 4;
            this.label_CurrentIngredients.Text = "[Current Ingredients]:";
            // 
            // label_CurrentRecipes
            // 
            this.label_CurrentRecipes.AutoSize = true;
            this.label_CurrentRecipes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_CurrentRecipes.Location = new System.Drawing.Point(903, 39);
            this.label_CurrentRecipes.Name = "label_CurrentRecipes";
            this.label_CurrentRecipes.Size = new System.Drawing.Size(154, 20);
            this.label_CurrentRecipes.TabIndex = 3;
            this.label_CurrentRecipes.Text = "[Current Recipes]:";
            // 
            // label_Ingredients
            // 
            this.label_Ingredients.AutoSize = true;
            this.label_Ingredients.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Ingredients.Location = new System.Drawing.Point(16, 39);
            this.label_Ingredients.Name = "label_Ingredients";
            this.label_Ingredients.Size = new System.Drawing.Size(115, 20);
            this.label_Ingredients.TabIndex = 2;
            this.label_Ingredients.Text = "[Ingredients]:";
            // 
            // Ingredients_dataGridView2
            // 
            this.Ingredients_dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Ingredients_dataGridView2.Location = new System.Drawing.Point(19, 64);
            this.Ingredients_dataGridView2.Name = "Ingredients_dataGridView2";
            this.Ingredients_dataGridView2.Size = new System.Drawing.Size(854, 231);
            this.Ingredients_dataGridView2.TabIndex = 1;
            // 
            // Recipes_dataGridView1
            // 
            this.Recipes_dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Recipes_dataGridView1.Location = new System.Drawing.Point(19, 61);
            this.Recipes_dataGridView1.Name = "Recipes_dataGridView1";
            this.Recipes_dataGridView1.Size = new System.Drawing.Size(250, 231);
            this.Recipes_dataGridView1.TabIndex = 0;
            // 
            // Recipes_groupBox
            // 
            this.Recipes_groupBox.Controls.Add(this.button_printMe);
            this.Recipes_groupBox.Controls.Add(this.energy_label);
            this.Recipes_groupBox.Controls.Add(this.cost_label);
            this.Recipes_groupBox.Controls.Add(this.button_Change_Instrcution);
            this.Recipes_groupBox.Controls.Add(this.button_Remove_RequiredItem);
            this.Recipes_groupBox.Controls.Add(this.button_Remove_Recipe);
            this.Recipes_groupBox.Controls.Add(this.button_Add_Recipe);
            this.Recipes_groupBox.Controls.Add(this.label_Instruction);
            this.Recipes_groupBox.Controls.Add(this.label_Required);
            this.Recipes_groupBox.Controls.Add(this.label_Recipes);
            this.Recipes_groupBox.Controls.Add(this.label_Energy);
            this.Recipes_groupBox.Controls.Add(this.label_Cost);
            this.Recipes_groupBox.Controls.Add(this.Instructions_richTextBox1);
            this.Recipes_groupBox.Controls.Add(this.Require_dataGridView3);
            this.Recipes_groupBox.Controls.Add(this.Recipes_dataGridView1);
            this.Recipes_groupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Recipes_groupBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold);
            this.Recipes_groupBox.Location = new System.Drawing.Point(3, 3);
            this.Recipes_groupBox.Name = "Recipes_groupBox";
            this.Recipes_groupBox.Size = new System.Drawing.Size(1418, 340);
            this.Recipes_groupBox.TabIndex = 0;
            this.Recipes_groupBox.TabStop = false;
            this.Recipes_groupBox.Text = "Recipes";
            // 
            // button_printMe
            // 
            this.button_printMe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.button_printMe.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button_printMe.Location = new System.Drawing.Point(1110, 297);
            this.button_printMe.Name = "button_printMe";
            this.button_printMe.Size = new System.Drawing.Size(98, 33);
            this.button_printMe.TabIndex = 15;
            this.button_printMe.Text = "Print Me";
            this.button_printMe.UseVisualStyleBackColor = true;
            // 
            // energy_label
            // 
            this.energy_label.AutoSize = true;
            this.energy_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.energy_label.Location = new System.Drawing.Point(1113, 211);
            this.energy_label.Name = "energy_label";
            this.energy_label.Size = new System.Drawing.Size(70, 20);
            this.energy_label.TabIndex = 14;
            this.energy_label.Text = "No value";
            // 
            // cost_label
            // 
            this.cost_label.AutoSize = true;
            this.cost_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cost_label.Location = new System.Drawing.Point(1113, 148);
            this.cost_label.Name = "cost_label";
            this.cost_label.Size = new System.Drawing.Size(70, 20);
            this.cost_label.TabIndex = 13;
            this.cost_label.Text = "No value";
            // 
            // button_Change_Instrcution
            // 
            this.button_Change_Instrcution.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Change_Instrcution.Location = new System.Drawing.Point(937, 297);
            this.button_Change_Instrcution.Name = "button_Change_Instrcution";
            this.button_Change_Instrcution.Size = new System.Drawing.Size(117, 33);
            this.button_Change_Instrcution.TabIndex = 12;
            this.button_Change_Instrcution.Text = "Change";
            this.button_Change_Instrcution.UseVisualStyleBackColor = true;
            // 
            // button_Remove_RequiredItem
            // 
            this.button_Remove_RequiredItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Remove_RequiredItem.Location = new System.Drawing.Point(510, 297);
            this.button_Remove_RequiredItem.Name = "button_Remove_RequiredItem";
            this.button_Remove_RequiredItem.Size = new System.Drawing.Size(117, 33);
            this.button_Remove_RequiredItem.TabIndex = 11;
            this.button_Remove_RequiredItem.Text = "Remove";
            this.button_Remove_RequiredItem.UseVisualStyleBackColor = true;
            // 
            // button_Remove_Recipe
            // 
            this.button_Remove_Recipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Remove_Recipe.Location = new System.Drawing.Point(152, 297);
            this.button_Remove_Recipe.Name = "button_Remove_Recipe";
            this.button_Remove_Recipe.Size = new System.Drawing.Size(117, 33);
            this.button_Remove_Recipe.TabIndex = 10;
            this.button_Remove_Recipe.Text = "Remove";
            this.button_Remove_Recipe.UseVisualStyleBackColor = true;
            // 
            // button_Add_Recipe
            // 
            this.button_Add_Recipe.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_Add_Recipe.Location = new System.Drawing.Point(19, 297);
            this.button_Add_Recipe.Name = "button_Add_Recipe";
            this.button_Add_Recipe.Size = new System.Drawing.Size(117, 33);
            this.button_Add_Recipe.TabIndex = 9;
            this.button_Add_Recipe.Text = "Add";
            this.button_Add_Recipe.UseVisualStyleBackColor = true;
            // 
            // label_Instruction
            // 
            this.label_Instruction.AutoSize = true;
            this.label_Instruction.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Instruction.Location = new System.Drawing.Point(851, 33);
            this.label_Instruction.Name = "label_Instruction";
            this.label_Instruction.Size = new System.Drawing.Size(110, 20);
            this.label_Instruction.TabIndex = 8;
            this.label_Instruction.Text = "[Instruction]:";
            // 
            // label_Required
            // 
            this.label_Required.AutoSize = true;
            this.label_Required.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Required.Location = new System.Drawing.Point(275, 33);
            this.label_Required.Name = "label_Required";
            this.label_Required.Size = new System.Drawing.Size(147, 20);
            this.label_Required.TabIndex = 7;
            this.label_Required.Text = "[Required Items]:";
            // 
            // label_Recipes
            // 
            this.label_Recipes.AutoSize = true;
            this.label_Recipes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Recipes.Location = new System.Drawing.Point(15, 33);
            this.label_Recipes.Name = "label_Recipes";
            this.label_Recipes.Size = new System.Drawing.Size(89, 20);
            this.label_Recipes.TabIndex = 6;
            this.label_Recipes.Text = "[Recipes]:";
            // 
            // label_Energy
            // 
            this.label_Energy.AutoSize = true;
            this.label_Energy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Energy.Location = new System.Drawing.Point(1113, 184);
            this.label_Energy.Name = "label_Energy";
            this.label_Energy.Size = new System.Drawing.Size(70, 20);
            this.label_Energy.TabIndex = 5;
            this.label_Energy.Text = "Energy:";
            // 
            // label_Cost
            // 
            this.label_Cost.AutoSize = true;
            this.label_Cost.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Cost.Location = new System.Drawing.Point(1113, 130);
            this.label_Cost.Name = "label_Cost";
            this.label_Cost.Size = new System.Drawing.Size(51, 20);
            this.label_Cost.TabIndex = 4;
            this.label_Cost.Text = "Cost:";
            // 
            // Instructions_richTextBox1
            // 
            this.Instructions_richTextBox1.Location = new System.Drawing.Point(855, 61);
            this.Instructions_richTextBox1.Name = "Instructions_richTextBox1";
            this.Instructions_richTextBox1.Size = new System.Drawing.Size(252, 231);
            this.Instructions_richTextBox1.TabIndex = 3;
            this.Instructions_richTextBox1.Text = "";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.Recipes_groupBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.Ingredient_groupBox, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 52.55172F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.44828F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1424, 659);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 659);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "(Assignment_One)My Recipes";
            ((System.ComponentModel.ISupportInitialize)(this.Require_dataGridView3)).EndInit();
            this.Ingredient_groupBox.ResumeLayout(false);
            this.Ingredient_groupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Ingredients_dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Recipes_dataGridView1)).EndInit();
            this.Recipes_groupBox.ResumeLayout(false);
            this.Recipes_groupBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog Recipe_openFileDialog1;
        private System.Windows.Forms.DataGridView Require_dataGridView3;
        private System.Windows.Forms.GroupBox Ingredient_groupBox;
        private System.Windows.Forms.Label Unit_label;
        private System.Windows.Forms.Button button_addIngredient;
        private System.Windows.Forms.Label Ingredient_label;
        private System.Windows.Forms.Label Recipe_label;
        private System.Windows.Forms.TextBox quantity_textBox1;
        private System.Windows.Forms.RadioButton radioButton_Imperial;
        private System.Windows.Forms.RadioButton radioButton_Metic;
        private System.Windows.Forms.Label label_AddQuantity;
        private System.Windows.Forms.Label label_CurrentIngredients;
        private System.Windows.Forms.Label label_CurrentRecipes;
        private System.Windows.Forms.Label label_Ingredients;
        private System.Windows.Forms.DataGridView Ingredients_dataGridView2;
        private System.Windows.Forms.DataGridView Recipes_dataGridView1;
        private System.Windows.Forms.GroupBox Recipes_groupBox;
        private System.Windows.Forms.Button button_printMe;
        private System.Windows.Forms.Label energy_label;
        private System.Windows.Forms.Label cost_label;
        private System.Windows.Forms.Button button_Change_Instrcution;
        private System.Windows.Forms.Button button_Remove_RequiredItem;
        private System.Windows.Forms.Button button_Remove_Recipe;
        private System.Windows.Forms.Button button_Add_Recipe;
        private System.Windows.Forms.Label label_Instruction;
        private System.Windows.Forms.Label label_Required;
        private System.Windows.Forms.Label label_Recipes;
        private System.Windows.Forms.Label label_Energy;
        private System.Windows.Forms.Label label_Cost;
        private System.Windows.Forms.RichTextBox Instructions_richTextBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}

