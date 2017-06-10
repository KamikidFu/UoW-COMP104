using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipHiddenThreat
{
    public partial class Ship: Card
    {
        private string name_;
        private int healthNum_;
        private int shieldNum_;

        public int HealthNum
        {
            get
            {
                return healthNum_;
            }
            set { healthNum_ = value; }
        }

        public int ShieldNum
        {
            get
            {
                return shieldNum_;
            }

            set
            {
                shieldNum_ = value;
            }
        }

        public Ship(string NAME, int HEALTHNUM):base(NAME)
        {
            name_ = NAME;
            healthNum_ = HEALTHNUM;
        }

        public override void useCard(Card target)
        {
            //Full Game Required
        }

        public override string ToString()
        {
            return name_ + " " + healthNum_;
        }
    }
}
