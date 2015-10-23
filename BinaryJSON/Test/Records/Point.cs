using System;

[Serializable]
public struct Point
{
    public static readonly Point Zero = new Point(0, 0);
    public static readonly Point One = new Point(1, 1);

    public int x;
    public int y;

    public Point(int x = 0, int y = 0)
    {
        this.x = x;
        this.y = y;
    }

    public Point(Point point)
    {
        x = point.x;
        y = point.y;
    }
    public static Point operator -(Point s1, Point s2)
    {
        return new Point(s1.x - s2.x, s1.y - s2.y);
    }

    public static Point operator *(Point s1, Point s2)
    {
        return new Point(s1.x * s2.x, s1.y * s2.y);
    }

    public static Point operator *(Point s1, float s2)
    {
        return new Point((int)(s1.x * s2), (int)(s1.y * s2));
    }

    public static Point operator *(Point s1, int s2)
    {
        return new Point(s1.x * s2, s1.y * s2);
    }

    public static Point operator /(Point s1, Point s2)
    {
        return new Point(s1.x / s2.x, s1.y / s2.y);
    }

    public static Point operator /(Point s1, float s2)
    {
        return new Point((int)(s1.x / s2), (int)(s1.y / s2));
    }

    public static Point operator /(Point s1, int s2)
    {
        return new Point(s1.x / s2, s1.y / s2);
    }

    public static bool operator ==(Point s1, Point s2)
    {
        return s1.Equals(ref s2);
    }

    public static bool operator !=(Point s1, Point s2)
    {
        return !s1.Equals(ref s2);
    }

    public static Point operator +(Point s1, Point s2)
    {
        return new Point(s1.x + s2.x, s1.y + s2.y);
    }

    public void SetTo(int x, int y)
    {
        this.x = x;
        this.y = y;
    }

    public int SqrLength
    {
        get { return x * x + y * y; }
    }

    public bool Equals(ref Point other)
    {
        return x == other.x && y == other.y;
    }

    public bool Equals(Point other)
    {
        return other.x == x && other.y == y;
    }

    public bool Equals(int x, int y)
    {
        return this.x == x && this.y == y;
    }

    public override bool Equals(object other)
    {
        if (ReferenceEquals(null, other)) return false;
        return other is Point && Equals((Point)other);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return (x * 397) ^ y;
        }
    }

    public override string ToString()
    {
        return String.Format("[Point(x:{0}, y:{1})]", x, y);
    }

    public object Clone()
    {
        return new Point(x, y);
    }

    public Point Copy()
    {
        return new Point(x, y);
    }

    public void CopyFrom(PointF point)
    {
        x = (int)point.x;
        y = (int)point.y;
    }

    public void CopyFrom(Point point)
    {
        x = point.x;
        y = point.y;
    }

    public void CopyFrom(ref Point point)
    {
        x = point.x;
        y = point.y;
    }

    public int Hash { get { return x + y; } }
}

