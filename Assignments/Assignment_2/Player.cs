﻿using System;
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
        }
        

        public void drawCards(int howManyToDraw)
        {           
            myCards_.drawCards(howManyToDraw);
        }

        public void disCards(HandCard whichOneTodiscard)
        {
            if(whichOneTodiscard!=null)
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

        public string Mode
        {
            get
            {
                return mode_;
            }
        }
    }
}
