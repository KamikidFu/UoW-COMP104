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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Recipes_dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yieldDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instructionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recipeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Ingredients_dataGridView2 = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.defaultQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.energyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ingredientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Require_dataGridView3 = new System.Windows.Forms.DataGridView();
            this.ingredientNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.quantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recipeItemsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Instructions_richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.cost_label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.energy_label8 = new System.Windows.Forms.Label();
            this.AddItem_button1 = new System.Windows.Forms.Button();
            this.quantity_textBox1 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.RemoveItem_button2 = new System.Windows.Forms.Button();
            this.ChangeInstruction_button3 = new System.Windows.Forms.Button();
            this.Read_button4 = new System.Windows.Forms.Button();
            this.Recipe_openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Recipes_dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ingredients_dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Require_dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeItemsBindingSource)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.Recipes_dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Ingredients_dataGridView2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Require_dataGridView3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.Instructions_richTextBox1, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.48352F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 83.51648F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1424, 500);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 82);
            this.label1.TabIndex = 0;
            this.label1.Text = "Recipes:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(259, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(563, 82);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ingredients:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(828, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(335, 82);
            this.label3.TabIndex = 2;
            this.label3.Text = "Require:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(1169, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(252, 82);
            this.label4.TabIndex = 3;
            this.label4.Text = "Instructions:";
            // 
            // Recipes_dataGridView1
            // 
            this.Recipes_dataGridView1.AutoGenerateColumns = false;
            this.Recipes_dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Recipes_dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.yieldDataGridViewTextBoxColumn,
            this.instructionDataGridViewTextBoxColumn});
            this.Recipes_dataGridView1.DataSource = this.recipeBindingSource;
            this.Recipes_dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Recipes_dataGridView1.Location = new System.Drawing.Point(3, 85);
            this.Recipes_dataGridView1.Name = "Recipes_dataGridView1";
            this.Recipes_dataGridView1.RowTemplate.Height = 23;
            this.Recipes_dataGridView1.Size = new System.Drawing.Size(250, 412);
            this.Recipes_dataGridView1.TabIndex = 4;
            this.Recipes_dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Recipes_dataGridView1_CellEndEdit);
            this.Recipes_dataGridView1.SelectionChanged += new System.EventHandler(this.Recipes_dataGridView1_SelectionChanged);
            this.Recipes_dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Recipes_dataGridView1_KeyDown);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // yieldDataGridViewTextBoxColumn
            // 
            this.yieldDataGridViewTextBoxColumn.DataPropertyName = "Yield";
            this.yieldDataGridViewTextBoxColumn.HeaderText = "Yield";
            this.yieldDataGridViewTextBoxColumn.Name = "yieldDataGridViewTextBoxColumn";
            // 
            // instructionDataGridViewTextBoxColumn
            // 
            this.instructionDataGridViewTextBoxColumn.DataPropertyName = "Instruction";
            this.instructionDataGridViewTextBoxColumn.HeaderText = "Instruction";
            this.instructionDataGridViewTextBoxColumn.Name = "instructionDataGridViewTextBoxColumn";
            // 
            // recipeBindingSource
            // 
            this.recipeBindingSource.DataSource = typeof(Assignment_Framework_with_Classes.Recipe);
            // 
            // Ingredients_dataGridView2
            // 
            this.Ingredients_dataGridView2.AutoGenerateColumns = false;
            this.Ingredients_dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Ingredients_dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn1,
            this.defaultQuantityDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.energyDataGridViewTextBoxColumn,
            this.unitDataGridViewTextBoxColumn});
            this.Ingredients_dataGridView2.DataSource = this.ingredientBindingSource;
            this.Ingredients_dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Ingredients_dataGridView2.Location = new System.Drawing.Point(259, 85);
            this.Ingredients_dataGridView2.Name = "Ingredients_dataGridView2";
            this.Ingredients_dataGridView2.RowTemplate.Height = 23;
            this.Ingredients_dataGridView2.Size = new System.Drawing.Size(563, 412);
            this.Ingredients_dataGridView2.TabIndex = 5;
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            // 
            // defaultQuantityDataGridViewTextBoxColumn
            // 
            this.defaultQuantityDataGridViewTextBoxColumn.DataPropertyName = "Default_Quantity";
            this.defaultQuantityDataGridViewTextBoxColumn.HeaderText = "Default_Quantity";
            this.defaultQuantityDataGridViewTextBoxColumn.Name = "defaultQuantityDataGridViewTextBoxColumn";
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            // 
            // energyDataGridViewTextBoxColumn
            // 
            this.energyDataGridViewTextBoxColumn.DataPropertyName = "Energy";
            this.energyDataGridViewTextBoxColumn.HeaderText = "Energy";
            this.energyDataGridViewTextBoxColumn.Name = "energyDataGridViewTextBoxColumn";
            // 
            // unitDataGridViewTextBoxColumn
            // 
            this.unitDataGridViewTextBoxColumn.DataPropertyName = "Unit";
            this.unitDataGridViewTextBoxColumn.HeaderText = "Unit";
            this.unitDataGridViewTextBoxColumn.Name = "unitDataGridViewTextBoxColumn";
            // 
            // ingredientBindingSource
            // 
            this.ingredientBindingSource.DataSource = typeof(Assignment_Framework_with_Classes.Ingredient);
            // 
            // Require_dataGridView3
            // 
            this.Require_dataGridView3.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.Require_dataGridView3.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.Require_dataGridView3.AutoGenerateColumns = false;
            this.Require_dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Require_dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ingredientNameDataGridViewTextBoxColumn,
            this.quantityDataGridViewTextBoxColumn,
            this.unitDataGridViewTextBoxColumn1});
            this.Require_dataGridView3.DataSource = this.recipeItemsBindingSource;
            this.Require_dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Require_dataGridView3.Location = new System.Drawing.Point(828, 85);
            this.Require_dataGridView3.Name = "Require_dataGridView3";
            this.Require_dataGridView3.RowTemplate.Height = 23;
            this.Require_dataGridView3.Size = new System.Drawing.Size(335, 412);
            this.Require_dataGridView3.TabIndex = 6;
            this.Require_dataGridView3.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Require_dataGridView3_CellEndEdit);
            this.Require_dataGridView3.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Require_dataGridView3_KeyDown);
            // 
            // ingredientNameDataGridViewTextBoxColumn
            // 
            this.ingredientNameDataGridViewTextBoxColumn.DataPropertyName = "IngredientName";
            this.ingredientNameDataGridViewTextBoxColumn.HeaderText = "IngredientName";
            this.ingredientNameDataGridViewTextBoxColumn.Name = "ingredientNameDataGridViewTextBoxColumn";
            // 
            // quantityDataGridViewTextBoxColumn
            // 
            this.quantityDataGridViewTextBoxColumn.DataPropertyName = "Quantity";
            this.quantityDataGridViewTextBoxColumn.HeaderText = "Quantity";
            this.quantityDataGridViewTextBoxColumn.Name = "quantityDataGridViewTextBoxColumn";
            // 
            // unitDataGridViewTextBoxColumn1
            // 
            this.unitDataGridViewTextBoxColumn1.DataPropertyName = "Unit";
            this.unitDataGridViewTextBoxColumn1.HeaderText = "Unit";
            this.unitDataGridViewTextBoxColumn1.Name = "unitDataGridViewTextBoxColumn1";
            // 
            // recipeItemsBindingSource
            // 
            this.recipeItemsBindingSource.DataSource = typeof(Assignment_Framework_with_Classes.RecipeItems);
            // 
            // Instructions_richTextBox1
            // 
            this.Instructions_richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Instructions_richTextBox1.Location = new System.Drawing.Point(1169, 85);
            this.Instructions_richTextBox1.Name = "Instructions_richTextBox1";
            this.Instructions_richTextBox1.Size = new System.Drawing.Size(252, 412);
            this.Instructions_richTextBox1.TabIndex = 7;
            this.Instructions_richTextBox1.Text = "";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 11;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.650727F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.724719F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.707865F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.407303F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.199438F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.738764F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.44382F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.567416F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.988764F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.828652F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28.58146F));
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cost_label6, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.energy_label8, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.AddItem_button1, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.quantity_textBox1, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.RemoveItem_button2, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.ChangeInstruction_button3, 8, 0);
            this.tableLayoutPanel2.Controls.Add(this.Read_button4, 9, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 506);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 3;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 44F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 48F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1424, 126);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 3);
            this.label5.Margin = new System.Windows.Forms.Padding(3);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 28);
            this.label5.TabIndex = 0;
            this.label5.Text = "Cost:";
            // 
            // cost_label6
            // 
            this.cost_label6.AutoSize = true;
            this.cost_label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cost_label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cost_label6.Location = new System.Drawing.Point(97, 0);
            this.cost_label6.Name = "cost_label6";
            this.cost_label6.Size = new System.Drawing.Size(104, 34);
            this.cost_label6.TabIndex = 1;
            this.cost_label6.Text = "...";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(207, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(118, 34);
            this.label7.TabIndex = 2;
            this.label7.Text = "Calories:";
            // 
            // energy_label8
            // 
            this.energy_label8.AutoSize = true;
            this.energy_label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.energy_label8.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.energy_label8.Location = new System.Drawing.Point(331, 0);
            this.energy_label8.Name = "energy_label8";
            this.energy_label8.Size = new System.Drawing.Size(71, 34);
            this.energy_label8.TabIndex = 3;
            this.energy_label8.Text = "...";
            // 
            // AddItem_button1
            // 
            this.AddItem_button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AddItem_button1.Location = new System.Drawing.Point(578, 3);
            this.AddItem_button1.Name = "AddItem_button1";
            this.AddItem_button1.Size = new System.Drawing.Size(100, 28);
            this.AddItem_button1.TabIndex = 4;
            this.AddItem_button1.Text = "Add Ingredient";
            this.AddItem_button1.UseVisualStyleBackColor = true;
            this.AddItem_button1.Click += new System.EventHandler(this.AddItem_button1_Click);
            // 
            // quantity_textBox1
            // 
            this.quantity_textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.quantity_textBox1.Location = new System.Drawing.Point(539, 3);
            this.quantity_textBox1.Name = "quantity_textBox1";
            this.quantity_textBox1.Size = new System.Drawing.Size(33, 21);
            this.quantity_textBox1.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Font = new System.Drawing.Font("Microsoft YaHei UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(408, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 34);
            this.label6.TabIndex = 6;
            this.label6.Text = "How many to add?";
            // 
            // RemoveItem_button2
            // 
            this.RemoveItem_button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RemoveItem_button2.Location = new System.Drawing.Point(684, 3);
            this.RemoveItem_button2.Name = "RemoveItem_button2";
            this.RemoveItem_button2.Size = new System.Drawing.Size(116, 28);
            this.RemoveItem_button2.TabIndex = 5;
            this.RemoveItem_button2.Text = "Remove Ingredient";
            this.RemoveItem_button2.UseVisualStyleBackColor = true;
            this.RemoveItem_button2.Click += new System.EventHandler(this.RemoveItem_button2_Click);
            // 
            // ChangeInstruction_button3
            // 
            this.ChangeInstruction_button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChangeInstruction_button3.Location = new System.Drawing.Point(806, 3);
            this.ChangeInstruction_button3.Name = "ChangeInstruction_button3";
            this.ChangeInstruction_button3.Size = new System.Drawing.Size(122, 28);
            this.ChangeInstruction_button3.TabIndex = 8;
            this.ChangeInstruction_button3.Text = "Change Instruction";
            this.ChangeInstruction_button3.UseVisualStyleBackColor = true;
            this.ChangeInstruction_button3.Click += new System.EventHandler(this.ChangeInstruction_button3_Click);
            // 
            // Read_button4
            // 
            this.Read_button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Read_button4.Location = new System.Drawing.Point(934, 3);
            this.Read_button4.Name = "Read_button4";
            this.Read_button4.Size = new System.Drawing.Size(77, 28);
            this.Read_button4.TabIndex = 9;
            this.Read_button4.Text = "Read Files";
            this.Read_button4.UseVisualStyleBackColor = true;
            this.Read_button4.Click += new System.EventHandler(this.Read_button4_Click);
            // 
            // Recipe_openFileDialog1
            // 
            this.Recipe_openFileDialog1.FileName = "Open New Recipe";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 632);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "(Assignment_One)My Recipes";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Recipes_dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ingredients_dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Require_dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeItemsBindingSource)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView Recipes_dataGridView1;
        private System.Windows.Forms.DataGridView Ingredients_dataGridView2;
        private System.Windows.Forms.DataGridView Require_dataGridView3;
        private System.Windows.Forms.RichTextBox Instructions_richTextBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn yieldDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn instructionDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource recipeBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn defaultQuantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource ingredientBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn energyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label cost_label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label energy_label8;
        private System.Windows.Forms.BindingSource recipeItemsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn unitDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn quantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ingredientNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button AddItem_button1;
        private System.Windows.Forms.Button RemoveItem_button2;
        private System.Windows.Forms.TextBox quantity_textBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button ChangeInstruction_button3;
        private System.Windows.Forms.Button Read_button4;
        private System.Windows.Forms.OpenFileDialog Recipe_openFileDialog1;
    }
}

