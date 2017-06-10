using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipHiddenThreat
{
    public partial class Peg: HandCard
    {
        private string name_;
        private int attackNum_;
        private string color_;       
        
        public Peg(string NAME, int ATTACKNUMBER, string COLOR):base(NAME)
        {
            name_ = NAME;
            attackNum_ = ATTACKNUMBER;
            color_ = COLOR;
        }

        public override void useCard(Card target)
        {
            if(target is Ship)
            {
                Ship targetShip = (Ship)target;
                if(this.color_=="White")
                {
                    if(targetShip.Name=="Submarine")
                    {
                        targetShip.HealthNum -= this.attackNum_;
                    }
                }
                else
                {
                    if(targetShip.Name!="Sea" && targetShip.Name!="Submarine")
                    {
                        targetShip.HealthNum -= this.attackNum_;
                    }
                }
            }
        }

        public int AttackNum
        {
            get
            {
                return attackNum_;
            }
        }

        public string Color
        {
            get
            {
                return color_;
            }
        }
    }
}
