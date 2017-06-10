namespace Task3
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
            this.textBox1_Parameter = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1_Output = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // textBox1_Parameter
            // 
            this.textBox1_Parameter.Location = new System.Drawing.Point(83, 12);
            this.textBox1_Parameter.Name = "textBox1_Parameter";
            this.textBox1_Parameter.Size = new System.Drawing.Size(100, 21);
            this.textBox1_Parameter.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "Parameter:";
            // 
            // button1_Output
            // 
            this.button1_Output.Location = new System.Drawing.Point(189, 10);
            this.button1_Output.Name = "button1_Output";
            this.button1_Output.Size = new System.Drawing.Size(75, 23);
            this.button1_Output.TabIndex = 2;
            this.button1_Output.Text = "Output";
            this.button1_Output.UseVisualStyleBackColor = true;
            this.button1_Output.Click += new System.EventHandler(this.button1_Output_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(14, 39);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(1206, 304);
            this.listBox1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1232, 374);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1_Output);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1_Parameter);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1_Parameter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1_Output;
        private System.Windows.Forms.ListBox listBox1;
    }
}

