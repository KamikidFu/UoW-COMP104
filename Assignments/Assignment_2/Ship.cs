using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipHiddenThreat
{
    public partial class Ship: Card
    {
        private string name_;
        private int healthNum_;
        private int shieldNum_;
        private int deploymentX_;
        private int deploymentY_;

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

        public Ship(string NAME, int HEALTHNUM):base(NAME)
        {
            name_ = NAME;
            healthNum_ = HEALTHNUM;
        }

        public override void useCard(Card target)
        {
            if(this.name_=="PT Boat")
            {
                Ship targetShip = (Ship)target;
                targetShip.healthNum_++;
            }
        }

        public override string ToString()
        {
            return name_ + " " + healthNum_;
        }
    }
}
