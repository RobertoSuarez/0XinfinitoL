using System;

public class Point
{
    public int X;
    public int Y;
    Point parent;
    public Point(int x, int y, Point p)
    {
        X = x;
        Y = y;
        parent = p;
    }

    public Point opposite()
    {
        if (X.CompareTo(parent.X) != 0)
        {
            return new Point(X + X.CompareTo(parent.X), Y, this);
        }
        if (Y.CompareTo(parent.Y) != 0)
        {
            return new Point(X, Y + Y.CompareTo(parent.Y), this);
        }
        return null;
    }
}