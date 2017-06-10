using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SpaceInvaders
{
    class Explosion : Sprite
    {
        private int diameter;
        public Explosion(int x, int y, int width, int height) : base(x, y, width, height)
        {
            //input x,y are the object's, which need explosion, centre x,y.
            this.X = x - this.Width / 2;
            this.Y = y - this.Height / 2;
            diameter = width;
            diameter = height;
            this.SpriteName = "Explosion";
        }
        public override void Move()
        {
            //Move is to change the size of explosion
            if(diameter>0)
            {
                this.X += 5;
                this.Y += 5;
                diameter -= 10;
            }
        }
        public override void Draw(Graphics graphics)
        {
            graphics.FillEllipse(Brushes.Red, this.X, this.Y, diameter, diameter);
        }
    }
}
