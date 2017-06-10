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
    /// Ingredient which we like to set up different ingredients for recipes
    /// Ingredient needs a NAME, QUANTITY, PRICE, ENERGY VALUE
    /// Written by Yunhao Fu and Jiayi Hu, 2016
    /// Thank you very much :-)
    /// </summary>
    class Ingredient : INotifyPropertyChanged
    {
        //***********************************
        //* Event Handling
        /// <summary>
        /// As for property-changed event, using INotifyPropertyChanged.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Auxiliary method to send a property-change event for a given property.
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
        ///Name of Ingredient, e.g. "egg"
        ///</summary>
        private string name_;
        ///<summary>
        ///Default quantity of Ingredient, e.g. "1" means 1 unit of ingredient
        ///</summary>
        private double defaultQuantity_;
        ///<summary>
        ///Price of ingredient, e.g."$1" means this ingredient has price of 1 dollar
        ///</summary>
        private decimal price_;
        ///<summary>
        ///Energy value of ingredient, e.g. "1000" means 1000 kcal of ingredient assumption.
        ///</summary>
        private uint energy_;
        ///<summary>
        ///Unit of ingredient, e.g."g" is unit, like 10g
        ///</summary>
        private string unit_;


        //***********************************
        //*Constructors
        ///<summary>
        ///Default constructor. Which for the functionality to add new ingredient as said in Task2 b)
        ///Using the last row of datagrid view with empty things
        ///</summary>
        public Ingredient() : this("", 0, "", 0, 0)
        { }
        ///<summary>
        ///Create a new recipe by given name, yield, instruction
        ///</summary>
        public Ingredient(string NAME, double QUANTITY, string UNIT, uint ENERGY, decimal PRICE)
        {
            // Initialise variable
            name_ = NAME;
            defaultQuantity_ = QUANTITY;
            unit_ = UNIT;
            price_ = PRICE;
            energy_ = ENERGY;
        }

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
                //IF the name of ingredient has changed
                if (name_ != value)
                {
                    name_ = value;
                    //Send property-changed notification to those that want to know
                    CatchPropertyChanged("Name");
                }
            }
        }

        public double Default_Quantity
        {
            get
            {
                return defaultQuantity_;
            }

            set
            {
                //IF the name of ingredient has changed
                if (defaultQuantity_ != value)
                {
                    defaultQuantity_ = value;
                    //Send property-changed notification to those that want to know
                    CatchPropertyChanged("Quantity");
                }
            }
        }

        public decimal Price
        {
            get
            {
                return price_;
            }

            set
            {
                //IF the name of ingredient has changed
                if (price_ != value)
                {
                    price_ = value;
                    //Send property-changed notification to those that want to know
                    CatchPropertyChanged("Price");
                }
            }
        }

        public uint Energy
        {
            get
            {
                return energy_;
            }

            set
            {
                //IF the name of ingredient has changed
                if (energy_ != value)
                {
                    energy_ = value;
                    //Send property-changed notification to those that want to know
                    CatchPropertyChanged("Energy");
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
