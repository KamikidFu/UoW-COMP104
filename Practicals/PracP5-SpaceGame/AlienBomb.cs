using System;
using System.Drawing;

namespace SpaceInvaders
{
  /// <summary>
  /// A bomb dropped by the alien ship.
  /// Moves downwards at constant speed.
  /// </summary>
  class AlienBomb : Sprite
  {
    //####################################################################
    //# Constants
    /// <summary>
    /// The constant width of the bomb.
    /// </summary>
    private const int WIDTH = 20;
    /// <summary>
    /// The constant height of the bomb.
    /// </summary>
    private const int HEIGHT = 10;
    /// <summary>
    /// The amount in pixels by which the bomb drops down each tick.
    /// </summary>
    private const int SPEED = 3;

    //####################################################################
    //# Constants
    /// <summary>
    /// Creates a new bomb at the given position.
    /// </summary>
    /// <param name="xpos">The x coordinate of the center of the bomb.</param>
    /// <param name="ypos">The y corrdinate of the top of the bomb.</param>
    public AlienBomb(int xpos, int ypos)
      : base(xpos - WIDTH / 2, ypos, WIDTH, HEIGHT)
    {
            this.SpriteName = "Alien Bomb";
    }

    //####################################################################
    //# Public Methods
    /// <summary>
    /// Moves the bomb downwards according to its speed.
    /// </summary>
    public override void Move()
    {
      Y += SPEED;
    }

    /// <summary>
    /// Draws the bomb as a grey ellipse.
    /// </summary>
    public override void Draw(Graphics paper)
    {
      paper.FillEllipse(Brushes.Gray, X, Y, WIDTH, HEIGHT);
    }
  }
}
