using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Al llegar un enemigo a un punto de destino, se dirige hacia otro aleatoriamente
public class Destiny : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 3)
        {          
            other.gameObject.GetComponent<CrazyAgent>().ChangeDestination();            
        }
    }
}
