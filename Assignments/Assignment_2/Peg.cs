using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipHiddenThreat
{
    public partial class Peg : HandCard
    {
        //Instance variables
        //Variables         ||Explanation
        //name_             ||The name of peg
        //attackNum_        ||The attack number of peg
        //color_            ||The color of peg
        private string name_;
        private int attackNum_;
        private string color_;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="NAME">The name of peg</param>
        /// <param name="ATTACKNUMBER">The attack number of peg</param>
        /// <param name="COLOR">The color of peg</param>
        public Peg(string NAME, int ATTACKNUMBER, string COLOR) : base(NAME)
        {
            name_ = NAME;
            attackNum_ = ATTACKNUMBER;
            color_ = COLOR;
        }

        //Public method
        public override void useCard(Card target)
        {
            //Use the method below to do work 
        }
        /// <summary>
        /// The usePegCard method to use peg
        /// </summary>
        /// <param name="target">The target attack ship</param>
        /// <param name="Mode">Current mode</param>
        public void usePegCard(Card target, string Mode)
        {
            if (Mode == "Base")
            {
                //Base game, the target ship only is attacked by red peg
                if (target is Ship)
                {
                    Ship targetShip = (Ship)target;
                    if (this.color_ == "Red")
                    {
                        if (targetShip.Name != "Sea")
                        {
                            //Minus the attack number
                            targetShip.HealthNum -= this.attackNum_;
                        }
                    }
                }
            }
            else
            {
                //Full game, White peg to attack submarine
                //Red peg to attack others
                if (target is Ship)
                {
                    Ship targetShip = (Ship)target;
                    if (this.color_ == "White")
                    {
                        if (targetShip.Name == "Submarine")
                        {
                            //If the ship has shield number
                            if (targetShip.ShieldNum > 0)
                            {
                                //Firstly minus the shield
                                targetShip.ShieldNum -= this.attackNum_;
                            }
                            else
                            {
                                //Or, then?, use red peg
                                targetShip.HealthNum -= this.attackNum_;
                            }
                        }
                    }
                    else
                    {
                        if (targetShip.Name != "Sea" && targetShip.Name != "Submarine")
                        {
                            //If the ship has shield number
                            if (targetShip.ShieldNum > 0)
                            {
                                //Firstly minus the shield
                                targetShip.ShieldNum -= this.attackNum_;
                            }
                            else
                            {
                                //Or, then?, use red peg
                                targetShip.HealthNum -= this.attackNum_;
                            }
                        }
                    }
                }
            }
        }
        //Proporties
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
