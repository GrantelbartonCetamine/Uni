using System;
using System.Numerics;

class VectorMath
{

    Vector3 StructVectorX;
    Vector3 StructVectorY;
    Vector3 StructVectorZ;

    Vector3 PlusVectorX;
    Vector3 PlusVectorY;

    Vector3 MinusVectorX;
    Vector3 MinusVectorY;

    Vector3 DistanceVectorX;
    Vector3 DistanceVectorY;

    Vector3 Distance2VectorX;
    Vector3 Distance2VectorY;

    Vector3 LenghtVectorX;
    Vector3 LenghtVectorY;

    static void Main()
    {
        VectorMath MathVectors = new VectorMath();
        MathVectors.FloatAttributtes();
        MathVectors.StructOnZero();
        MathVectors.InitializeParameters();
        MathVectors.Plus();
        MathVectors.Minus();
        MathVectors.Distance2();
        Distance();
        MathVectors.Lenght();
        MathVectors.Sqrt();

    }

    private void FloatAttributtes() 
    {
        Vector3 TimeStepOffset = new Vector3(1f, 2f, 3f);

        Console.WriteLine($" In Function FloatAttributtes  \nVector with 3 Float Attributes : {TimeStepOffset} \n");
    }

    private void StructOnZero() 

    {
        Vector3 vector = new Vector3(0, 0, 0);

        Console.WriteLine($"In Function StructOnZero  \n Vector3 with all Axes on Zero : {vector}\n");
    }

    private void InitializeParameters() 
    {
        StructVectorX = new Vector3(1f, 0, 0);
        StructVectorY = new Vector3(0, 2f, 0);
        StructVectorZ = new Vector3(0, 0, 3f);

        Console.WriteLine($"In Function InitializeParameters  \n X Vector : {StructVectorX} ,\n Y Vector : {StructVectorY} ,\n Z Vector : {StructVectorZ}\n");
    }

    private void Plus() 
    {

        PlusVectorX = new Vector3(33, 35, 94);
        PlusVectorY = new Vector3(12, 364, 63);

        Vector3 result = PlusVectorX + PlusVectorY;

        Console.WriteLine($"In Function Plus with  PlusVectorX {PlusVectorX} + PlusVectorY {PlusVectorY} the  result is :  \n{result}\n");

    }

    void Minus()
    {

        MinusVectorX = new Vector3(1, 5, 8);
        MinusVectorY = new Vector3(0, 4, 6);

        Vector3 Result = MinusVectorX - MinusVectorY;

        Console.WriteLine($"In Function Minus : Vector MinusVectorX {MinusVectorX} - MinusVectorY {MinusVectorY} is: {Result}\n ");

    }

    static float Distance()
    {
        Vector3 DistanceVectorX = new Vector3(2f, 5f, 10f);
        Vector3 DistanceVectorY = new Vector3(9f, 4f, 7f);

        float Result = Vector3.Distance(DistanceVectorX, DistanceVectorY);

        Console.WriteLine($"In Function Distance the Distance Between Vector X {DistanceVectorX} and Y {DistanceVectorY} is {Result}\n");

        return Result;
    }

    float Distance2()
    {
        Distance2VectorX = new Vector3(2f, 5f, 8f);
        Distance2VectorY = new Vector3(9f, 4f, 10f);

        float Result = Vector3.Distance(Distance2VectorX, Distance2VectorY);

        Console.WriteLine($"In Function Distance2 the Distance Between Vector X and Y is {Result}\n");

        return Result;
    }

    float Lenght()
    {

        Vector3 LenghtVectorX = new Vector3(10, 560, 340);
        Vector3 LenghtVectorY = new Vector3(340, 1230, 5670);

        float lenghtX = LenghtVectorX.Length();
        float lenghty = LenghtVectorY.Length();

        Console.WriteLine($"In Function Lenght the Lenght of LenghtVectorX is {lenghtX} and Lenght of LenghtVectorY is : {lenghty}");
        return (lenghtX +  lenghty);

    }

    float Sqrt()
    {
        Vector3 SquareVectorX = new Vector3(1, 45, 45);
        Vector3 SquareVectorY = new Vector3(1, 45, 45);

        float squareVectorX = SquareVectorX.LengthSquared();
        float squareVectorY = SquareVectorY.LengthSquared();

        Console.WriteLine($"In Square root Function the Square root of SquareVectorY is {squareVectorX} and Square root of SquareVectorY is {squareVectorY}");

        return (squareVectorX + squareVectorY);
    }
}
