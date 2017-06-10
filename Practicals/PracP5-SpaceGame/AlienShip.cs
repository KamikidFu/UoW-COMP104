using System;
using System.Drawing;

namespace SpaceInvaders
{
  /// <summary>
  /// The alien ship moves backwards and forwards across the screen,
  /// gradually moving lower.  It drops bombs randomly.
  /// </summary>
  class AlienShip : Sprite
  {
    //####################################################################
    //# Instance Variables
    /// <summary>
    /// The direction and speed.  
    /// Positive moves right, negative moves left.
    /// </summary>
    private int speed_ = SPEED;
    /// <summary>
    /// The width of the space across which the alien moves.
    /// This is used to make the alien change direction when it hits the edge
    /// of the screen.
    /// </summary>
    private int widthOfSpace_;
    /// <summary>
    /// A random number generator, used to drop bombs.
    /// </summary>
    private Random random_ = new Random();

    //####################################################################
    //# Constants
    /// <summary>
    /// Width of the alien sprite's sensitive area. This is smaller than the
    /// full alien image, making the alien a little harder to hit.
    /// </summary>
    private const int WIDTH = 40;
    /// <summary>
    /// Height of the alien sprite's sensitive area.
    /// </summary>
    private const int HEIGHT = 20;
    /// <summary>
    /// The amount in pixels by which the alien ship moves horizontally each tick.
    /// </summary>
    private const int SPEED = 3;
    /// <summary>
    /// The amount in pixels by which the alien ship advances downward each
    /// time it reaches the edge of the screen.
    /// </summary>
    private const int ADVANCE = 5;

    //####################################################################
    //# Constructor
    /// <summary>
    /// Creates a new alien ship for a screen with the given width.
    public AlienShip(int screenWidth)
      : base(0, 0, WIDTH, HEIGHT)
    {
      widthOfSpace_ = screenWidth;
            this.SpriteName = "Alien Ship";
    }

    //####################################################################
    //# Public Methods
    /// <summary>
    /// Moves the alien ship left or right. When the edge of the screen
    /// is reached, reverses the direction and moves the alien down.
    /// </summary>
    public override void Move()
    {
      X += speed_;
      if (X < 0 || X + Width > widthOfSpace_) {
        speed_ = -speed_;
        Y += ADVANCE;
      }
    }

    /// <summary>
    /// Displays the alien image.
    /// </summary>
    public override void Draw(Graphics graphics)
    {
      graphics.DrawImageUnscaled(Properties.Resources.alien, X, Y);
    }

    /// <summary>
    /// Chooses whether or not to drop a bomb.
    /// </summary>
    /// <returns>A new bomb, or null.</returns>
    public AlienBomb LaunchBomb()
    {
      if (random_.Next(100) < 5) {  // 5% chance to drop a bomb
        return new AlienBomb(X + Width / 2, Y + Height + ADVANCE);
      } else {
        return null;
      }
    }
  }
}
