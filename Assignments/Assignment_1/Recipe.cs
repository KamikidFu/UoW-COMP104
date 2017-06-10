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

    ///<summary>
    ///These following code(INotifyPropertyChanged Event Handling) is refered by Lecture 17 Programming demo writen by Robi.
    ///Thanks for hits and helps :-)
    ///</summary>
    public class Recipe : INotifyPropertyChanged
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
        ///Yield of recipe, e.g. "1" means 1 serving it normally produces, and the yield should be the unsigned integer
        ///</summary>
        private uint yield_;
        /// <summary>
        /// Previous yield for every recipes, like a reference when change yield, , and the yield should be the unsigned integer
        /// </summary>
        private uint previousYield_;
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
            previousYield_ = YIELD;
            instruction_ = INSTRUCTION;
            // Create an empty list of requirements for this new recipe
            Requirements_ = new BindingList<RecipeItems>();
            //Register decleared above is for a list-changed event to handler on the enrolment list.
            Requirements_.ListChanged += new ListChangedEventHandler(RequirementListChanged);
        }

        //***********************************
        //* Public Method        
       /// <summary>
       /// Calculate the cost of this recipe
       /// </summary>
       /// <param name="ingredientList">A ingredient reference list which at least contains price</param>
       /// <returns></returns>
        public double calculateCost(BindingList<Ingredient> ingredientList)
        {
            //Set up local varibles
            double cost = 0.0d;
            //For each required items to calculate the cost
            for(int i=0;i<requirements_.Count;i++)
            {
                //For each ingredients in the reference list passed into the method
                for(int j=0;j<ingredientList.Count;j++)
                {
                    //If the required item name is the same as ingredient name in passed list
                    if(requirements_[i].IngredientName==ingredientList[j].Name)
                    {
                        //Different units may in different cases to calculate the cost
                        if (requirements_[i].Unit == ingredientList[j].Unit)
                        {
                            //If the unit is same, simply add up the cost
                            cost = cost + (((double)ingredientList[j].Price / ingredientList[j].Default_Quantity) * requirements_[i].Quantity);
                        }
                        else if (requirements_[i].Unit == "lb" && ingredientList[j].Unit == "oz")
                        {
                            //If the units are lb and oz in item and list, due to 1 lb = 16 oz, the formula is as below
                            cost = cost + (((double)ingredientList[j].Price / ingredientList[j].Default_Quantity) * requirements_[i].Quantity * 16);
                        }
                        else if (requirements_[i].Unit == "tbsp" && ingredientList[j].Unit == "tsp")
                        {
                            //If the units are tbsp and tsp, due to 1 tbsp = 3 tsp, the formula is as below
                            cost = cost + (((double)ingredientList[j].Price / ingredientList[j].Default_Quantity) * requirements_[i].Quantity * 3);
                        }
                        else if(requirements_[i].Unit=="cup" && ingredientList[j].Unit=="tbsp")
                        {
                            //If the units are cup and tbsp, due to 1 cup = 16 tsp, the formula is as below
                            cost = cost + (((double)ingredientList[j].Price / ingredientList[j].Default_Quantity) * requirements_[i].Quantity * 16);
                        }
                        else if(requirements_[i].Unit=="cup"&&ingredientList[j].Unit=="tsp")
                        {
                            //If the units are cup and tsp, due to 1 cup = (16*3)48 tsp, the formula is as below
                            cost = cost + (((double)ingredientList[j].Price / ingredientList[j].Default_Quantity) * requirements_[i].Quantity * 48);
                        }
                        else if (requirements_[i].Unit == "kg" && ingredientList[j].Unit == "g")
                        {
                            //If the units are kg and g, due to 1 kg = 1000g, the formula is as below
                            cost = cost + (((double)ingredientList[j].Price / ingredientList[j].Default_Quantity) * requirements_[i].Quantity * 1000);
                        }
                        else if (requirements_[i].Unit == "l" && ingredientList[j].Unit == "ml")
                        {
                            //If the units are l and ml, due to 1 l = 1000ml, the formula is as below
                            cost = cost + (((double)ingredientList[j].Price / ingredientList[j].Default_Quantity) * requirements_[i].Quantity * 1000);
                        }
                    }
                }
            }
            //Return the cost value to where call the method
            return cost;
        }

        /// <summary>
        /// Calculate the energy of this recipe
        /// </summary>
        /// <param name="ingredientList">A ingredient reference list which at least contains price</param>
        /// <returns></returns>
        public double calculateEnergy(BindingList<Ingredient> ingredientList)
        {
            //Set up varible
            double energy = 0.0d;
            //For each required items to calculate the cost
            for (int i = 0; i < requirements_.Count; i++)
            {
                //For each ingredients in the reference list passed into the method
                for (int j = 0; j < ingredientList.Count; j++)
                {
                    //If the required item name is the same as ingredient name in passed list
                    if (requirements_[i].IngredientName == ingredientList[j].Name)
                    {
                        //Because there is not unit difference in energy, so just add them one by one
                        energy = energy + (((double)ingredientList[j].Energy / ingredientList[j].Default_Quantity) * requirements_[i].Quantity);
                    }
                }
            }
            //Return the energy value where call the method
            return energy;
        }

        /// <summary>
        /// Add ingredient which the recipe need
        /// </summary>
        /// <param name="RecipeNeedItem">A new RecipeItems object from ingredients</param>
        public void Add(RecipeItems RecipeNeedItem)
        {
            //Add required items into local list
            this.requirements_.Add(RecipeNeedItem);
        }

        /// <summary>
        /// Change the quantity when yield is changed by user
        /// </summary>
        /// <param name="newYield">The new yield value pass into method</param>
        public void changeQuantity(uint newYield)
        {
            //Calculate how many times the yield changed
            double yieldChange = (double)newYield / this.previousYield_;
            //For each items in local list to change the quantity
            for (int i = 0; i < requirements_.Count; i++)
            {
                //The new quantity is equal to the old quantity times the yieldChange
                requirements_[i].Quantity *= yieldChange;
            }
            //Save the yield value to previousYield varible for next change or call the method
            previousYield_ = newYield;
        }

        /// <summary>
        /// Change the unit when the radio button value is changed
        /// </summary>
        /// <param name="toUnit">Which unit is aimed to change to</param>
        public void changeUnit(string toUnit)
        {
            //If user wants to change unit to metric
            if (toUnit == "Metric")
            {                
                //For each items in local list as they need to be changed
                foreach (RecipeItems checkItems in this.requirements_)
                {
                    //Set varibles
                    //changedQuantity is for storing the result of exchanging units
                    double changedQuantity = 0.0d;
                    //New unit will store in this changedUnit string varible
                    string changedUnit = "";                    
                    //Different units cases in each items
                    if (checkItems.Unit == "cup" || checkItems.Unit == "cup ")
                    {
                        //If the item is cup or cup with a spare space
                        //Firstly change the quantity, due to 1 cup = 240 ml
                        changedQuantity = checkItems.Quantity * 240;
                        //If the final result is greater than 1000, the final unit need to be Liter, "l"
                        if (changedQuantity >= 1000)
                        {
                            //Divide 1000 to how many l
                            changedQuantity /= 1000;
                            //Change unit to l
                            changedUnit = "l";
                        }
                        else
                        {
                            //Or it is not over 1000, change unit to ml
                            changedUnit = "ml";
                        }
                    }
                    //change tbsp to ml
                    else if (checkItems.Unit == "tbsp" || checkItems.Unit=="tbsp ")
                    {
                        //1 tbsp = 15 ml
                        changedQuantity = checkItems.Quantity * 15;
                        changedUnit = "ml";
                    }
                    //change tsp to ml
                    else if (checkItems.Unit == "tsp" || checkItems.Unit == "tsp ")
                    {
                        //1 tsp = 5ml
                        changedQuantity = checkItems.Quantity * 5;
                        changedUnit = "ml";
                    }
                    //change lb to kg
                    else if (checkItems.Unit == "lb" || checkItems.Unit == "lb ")
                    {
                        //1 lb = 543.592 g
                        changedQuantity = checkItems.Quantity * 453.592;
                        //Over 1000?
                        if (changedQuantity >= 1000)
                        {
                            //1 kg = 1000 g
                            changedQuantity /= 1000;
                            changedUnit = "kg";
                        }
                        else
                        {
                            //Or just g
                            changedUnit = "g";
                        }
                    }
                    //change oz to g
                    else if (checkItems.Unit == "oz" || checkItems.Unit == "oz ")
                    {
                        //1oz=28.3495g
                        changedQuantity = checkItems.Quantity * 28.3495;
                        changedUnit = "g";
                    }
                    else { continue; }
                    //Update the property
                    checkItems.Quantity = changedQuantity;
                    checkItems.Unit = changedUnit;
                }
            }
            /*
             * Change unit from metric to imperial is similar to the code above***************************
             */
            if (toUnit == "Imperial")
            {
                foreach (RecipeItems checkItems in this.requirements_)
                {
                    double changedQuantity = 0.0d;
                    string changedUnit = "";
                    if (checkItems.Unit == "ml" || checkItems.Unit == "ml ")
                    {
                        changedQuantity = checkItems.Quantity / 5;
                        if (changedQuantity < 48)
                        {
                            if (changedQuantity > 10)
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
                    else if (checkItems.Unit == "l" || checkItems.Unit == "l ")
                    {
                        changedQuantity = checkItems.Quantity * 1000 / 240;
                        changedUnit = "cup";
                    }
                    else if (checkItems.Unit == "g" || checkItems.Unit == "g ")
                    {
                        changedQuantity = checkItems.Quantity / 28.3495;
                        if (changedQuantity <= 16)
                        {
                            changedUnit = "oz";
                        }
                        else
                        {
                            changedQuantity /= 16;
                            changedUnit = "lb";
                        }
                    }
                    else if (checkItems.Unit == "kg" || checkItems.Unit == "kg ")
                    {
                        changedQuantity = (checkItems.Quantity * 1000) / 28.3495;
                        if (changedQuantity <= 16)
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
                        continue;
                    }
                    checkItems.Quantity = changedQuantity;
                    checkItems.Unit = changedUnit;
                }
            }
        }

        //Update unit, this is for any uncommon amount to update to common amount unit
        public void updateUnit()
        {
            //Foreach recipe items to update
            foreach (RecipeItems checkItems in this.requirements_)
            {
                //tsp to other unit in same system
                //1 cup = 16 tbsp = 48 tsp
                if (checkItems.Unit == "tsp" && checkItems.Quantity > 10 && checkItems.Quantity < 48)
                {
                    checkItems.Quantity /= 3;
                    checkItems.Unit = "tbsp";
                }
                else if (checkItems.Unit == "tsp" && checkItems.Quantity >= 48)
                {
                    checkItems.Quantity /= 48;
                    checkItems.Unit = "cup";
                }
                //tbsp to other unit in same system
                //1 cup = 16 tbsp =48 tsp
                else if (checkItems.Unit == "tbsp" && checkItems.Quantity >= 16)
                {
                    checkItems.Quantity /= 16;
                    checkItems.Unit = "cup";
                }
                else if(checkItems.Unit=="tbsp")
                {
                    checkItems.Quantity *= 3;
                    checkItems.Unit = "tsp";
                }
                //oz to other unit in same system
                //1 lb = 16 oz
                else if (checkItems.Unit == "oz" && checkItems.Quantity > 16)
                {
                    checkItems.Quantity /= 16;
                    checkItems.Unit = "lb";
                }
                //g to other unit in same system
                //1kg = 1000g
                else if (checkItems.Unit == "g" && checkItems.Quantity > 1000)
                {
                    checkItems.Quantity /= 1000;
                    checkItems.Unit = "kg";
                }
                //ml to other unit in same system
                //1 l = 1000 ml
                else if (checkItems.Unit == "ml" && checkItems.Quantity > 1000)
                {
                    checkItems.Quantity /= 1000;
                    checkItems.Unit = "l";
                }
                //cup to other unit in same system
                //1 cup = 16 tbsp
                else if (checkItems.Unit == "cup" && checkItems.Quantity < 1)
                {
                    checkItems.Quantity *= 16;
                    checkItems.Unit = "tbsp";
                }
                //kg to other unit in same system
                //1kg = 1000g
                else if (checkItems.Unit == "kg" && checkItems.Quantity < 1)
                {
                    checkItems.Quantity *= 1000;
                    checkItems.Unit = "g";
                }
                //l to other unit in same system
                //1l=1000ml
                else if (checkItems.Unit == "l" && checkItems.Quantity < 1)
                {
                    checkItems.Quantity *= 1000;
                    checkItems.Unit = "ml";
                }
                else continue;
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
        public uint PreviousYield
        {
            get
            {
                return previousYield_;
            }

            set
            {
                previousYield_ = value;
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
