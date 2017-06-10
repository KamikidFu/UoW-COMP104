namespace Assignment_1
{
    partial class Assignment_1
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Recipes_dataGridView = new System.Windows.Forms.DataGridView();
            this.Ingredients_dataGridView = new System.Windows.Forms.DataGridView();
            this.Require_dataGridView = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Instruction_richTextBox = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Recipes_dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ingredients_dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Require_dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.9568F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.0432F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 240F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 232F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.Recipes_dataGridView, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.Ingredients_dataGridView, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.Require_dataGridView, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.button1, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.Instruction_richTextBox, 3, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.72791F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.27209F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 57F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1104, 400);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 64);
            this.label1.TabIndex = 0;
            this.label1.Text = "Recipes:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(255, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(373, 64);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ingredients:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(634, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(234, 64);
            this.label3.TabIndex = 2;
            this.label3.Text = "Require:";
            // 
            // Recipes_dataGridView
            // 
            this.Recipes_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Recipes_dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Recipes_dataGridView.Location = new System.Drawing.Point(3, 67);
            this.Recipes_dataGridView.Name = "Recipes_dataGridView";
            this.Recipes_dataGridView.Size = new System.Drawing.Size(246, 272);
            this.Recipes_dataGridView.TabIndex = 3;
            this.Recipes_dataGridView.SelectionChanged += new System.EventHandler(this.Recipes_dataGridView_SelectionChanged);
            // 
            // Ingredients_dataGridView
            // 
            this.Ingredients_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Ingredients_dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Ingredients_dataGridView.Location = new System.Drawing.Point(255, 67);
            this.Ingredients_dataGridView.Name = "Ingredients_dataGridView";
            this.Ingredients_dataGridView.Size = new System.Drawing.Size(373, 272);
            this.Ingredients_dataGridView.TabIndex = 4;
            // 
            // Require_dataGridView
            // 
            this.Require_dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Require_dataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Require_dataGridView.Location = new System.Drawing.Point(634, 67);
            this.Require_dataGridView.Name = "Require_dataGridView";
            this.Require_dataGridView.Size = new System.Drawing.Size(234, 272);
            this.Require_dataGridView.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 345);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(874, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(204, 41);
            this.label4.TabIndex = 7;
            this.label4.Text = "Instruction:";
            // 
            // Instruction_richTextBox
            // 
            this.Instruction_richTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Instruction_richTextBox.Location = new System.Drawing.Point(874, 67);
            this.Instruction_richTextBox.Name = "Instruction_richTextBox";
            this.Instruction_richTextBox.Size = new System.Drawing.Size(227, 272);
            this.Instruction_richTextBox.TabIndex = 8;
            this.Instruction_richTextBox.Text = "";
            // 
            // Assignment_1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 400);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Assignment_1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Recipes_dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Ingredients_dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Require_dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView Recipes_dataGridView;
        private System.Windows.Forms.DataGridView Ingredients_dataGridView;
        private System.Windows.Forms.DataGridView Require_dataGridView;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RichTextBox Instruction_richTextBox;
    }
}

