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
            DeliveryAddress_ = address;
            SenderName_ = name;
            _thickness_ = thickness;
            Weight_ = weight;
            Height_ = height;
            Length_ = length;
            Urgent_ = false;
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
            DeliveryAddress_ = address;
            SenderName_ = name;
            _thickness_ = thickness;
            Weight_ = weight;
            Height_ = height;
            Length_ = length;
            Urgent_ = urgent;
        }

        /// <summary>
        /// Update of urgent situation
        /// </summary>
        public bool upToUrgent
        {
            get { return Urgent_; }
            set { Urgent_ = value; }
        }

        public string DeliveryAddress_
        {
            get
            {
                return _deliveryAddress_;
            }

            set
            {
                _deliveryAddress_ = value;
            }
        }

        public string SenderName_
        {
            get
            {
                return _senderName_;
            }

            set
            {
                _senderName_ = value;
            }
        }

        public int StampNum_
        {
            get
            {
                return _stampNum_;
            }

            set
            {
                _stampNum_ = value;
            }
        }

        public int Weight_
        {
            get
            {
                return _weight_;
            }

            set
            {
                _weight_ = value;
            }
        }

        public bool Urgent_
        {
            get
            {
                return _urgent_;
            }

            set
            {
                _urgent_ = value;
            }
        }

        public int Height_
        {
            get
            {
                return _height_;
            }

            set
            {
                _height_ = value;
            }
        }

        public int Length_
        {
            get
            {
                return _length_;
            }

            set
            {
                _length_ = value;
            }
        }

        /// <summary>
        /// Get the cost of parcel
        /// </summary>
        /// <returns></returns>
        public decimal GetCost()
        {
            decimal totalCost = 0;
            double size = Height_ * Length_ * _thickness_;

            if(size<=2000000)
            {
                StampNum_ = Convert.ToInt32(Weight_) * 2;
            }
            else if(size<=3000000)
            {
                StampNum_ = Convert.ToInt32(Weight_) * 3;
            }
            else if(size<=6000000)
            {
                StampNum_ = Convert.ToInt32(Weight_) * 4;
            }
            else { StampNum_ = Convert.ToInt32(Weight_) * 5; }

            if (Urgent_) StampNum_ += Convert.ToInt32(Weight_);

            return totalCost = (Convert.ToDecimal(StampNum_) * 70) / 100;
        }

        public override string ToString()
        {
            decimal cost = GetCost();
            return SenderName_.ToString().PadRight(10) + Height_.ToString().PadRight(5) + 
                Length_.ToString().PadRight(5) + Weight_.ToString().PadRight(5) + _thickness_.ToString().PadRight(5) 
                + StampNum_.ToString().PadRight(10) + cost.ToString("c");
        }
    }
}
