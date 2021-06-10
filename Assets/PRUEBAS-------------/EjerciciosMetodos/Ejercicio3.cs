using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejercicio3 : MonoBehaviour
{
    //M�todo que devuelva true o false en el caso de que un gameObject pasado por par�metro tenga el tag "Player" o no

    [SerializeField] GameObject testGameObject;

    void Start()
    {
        Debug.Log(CheckGameObjectPlayer(testGameObject));        
    }

     private bool CheckGameObjectPlayer(GameObject g)
     {
        if(g.tag == "Player")
        {
            return true;
        }
        else
        {
            return false;
        }
     }
}


