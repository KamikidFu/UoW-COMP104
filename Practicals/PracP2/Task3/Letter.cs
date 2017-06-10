using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Letter
    {
        //Instance variable
        private string _deliveryAddress_;
        private string _senderName_;
        private int _height_;
        private int _length_;
        private bool _urgent_;
        private int _stampNum_ = 0;

        /// <summary>
        /// A constructor of known length and height
        /// </summary>
        /// <param name="height">The object's height</param>
        /// <param name="length">The object's length</param>
        public Letter(string address, string name, int height, int length)
        {
            _deliveryAddress_ = address;
            _senderName_ = name;
            _height_ = height;
            _length_ = length;
            _urgent_ = false;
        }

        /// <summary>
        /// A constructor of all three knonw information
        /// </summary>
        /// <param name="height">The object's height</param>
        /// <param name="length">The object's length</param>
        /// <param name="urgent">Whether urgent or not</param>
        public Letter(string address, string name, int height, int length,bool urgent)
        {
            _deliveryAddress_ = address;
            _senderName_ = name;
            _height_ = height;
            _length_ = length;
            _urgent_ = urgent;
        }

        /// <summary>
        /// Update of urgent situation
        /// </summary>
        public bool upToUrgent
        {
            get { return _urgent_; }
            set { _urgent_ = value; }
        }

        /// <summary>
        /// Get the cost of letter
        /// </summary>
        /// <returns></returns>
        public decimal GetCost()
        {
            decimal totalCost = 0.0m;
            if(_height_<=130 && _length_<=235)
            {
                _stampNum_ = 1;
            }
            else if(_height_<=165 && _length_<=235)
            {
                _stampNum_ = 2;
            }
            else if(_height_<230 && _length_<=325)
            {
                _stampNum_ = 3;
            }
            else
            {
                _stampNum_ = 4;
            }

            if (_urgent_) _stampNum_++;

            return totalCost = (Convert.ToDecimal(_stampNum_) *70)/100;
        }

        public override string ToString()
        {
            decimal cost = GetCost();
            return _senderName_.ToString().PadRight(10) + _height_.ToString().PadRight(10) + 
                _length_.ToString().PadRight(10) + _stampNum_.ToString().PadRight(10) + cost.ToString("c");
        }

    }
}
