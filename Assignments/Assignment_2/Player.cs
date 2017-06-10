using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipHiddenThreat
{
    public partial class Player
    {
        private string name_;
        private string team_;
        private string mode_;
        private HandCard myCards_;
        

        public Player(string NAME, string TEAM, string MODE)
        {
            name_ = NAME;
            team_ = TEAM;
            mode_ = MODE;
            myCards_ = new HandCard(Name+"'sCards",mode_);
            //if(name_!= "ToBeHonestThisIsTheRobotNameQuiteLongButIdentifiablePlayWillNeverChooseThisLongName")
            //{
            //}
        }
        

        public void drawCards(int howManyToDraw)
        {
            myCards_.drawCards(howManyToDraw);
        }

        public void disCards(HandCard whichOneTodiscard)
        {
            myCards_.discards(whichOneTodiscard);
        }
        public HandCard MyCards
        {
            get
            {
                return myCards_;
            }
        }

        public string Name
        {
            get
            {
                return name_;
            }
        }

        public string Team
        {
            get
            {
                return team_;
            }
        }
    }
}
