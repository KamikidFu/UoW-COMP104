namespace Enrolment_Records
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.studentsListBox_ = new System.Windows.Forms.ListBox();
            this.papersListBox_ = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.enrolmentsListBox_ = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1_StudentID = new System.Windows.Forms.TextBox();
            this.textBox2_PaperCode = new System.Windows.Forms.TextBox();
            this.button1_AddStudent = new System.Windows.Forms.Button();
            this.button2_RemoveStudent = new System.Windows.Forms.Button();
            this.comboBox1_Grade = new System.Windows.Forms.ComboBox();
            this.button3_CheckID = new System.Windows.Forms.Button();
            this.button4_CheckCode = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.86192F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.13808F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 286F));
            this.tableLayoutPanel1.Controls.Add(this.studentsListBox_, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.papersListBox_, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.enrolmentsListBox_, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.04478F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.95522F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(947, 366);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // studentsListBox_
            // 
            this.studentsListBox_.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentsListBox_.FormattingEnabled = true;
            this.studentsListBox_.ItemHeight = 14;
            this.studentsListBox_.Location = new System.Drawing.Point(3, 43);
            this.studentsListBox_.Name = "studentsListBox_";
            this.studentsListBox_.Size = new System.Drawing.Size(303, 312);
            this.studentsListBox_.TabIndex = 0;
            this.studentsListBox_.SelectedIndexChanged += new System.EventHandler(this.studentsListBox__SelectedIndexChanged);
            // 
            // papersListBox_
            // 
            this.papersListBox_.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.papersListBox_.FormattingEnabled = true;
            this.papersListBox_.ItemHeight = 14;
            this.papersListBox_.Location = new System.Drawing.Point(312, 43);
            this.papersListBox_.Name = "papersListBox_";
            this.papersListBox_.Size = new System.Drawing.Size(345, 312);
            this.papersListBox_.TabIndex = 1;
            this.papersListBox_.SelectedIndexChanged += new System.EventHandler(this.papersListBox__SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "Students:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(312, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 28);
            this.label2.TabIndex = 3;
            this.label2.Text = "Papers:";
            // 
            // enrolmentsListBox_
            // 
            this.enrolmentsListBox_.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.enrolmentsListBox_.FormattingEnabled = true;
            this.enrolmentsListBox_.ItemHeight = 14;
            this.enrolmentsListBox_.Location = new System.Drawing.Point(663, 43);
            this.enrolmentsListBox_.Name = "enrolmentsListBox_";
            this.enrolmentsListBox_.Size = new System.Drawing.Size(278, 312);
            this.enrolmentsListBox_.TabIndex = 4;
            this.enrolmentsListBox_.SelectedIndexChanged += new System.EventHandler(this.enrolmentsListBox__SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Consolas", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(663, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 28);
            this.label3.TabIndex = 5;
            this.label3.Text = "Enrolment:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 381);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "Student ID:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(213, 381);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 3;
            this.label5.Text = "Paper Code:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(396, 381);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 4;
            this.label6.Text = "Grade:";
            // 
            // textBox1_StudentID
            // 
            this.textBox1_StudentID.Location = new System.Drawing.Point(95, 378);
            this.textBox1_StudentID.Name = "textBox1_StudentID";
            this.textBox1_StudentID.Size = new System.Drawing.Size(100, 21);
            this.textBox1_StudentID.TabIndex = 5;
            // 
            // textBox2_PaperCode
            // 
            this.textBox2_PaperCode.Location = new System.Drawing.Point(290, 378);
            this.textBox2_PaperCode.Name = "textBox2_PaperCode";
            this.textBox2_PaperCode.Size = new System.Drawing.Size(100, 21);
            this.textBox2_PaperCode.TabIndex = 6;
            // 
            // button1_AddStudent
            // 
            this.button1_AddStudent.Location = new System.Drawing.Point(36, 405);
            this.button1_AddStudent.Name = "button1_AddStudent";
            this.button1_AddStudent.Size = new System.Drawing.Size(133, 23);
            this.button1_AddStudent.TabIndex = 8;
            this.button1_AddStudent.Text = "Add Student";
            this.button1_AddStudent.UseVisualStyleBackColor = true;
            this.button1_AddStudent.Click += new System.EventHandler(this.button1_AddStudent_Click);
            // 
            // button2_RemoveStudent
            // 
            this.button2_RemoveStudent.Location = new System.Drawing.Point(175, 405);
            this.button2_RemoveStudent.Name = "button2_RemoveStudent";
            this.button2_RemoveStudent.Size = new System.Drawing.Size(133, 23);
            this.button2_RemoveStudent.TabIndex = 9;
            this.button2_RemoveStudent.Text = "Remove Student";
            this.button2_RemoveStudent.UseVisualStyleBackColor = true;
            this.button2_RemoveStudent.Click += new System.EventHandler(this.button2_RemoveStudent_Click);
            // 
            // comboBox1_Grade
            // 
            this.comboBox1_Grade.FormattingEnabled = true;
            this.comboBox1_Grade.Items.AddRange(new object[] {
            "A+",
            "A",
            "A-",
            "B+",
            "B",
            "B-",
            "C+",
            "C",
            "C-",
            "D",
            "E",
            "IC"});
            this.comboBox1_Grade.Location = new System.Drawing.Point(443, 378);
            this.comboBox1_Grade.Name = "comboBox1_Grade";
            this.comboBox1_Grade.Size = new System.Drawing.Size(121, 20);
            this.comboBox1_Grade.TabIndex = 10;
            // 
            // button3_CheckID
            // 
            this.button3_CheckID.Location = new System.Drawing.Point(314, 405);
            this.button3_CheckID.Name = "button3_CheckID";
            this.button3_CheckID.Size = new System.Drawing.Size(75, 23);
            this.button3_CheckID.TabIndex = 11;
            this.button3_CheckID.Text = "Check ID";
            this.button3_CheckID.UseVisualStyleBackColor = true;
            this.button3_CheckID.Click += new System.EventHandler(this.button3_CheckID_Click);
            // 
            // button4_CheckCode
            // 
            this.button4_CheckCode.Location = new System.Drawing.Point(395, 405);
            this.button4_CheckCode.Name = "button4_CheckCode";
            this.button4_CheckCode.Size = new System.Drawing.Size(75, 23);
            this.button4_CheckCode.TabIndex = 12;
            this.button4_CheckCode.Text = "Check Code";
            this.button4_CheckCode.UseVisualStyleBackColor = true;
            this.button4_CheckCode.Click += new System.EventHandler(this.button4_CheckCode_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 453);
            this.Controls.Add(this.button4_CheckCode);
            this.Controls.Add(this.button3_CheckID);
            this.Controls.Add(this.comboBox1_Grade);
            this.Controls.Add(this.button2_RemoveStudent);
            this.Controls.Add(this.button1_AddStudent);
            this.Controls.Add(this.textBox2_PaperCode);
            this.Controls.Add(this.textBox1_StudentID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListBox studentsListBox_;
        private System.Windows.Forms.ListBox papersListBox_;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox enrolmentsListBox_;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1_StudentID;
        private System.Windows.Forms.TextBox textBox2_PaperCode;
        private System.Windows.Forms.Button button1_AddStudent;
        private System.Windows.Forms.Button button2_RemoveStudent;
        private System.Windows.Forms.ComboBox comboBox1_Grade;
        private System.Windows.Forms.Button button3_CheckID;
        private System.Windows.Forms.Button button4_CheckCode;
    }
}

