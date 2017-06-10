using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enrolment_Records
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        // Create the list of papers, and add some papers
        BindingList<Papers> papers_ = new BindingList<Papers>();
        // Create the list of students, and add some students
        BindingList<Students> students_ = new BindingList<Students>();
        ////Create the list of GRADES, come with papers and students
        //BindingList<Grade> grades_ = new BindingList<Grade>();
        private void Form1_Load(object sender, EventArgs e)
        {

            papers_.Add(new Papers("COMP103", "Introduction to Computer Science 1"));
            papers_.Add(new Papers("COMP104", "Introduction to Computer Science 2"));
            papers_.Add(new Papers("COMP123", "The Computing Experience"));
            papers_.Add(new Papers("COMP125", "Visual Computing"));
            papers_.Add(new Papers("COMP126", "Computing Media"));
            papers_.Add(new Papers("COMP200", "Computer Systems"));
            papers_.Add(new Papers("COMP202", "Computer Communications"));
            papers_.Add(new Papers("COMP203", "Programming with Data Structures"));
            papers_.Add(new Papers("COMP204", "Object-Oriented Program Design"));
            papers_.Add(new Papers("COMP219", "Database Practice and Experience"));
            papers_.Add(new Papers("COMP221", "Introduction to 3D Modelling and Animation"));
            papers_.Add(new Papers("COMP223", "Information Discovery"));
            papers_.Add(new Papers("COMP224", "Visual Design for Interactive Media"));
            papers_.Add(new Papers("COMP233", "Internet Applications"));
            papers_.Add(new Papers("COMP235", "Logic and Computation"));
            papers_.Add(new Papers("COMP241", "Software Engineering Development"));
            papers_.Add(new Papers("COMP242", "Software Engineering Process"));
            papers_.Add(new Papers("COMP258", "Programming Usable Systems"));
            papers_.Add(new Papers("COMP278", "Interactive Computing"));
            // Make this list the data source of the papers list box


            students_.Add(new Students(27830000, "Muhammad ibn Musa al-Khwarizmi", DateTime.Now));
            students_.Add(new Students(13980000, "Johannes Gutenberg", DateTime.Now));
            students_.Add(new Students(14880120, "Sebastian Münster", DateTime.Now));
            students_.Add(new Students(15640426, "William Shakespeare", DateTime.Now));
            students_.Add(new Students(16010817, "Pierre de Fermat", DateTime.Now));
            students_.Add(new Students(16421225, "Isaac Newton", DateTime.Now));
            students_.Add(new Students(16460701, "Gottfried Wilhelm Leibnitz", DateTime.Now));
            students_.Add(new Students(17580506, "Maximilien de Robespierre", DateTime.Now));
            students_.Add(new Students(18060627, "Augustus de Morgan", DateTime.Now));
            students_.Add(new Students(18470211, "Thomas Edison", DateTime.Now));
            students_.Add(new Students(18671107, "Marie Curie", DateTime.Now));
            students_.Add(new Students(18710830, "Ernest Rutherford", DateTime.Now));
            students_.Add(new Students(18790314, "Albert Einstein", DateTime.Now));
            students_.Add(new Students(18820323, "Emmy Noether", DateTime.Now));
            students_.Add(new Students(18870523, "Thoralf Skolem", DateTime.Now));
            students_.Add(new Students(19031228, "John von Neumann", DateTime.Now));
            students_.Add(new Students(19060428, "Kurt Gödel", DateTime.Now));
            students_.Add(new Students(19061209, "Grace Hopper", DateTime.Now));
            students_.Add(new Students(19000212, "Jacques Herbrand", DateTime.Now));
            students_.Add(new Students(19120623, "Alan Turing", DateTime.Now));
            students_.Add(new Students(19300511, "Edsger Dijkstra", DateTime.Now));
            students_.Add(new Students(19340111, "Antony Hoare", DateTime.Now));
            // Make this list the data source of the students list box

            //Add some students to paper
            Papers p1 = papers_[0];
            for (int i = 0; i < 5; i++)
            {
                Students s1 = students_[i];
                p1.Add(s1, "A+");
            }
            updateListBox(p1);
        }

        /// <summary>
        /// Update listBox with the current paper to see who is enroled
        /// </summary>
        /// <param name="currentPaper"></param>
        private void updateListBox(Papers currentPaper)
        {

            papersListBox_.DataSource = null;
            studentsListBox_.DataSource = null;
            enrolmentsListBox_.DataSource = null;
            //Show the data
            papersListBox_.DataSource = papers_;
            studentsListBox_.DataSource = students_;
            enrolmentsListBox_.DataSource = currentPaper.EnrolmentsList;

        }

        /// <summary>
        /// Retrive data from listbox to textbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void studentsListBox__SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = studentsListBox_.SelectedIndex;
            if (index >= 0)
                textBox1_StudentID.Text = students_[index].StudentID.ToString();
        }
        private void papersListBox__SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = papersListBox_.SelectedIndex;
            if (index >= 0)
            {
                textBox2_PaperCode.Text = papers_[index].PaperCode;
                Papers p = papers_[index];
                updateListBox(p);
            }
        }
        private void enrolmentsListBox__SelectedIndexChanged(object sender, EventArgs e)
        {
            int indexStudent = enrolmentsListBox_.SelectedIndex;
            int indexPaper = papersListBox_.SelectedIndex;

            if (indexPaper >= 0 && indexStudent >= 0)
            {
                Papers p = papers_[indexPaper];
                Enrolment enrol = p.EnrolmentsList[indexStudent];
                textBox1_StudentID.Text = enrol.Student.StudentID.ToString();
                textBox2_PaperCode.Text = p.PaperCode;
                comboBox1_Grade.Text = enrol.Grade;
            }

        }

        /// <summary>
        /// Add student to paper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_AddStudent_Click(object sender, EventArgs e)
        {
            if (textBox1_StudentID.Text != "" && textBox2_PaperCode.Text != "" && comboBox1_Grade.Text != "")
            {
                ulong studentID = ulong.Parse(textBox1_StudentID.Text);
                string paperCode = textBox2_PaperCode.Text;
                string Grade = comboBox1_Grade.Text;

                int studentIndex = 0;
                foreach (Students s1 in students_)
                {
                    if (s1.StudentID == studentID)
                    {
                        break;
                    }
                    else { studentIndex++; }
                }
                int paperIndex = 0;
                foreach (Papers p1 in papers_)
                {
                    if (p1.PaperCode == paperCode)
                    {
                        break;
                    }
                    else { paperIndex++; }
                }
                Papers p = papers_[paperIndex];
                Students s = students_[studentIndex];
                Enrolment enrol = new Enrolment(s, p);
                if (!(p.EnrolmentsList.Contains(enrol)))
                {
                    p.Add(s, Grade);
                }
                else
                { MessageBox.Show("This student is already in the paper."); }
                //for(int i=0;i<p.EnrolmentsList.Count;i++)
                //{
                //    if(p.EnrolmentsList[i].Student.StudentID==enrol.Student.StudentID)
                //    {
                //        MessageBox.Show("This student is already in the paper!");
                //    }
                //    else
                //    {
                //        p.Add(s, Grade);
                //    }
                //}
                updateListBox(p);
            }
            else
            {
                MessageBox.Show("Add student to paper need three textboxs above filled information!");
            }
        }
        /// <summary>
        /// Remove student from the paper
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_RemoveStudent_Click(object sender, EventArgs e)
        {
            if (textBox1_StudentID.Text != "" && textBox2_PaperCode.Text != "")
            {
                ulong studentID = ulong.Parse(textBox1_StudentID.Text);
                string paperCode = textBox2_PaperCode.Text;
                string Grade = comboBox1_Grade.Text;

                int paperIndex = -1;
                for (int i = 0; i < papers_.Count; i++)
                {
                    if (paperCode == papers_[i].PaperCode)
                    {
                        paperIndex = i;
                        break;
                    }
                }
                int studentIndex = -1;
                for (int i = 0; i < students_.Count; i++)
                {
                    if (studentID == students_[i].StudentID)
                    {
                        studentIndex = i;
                        break;
                    }
                }

                Papers p = papers_[paperIndex];
                Students s = students_[studentIndex];
                Enrolment enrol = new Enrolment(s, p, Grade);
                for (int i = 0; i < p.EnrolmentsList.Count; i++)
                {
                    if (p.EnrolmentsList[i].Student.StudentID == enrol.Student.StudentID)
                    {
                        p.EnrolmentsList.RemoveAt(i);
                        break;
                    }
                }
                updateListBox(p);
            }
            else
            {
                MessageBox.Show("Remove student from paper need the ID and Code above filled information!");
            }
        }

        /// <summary>
        /// Check the ID of student
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_CheckID_Click(object sender, EventArgs e)
        {
            ////MessageBox.Show("学生类，课目类和成绩类没有成功关联，此段代码有问题！");
            ////有问题！！！
            ulong studentID = ulong.Parse(textBox1_StudentID.Text);
            int studentIndex = 0;
            foreach (Students s1 in students_)
            {
                if (s1.StudentID == studentID)
                {
                    break;
                }
                else { studentIndex++; }
            }
            Students s = students_[studentIndex];

            string output = "The student: " + s.StudentName + ": " + "\n";

            for (int i = 0; i < papers_.Count; i++)
            {
                Papers p = papers_[i];
                for (int j = 0; j < p.EnrolmentsList.Count; j++)
                {
                    if (p.EnrolmentsList[j].Student.StudentID == s.StudentID)
                    {
                        output += p.PaperCode + " Grade: " + p.EnrolmentsList[j].Grade + "\n";
                    }
                }
            }

            MessageBox.Show(output);

        }

        private void button4_CheckCode_Click_1(object sender, EventArgs e)
        {
            //MessageBox.Show("学生类，课目类和成绩类没有成功关联，此段代码有问题！");
            //有问题！！！
            string paperCode = textBox2_PaperCode.Text;
            int paperIndex = 0;

            foreach (Papers p1 in papers_)
            {
                if (p1.PaperCode == paperCode)
                {
                    break;
                }
                else { paperIndex++; }
            }
            Papers p = papers_[paperIndex];
            string output = "The Paper: " + p.PaperTitle + ": " + "\n";
            for (int i = 0; i < students_.Count; i++)
            {
                Students s = students_[i];
                //if (p.Enrolments_.Contains(s))
                //{
                //    int studentIndexInPaper = p.Enrolments_.IndexOf(s);
                //    output += "Paper Code: " + p.PaperCode + " Paper Grade: " + s.GradeList_[i] + "\n";
                //}
                //if (p.Enrolments_.Contains(s))
                //{
                //    output += s.StudentName + " with ID: " + s.StudentID + " has grade: " + s.GradeList_[hasPaperIndex] + " Birth:" + s.DateOfBirth + "\n";
                //    hasPaperIndex++;
                //}
                for (int j = 0; j < p.EnrolmentsList.Count; j++)
                {
                    if (p.EnrolmentsList[j].Student.StudentID == s.StudentID)
                    {
                        output += s.StudentName + " with ID: " + s.StudentID + " has grade: " + p.EnrolmentsList[j].Grade + " Birth:" + s.DateOfBirth + "\n";
                    }
                }
            }

            MessageBox.Show(output);
        }
    }
}

