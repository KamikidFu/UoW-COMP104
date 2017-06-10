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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Recipes_dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Ingredients_dataGridView2 = new System.Windows.Forms.DataGridView();
            this.Require_dataGridView3 = new System.Windows.Forms.DataGridView();
            this.Instructions_richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.yieldDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.instructionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.recipeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.defaultQuantityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.energyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.unitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ingredientBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Recipes_dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ingredients_dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Require_dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 569F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 41.98347F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 58.01653F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.Recipes_dataGridView1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Ingredients_dataGridView2, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Require_dataGridView3, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.Instructions_richTextBox1, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.button2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.button3, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.button4, 3, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1424, 542);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(244, 81);
            this.label1.TabIndex = 0;
            this.label1.Text = "Recipes:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(253, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(563, 81);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ingredients:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(822, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(247, 81);
            this.label3.TabIndex = 2;
            this.label3.Text = "Require:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(1075, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(346, 81);
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
            this.Recipes_dataGridView1.Location = new System.Drawing.Point(3, 84);
            this.Recipes_dataGridView1.Name = "Recipes_dataGridView1";
            this.Recipes_dataGridView1.RowTemplate.Height = 23;
            this.Recipes_dataGridView1.Size = new System.Drawing.Size(244, 405);
            this.Recipes_dataGridView1.TabIndex = 4;
            this.Recipes_dataGridView1.SelectionChanged += new System.EventHandler(this.Recipes_dataGridView1_SelectionChanged);
            this.Recipes_dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Recipes_dataGridView1_KeyDown);
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
            this.Ingredients_dataGridView2.Location = new System.Drawing.Point(253, 84);
            this.Ingredients_dataGridView2.Name = "Ingredients_dataGridView2";
            this.Ingredients_dataGridView2.RowTemplate.Height = 23;
            this.Ingredients_dataGridView2.Size = new System.Drawing.Size(563, 405);
            this.Ingredients_dataGridView2.TabIndex = 5;
            // 
            // Require_dataGridView3
            // 
            this.Require_dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Require_dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Require_dataGridView3.Location = new System.Drawing.Point(822, 84);
            this.Require_dataGridView3.Name = "Require_dataGridView3";
            this.Require_dataGridView3.RowTemplate.Height = 23;
            this.Require_dataGridView3.Size = new System.Drawing.Size(247, 405);
            this.Require_dataGridView3.TabIndex = 6;
            // 
            // Instructions_richTextBox1
            // 
            this.Instructions_richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Instructions_richTextBox1.Location = new System.Drawing.Point(1075, 84);
            this.Instructions_richTextBox1.Name = "Instructions_richTextBox1";
            this.Instructions_richTextBox1.Size = new System.Drawing.Size(346, 405);
            this.Instructions_richTextBox1.TabIndex = 7;
            this.Instructions_richTextBox1.Text = "";
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Location = new System.Drawing.Point(3, 495);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(244, 44);
            this.button1.TabIndex = 8;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button2.Location = new System.Drawing.Point(253, 495);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(563, 44);
            this.button2.TabIndex = 9;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button3.Location = new System.Drawing.Point(822, 495);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(247, 44);
            this.button3.TabIndex = 10;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button4.Location = new System.Drawing.Point(1075, 495);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(346, 44);
            this.button4.TabIndex = 11;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 542);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "(Assignment_One)My Recipes";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Recipes_dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ingredients_dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Require_dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.recipeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ingredientBindingSource)).EndInit();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
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
    }
}

