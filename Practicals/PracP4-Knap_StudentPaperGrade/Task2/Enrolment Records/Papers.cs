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
    class Papers
    {
        BindingList<Enrolment> enrolments_ = new BindingList<Enrolment>();
        //Instance Varibles
        private string PaperCode_;
        private string PaperTitle_;

        public Papers(string papercode, string papertitle)
        {
            PaperCode_ = papercode;
            PaperTitle_ = papertitle;
        }
        //Methods
        /// <summary>
        /// Add student to a paper
        /// </summary>
        /// <param name="s1">The student selected</param>
        public void Add(Students s1, string grade)
        {
            Enrolment enrol = new Enrolment(s1, this, grade);
            enrolments_.Add(enrol);
        }
        public void Remove(Enrolment enrol)
        {
            enrolments_.Remove(enrol);
        }

        public override string ToString()
        {
            string text = PaperCode_ + " " + PaperTitle_;
            if (EnrolmentCount > 0)
            {
                text += " (" + EnrolmentCount.ToString() + " enrolled)";
            }
            return text;
        }

        //Access
        public string PaperCode
        {
            get
            {
                return PaperCode_;
            }

            set
            {
                PaperCode_ = value;
            }
        }

        public string PaperTitle
        {
            get
            {
                return PaperTitle_;
            }

            set
            {
                PaperTitle_ = value;
            }
        }
        public int EnrolmentCount
        {
            get { return enrolments_.Count; }
        }

        internal BindingList<Enrolment> EnrolmentsList
        {
            get
            {
                return enrolments_;
            }
        }


    }
}
