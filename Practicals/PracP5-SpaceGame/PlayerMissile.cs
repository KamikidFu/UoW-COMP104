using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SpaceInvaders
{
    //4.1 New Class
    class PlayerMissile:Sprite
    { 
        //4.2 4 wide, 12 tall
        private const int WIDTH = 4;
        private const int HEIGHT = 12;
        public PlayerMissile(int x, int y) : base(x, y,WIDTH,HEIGHT)
        {
            X = x;
            Y = y;
            this.SpriteName = "Player Missile";
        }
        //4.3 Move it with 4 speed
        public override void Move()
        {
            Y -= 4;
        }
       
        //4.X? Draw method
        public override void Draw(Graphics graphics)
        {
            graphics.FillRectangle(Brushes.Yellow, X, Y, WIDTH, HEIGHT);
        }

    }
}
