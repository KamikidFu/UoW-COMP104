using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Forms;

namespace Assignment_Framework_with_Classes
{
    ///<summary>
    ///RecipeItems class is a class to store information about the items required in recipe.
    ///These item has three property, ingredient name, quantity and unit.
    ///It is aimed to generate a list in Recipe class
    ///</summary>

    ///<summary>
    ///These following code(INotifyPropertyChanged Event Handling) is refered by Lecture 17 Programming demo writen by Robi.
    ///Thanks for hits and helps :-)
    ///</summary>
    public class RecipeItems:INotifyPropertyChanged
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
            CatchPropertyChanged("Quantity");
            CatchPropertyChanged("IngredientName");
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
        /// <summary>
        /// quantity is how many things in the recipe
        /// </summary>
        private double quantity_;
        /// <summary>
        /// The ingredients name in the recipe
        /// </summary>
        private string ingredients_;
        /// <summary>
        /// The unit of need things
        /// </summary>
        private string unit_;


        //***********************************
        //*Constructors
        public RecipeItems() : this("", 0, "")
        { }
        ///<summary>
        ///Create a new recipe by given name, yield, instruction
        ///</summary>
        public RecipeItems(string NAME, double QUANTITY, string UNIT)
        {
            // Initialise variable
            ingredients_ = NAME;
            quantity_ = QUANTITY;
            unit_ = UNIT;
        }

        

        //***********************************
        //*Properties
        public string IngredientName
        {
            get
            {
                return ingredients_;
            }

            set
            {
                //IF the name of ingredient has changed
                if (ingredients_ != value)
                {
                    ingredients_ = value;
                    //Send property-changed notification to those that want to know
                    CatchPropertyChanged("IngredientName");
                }
            }
        }
        public double Quantity
        {
            get
            {
                return quantity_;
            }

            set
            {
                //IF the name of ingredient has changed
                if (quantity_ != value)
                {
                    quantity_ = value;
                    //Send property-changed notification to those that want to know
                    CatchPropertyChanged("Quantity");
                }
            }
        }
        public string Unit
        {
            get
            {
                return unit_;
            }

            set
            {
                //IF the name of ingredient has changed
                if (unit_ != value)
                {
                    unit_ = value;
                    //Send property-changed notification to those that want to know
                    CatchPropertyChanged("Unit");
                }
            }
        }
    }
}
