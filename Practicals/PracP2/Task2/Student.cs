using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Student
    {
        //Instance variables
        private int _idNumber_;
        private string _name_;
        private bool _paid_;

        /// <summary>
        /// A new constructor
        /// </summary>
        /// <param name="id">Student's ID number</param>
        /// <param name="name">Student's Name</param>
        public Student(int id, string name)
        {
            _idNumber_ = id;
            _name_ = name;
            _paid_ = false;
        }

        /// <summary>
        /// Override ToString Method
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string paidBool = "Not paid";
            if (_paid_) paidBool = "Has paid";
            return _name_.ToString().PadRight(10) + _idNumber_.ToString().PadRight(10) + paidBool;
        }


    }
    
}
