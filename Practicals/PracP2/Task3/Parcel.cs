using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Parcel
    {
        //Instance variable
        private string _deliveryAddress_;
        private string _senderName_;
        private int _height_;
        private int _length_;
        private int _thickness_;
        private int _weight_;
        private int _stampNum_ = 0;
        private bool _urgent_;

        /// <summary>
        /// A constructor of known length and height
        /// </summary>
        /// <param name="height">The object's height</param>
        /// <param name="length">The object's length</param>      
        /// <param name="thickness">The object's thickness</param>
        /// <param name="weight">The object's weight</param>
        public Parcel(string address, string name, int height, int length,int thickness,int weight)
        {
            _deliveryAddress_ = address;
            _senderName_ = name;
            _thickness_ = thickness;
            _weight_ = weight;
            _height_ = height;
            _length_ = length;
            _urgent_ = false;
        }

        /// <summary>
        /// A constructor of all three knonw information
        /// </summary>
        /// <param name="height">The object's height</param>
        /// <param name="length">The object's length</param>
        /// <param name="thickness">The object's thickness</param>
        /// <param name="weight">The object's weight</param>
        /// <param name="urgent">The object is urgent or not</param>
        public Parcel(string address, string name, int height, int length,int thickness,int weight, bool urgent)
        {
            _deliveryAddress_ = address;
            _senderName_ = name;
            _thickness_ = thickness;
            _weight_ = weight;
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
        /// Get the cost of parcel
        /// </summary>
        /// <returns></returns>
        public decimal GetCost()
        {
            decimal totalCost = 0;
            double size = _height_ * _length_ * _thickness_;

            if(size<=2000000)
            {
                _stampNum_ = Convert.ToInt32(_weight_) * 2;
            }
            else if(size<=3000000)
            {
                _stampNum_ = Convert.ToInt32(_weight_) * 3;
            }
            else if(size<=6000000)
            {
                _stampNum_ = Convert.ToInt32(_weight_) * 4;
            }
            else { _stampNum_ = Convert.ToInt32(_weight_) * 5; }

            if (_urgent_) _stampNum_ += Convert.ToInt32(_weight_);

            return totalCost = (Convert.ToDecimal(_stampNum_) * 70) / 100;
        }

        public override string ToString()
        {
            decimal cost = GetCost();
            return _senderName_.ToString().PadRight(10) + _height_.ToString().PadRight(5) + 
                _length_.ToString().PadRight(5) + _weight_.ToString().PadRight(5) + _thickness_.ToString().PadRight(5) 
                + _stampNum_.ToString().PadRight(10) + cost.ToString("c");
        }
    }
}
