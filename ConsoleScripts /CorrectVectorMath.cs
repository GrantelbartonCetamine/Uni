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

    public static Vector operator +(Vector a, Vector b)

    {
        return new Vector(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
    }

    public static Vector operator -(Vector a, Vector b)
    {

        return new Vector(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
    }

    public static Vector operator *(Vector a , float scalarfloat)
    {
        return new Vector(a.X * scalarfloat , a.Y * scalarfloat, a.Z * scalarfloat);
    }

    public float Distance(Vector a)
    {
        return MathF.Sqrt((X - a.X) * (X - a.X) + (Y - a.X) * (Y - a.Y) + (Z - a.Z) * (Z - a.Z));
    }
    
    public static float Dictance(Vector a , Vector b)
    {
        return a.Distance(b);
    }

    public float Lenght()
    {
        return MathF.Sqrt(X * X + Y * Y + Z * Z);
    }

    public float SquaredLenght()
    {
        return X * X + Y * Y + Z * Z;
    }

    public override string ToString()
    {
        return $"({X} , {Y} , {Z})";
    }


}

class Program()
{

    static void Main()
    {
        Result();

    }

    public static void Result()
    {
        Vector XVector = new Vector(3 , 4 , 5);
        Vector YVector = new Vector(6 , 7 , 8);

        Console.WriteLine($"First Vector : {XVector} , Second Vector : {YVector}");

        //Addition
        Console.WriteLine($"Addition is : {XVector + YVector}");

        //Subtraction
        Console.WriteLine($"Subtraction is : {XVector - YVector}");

        //Multiplication
        Console.WriteLine($"Multiplication is : {XVector * 4}");

        //Distance
        Console.WriteLine($"Distance between XVector and YVector is is : {XVector.Distance(YVector)}");

        //Lenght
        Console.WriteLine($"Lenght is : {XVector.Lenght()}");

        //SquaredLenght
        Console.WriteLine($"SquaredLenght is : {XVector.SquaredLenght()}");
    }
}   

