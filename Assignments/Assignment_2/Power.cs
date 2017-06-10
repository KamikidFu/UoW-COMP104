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
                targetButton.Text = myShip.Name + "\n(Health:" + myShip.HealthNum + ")(Shield:" + myShip.ShieldNum + ")";
            }
        }
        public void useCard(Card usingCard, string whichFunction, Player whoPlay, Ship powerUsedShip)
        {
            if(this.name_== "Discard White Peg or Play 2 Cards")
            {
                if(whichFunction=="1")
                {
                    for(int i=0;i<whoPlay.MyCards.InHandCards.Count;i++)
                    {
                       if( whoPlay.MyCards.InHandCards[i].Name=="White Peg")
                        {
                            whoPlay.disCards(whoPlay.MyCards.InHandCards[i]);
                            whoPlay.MyCards.InHandCards.RemoveAt(i);
                        }
                    }
                }
                else
                {
                    whoPlay.Full_RestOfRound = 2;
                }
            }
            else
            {
                if(whichFunction=="1")
                {
                    if (powerUsedShip != null)
                    {
                        powerUsedShip.HealthNum++;
                    }
                    whoPlay.Full_RestOfRound = 1;
                }
                else
                {
                    whoPlay.drawCards(3);
                    whoPlay.Full_RestOfRound = 1;
                }
            }
        }
    }
}
