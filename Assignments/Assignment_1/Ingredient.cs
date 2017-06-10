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
    public class Ingredient : INotifyPropertyChanged
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
        //Method for task 3 e).
        public void changeUnit(string toUnit)
        {
            //Check which unit's measure system that the user want to use.
            //If user choose "Metric".
            if (toUnit == "Metric")
            {
                //Set two variables to change the volume units.
                //One for the quantity and one for the unit.
                double changedQuantity = 0.0d;
                string changedUnit = "";
                //If the unit which the user want to change is "cup".
                if (this.unit_ == "cup")
                {
                    //Then change the quantity, 1 cup is 240ml.
                    changedQuantity = this.defaultQuantity_ * 240;
                    //If the quantity is greater than 1000, then it will be measured in "l", not "ml".
                    if (changedQuantity > 1000)
                    {
                        changedQuantity /= 1000;
                        changedUnit = "l";
                    }
                    //Else the quantity will be measured in "ml".
                    else
                    {
                        changedUnit = "ml";
                    }
                }
                //Else if the unit which the user want to change is "tbsp".
                else if (this.unit_ == "tbsp")
                {
                    //Then change the quantity, 1 tbsp is 15 ml.
                    changedQuantity = this.defaultQuantity_ * 15;
                    changedUnit = "ml";
                }
                //Else if the unit which the user want to change is "tsp".
                else if (this.unit_ == "tsp")
                {
                    //Then chang the quantity, 1 tsp is 5 ml.
                    changedQuantity = this.defaultQuantity_ * 5;
                    changedUnit = "ml";
                }
                //Else if the unit which the user want to change is "lb".
                else if (this.unit_ == "lb")
                {
                    //Then chang the quantity, 1 lb is 453.592 g.
                    changedQuantity = this.defaultQuantity_ * 453.592;
                    //If the quantity is greater than 1000, then it will be maesured in "kg" instead of "g".
                    if (changedQuantity > 1000)
                    {
                        changedQuantity /= 1000;
                        changedUnit = "kg";
                    }
                    //Else the quantity will be measured in "g".
                    else
                    {
                        changedUnit = "g";
                    }
                }
                //Else if the unit which the user want to change is "oz".
                else if (this.unit_ == "oz")
                {
                    //Then change the quantity, 1 oz is 28.3495 g.
                    changedQuantity = this.defaultQuantity_ * 28.3495;
                    changedUnit = "g";
                }
                //Else, do nothing.
                else { return; }
                //Change the quantity and the unit in datagirdview.
                this.defaultQuantity_ = changedQuantity;
                this.unit_ = changedUnit;
            }
            //If user choose "Imperial".
            if (toUnit == "Imperial")
            {
                //Set two variables to change the volume units.
                //One for the quantity and one for the unit.
                double changedQuantity = 0.0d;
                string changedUnit = "";
                //If the unit which the user want to change is "ml".
                if (this.unit_ == "ml")
                {
                    //Yi bu yi bu to ce ta!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!Hello??????
                    //Then the changed quantity will be measured in "tbsp". 5 ml is 1 tsp.
                    //changedQuantity = (int)this.defaultQuantity_ / 5;
                    ////The max quantity for things measured in teaspoon i
                    //if (changedQuantity > 10)
                    //{
                    //    changedQuantity /= (int)3;
                    //    changedUnit = "tbsp";
                    //}
                    //else
                    //{
                    //    changedUnit = "tsp";
                    //}
                    changedQuantity = this.defaultQuantity_ / 5;
                    if(changedQuantity<48)
                    {
                        if(changedQuantity>10)
                        {
                            changedQuantity /= 3;
                            changedUnit = "tbsp";
                        }
                        else
                        {
                            changedUnit = "tsp";
                        }
                    }
                    else
                    {
                        changedQuantity /= 48;
                        changedUnit = "cup";
                    }
                }
                else if (this.unit_ == "l")
                {
                    changedQuantity = this.defaultQuantity_ / 240;
                    changedUnit = "cup";
                }
                else if (this.unit_ == "g")
                {
                    changedQuantity = this.defaultQuantity_ / 28.3495;
                    if (changedQuantity < 16)
                    {
                        changedUnit = "oz";
                    }
                    else
                    {
                        changedQuantity /= 16;
                        changedUnit = "lb";
                    }
                }
                else if (this.unit_ == "kg")
                {
                    changedQuantity = (this.defaultQuantity_ * 1000) / 28.3495;
                    if (changedQuantity < 16)
                    {
                        changedUnit = "oz";
                    }
                    else
                    {
                        changedQuantity /= 16;
                        changedUnit = "lb";
                    }
                }
                else
                {
                    return;
                }
                this.defaultQuantity_ = changedQuantity;
                this.unit_ = changedUnit;
            }
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
