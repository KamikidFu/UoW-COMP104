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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.letterHeight_textBox1 = new System.Windows.Forms.TextBox();
            this.letterLength_textBox2 = new System.Windows.Forms.TextBox();
            this.parcelHeight_textBox3 = new System.Windows.Forms.TextBox();
            this.parcelLength_textBox4 = new System.Windows.Forms.TextBox();
            this.parcelThickness_textBox5 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.parcelWeight_textBox6 = new System.Windows.Forms.TextBox();
            this.letterUrgent_checkBox1 = new System.Windows.Forms.CheckBox();
            this.parcelUrgent_checkBox2 = new System.Windows.Forms.CheckBox();
            this.button1_addLetter = new System.Windows.Forms.Button();
            this.button2_addParcel = new System.Windows.Forms.Button();
            this.listBox1_letter = new System.Windows.Forms.ListBox();
            this.listBox2_parcel = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox1_letter);
            this.groupBox1.Controls.Add(this.button1_addLetter);
            this.groupBox1.Controls.Add(this.letterUrgent_checkBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.letterLength_textBox2);
            this.groupBox1.Controls.Add(this.letterHeight_textBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 174);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Letters";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBox2_parcel);
            this.groupBox2.Controls.Add(this.button2_addParcel);
            this.groupBox2.Controls.Add(this.parcelUrgent_checkBox2);
            this.groupBox2.Controls.Add(this.parcelWeight_textBox6);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.parcelThickness_textBox5);
            this.groupBox2.Controls.Add(this.parcelLength_textBox4);
            this.groupBox2.Controls.Add(this.parcelHeight_textBox3);
            this.groupBox2.Location = new System.Drawing.Point(12, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(442, 196);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parcels";
            // 
            // letterHeight_textBox1
            // 
            this.letterHeight_textBox1.Location = new System.Drawing.Point(62, 20);
            this.letterHeight_textBox1.Name = "letterHeight_textBox1";
            this.letterHeight_textBox1.Size = new System.Drawing.Size(100, 21);
            this.letterHeight_textBox1.TabIndex = 0;
            // 
            // letterLength_textBox2
            // 
            this.letterLength_textBox2.Location = new System.Drawing.Point(221, 20);
            this.letterLength_textBox2.Name = "letterLength_textBox2";
            this.letterLength_textBox2.Size = new System.Drawing.Size(100, 21);
            this.letterLength_textBox2.TabIndex = 1;
            // 
            // parcelHeight_textBox3
            // 
            this.parcelHeight_textBox3.Location = new System.Drawing.Point(17, 41);
            this.parcelHeight_textBox3.Name = "parcelHeight_textBox3";
            this.parcelHeight_textBox3.Size = new System.Drawing.Size(59, 21);
            this.parcelHeight_textBox3.TabIndex = 0;
            // 
            // parcelLength_textBox4
            // 
            this.parcelLength_textBox4.Location = new System.Drawing.Point(98, 41);
            this.parcelLength_textBox4.Name = "parcelLength_textBox4";
            this.parcelLength_textBox4.Size = new System.Drawing.Size(61, 21);
            this.parcelLength_textBox4.TabIndex = 1;
            // 
            // parcelThickness_textBox5
            // 
            this.parcelThickness_textBox5.Location = new System.Drawing.Point(184, 41);
            this.parcelThickness_textBox5.Name = "parcelThickness_textBox5";
            this.parcelThickness_textBox5.Size = new System.Drawing.Size(55, 21);
            this.parcelThickness_textBox5.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "Height:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Length:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 12);
            this.label3.TabIndex = 3;
            this.label3.Text = "Height:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 12);
            this.label4.TabIndex = 4;
            this.label4.Text = "Length:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(182, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 5;
            this.label5.Text = "Thickness:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(260, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 12);
            this.label6.TabIndex = 6;
            this.label6.Text = "Weight:";
            // 
            // parcelWeight_textBox6
            // 
            this.parcelWeight_textBox6.Location = new System.Drawing.Point(262, 41);
            this.parcelWeight_textBox6.Name = "parcelWeight_textBox6";
            this.parcelWeight_textBox6.Size = new System.Drawing.Size(59, 21);
            this.parcelWeight_textBox6.TabIndex = 7;
            // 
            // letterUrgent_checkBox1
            // 
            this.letterUrgent_checkBox1.AutoSize = true;
            this.letterUrgent_checkBox1.Location = new System.Drawing.Point(327, 25);
            this.letterUrgent_checkBox1.Name = "letterUrgent_checkBox1";
            this.letterUrgent_checkBox1.Size = new System.Drawing.Size(60, 16);
            this.letterUrgent_checkBox1.TabIndex = 4;
            this.letterUrgent_checkBox1.Text = "Urgent";
            this.letterUrgent_checkBox1.UseVisualStyleBackColor = true;
            // 
            // parcelUrgent_checkBox2
            // 
            this.parcelUrgent_checkBox2.AutoSize = true;
            this.parcelUrgent_checkBox2.Location = new System.Drawing.Point(327, 43);
            this.parcelUrgent_checkBox2.Name = "parcelUrgent_checkBox2";
            this.parcelUrgent_checkBox2.Size = new System.Drawing.Size(60, 16);
            this.parcelUrgent_checkBox2.TabIndex = 8;
            this.parcelUrgent_checkBox2.Text = "Urgent";
            this.parcelUrgent_checkBox2.UseVisualStyleBackColor = true;
            // 
            // button1_addLetter
            // 
            this.button1_addLetter.Location = new System.Drawing.Point(381, 20);
            this.button1_addLetter.Name = "button1_addLetter";
            this.button1_addLetter.Size = new System.Drawing.Size(41, 23);
            this.button1_addLetter.TabIndex = 5;
            this.button1_addLetter.Text = "Add";
            this.button1_addLetter.UseVisualStyleBackColor = true;
            this.button1_addLetter.Click += new System.EventHandler(this.button1_addLetter_Click);
            // 
            // button2_addParcel
            // 
            this.button2_addParcel.Location = new System.Drawing.Point(381, 39);
            this.button2_addParcel.Name = "button2_addParcel";
            this.button2_addParcel.Size = new System.Drawing.Size(41, 23);
            this.button2_addParcel.TabIndex = 9;
            this.button2_addParcel.Text = "Add";
            this.button2_addParcel.UseVisualStyleBackColor = true;
            this.button2_addParcel.Click += new System.EventHandler(this.button2_addParcel_Click);
            // 
            // listBox1_letter
            // 
            this.listBox1_letter.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1_letter.FormattingEnabled = true;
            this.listBox1_letter.ItemHeight = 14;
            this.listBox1_letter.Location = new System.Drawing.Point(17, 47);
            this.listBox1_letter.Name = "listBox1_letter";
            this.listBox1_letter.Size = new System.Drawing.Size(405, 116);
            this.listBox1_letter.TabIndex = 6;
            // 
            // listBox2_parcel
            // 
            this.listBox2_parcel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox2_parcel.FormattingEnabled = true;
            this.listBox2_parcel.ItemHeight = 14;
            this.listBox2_parcel.Location = new System.Drawing.Point(17, 68);
            this.listBox2_parcel.Name = "listBox2_parcel";
            this.listBox2_parcel.Size = new System.Drawing.Size(405, 116);
            this.listBox2_parcel.TabIndex = 10;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 400);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox listBox1_letter;
        private System.Windows.Forms.Button button1_addLetter;
        private System.Windows.Forms.CheckBox letterUrgent_checkBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox letterLength_textBox2;
        private System.Windows.Forms.TextBox letterHeight_textBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBox2_parcel;
        private System.Windows.Forms.Button button2_addParcel;
        private System.Windows.Forms.CheckBox parcelUrgent_checkBox2;
        private System.Windows.Forms.TextBox parcelWeight_textBox6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox parcelThickness_textBox5;
        private System.Windows.Forms.TextBox parcelLength_textBox4;
        private System.Windows.Forms.TextBox parcelHeight_textBox3;
    }
}

