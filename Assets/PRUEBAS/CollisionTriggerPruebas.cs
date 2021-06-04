using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTriggerPruebas : MonoBehaviour
{


    private void OnTriggerStay(Collider other)
    {
        Debug.Log("Me mantengo en el trigger");
    }
}
