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
            this.LetterSearch_button = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.LetterSearch_textBox = new System.Windows.Forms.TextBox();
            this.LetterSender_textBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.listBox1_letter = new System.Windows.Forms.ListBox();
            this.button1_addLetter = new System.Windows.Forms.Button();
            this.letterUrgent_checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.letterLength_textBox2 = new System.Windows.Forms.TextBox();
            this.letterHeight_textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.PaecelSearch_button = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.PacelSearch_textBox = new System.Windows.Forms.TextBox();
            this.ParcelsSender_textBox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.listBox2_parcel = new System.Windows.Forms.ListBox();
            this.button2_addParcel = new System.Windows.Forms.Button();
            this.parcelUrgent_checkBox2 = new System.Windows.Forms.CheckBox();
            this.parcelWeight_textBox6 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.parcelThickness_textBox5 = new System.Windows.Forms.TextBox();
            this.parcelLength_textBox4 = new System.Windows.Forms.TextBox();
            this.parcelHeight_textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LetterSearch_button);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.LetterSearch_textBox);
            this.groupBox1.Controls.Add(this.LetterSender_textBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.listBox1_letter);
            this.groupBox1.Controls.Add(this.button1_addLetter);
            this.groupBox1.Controls.Add(this.letterUrgent_checkBox1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.letterLength_textBox2);
            this.groupBox1.Controls.Add(this.letterHeight_textBox1);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(442, 198);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Letters";
            // 
            // LetterSearch_button
            // 
            this.LetterSearch_button.Location = new System.Drawing.Point(395, 169);
            this.LetterSearch_button.Name = "LetterSearch_button";
            this.LetterSearch_button.Size = new System.Drawing.Size(41, 21);
            this.LetterSearch_button.TabIndex = 11;
            this.LetterSearch_button.Text = "GO";
            this.LetterSearch_button.UseVisualStyleBackColor = true;
            this.LetterSearch_button.Click += new System.EventHandler(this.LetterSearch_button_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(202, 173);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(81, 13);
            this.label9.TabIndex = 10;
            this.label9.Text = "Search Sender:";
            // 
            // LetterSearch_textBox
            // 
            this.LetterSearch_textBox.Location = new System.Drawing.Point(289, 170);
            this.LetterSearch_textBox.Name = "LetterSearch_textBox";
            this.LetterSearch_textBox.Size = new System.Drawing.Size(100, 20);
            this.LetterSearch_textBox.TabIndex = 9;
            // 
            // LetterSender_textBox
            // 
            this.LetterSender_textBox.Location = new System.Drawing.Point(95, 170);
            this.LetterSender_textBox.Name = "LetterSender_textBox";
            this.LetterSender_textBox.Size = new System.Drawing.Size(100, 20);
            this.LetterSender_textBox.TabIndex = 8;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(14, 173);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(75, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Sender Name:";
            // 
            // listBox1_letter
            // 
            this.listBox1_letter.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1_letter.FormattingEnabled = true;
            this.listBox1_letter.ItemHeight = 14;
            this.listBox1_letter.Location = new System.Drawing.Point(17, 51);
            this.listBox1_letter.Name = "listBox1_letter";
            this.listBox1_letter.Size = new System.Drawing.Size(405, 116);
            this.listBox1_letter.TabIndex = 6;
            // 
            // button1_addLetter
            // 
            this.button1_addLetter.Location = new System.Drawing.Point(381, 22);
            this.button1_addLetter.Name = "button1_addLetter";
            this.button1_addLetter.Size = new System.Drawing.Size(41, 25);
            this.button1_addLetter.TabIndex = 5;
            this.button1_addLetter.Text = "Add";
            this.button1_addLetter.UseVisualStyleBackColor = true;
            this.button1_addLetter.Click += new System.EventHandler(this.button1_addLetter_Click);
            // 
            // letterUrgent_checkBox1
            // 
            this.letterUrgent_checkBox1.AutoSize = true;
            this.letterUrgent_checkBox1.Location = new System.Drawing.Point(327, 27);
            this.letterUrgent_checkBox1.Name = "letterUrgent_checkBox1";
            this.letterUrgent_checkBox1.Size = new System.Drawing.Size(58, 17);
            this.letterUrgent_checkBox1.TabIndex = 4;
            this.letterUrgent_checkBox1.Text = "Urgent";
            this.letterUrgent_checkBox1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(168, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Length:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Height:";
            // 
            // letterLength_textBox2
            // 
            this.letterLength_textBox2.Location = new System.Drawing.Point(221, 22);
            this.letterLength_textBox2.Name = "letterLength_textBox2";
            this.letterLength_textBox2.Size = new System.Drawing.Size(100, 20);
            this.letterLength_textBox2.TabIndex = 1;
            // 
            // letterHeight_textBox1
            // 
            this.letterHeight_textBox1.Location = new System.Drawing.Point(62, 22);
            this.letterHeight_textBox1.Name = "letterHeight_textBox1";
            this.letterHeight_textBox1.Size = new System.Drawing.Size(100, 20);
            this.letterHeight_textBox1.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.PaecelSearch_button);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.PacelSearch_textBox);
            this.groupBox2.Controls.Add(this.ParcelsSender_textBox);
            this.groupBox2.Controls.Add(this.label8);
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
            this.groupBox2.Location = new System.Drawing.Point(12, 217);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(442, 225);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Parcels";
            // 
            // PaecelSearch_button
            // 
            this.PaecelSearch_button.Location = new System.Drawing.Point(395, 194);
            this.PaecelSearch_button.Name = "PaecelSearch_button";
            this.PaecelSearch_button.Size = new System.Drawing.Size(41, 23);
            this.PaecelSearch_button.TabIndex = 15;
            this.PaecelSearch_button.Text = "GO";
            this.PaecelSearch_button.UseVisualStyleBackColor = true;
            this.PaecelSearch_button.Click += new System.EventHandler(this.PaecelSearch_button_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(202, 199);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(81, 13);
            this.label10.TabIndex = 14;
            this.label10.Text = "Search Sender:";
            // 
            // PacelSearch_textBox
            // 
            this.PacelSearch_textBox.Location = new System.Drawing.Point(289, 196);
            this.PacelSearch_textBox.Name = "PacelSearch_textBox";
            this.PacelSearch_textBox.Size = new System.Drawing.Size(100, 20);
            this.PacelSearch_textBox.TabIndex = 13;
            // 
            // ParcelsSender_textBox
            // 
            this.ParcelsSender_textBox.Location = new System.Drawing.Point(95, 196);
            this.ParcelsSender_textBox.Name = "ParcelsSender_textBox";
            this.ParcelsSender_textBox.Size = new System.Drawing.Size(100, 20);
            this.ParcelsSender_textBox.TabIndex = 12;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(14, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Sender Name:";
            // 
            // listBox2_parcel
            // 
            this.listBox2_parcel.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox2_parcel.FormattingEnabled = true;
            this.listBox2_parcel.ItemHeight = 14;
            this.listBox2_parcel.Location = new System.Drawing.Point(17, 74);
            this.listBox2_parcel.Name = "listBox2_parcel";
            this.listBox2_parcel.Size = new System.Drawing.Size(405, 116);
            this.listBox2_parcel.TabIndex = 10;
            // 
            // button2_addParcel
            // 
            this.button2_addParcel.Location = new System.Drawing.Point(381, 42);
            this.button2_addParcel.Name = "button2_addParcel";
            this.button2_addParcel.Size = new System.Drawing.Size(41, 25);
            this.button2_addParcel.TabIndex = 9;
            this.button2_addParcel.Text = "Add";
            this.button2_addParcel.UseVisualStyleBackColor = true;
            this.button2_addParcel.Click += new System.EventHandler(this.button2_addParcel_Click);
            // 
            // parcelUrgent_checkBox2
            // 
            this.parcelUrgent_checkBox2.AutoSize = true;
            this.parcelUrgent_checkBox2.Location = new System.Drawing.Point(327, 47);
            this.parcelUrgent_checkBox2.Name = "parcelUrgent_checkBox2";
            this.parcelUrgent_checkBox2.Size = new System.Drawing.Size(58, 17);
            this.parcelUrgent_checkBox2.TabIndex = 8;
            this.parcelUrgent_checkBox2.Text = "Urgent";
            this.parcelUrgent_checkBox2.UseVisualStyleBackColor = true;
            // 
            // parcelWeight_textBox6
            // 
            this.parcelWeight_textBox6.Location = new System.Drawing.Point(262, 44);
            this.parcelWeight_textBox6.Name = "parcelWeight_textBox6";
            this.parcelWeight_textBox6.Size = new System.Drawing.Size(59, 20);
            this.parcelWeight_textBox6.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(260, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Weight:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(182, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(59, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Thickness:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(96, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Length:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Height:";
            // 
            // parcelThickness_textBox5
            // 
            this.parcelThickness_textBox5.Location = new System.Drawing.Point(184, 44);
            this.parcelThickness_textBox5.Name = "parcelThickness_textBox5";
            this.parcelThickness_textBox5.Size = new System.Drawing.Size(55, 20);
            this.parcelThickness_textBox5.TabIndex = 2;
            // 
            // parcelLength_textBox4
            // 
            this.parcelLength_textBox4.Location = new System.Drawing.Point(98, 44);
            this.parcelLength_textBox4.Name = "parcelLength_textBox4";
            this.parcelLength_textBox4.Size = new System.Drawing.Size(61, 20);
            this.parcelLength_textBox4.TabIndex = 1;
            // 
            // parcelHeight_textBox3
            // 
            this.parcelHeight_textBox3.Location = new System.Drawing.Point(17, 44);
            this.parcelHeight_textBox3.Name = "parcelHeight_textBox3";
            this.parcelHeight_textBox3.Size = new System.Drawing.Size(59, 20);
            this.parcelHeight_textBox3.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(466, 448);
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
        private System.Windows.Forms.Button LetterSearch_button;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox LetterSearch_textBox;
        private System.Windows.Forms.TextBox LetterSender_textBox;
        private System.Windows.Forms.Button PaecelSearch_button;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox PacelSearch_textBox;
        private System.Windows.Forms.TextBox ParcelsSender_textBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
    }
}

