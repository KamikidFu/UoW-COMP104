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
    class Students
    {

        //Instance Varibles
        private string StudentName_;
        private ulong StudentID_;
        private DateTime DateOfBirth_;

        public Students(ulong ID, string Name, DateTime Birth)
        {
            StudentID_ = ID;
            StudentName_ = Name;
            DateOfBirth_ = Birth;
        }

        //Methods
        public override string ToString()
        {
            return StudentName_ + " (" + String.Format("{0:D8}", StudentID_) + ")" + " " + DateOfBirth.ToString();
        }


        //Access
        public string StudentName
        {
            get
            {
                return StudentName_;
            }

            set
            {
                StudentName_ = value;
            }
        }

        public ulong StudentID
        {
            get
            {
                return StudentID_;
            }

            set
            {
                StudentID_ = value;
            }
        }

        public DateTime DateOfBirth
        {
            get
            {
                return DateOfBirth_;
            }

            set
            {
                DateOfBirth_ = value;
            }
        }





    }
}
