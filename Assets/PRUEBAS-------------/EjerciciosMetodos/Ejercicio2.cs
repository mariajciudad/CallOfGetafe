using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejercicio2 : MonoBehaviour
{
    //Realizar un m�todo que muestre por consola la media aritm�tica de 3 valores pasada por par�metros de entrada
    
    [SerializeField] int value1;
    [SerializeField] int value2;
    [SerializeField] int value3;


    void Start()
    {
        ArithmeticAverage(value1, value2, value3);
    }

    private void ArithmeticAverage(int v1, int v2, int v3) 
    {
        int arithmeticResult = (v1 + v2 + v3) / 3;
        Debug.Log(arithmeticResult);
    }
}
