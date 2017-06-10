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
        ///Yield of recipe, e.g. "1" means 1 serving it normally produces
        ///</summary>
        private uint yield_;
        /// <summary>
        /// Previous yield for every recipes, like a reference when change yield.
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
        public Recipe(string NAME, uint YIELD)
        {
            // Initialise variable
            name_ = NAME;
            yield_ = YIELD;
            previousYield_ = YIELD;
            instruction_ = "";
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
            double cost = 0.0d;
            for(int i=0;i<requirements_.Count;i++)
            {
                for(int j=0;j<ingredientList.Count;j++)
                {
                    if(requirements_[i].IngredientName==ingredientList[j].Name)
                    {
                        cost = cost + (((double)ingredientList[j].Price / ingredientList[j].Default_Quantity) * requirements_[i].Quantity);
                    }
                }
            }
            return cost;
        }
        /// <summary>
        /// Calculate the energy of this recipe
        /// </summary>
        /// <param name="ingredientList">A ingredient reference list which at least contains price</param>
        /// <returns></returns>
        public double calculateEnergy(BindingList<Ingredient> ingredientList)
        {
            double energy = 0.0d;
            for (int i = 0; i < requirements_.Count; i++)
            {
                for (int j = 0; j < ingredientList.Count; j++)
                {
                    if (requirements_[i].IngredientName == ingredientList[j].Name)
                    {
                        energy = energy + (((double)ingredientList[j].Energy / ingredientList[j].Default_Quantity) * requirements_[i].Quantity);
                    }
                }
            }
            return energy;
        }
        /// <summary>
        /// Add ingredient which the recipe need
        /// </summary>
        /// <param name="RecipeNeedItem">A new RecipeItems object from ingredients</param>
        public void Add(RecipeItems RecipeNeedItem)
        {
            this.requirements_.Add(RecipeNeedItem);
        }

        public void changeQuantity(uint newYield)
        {
            double yieldChange = (double)newYield / this.previousYield_;
            for (int i = 0; i < requirements_.Count; i++)
            {
                requirements_[i].Quantity *= yieldChange;
            }
            previousYield_ = newYield;
        }

        public void changeUnit(string toUnit)
        {
            if (toUnit == "Metric")
            {
                //bool needChange = false;
                //for(int i =0;i<this.requirements_.Count;i++)
                //{
                //    if (this.requirements_[i].Unit == "ml" || this.requirements_[i].Unit == "g" || this.requirements_[i].Unit == "kg" || this.requirements_[i].Unit == "l")
                //    {
                //        needChange = false;
                //    }
                //    else
                //    {
                //        needChange = true;
                //    }
                //}
                foreach (RecipeItems checkItems in this.requirements_)
                {
                    //if (checkItems.Unit == "cup" || checkItems.Unit == "tbsp" || checkItems.Unit == "tsp" || checkItems.Unit == "lb" || checkItems.Unit == "oz") 
                    //{
                    //Change Unit
                    //checkItems.Quantity = changedQuantity;
                    //checkItems.Unit = changedUnit;
                    double changedQuantity = 0.0d;
                    string changedUnit = "";                    
                    if (checkItems.Unit == "cup")
                    {
                        changedQuantity = checkItems.Quantity * 240;
                        if (changedQuantity > 1000)
                        {
                            changedQuantity /= 1000;
                            changedUnit = "l";
                        }
                        else
                        {
                            changedUnit = "ml";
                        }
                    }
                    else if (checkItems.Unit == "tbsp")
                    {
                        changedQuantity = checkItems.Quantity * 15;
                        changedUnit = "ml";
                    }
                    else if (checkItems.Unit == "tsp")
                    {
                        changedQuantity = checkItems.Quantity * 5;
                        changedUnit = "ml";
                    }
                    else if (checkItems.Unit == "lb")
                    {
                        changedQuantity = checkItems.Quantity * 453.592;
                        if (changedQuantity > 1000)
                        {
                            changedQuantity /= 1000;
                            changedUnit = "kg";
                        }
                        else
                        {
                            changedUnit = "g";
                        }
                    }
                    else if (checkItems.Unit == "oz")
                    {
                        changedQuantity = checkItems.Quantity * 28.3495;
                        changedUnit = "g";
                    }
                    else
                    {
                        continue;
                    }
                }
            }
            else if (toUnit == "Imperial")
            {
                foreach (RecipeItems checkItems in this.requirements_)
                {
                    double changedQuantity = 0.0d;
                    string changedUnit = "";
                    if (checkItems.Unit == "ml")
                    {
                        changedQuantity = checkItems.Quantity / 5;
                        if (changedQuantity>5)
                        {
                            changedQuantity /= 3;
                            changedUnit = "tbsp";
                        }
                        else
                        {
                            changedUnit = "tsp";
                        }
                    }
                    else if (checkItems.Unit == "l")
                    {
                        changedQuantity = checkItems.Quantity / 240;
                        changedUnit = "cup";
                    }
                    else if (checkItems.Unit == "g")
                    {
                        changedQuantity = checkItems.Quantity / 28.3495;
                        if(changedQuantity<16)
                        {
                            changedUnit = "oz";
                        }
                        else
                        {
                            changedQuantity /= 16;
                            changedUnit = "lb";
                        }
                    }
                    else if (checkItems.Unit == "kg")
                    {
                        changedQuantity = (checkItems.Quantity * 1000) / 28.3495;
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
                        continue;
                    }
                    checkItems.Quantity = changedQuantity;
                    checkItems.Unit = changedUnit;
                }
            }
            else
            {
                return;
            }
            //if(needChange)
            //{
            //    foreach(RecipeItems items in this.requirements_)
            //    {
            //        if(items.Unit=="cup"|| items.Unit == "tbsp"||items.Unit=="tsp")                                                  
            //    }
            //}


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
