using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace Assignment_Framework_with_Classes
{
    /// <summary>
    /// Recipes which we like to make delious things
    /// Recipe needs a NAME, YIELD, INSTRUCTIONS, INGREDIENTS
    /// INGREDIENTS is another class in the application
    /// So, here in RECIPE class we use a bindinglist to store the INGREDIENTS
    /// The name is REQUIREMENTS
    /// Written by Yunhao Fu and Jiayi Hu, 2016
    /// Thank you very much :-)
    /// </summary>
    class Recipe : INotifyPropertyChanged
    {
        //***********************************
        //* Event Handling
        /// <summary>
        /// As for property-changed event, using INotifyPropertyChanged.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Event handler for change events received from requrement list in this class.
        /// Called automatically when requrement list has changed.
        /// </summary>
        private void RequirementListChanged(object sender, ListChangedEventArgs e)
        {
            // Notify listeners that the number of enrolled students may have changed
            CatchPropertyChanged("NAME");
            CatchPropertyChanged("YIELD");
            CatchPropertyChanged("INSTRUCTION");
        }

        /// <summary>
        /// Method to send a property-change event for a given property.
        /// </summary>
        /// <param name="prop">The name of the property that has changed.</param>
        private void CatchPropertyChanged(string properties)
        {
            // if there are registered listeners
            if (PropertyChanged != null)
            {
                // send the notification
                PropertyChanged(this, new PropertyChangedEventArgs(properties));
            }
        }



        //***********************************
        //*Instance Variables
        ///<summary>
        ///Name of recipe, e.g. "brownie"
        ///</summary>        
        private string name_;
        ///<summary>
        ///Yield of recipe, e.g. "1" means 1 serving it normally produces
        ///</summary>
        private uint yield_;
        ///<summary>
        ///Instructions of recipe, e.g. "..." means how to make the thing
        ///</summary>
        private string instruction_;
        ///<summary>
        ///One binding list to store the ingredients required in the recipe
        ///</summary>
        private BindingList<RecipeItems> requirements_;


        //***********************************
        //*Constructors
        ///<summary>
        ///Default constructor. Which for the functionality to add new recipe as said in Task2 b)
        ///Using the last row of datagrid view with empty things
        ///</summary>
        public Recipe() : this("", 0, "")
        { }
        ///<summary>
        ///Create a new recipe by given name, yield, instruction
        ///</summary>
        public Recipe(string NAME, uint YIELD, string INSTRUCTION)
        {
            // Initialise variable
            name_ = NAME;
            yield_ = YIELD;
            instruction_ = INSTRUCTION;
            // Create an empty list of requirements for this new recipe
            Requirements_ = new BindingList<RecipeItems>();
            //Register decleared above is for a list-changed event to handler on the enrolment list.
            Requirements_.ListChanged += new ListChangedEventHandler(RequirementListChanged);
        }

        //***********************************
        //* Public Method
        /// <summary>
        /// 
        /// </summary>

        //***********************************
        //*Properties
        public string Name
        {
            get
            {
                return name_;
            }

            set
            {
                name_ = value;
            }
        }
        public uint Yield
        {
            get
            {
                return yield_;
            }

            set
            {
                yield_ = value;
            }
        }
        public string Instruction
        {
            get
            {
                return instruction_;
            }

            set
            {
                instruction_ = value;
            }
        }

        internal BindingList<RecipeItems> Requirements_
        {
            get
            {
                return requirements_;
            }

            set
            {
                requirements_ = value;
            }
        }
    }
}
