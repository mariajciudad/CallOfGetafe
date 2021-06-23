using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase que gestiona los botiquines
public class FirstAidKit : MonoBehaviour
{
    [SerializeField] int healAmount;
    [SerializeField] PlayerHealth playerHealth;    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            playerHealth.AddLife(healAmount);
            Destroy(gameObject);
        }
    }
}
