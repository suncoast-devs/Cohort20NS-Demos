using System;

namespace ClassyClasses
{
  class Point
  {
    int _SecretX;
    int _SecretY;
    int _AccessCounter;

    public Point(int x, int y)
    {
      this.X = x;
      this.Y = y;
    }

    public int X
    {
      get
      {
        this._AccessCounter++;
        return this._SecretX;
      }
      set
      {
        this._AccessCounter++;
        this._SecretX = value;
      }
    }

    public int Y
    {
      get
      {
        this._AccessCounter++;
        return this._SecretY;
      }
      set
      {
        this._AccessCounter++;
        this._SecretY = value;
      }
    }

    public int AccessCount
    {
      get => _AccessCounter;
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      var point = new Point(10, 20); // Origin, {0, 0} <--

      Console.WriteLine($"X is {point.X}");
      Console.WriteLine($"Y is {point.Y}");

      point.Y = 32; // <--

      Console.WriteLine($"Y is {point.Y}");

      Console.WriteLine($"The point was accessed {point.AccessCount} times.");
    }
  }
}
