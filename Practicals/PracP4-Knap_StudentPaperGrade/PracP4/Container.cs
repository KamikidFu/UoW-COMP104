using System;
using System.ComponentModel;

namespace PracP4
{
  public class Container
  {
    //#####################################################################
    //# Instance Variables
    private string name_;
    private double maxWeight_;
    private double maxVolume_;
    private BindingList<Item> contents_;

    //#####################################################################
    //# Constructor
    public Container(string name, double maxWeight, double maxVolume)
    {
      name_ = name;
      maxWeight_ = maxWeight;
      maxVolume_ = maxVolume;
      contents_ = new BindingList<Item>();
    }

    //#####################################################################
    //# Public Methods
    public void Add(Item item)
    {
      contents_.Add(item);
    }

    //#####################################################################
    //# Properties
    public string Name { get { return name_; } }
    public double MaxWeight { get { return maxWeight_; } }
    public double MaxVolume { get { return maxVolume_; } }
    public BindingList<Item> Contents { get { return contents_; } }

        /*
        Task 1: Add three read-only properties PackedWeight, etc...
        Return appropriate sums
        */
        public double PackedWeight
        {
            get
            {
                double sumOfWeight = 0.0d;
                for (int i = 0; i < contents_.Count; i++)
                    sumOfWeight += contents_[i].Weight;
                return sumOfWeight;
            }
        }
        public double PackedVolume
        {
            get
            {
                double sumOfVolume = 0.0d;
                for (int i = 0; i < contents_.Count; i++)
                    sumOfVolume += contents_[i].Volume;
                return sumOfVolume;
            }
        }
        public decimal PackedValue
        {
            get
            {
                decimal sumOfValue = 0.0m;
                for (int i = 0; i < contents_.Count; i++)
                    sumOfValue += contents_[i].Value;
                return sumOfValue;
            }
        }
    }
}
