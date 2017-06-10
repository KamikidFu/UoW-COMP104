using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipHiddenThreat
{
    public partial class HandCard:Card
    {
        private string name_;
        private List<HandCard> restDestructionCards_;
        private List<HandCard> usedDestructionCards_;
        private List<HandCard> inHandCards_;

        public HandCard(string NAME):base(NAME)
        {
            name_ = Name;
            restDestructionCards_ = new List<HandCard>();
            usedDestructionCards_ = new List<HandCard>();
            inHandCards_ = new List<HandCard>();            
        }

        public void initialHandCards()
        {

        }

        public override void useCard(Card target)
        {

        }
    }
}
