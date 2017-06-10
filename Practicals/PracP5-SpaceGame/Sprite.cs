using System;
using System.Drawing;


namespace SpaceInvaders
{
  /// <summary>
  /// Superclass of all movable objects in the Space Invaders game.
  /// </summary>
  public abstract class Sprite
  {
    //####################################################################
    //# Instance Variables
    /// <summary>
    /// The x coordinate of the left edge of the sprite.
    /// </summary>
    private int x_;
    /// <summary>
    /// The y corrdinate of the top of the sprite.
    /// </summary>
    private int y_;
    /// <summary>
    /// The width of the sprite in pixels.
    /// </summary>
    private int width_;
    /// <summary>
    /// The height of the sprite in pixels.
    /// </summary>
    private int height_;
        private string spriteName;

        //####################################################################
        //# Constructor
        /// <summary>
        /// Creates a new sprite with the given size and position.
        /// </summary>
        public Sprite(int x, int y, int width, int height)
    {
      x_ = x;
      y_ = y;
      width_ = width;
      height_ = height;
    }


    //####################################################################
    //# Public Methods
    /// <summary>
    /// Moves the srpite. This method is called once during each animation
    /// tick to move the sprite by a small amount.
    /// </summary>
    public abstract void Move();

    /// <summary>
    /// Displayes the sprite in the given graphics context.
    /// </summary>
    public abstract void Draw(Graphics graphics);

    /// <summary>
    /// Determines whether or not the sprite has collided with the given
    /// other sprite.
    /// </summary>
    /// <param name="other">The second sprite to be checked for collision.</param>
    /// <returns>true if the two sprites are different and their bounding boxes overlap,
    /// false otherwise.</returns>
    public bool HasCollidedWith(Sprite other)
    {
      if (this == other) {
        return false;  // Never a collision with the object itself!
      } else {
        Rectangle bbox1 = BoundingBox;
        Rectangle bbox2 = other.BoundingBox;
        return bbox1.IntersectsWith(bbox2);
      }
    }


    //####################################################################
    //# Public Properties
    /// <summary>
    /// The x coordinate of the left edge of the sprite.
    /// </summary>
    public int X
    {
      get
      {
        return x_;
      }
      set
      {
        x_ = value;
      }
    }

    /// <summary>
    /// The y corrdinate of the top of the sprite.
    /// </summary>
    public int Y
    {
      get
      {
        return y_;
      }
      set
      {
        y_ = value;
      }
    }

    /// <summary>
    /// The width of the sprite in pixels.
    /// </summary>
    public int Width { get { return width_; } set { width_ = value; } }

    /// <summary>
    /// The height of the sprite in pixels.
    /// </summary>
    public int Height { get { return height_; } set { width_ = value; } }


    //####################################################################
    //# Public Properties
    /// <summary>
    /// A rectangle representing the sprite's area sensitive for collision checking. 
    /// </summary>
    private Rectangle BoundingBox
    {
      get
      {
        return new Rectangle(x_, y_, width_, height_);
      }
    }

        public string SpriteName
        {
            get
            {
                return spriteName;
            }

            set
            {
                spriteName = value;
            }
        }
    }
}
