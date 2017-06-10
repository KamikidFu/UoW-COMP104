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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1_ReadFile = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.button2_Analyse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(25, 11);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(301, 21);
            this.textBox1.TabIndex = 0;
            // 
            // button1_ReadFile
            // 
            this.button1_ReadFile.Location = new System.Drawing.Point(332, 9);
            this.button1_ReadFile.Name = "button1_ReadFile";
            this.button1_ReadFile.Size = new System.Drawing.Size(75, 21);
            this.button1_ReadFile.TabIndex = 1;
            this.button1_ReadFile.Text = "Read Files";
            this.button1_ReadFile.UseVisualStyleBackColor = true;
            this.button1_ReadFile.Click += new System.EventHandler(this.button1_ReadFile_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 14;
            this.listBox1.Location = new System.Drawing.Point(25, 63);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(382, 228);
            this.listBox1.TabIndex = 2;
            // 
            // button2_Analyse
            // 
            this.button2_Analyse.Location = new System.Drawing.Point(332, 36);
            this.button2_Analyse.Name = "button2_Analyse";
            this.button2_Analyse.Size = new System.Drawing.Size(75, 21);
            this.button2_Analyse.TabIndex = 3;
            this.button2_Analyse.Text = "Analyse";
            this.button2_Analyse.UseVisualStyleBackColor = true;
            this.button2_Analyse.Click += new System.EventHandler(this.button2_Analyse_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 305);
            this.Controls.Add(this.button2_Analyse);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1_ReadFile);
            this.Controls.Add(this.textBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1_ReadFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button2_Analyse;
    }
}

