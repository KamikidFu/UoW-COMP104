using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipHiddenThreat
{
    public partial class Player
    {
        //Instance variables
        //Variables         ||Explanation
        //name_             ||The name of player
        //team_             ||The team of player
        //mode_             ||Player plays what mode
        //myCards_          ||In hand cards
        //full_restOfRound_ ||In full game, rest of round
        //full_restOfCard_  ||In full game, the cap of player to draw cards
        private string name_;
        private string team_;
        private string mode_;
        private HandCard myCards_;
        private int full_restOfRound_;
        private int full_restOfCard_;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="NAME">Player name</param>
        /// <param name="TEAM">Player team</param>
        /// <param name="MODE">Player mode</param>
        public Player(string NAME, string TEAM, string MODE)
        {
            name_ = NAME;
            team_ = TEAM;
            mode_ = MODE;
            myCards_ = new HandCard(Name + "'sCards", mode_);
            if (MODE == "Full")
            { full_restOfRound_ = 1; full_restOfCard_ = 5; }
        }

        /// <summary>
        /// Player draw cards
        /// </summary>
        /// <param name="howManyToDraw">the number of cards to draw</param>
        public void drawCards(int howManyToDraw)
        {
            myCards_.drawCards(howManyToDraw);
        }

        /// <summary>
        /// Player discard
        /// </summary>
        /// <param name="whichOneTodiscard"> Which card to discard</param>
        public void disCards(HandCard whichOneTodiscard)
        {
            if (whichOneTodiscard != null)
                myCards_.discards(whichOneTodiscard);
        }

        //Proporties
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

        public string Mode
        {
            get
            {
                return mode_;
            }
        }

        public int Full_RestOfRound
        {
            get
            {
                return full_restOfRound_;
            }

            set
            {
                full_restOfRound_ = value;
            }
        }

        public int Full_RestOfCard
        {
            get
            {
                return full_restOfCard_;
            }

            set
            {
                full_restOfCard_ = value;
            }
        }
    }
}
