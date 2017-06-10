using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleshipHiddenThreat
{
    public partial class Power : HandCard
    {
        //name_||The name of power
        private string name_;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="NAME">The name of power</param>
        public Power(string NAME) : base(NAME)
        {
            name_ = NAME;
        }
        public override void useCard(Card target)
        {
            //Using other useCard method for power use 
        }

        /// <summary>
        /// One useCard method for shield use
        /// </summary>
        /// <param name="target">The target ship</param>
        /// <param name="targetButton">The target ship in which button</param>
        public void useCard(Card target, Button targetButton)
        {
            if (this.name_ == "Shield")
            {
                Ship myShip = (Ship)target;
                myShip.ShieldNum += 2;
                targetButton.Text = myShip.Name + "\n(Health:" + myShip.HealthNum + ")(Shield:" + myShip.ShieldNum + ")";
            }
        }
        /// <summary>
        /// One useCard method for other power(Only AI Use)
        /// Player power use in main form codes
        /// </summary>
        /// <param name="usingCard">Which power card to use</param>
        /// <param name="whichFunction">using which function</param>
        /// <param name="whoPlay">who play this power</param>
        /// <param name="powerUsedShip">to which ship using the power</param>
        public void useCard(Card usingCard, string whichFunction, Player whoPlay, Ship powerUsedShip)
        {
            //If it is Discard White Peg or Play 2 Cards
            if (this.name_ == "Discard White Peg or Play 2 Cards")
            {
                //And using the first power discard white peg
                if (whichFunction == "1")
                {
                    //Discard all the white peg
                    for (int i = 0; i < whoPlay.MyCards.InHandCards.Count; i++)
                    {
                        if (whoPlay.MyCards.InHandCards[i].Name == "White Peg")
                        {
                            whoPlay.disCards(whoPlay.MyCards.InHandCards[i]);
                            whoPlay.MyCards.InHandCards.RemoveAt(i);
                        }
                    }
                }
                else
                {
                    //Play two more rounds
                    whoPlay.Full_RestOfRound = 2;
                }
            }
            else
            {
                //The other power
                if (whichFunction == "1")
                {
                    //If it is the repair power
                    if (powerUsedShip != null)
                    {
                        powerUsedShip.HealthNum++;
                    }
                    //Then play one more
                    whoPlay.Full_RestOfRound = 1;
                }
                else
                {
                    //Draw the 3 new cards
                    whoPlay.drawCards(3);
                    //Then play one more
                    whoPlay.Full_RestOfRound = 1;
                }
            }
        }
    }
}
