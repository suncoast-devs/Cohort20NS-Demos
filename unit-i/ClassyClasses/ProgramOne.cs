using System;

namespace ClassyClassesOld
{

  class Size
  {
    public int Length;
    public int Width;

    public Size(int l, int w) // <--- These are the parameters.
    {
      this.Length = l;
      this.Width = w;
    }
  }

  class Point
  {
    public int X;
    public int Y;

    public Point(int x, int y)
    {
      this.X = x;
      this.Y = y;
    }
  }

  class Rect
  {
    // public Point Origin;
    Point _Origin;
    Size _Size;

    // Create an empty Rect
    public Rect()
    {
      this._Origin = new Point(0, 0);
      this._Size = new Size(0, 0);
    }

    // Create a Rect, with a given Point and Size
    public Rect(Point origin, Size size)
    {
      this._Origin = origin;
      this._Size = size;
    }

    // Create a Square
    public Rect(Point origin, int n)
    {
      this._Origin = origin;
      this._Size = new Size(n, n);
    }

    // Create an Rect given two coordinates (x and y) and two dimensions (length and width)
     public Rect(int x, int y, int l, int w)
    {
      this._Origin = new Point(x, y);
      this._Size = new Size(l, w);
    }

    public void Translate(int x, int y)
    {
      this._Origin.X += x;
      this._Origin.Y += y;
    }

    public void Scale(int x, int y)
    {
      this._Size.Width *= x;
      this._Size.Length *= y;
    }

    public void Scale(int m)
    {
      this._Size.Length *= m;
      this._Size.Width *= m;
    }

    public Point Origin
    {
      get
      {
        return _Origin;
      }

      set
      {
        this._Origin = value;
      }
    }

     public Size Size
    {
      get
      {
        return _Size;
      }
    }

    public string Info
    {
      get
      {
        return $"LEFT: {this.Origin.X}, RIGHT: {this.Origin.X + this.Size.Width}, TOP: {this.Origin.Y + this.Size.Length}, BOTTOM: {this.Origin.Y}";
      }
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      var point = new Point(0, 0); // Origin, {0, 0}
    }
  }
}
