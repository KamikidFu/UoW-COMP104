using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipHiddenThreat
{
    class Peg: Card
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
        }

        public int AttackNum_
        {
            get
            {
                return attackNum_;
            }
        }

        public string Color_
        {
            get
            {
                return color_;
            }
        }
    }
}
