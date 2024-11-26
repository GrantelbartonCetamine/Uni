using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorMath : MonoBehaviour
{


    void Start()
    {

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

    private void InitializeParameters(Vector3 X, Vector3 Y, Vector3 Z) //  Einen Konstruktor in dem x, y, z mit Parametern initialisiert werden
    {
        X = new Vector3(1f, 0, 0);
        Y = new Vector3(0, 2f, 0);
        Z = new Vector3(0, 0, 3f);

        Debug.Log($"X Vector : {X} , Y Vector {Y} , Z Vector : {Z}");
    }

    private void Plus(Vector3 FirstVector , Vector3 SecondVector)  //  + Operator für die Addition mit einem anderen Vektor
    {
        FirstVector = new Vector3(1,0,0);
        SecondVector = new Vector3(0,5,0);

        Vector3 result = FirstVector + SecondVector;

        Debug.Log($"Result of Plus Operation is {result}");

    }

    void Minus(Vector3 FirstMinusVector , Vector3 SecondMinusVector) //  - Operator für die Substraktion mit einem anderen Vektor
    {

        FirstMinusVector = new Vector3(1,5,8);
        SecondMinusVector = new Vector3(0,4,6);

        Vector3 Result = FirstMinusVector - SecondMinusVector;

        Debug.Log($"Result of Minus Operation is {Result}");
    }

    void Divide(Vector3 FirstMalVector, Vector3 SecondMalVector) //  * Operator für die Multiplikation mit einem Skalar (Zahl)
    {
        Vector3 Result = new Vector3(
            FirstMalVector.x * SecondMalVector.x,
            FirstMalVector.y * SecondMalVector.y,
            FirstMalVector.z * SecondMalVector.z
            );

        Debug.Log($"Result of Minus Operation is {Result}");
    }













}



//  Drei float Attribute/Felder: x, y, z
//  
//  Standardkonstruktor in dem x, y, z auf 0 gesetzt werden 
//  
//  Einen Konstruktor in dem x, y, z mit Parametern initialisiert werden
//  
//  + Operator für die Addition mit einem anderen Vektor
//  
//  - Operator für die Substraktion mit einem anderen Vektor
//  
//  * Operator für die Multiplikation mit einem Skalar (Zahl)
//  
//  Methode die die Distanz zwischen zwei Vektoren/Punkten berechnet und als float zurückgeben. Implementiere diese Methode in einer statischen und nicht-statischen Version.
//  
//  Methode die die Länge eines Vektors berechnet und als float ausgibt.
//  
//  Methode die die Quadratlänge eines Vektors berechnet und als float ausgibt.
