using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionPruebas : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Colision comienza");
    }

    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Colision se mantiene");
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Colision sale");
    }

}
