using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enrolment_Records
{
    class Enrolment
    {
        private Students student_;
        private Papers paper_;
        private string grade_;

        internal Students Student
        {
            get
            {
                return student_;
            }

            set
            {
                student_ = value;
            }
        }

        internal Papers Paper
        {
            get
            {
                return paper_;
            }

            set
            {
                paper_ = value;
            }
        }

        public string Grade
        {
            get
            {
                return grade_;
            }

            set
            {
                grade_ = value;
            }
        }

        public Enrolment(Students student, Papers paper, string grade)
        {
            student_ = student;
            paper_ = paper;
            grade_ = grade;
        }
        public Enrolment(Students student, Papers paper)
        {
            student_ = student;
            paper_ = paper;
            grade_ = "";
        }

        public override string ToString()
        {
            return grade_ + " " + student_.ToString();
        }
    }
}
