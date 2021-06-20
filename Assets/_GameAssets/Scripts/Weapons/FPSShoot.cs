using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//----------
//Clase que gestiona el disparo, es decir, lanzamiento del Raycast e impacto 
//y reducir la munición al disparar. 
//----------
public class FPSShoot : MonoBehaviour
{
    [SerializeField] WeaponManager weaponManager;

    [SerializeField] LayerMask layerMask;
           
    
    void Update()
    {
        Ray ray= new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Input.GetMouseButtonDown(0))
        {
            if (weaponManager.actualWeapon.GetComponent<Weapon>().ammoInMagazine > 0)
            {
                weaponManager.actualWeapon.GetComponent<Weapon>().ammoInMagazine--;

                if (Physics.Raycast(ray.origin, ray.direction, out hit, 50f, layerMask))
                {
                    hit.collider.gameObject.GetComponent<Enemy>().RemoveLife(weaponManager.damage);
                }
            }
        }
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);
    }       
}