using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//----------
//Clase que portan las armas en el suelo para llamar al método coger arma
//----------
public class CatchWeapon : MonoBehaviour
{
    [SerializeField] int idWeapon;      

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 10)
        {
            other.gameObject.transform.GetComponent<WeaponManager>().EquipWeapon(idWeapon, true);

            Destroy(gameObject.transform.gameObject);
        }
    }
}
