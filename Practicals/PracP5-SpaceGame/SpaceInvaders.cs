using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace SpaceInvaders
{
  /// <summary>
  /// A simple game of space invaders.
  /// </summary>
  public partial class SpaceInvaders : Form
  {

    //####################################################################
    //# Instance Variables
    /// <summary>
    /// List of all sprites.
    /// </summary>
    private List<Sprite> sprites_;
    /// <summary>
    /// The alien ship. It is also included in the list of sprites,
    /// but the separate variable helps to invoke the alien's special
    /// method to drop bombs.
    /// </summary>
        private AlienShip alien_;
        private PlayerShip playerShip_;
        //private bool isExplosed = false;
        //####################################################################
        //# Constructor
        /// <summary>
        /// Initialise the Space Invaders game.
        /// </summary>
        public SpaceInvaders()
    {
      InitializeComponent();
      MinimumSize = Size;
      MaximumSize = Size;
      sprites_ = new List<Sprite>();
      alien_ = new AlienShip(pictureBox_.Width);
            playerShip_ = new PlayerShip(pictureBox_.Width, pictureBox_.Height);
      sprites_.Add(alien_);
            sprites_.Add(playerShip_);
            
           
        }

        //####################################################################
        //# Event Handlers
        /// <summary>
        /// Tick handler of animation timer.
        /// This code is executed repeatedly at regular time intervals.
        /// </summary>
        private void animationTimer__Tick(object sender, EventArgs e)
    {
            
            // Move all sprites.
            foreach (Sprite sprite in sprites_) {
        sprite.Move();
      }
      // Check whether the alien wants to drop a bomb.
      AlienBomb bomb = alien_.LaunchBomb();
      if (bomb != null) {
        sprites_.Add(bomb);
      }
      // Make sure all changes are displayed.
      Refresh();
            // Check for collisions.
            foreach (Sprite sprite in sprites_)
            {
                
                if (sprite.HasCollidedWith(alien_))
                {
                    //###############################################################################################
                    //7.1 Explosion                  
                    //############################################################################################### 
                    sprites_.Clear();
                    //isExplosed = true;
                    Explosion ex = new Explosion(alien_.X + (alien_.Width / 2), alien_.Y + (alien_.Height / 2), 50, 50);
                    sprites_.Add(ex);
                    animationTimer_.Stop();
                    ExplosionTimer_.Start();
                    if (MessageBox.Show("GOOD JOB!" + "\n" + "The Alien ship has been hit! Player wins." + "\n" + "Restart game?", "Nice",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ExplosionTimer_.Stop();
                        Application.Restart();
                    }
                    else { Application.Exit(); }
                    break;
                }
                else if (sprite.HasCollidedWith(playerShip_))
                {
                    sprites_.Clear();
                    //isExplosed = true;
                    Explosion ex = new Explosion(playerShip_.X + (playerShip_.Width / 2), playerShip_.Y + (playerShip_.Height / 2), 50, 50);
                    sprites_.Add(ex);
                    animationTimer_.Stop();
                    ExplosionTimer_.Start();
                    if (MessageBox.Show("*GAME OVER*"+"\n"+"The player ship has been hit! Alien wins."+"\n"+"Restart game?", "Ops...", 
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        ExplosionTimer_.Stop();
                        Application.Restart();
                    }
                    else { Application.Exit(); }                    
                    break;
                }
            }
            //5.1 Clear the memory
            for (int i=0;i<sprites_.Count;i++)
            {
                for(int j=0;j<sprites_.Count;j++)
                {
                    if (i < sprites_.Count && j < sprites_.Count)
                    {
                        if (sprites_[i].SpriteName == "Alien Bomb" && sprites_[j].SpriteName == "Player Missile")
                        {
                            AlienBomb alienBomb = (AlienBomb)sprites_[i];
                            PlayerMissile playerMissile = (PlayerMissile)sprites_[j];
                            if (alienBomb.HasCollidedWith(playerMissile))
                            {
                                sprites_.Remove(alienBomb);
                                sprites_.Remove(playerMissile);
                            }
                            else if (alienBomb.Y > pictureBox_.Height)
                            {
                                sprites_.Remove(alienBomb);
                            }
                            else if (playerMissile.Y < 0)
                            {
                                sprites_.Remove(playerMissile);
                            }
                        }
                    }
                }
            }
    }

        /// <summary>
        /// Paint event handler. This is called when the form needs repainting,
        /// or in response to the Refresh() method call above. It simply displays
        /// all sprites in the correct graphics context.
        /// </summary>
        private void SpaceInvaders_Paint(object sender, PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;
            graphics.Clear(Color.Black);
            foreach (Sprite sprite in sprites_)
            {
                //if (!isExplosed)
                //{
                //    sprite.Draw(graphics);
                //}
                //else
                //{
                //    if (sprite.SpriteName == "Explosion")
                //    {
                //        sprite.Draw(graphics);
                //    }
                //}
                sprite.Draw(graphics);
            }

        }

        private void pictureBox__MouseMove(object sender, MouseEventArgs e)
        {
            int shipIndex = 0;
            for (int i = 0; i < sprites_.Count; i++)
            {
                if (sprites_[i].SpriteName == "Player Ship")
                {
                    shipIndex = i;
                    break;
                }
            }
            if (shipIndex != 0)
            {
                PlayerShip playerShip = (PlayerShip)sprites_[shipIndex];
                if (e.X < 420 && e.X > 0)
                {
                    playerShip.MoveTo(e.X);
                }
            }
        }

        private void pictureBox__MouseClick(object sender, MouseEventArgs e)
        {
            int shipIndex = -1;
            int missileIndex = -1;
            for (int i = 0; i < sprites_.Count; i++)
            {
                if (sprites_[i].SpriteName == "Player Ship")
                {
                    shipIndex = i;
                    break;
                }
            }
            for(int i=0;i<sprites_.Count;i++)
            {
                if(sprites_[i].SpriteName=="Player Missile")
                {
                    missileIndex = i;
                    break;
                }
            }
            //6.1 Only one missile in screen
            if (shipIndex != -1 && missileIndex==-1)
            {
                PlayerShip playerShip = (PlayerShip)sprites_[shipIndex];
                sprites_.Add(playerShip.LauchMissile());
            }
            pictureBox_.Refresh();
        }

        private void ExplosionTimer__Tick(object sender, EventArgs e)
        {
            animationTimer_.Stop();
            // Move all sprites.
            foreach (Sprite sprite in sprites_)
            {
                sprite.Move();
            }              
            Refresh();
        }

        //private void DrawExplosion(Graphics paper, Sprite obj)
        //{
        //    int diameter = 50;
        //    while (diameter != 0)
        //    {
        //        paper.FillEllipse(Brushes.Red, ((obj.X + obj.Width / 2) - diameter/2), (obj.Y + obj.Height / 2) - diameter/2, diameter, diameter);
        //        diameter -= 10;
        //    }
        //}

        //private void Delay(int Millisecond) //延迟系统时间，但系统又能同时能执行其它任务；
        //{
        //    DateTime current = DateTime.Now;
        //    while (current.AddMilliseconds(Millisecond) > DateTime.Now)
        //    {
        //        Application.DoEvents();//转让控制权            
        //    }
        //    return;
        //}
    }
}