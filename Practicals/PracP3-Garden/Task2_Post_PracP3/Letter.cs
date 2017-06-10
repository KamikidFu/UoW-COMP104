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
        private int _stampNum_;

        //Properties
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

        /// <summary>
        /// A constructor of known length and height
        /// </summary>
        /// <param name="height">The object's height</param>
        /// <param name="length">The object's length</param>
        public Letter(string address, string name, int height, int length)
        {
            DeliveryAddress_ = address;
            SenderName_ = name;
            Height_ = height;
            Length_ = length;
            Urgent_ = false;
        }

        /// <summary>
        /// A constructor of all three knonw information
        /// </summary>
        /// <param name="height">The object's height</param>
        /// <param name="length">The object's length</param>
        /// <param name="urgent">Whether urgent or not</param>
        public Letter(string address, string name, int height, int length,bool urgent)
        {
            DeliveryAddress_ = address;
            SenderName_ = name;
            Height_ = height;
            Length_ = length;
            Urgent_ = urgent;
        }        

        /// <summary>
        /// Get the cost of letter
        /// </summary>
        /// <returns></returns>
        public decimal GetCost()
        {
            decimal totalCost = 0.0m;
            if(Height_<=130 && Length_<=235)
            {
                StampNum_ = 1;
            }
            else if(Height_<=165 && Length_<=235)
            {
                StampNum_ = 2;
            }
            else if(Height_<230 && Length_<=325)
            {
                StampNum_ = 3;
            }
            else
            {
                StampNum_ = 4;
            }

            if (Urgent_) StampNum_++;

            return totalCost = (Convert.ToDecimal(StampNum_) *70)/100;
        }

        public override string ToString()
        {
            decimal cost = GetCost();
            return SenderName_.ToString().PadRight(10) + Height_.ToString().PadRight(10) + 
                Length_.ToString().PadRight(10) + StampNum_.ToString().PadRight(10) + cost.ToString("c");
        }

      


    }
}
