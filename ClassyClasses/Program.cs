using System;

namespace ClassyClasses
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
    public Point Origin { get; }
    public Size Size { get; }

    public Rect()
    {
      this.Origin = new Point(0, 0);
      this.Size = new Size(0, 0);
    }

    public Rect(Point origin, Size size)
    {
      this.Origin = origin;
      this.Size = size;
    }

    public Rect(Point origin, int n)
    {
      this.Origin = origin;
      this.Size = new Size(n, n);
    }

     public Rect(int x, int y, int l, int w)
    {
      this.Origin = new Point(x, y);
      this.Size = new Size(l, w);
    }

    public void Translate(int x, int y)
    {
      this.Origin.X += x;
      this.Origin.Y += y;
    }

    public void Scale(int x, int y)
    {
      this.Size.Length *= x;
      this.Size.Width *= y;
    }

    public void Scale(int m)
    {
      this.Size.Length *= m;
      this.Size.Width *= m;
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      var point = new Point(0, 0); // Origin, {0, 0}
      var size = new Size(4, 3);
                     //    ^--- These are the arguments.

      // point.X, point.Y
      // size.Length, size.Width
      
      var oldTV = new Rect(point, size); // {0, 0}, {4, 3}
      Console.WriteLine($"My old TV is {oldTV.Size.Length} by {oldTV.Size.Width}.");

      var square = new Rect(point, 4);  // Square, {0, 0}, {4, 4}
      Console.WriteLine($"My square is {square.Size.Length} by {square.Size.Width}.");

      var newTV = new Rect(3, 4, 16, 10); // {3, 4} {19, 14}
      Console.WriteLine($"My new TV is {newTV.Size.Length} by {newTV.Size.Width}.");

      Console.WriteLine($"My new TV at {newTV.Origin.X},{newTV.Origin.Y}.");
      newTV.Translate(4, 10);

      // newTV.Origin = new Point(4, 10);
      Console.WriteLine($"My new TV now at {newTV.Origin.X},{newTV.Origin.Y}.");

      newTV.Scale(2, 2);

      Console.WriteLine($"My new TV is now {newTV.Size.Length} by {newTV.Size.Width}.");

      newTV.Scale(5);
      Console.WriteLine($"My new TV is now {newTV.Size.Length} by {newTV.Size.Width}.");
    }
  }
}
