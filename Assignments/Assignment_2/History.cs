using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipHiddenThreat
{
    public partial class History
    {
        //Instance Variables
        private List<string> history_;
        private int historyCounter_;

        //Constructor
        public History(int startCounter)
        {
            history_ = new List<string>();
            historyCounter_ = startCounter;
        }

        //Method
        public void Add(int history_Counter, string history_information)
        {
            history_.Add(history_Counter + ". " + history_information);
        }

        //Properties
        public List<string> HistoryList
        {
            get
            {
                return history_;
            }
        }

        //Current history index
        public int HistoryCounter
        {
            get
            {
                return historyCounter_;
            }

            set
            {
                historyCounter_ = value;
            }
        }
    }
}
