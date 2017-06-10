using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace PracP3
{
    class Plant
    {
        //Properties
        public string Name { get; set; }
        public int Size { get; set; }
        public decimal Cost { get; set; }
        public bool selected_ { get; set; }

        private int _x, _y; //position of plant

        //Constructor
        public Plant(string name, int size, decimal cost, int x, int y)
        {
            Name = name;
            Size = size;
            Cost = cost;
            _x = x;
            _y = y;
        }

        //Methods
        public void DrawPlant(Graphics paper)
        {
            paper.FillEllipse(Brushes.Green, _x - Size / 2, _y - Size / 2, Size, Size);
        }

        public void DrawPlant(Graphics paper, bool selected)
        {
            Pen p1 = new Pen(Color.Red, 3);
            if (selected)            
                paper.DrawEllipse(p1, _x - Size / 2, _y - Size / 2, Size, Size);
        }

        //Override method
        public override string ToString()
        {
            return Name.PadRight(25) + Size.ToString().PadLeft(4) + "cm wide at " +
               "(" + _x.ToString().PadLeft(3) + "," + _y.ToString().PadLeft(3) + ")" + Cost.ToString("c").PadLeft(10);
        }

        //Check the plant is clicked
        public bool IsClicked(int x, int y)
        {
            if(((x-_x)*(x-_x))+((y-_y)*(y-_y))<=((Size/2)*(Size/2)))
            {
                return true;
            }
            else { return false; }
        }
    }
}
