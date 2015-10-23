using System;

[Serializable]
public struct Size : IEquatable<Size>, IComparable<Size>
{

    public static readonly Size Zero = new Size(0, 0);
    public static readonly Size One = new Size(1, 1);

    public int width;
    public int height;

    public Size(int width = 0, int height = 0)
    {
        this.width = width;
        this.height = height;
    }

    public void Set(int width, int height)
    {
        this.width = width;
        this.height = height;
    }

    public void CopyFrom(Size size)
    {
        width = size.width;
        height = size.height;
    }

    public void CopyFrom(ref Size size)
    {
        width = size.width;
        height = size.height;
    }

    public static Size operator +(Size s1, Size s2)
    {
        return new Size(s1.width + s2.width, s1.height + s2.height);
    }

    public static Size operator -(Size s1, Size s2)
    {
        return new Size(s1.width - s2.width, s1.height - s2.height);
    }

    public static Size operator +(Size s1, int s2)
    {
        return new Size(s1.width + s2, s1.height + s2);
    }

    public static Size operator -(Size s1, int s2)
    {
        return new Size(s1.width - s2, s1.height - s2);
    }

    public static bool operator ==(Size s1, Size s2)
    {
        return s1.Equals(ref s2);
    }

    public static bool operator !=(Size s1, Size s2)
    {
        return !s1.Equals(ref s2);
    }

    public bool Equals(ref Size other)
    {
        return width == other.width && height == other.height;
    }

    public bool Equals(Size other)
    {
        return width == other.width && height == other.height;
    }

    public override bool Equals(object other)
    {
        if (ReferenceEquals(null, other)) return false;
        return other is Size && Equals((Size)other);
    }

    public override int GetHashCode()
    {
        unchecked
        {
            return (width * 397) ^ height;
        }
    }

    public int CompareTo(Size other)
    {
        if (Math.Sqrt(width * width + height * height) > Math.Sqrt(other.width * other.width + other.height * other.height))
            return 1;
        return -1;
    }

    public override string ToString()
    {
        return width + " " + height;
    }

}
