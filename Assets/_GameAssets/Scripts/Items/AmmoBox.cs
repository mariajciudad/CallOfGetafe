using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Clase que gestiona las cajas de munición
public class AmmoBox : MonoBehaviour
{
    [SerializeField] int bullets;
    [SerializeField] GameObject weapon;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 10) //Player
        {
            weapon.GetComponent<Weapon>().GetAmmo(bullets);
            Destroy(gameObject);
        }
    }
}
