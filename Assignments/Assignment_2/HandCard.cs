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
        private string mode_;
        private int[] cardsIndex_;
        private int currentIndexOFCardsIndex_;
        private List<HandCard> restDestructionCards_;
        private List<HandCard> usedDestructionCards_;
        private List<HandCard> inHandCards_;

        public List<HandCard> InHandCards
        {
            get
            {
                return inHandCards_;
            }
        }

        public HandCard(string NAME,string MODE ):base(NAME)
        {
            name_ = Name;
            mode_ = MODE;
            restDestructionCards_ = new List<HandCard>();
            usedDestructionCards_ = new List<HandCard>();
            inHandCards_ = new List<HandCard>();
            currentIndexOFCardsIndex_ = 0;
            initialRestDeckCards();
            randomCards();
            drawCards(5);
        }

        public HandCard(string NAME):base(NAME)
        {
            name_ = NAME;
        }

        private void initialRestDeckCards()
        {
            for (int i = 0; i < 10; i++)
            {
                restDestructionCards_.Add(new Peg("White Peg", 1, "White"));
            }
            for (int i = 0; i < 6; i++)
            {
                restDestructionCards_.Add(new Peg("Red Peg", 1, "Red"));
            }
            for (int i = 0; i < 3; i++)
            {
                restDestructionCards_.Add(new Peg("Red Peg", 2, "Red"));
            }
            restDestructionCards_.Add(new Peg("Red Peg", 4, "Red"));
            if(mode_=="Full")
            {
                restDestructionCards_.Add(new Power("Shield"));
                restDestructionCards_.Add(new Power("Shield"));
                restDestructionCards_.Add(new Power("Discard White Peg or Play 2 Cards"));
                restDestructionCards_.Add(new Power("Discard White Peg or Play 2 Cards"));
                restDestructionCards_.Add(new Power("Repair a ship or Draw 3 Cards, then Play 1"));
                restDestructionCards_.Add(new Power("Repair a ship or Draw 3 Cards, then Play 1"));
            }
        }
        private void randomCards()
        {
            int index = 0;
            int randIndexOfShip = 0;
            Random rand_ = new Random();
            if (mode_ == "Full")
            {
                cardsIndex_ = new int[26];
                while (index != 25)
                {
                    randIndexOfShip = rand_.Next(26);
                    if (!cardsIndex_.Contains(randIndexOfShip))
                    {
                        cardsIndex_[index] = randIndexOfShip;
                        index++;
                    }
                }
            }
            else
            {
                cardsIndex_ = new int[20];
                while (index !=19)
                {
                    randIndexOfShip = rand_.Next(20);
                    if (!cardsIndex_.Contains(randIndexOfShip))
                    {
                        cardsIndex_[index] = randIndexOfShip;
                        index++;
                    }
                }
            }
        }
        public void drawCards(int HowManyCardsToDraw)
        {
            if (HowManyCardsToDraw >= 0)
            {
                if (this.mode_ == "Full")
                {

                }
                else
                {

                    for (int i = 0; i < HowManyCardsToDraw; i++)
                    {
                        if (currentIndexOFCardsIndex_ < 20)
                        {
                            inHandCards_.Add(restDestructionCards_[cardsIndex_[currentIndexOFCardsIndex_]]);
                            currentIndexOFCardsIndex_++;
                        }
                        else
                        {
                            initialRestDeckCards();
                            randomCards();
                            currentIndexOFCardsIndex_ = 0;
                            inHandCards_.Add(restDestructionCards_[cardsIndex_[currentIndexOFCardsIndex_]]);
                            currentIndexOFCardsIndex_++;
                        }
                    }

                }
            }
          }
        public void discards(HandCard whichToDiscard)
        {
            usedDestructionCards_.Add(whichToDiscard);
        }
        public override void useCard(Card target)
        {

        }
    }
}
