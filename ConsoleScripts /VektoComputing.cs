using System;

struct Vector
{
    public float X, Y, Z;

    public Vector(float x, float y, float z)
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }


    // Addition 
    public static Vector operator +(Vector a, Vector b)

    {
        return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }


    // Subtraction
    public static Vector operator -(Vector a, Vector b)
    {

        return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }


    // Multiply
    public static Vector operator *(Vector a, float scalarfloat)
    {
        return new Vector(a.X * scalarfloat, a.Y * scalarfloat, a.Z * scalarfloat);
    }


    // Distance
    public float Distance(Vector a)
    {
        return MathF.Sqrt((X - a.X) * (X - a.X) + (Y - a.X) * (Y - a.Y) + (Z - a.Z) * (Z - a.Z));
    }


    // Static Distance
    public static float Dictance(Vector a, Vector b)
    {
        return a.Distance(b);
    }


    //Lenght
    public float Lenght()
    {
        return MathF.Sqrt(X * X + Y * Y + Z * Z);
    }


    //Sqrt Lenght
    public float SquaredLenght()
    {
        return X * X + Y * Y + Z * Z;
    }



    public override string ToString()
    {
        return $"({X} , {Y} , {Z})";
    }
}




