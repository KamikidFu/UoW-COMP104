using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipHiddenThreat
{
    public partial class Ship : Card
    {
        //Instance variables
        //Variables ||Explanation
        //name_     ||The name of ship
        //healthNum_||The ship health
        //shieldNum_||The ship shield
        //deploymentX_||Where the x-axis of ship
        //deploymentY_||Where the y-axis of ship
        //shieldOn_ ||If there is a shield
        private string name_;
        private int healthNum_;
        private int shieldNum_;
        private int deploymentX_;
        private int deploymentY_;
        private Power shieldOn_;

        //Constructor
        public Ship(string NAME, int HEALTHNUM) : base(NAME)
        {
            name_ = NAME;
            healthNum_ = HEALTHNUM;
        }

        //Proporties
        public int HealthNum
        {
            get
            {
                return healthNum_;
            }
            set { healthNum_ = value; }
        }

        public int ShieldNum
        {
            get
            {
                return shieldNum_;
            }

            set
            {
                shieldNum_ = value;
            }
        }

        public int DeploymentX
        {
            get
            {
                return deploymentX_;
            }

            set
            {
                deploymentX_ = value;
            }
        }

        public int DeploymentY
        {
            get
            {
                return deploymentY_;
            }

            set
            {
                deploymentY_ = value;
            }
        }

        public Power ShieldOn
        {
            get
            {
                return shieldOn_;
            }

            set
            {
                shieldOn_ = value;
            }
        }


        //Public methods
        /// <summary>
        /// Use the ability if it is PT Boat
        /// </summary>
        /// <param name="target"></param>
        public override void useCard(Card target)
        {
            if (this.name_ == "PT Boat")
            {
                Ship targetShip = (Ship)target;
                targetShip.healthNum_++;
            }
        }

        /// <summary>
        /// Tostring method for update history
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return name_ + " " + healthNum_;
        }
    }
}
