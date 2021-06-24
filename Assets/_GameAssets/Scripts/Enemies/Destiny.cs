using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destiny : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 3)
        {
            Debug.Log("xxx");
            //if (other.gameObject.GetComponent<SmartAgent>() != null)
            //{
            //    other.gameObject.GetComponent<SmartAgent>().ChangeDestination();
            //}
            //{
                other.gameObject.GetComponent<CrazyAgent>().ChangeDestination();
            //}
        }
    }
}
