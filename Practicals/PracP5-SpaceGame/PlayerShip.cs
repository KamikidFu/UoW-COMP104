using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace SpaceInvaders
{
    class PlayerShip:Sprite
    {
        //1.1 Width and height
        private const int WIDTH= 32;
        private const int HEIGHT = 16;

        //1.2 Constructor
        public PlayerShip(int widthOFPictureBox, int heightOFPictureBox)
            :base(widthOFPictureBox,heightOFPictureBox,WIDTH,HEIGHT)
        {
            X = widthOFPictureBox / 2;
            Y = heightOFPictureBox - HEIGHT;
            this.SpriteName = "Player Ship";
        }

        //1.3 Override Draw Method
        public override void Draw(Graphics graphics)
        {
            //Draw body
            graphics.FillRectangle(Brushes.DarkGreen, this.X,this.Y,WIDTH,HEIGHT);
            //Draw Gun
            graphics.FillRectangle(Brushes.DarkGreen, (this.X + (this.Width / 2) - 5), this.Y - 10, 10, 10);
        }

        //1.4 Override Move Method
        public override void Move()
        {
            //throw new NotImplementedException();
        }

        //3.1 MoveTo Method
        public void MoveTo(int x)
        {
            //Force to refresh
            this.X = 0;
            this.X = x;
        }

        //4.4 LauchMissile Method
        public PlayerMissile LauchMissile()
        {
            return new PlayerMissile(this.X + (this.Width / 2), this.Y - 10);
        }
    }
}
