using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejercicio1 : MonoBehaviour
{
    //Realizar un m�todo llamado AddLife que a�ada una cantidad de vida a una variable de clase llamada life igual a una cantidad pasada como par�metro de entrada

    [SerializeField] int life;
    [SerializeField] int addlLife;

    void Start()
    {
        AddLife(addlLife);
    }

    private void AddLife(int addLife) 
    {
        life += addlLife;
    }           
}
