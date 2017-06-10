using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            //power coding in main form
        }

        public void useCard(Card target, Button targetButton)
        {
            if (this.name_ == "Shield")
            {
                Ship myShip = (Ship)target;
                myShip.ShieldNum += 2;
                targetButton.Text += "(Shield:" + myShip.ShieldNum + ")";     
            }
        }
    }
}
