namespace Task2
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
            this.listBox1_Show = new System.Windows.Forms.ListBox();
            this.button1_newStudent = new System.Windows.Forms.Button();
            this.textBox1_ID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2_Name = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBox1_Show
            // 
            this.listBox1_Show.FormattingEnabled = true;
            this.listBox1_Show.ItemHeight = 12;
            this.listBox1_Show.Location = new System.Drawing.Point(12, 12);
            this.listBox1_Show.Name = "listBox1_Show";
            this.listBox1_Show.Size = new System.Drawing.Size(467, 316);
            this.listBox1_Show.TabIndex = 0;
            // 
            // button1_newStudent
            // 
            this.button1_newStudent.Location = new System.Drawing.Point(295, 334);
            this.button1_newStudent.Name = "button1_newStudent";
            this.button1_newStudent.Size = new System.Drawing.Size(94, 23);
            this.button1_newStudent.TabIndex = 1;
            this.button1_newStudent.Text = "New Student";
            this.button1_newStudent.UseVisualStyleBackColor = true;
            this.button1_newStudent.Click += new System.EventHandler(this.button1_newStudent_Click);
            // 
            // textBox1_ID
            // 
            this.textBox1_ID.Location = new System.Drawing.Point(42, 336);
            this.textBox1_ID.Name = "textBox1_ID";
            this.textBox1_ID.Size = new System.Drawing.Size(100, 21);
            this.textBox1_ID.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 339);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(148, 339);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "Name:";
            // 
            // textBox2_Name
            // 
            this.textBox2_Name.Location = new System.Drawing.Point(189, 336);
            this.textBox2_Name.Name = "textBox2_Name";
            this.textBox2_Name.Size = new System.Drawing.Size(100, 21);
            this.textBox2_Name.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 400);
            this.Controls.Add(this.textBox2_Name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1_ID);
            this.Controls.Add(this.button1_newStudent);
            this.Controls.Add(this.listBox1_Show);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1_Show;
        private System.Windows.Forms.Button button1_newStudent;
        private System.Windows.Forms.TextBox textBox1_ID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2_Name;
    }
}

