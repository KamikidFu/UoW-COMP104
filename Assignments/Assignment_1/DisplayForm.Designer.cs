namespace Assignment_Framework_with_Classes
{
    partial class DisplayForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.yield_textBox1 = new System.Windows.Forms.TextBox();
            this.update_button1 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.richTextBox1);
            this.groupBox1.Controls.Add(this.update_button1);
            this.groupBox1.Controls.Add(this.yield_textBox1);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(304, 328);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Your Recipe";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Yield:";
            // 
            // yield_textBox1
            // 
            this.yield_textBox1.Location = new System.Drawing.Point(53, 14);
            this.yield_textBox1.Name = "yield_textBox1";
            this.yield_textBox1.Size = new System.Drawing.Size(32, 21);
            this.yield_textBox1.TabIndex = 1;
            // 
            // update_button1
            // 
            this.update_button1.Location = new System.Drawing.Point(91, 12);
            this.update_button1.Name = "update_button1";
            this.update_button1.Size = new System.Drawing.Size(91, 23);
            this.update_button1.TabIndex = 2;
            this.update_button1.Text = "Update Recipe";
            this.update_button1.UseVisualStyleBackColor = true;
            this.update_button1.Click += new System.EventHandler(this.update_button1_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(6, 41);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(292, 281);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // DisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 352);
            this.Controls.Add(this.groupBox1);
            this.Name = "DisplayForm";
            this.Text = "DisplayForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button update_button1;
        private System.Windows.Forms.TextBox yield_textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}