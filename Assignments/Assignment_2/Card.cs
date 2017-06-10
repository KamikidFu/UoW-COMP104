using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipHiddenThreat
{
    public abstract class Card
    {
        //Instance Variables
        private string name_;

        //Constructor
        public Card(string name)
        {
            name_ = name;
        }       

        //Abstract method
        public abstract void useCard(Card target);

        //Properties
        public string Name
        {
            get
            {
                return name_;
            }
        }
    }
}
