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

        public int HealthNum_
        {
            get
            {
                return healthNum_;
            }
        }
        public Ship(string NAME, int HEALTHNUM):base(NAME)
        {
            name_ = NAME;
            healthNum_ = HEALTHNUM;
        }

        public override void useCard(Card target)
        {
           
        }

        public override string ToString()
        {
            return name_ + " " + healthNum_;
        }
    }
}
