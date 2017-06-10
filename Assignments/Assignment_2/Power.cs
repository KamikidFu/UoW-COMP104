using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipHiddenThreat
{
    public partial class Power: HandCard
    {
        private string name_;
        
        public Power(string NAME):base(NAME)
        {
            name_ = NAME;
        }

        public override void useCard(Card target)
        {
           //Full Game Required
        }
    }
}
