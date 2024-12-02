using UnityEngine;

public class VectorMath : MonoBehaviour
{

    Vector3 StructVectorX;
    Vector3 StructVectorY;
    Vector3 StructVectorZ;

    Vector3 PlusVectorX;
    Vector3 PlusVectorY;

    Vector3 MinusVectorX;
    Vector3 MinusVectorY;


    void Start()
    {
        FloatAttributtes();
        StructOnZero();
        InitializeParameters(out StructVectorX, out StructVectorY, out StructVectorZ);
        Plus(PlusVectorX , PlusVectorY);
        Minus(MinusVectorX , MinusVectorY);
    }


    void Update()
    {

    }

    private void FloatAttributtes() // Drei float Attribute/Felder: x, y, z
    {
        Vector3 TimeStepOffset = new Vector3(1f, 2f, 3f);
    }

    private void StructOnZero() //  Standardkonstruktor in dem x, y, z auf 0 gesetzt werden 

    {
        Vector3 vector = Vector3.zero;
    }

    private void InitializeParameters(out Vector3 X, out Vector3 Y, out Vector3 Z) //  Einen Konstruktor in dem x, y, z mit Parametern initialisiert werden
    {
        X = new Vector3(1f, 0, 0);
        Y = new Vector3(0, 2f, 0);
        Z = new Vector3(0, 0, 3f);

        Debug.Log($"X Vector : {X} , Y Vector {Y} , Z Vector : {Z}");
    }

    private void Plus(Vector3 PlusVectorX,Vector3 PlusVectorY)  //  + Operator für die Addition mit einem anderen Vektor
    {

        Vector3 result = PlusVectorX + PlusVectorY;

        Debug.Log($"Result of Plus Operation is {result}");

    }

    void Minus(Vector3 MinusVectorX,Vector3 MinusVectorY) //  - Operator für die Substraktion mit einem anderen Vektor
    {

        MinusVectorX = new Vector3(1, 5, 8);
        MinusVectorY = new Vector3(0, 4, 6);

        Vector3 Result = MinusVectorX - MinusVectorY;

        Debug.Log($"Result of Minus Operation is {Result}");
    }

}

