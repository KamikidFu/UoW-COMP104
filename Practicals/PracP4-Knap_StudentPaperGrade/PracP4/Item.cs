using System;

namespace PracP4
{
  public class Item
  {
    //#####################################################################
    //# Instance Variables
    private string name_;
    private double weight_;
    private double volume_;
    private decimal value_;

    //#####################################################################
    //# Constructor
    public Item(string name, double weight, double volume, decimal value)
    {
      name_ = name;
      weight_ = weight;
      volume_ = volume;
      value_ = value;
    }

    //#####################################################################
    //# Instance Variables
    public string Name { get { return name_; } }
    public double Weight { get { return weight_; } }
    public double Volume { get { return volume_; } }
    public decimal Value { get { return value_; } }
  }
}
