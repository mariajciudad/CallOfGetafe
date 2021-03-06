using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//----------
//Clase que gestiona el disparo: lanzamiento del Raycast e impacto y reducir la munición al disparar. 
//----------
public class FPSShoot : MonoBehaviour
{
    [SerializeField] WeaponManager weaponManager;

    [SerializeField] LayerMask layerMask;

    [SerializeField] Transform shootPoint;

    int shootDist;


    public AudioSource audioSource;
    public AudioClip[] audioClipFire;


    void Update()
    {
        //Distancia máxima a la que podrá llegar el raycast según el arma
        shootDist = weaponManager.actualWeapon.GetComponent<Weapon>().shootDistance;

        //Se crea un nuevo raycast desde un GameObject vacío
        Ray ray = new Ray(shootPoint.transform.position, shootPoint.transform.forward);
        RaycastHit hit;

        //Al pulsar el botón izquierdo del ratón, si el arma tiene balas, se restará una
        if (Input.GetMouseButtonDown(0))
        {               
            if (weaponManager.actualWeapon.GetComponent<Weapon>().ammoInMagazine > 0)
            {               
                weaponManager.actualWeapon.GetComponent<Weapon>().ammoInMagazine--;

                if (weaponManager.actualWeapon.name == "DesertEagle")
                {
                    audioSource.PlayOneShot(audioClipFire[0]);
                }
                else if (weaponManager.actualWeapon.name == "Shotgun")
                {
                    audioSource.PlayOneShot(audioClipFire[1]);
                }

                //Si el raycast colisiona con los GameObjects que tengan los layers seleccionados, se les reducirá su vida según el daño del arma
                if (Physics.Raycast(ray.origin, ray.direction, out hit, shootDist, layerMask))
                {
                    //Detecta al primer enemigo
                   if (hit.collider.gameObject.layer == 9)
                   {
                        hit.collider.gameObject.GetComponent<FirstEnemy>().RemoveLife(weaponManager.damage);
                     

                    }
                    //Detecta al resto de enemigos
                    else if (hit.collider.gameObject.layer == 3)
                    {
                        hit.collider.gameObject.GetComponent<EnemyLife>().RemoveLife(weaponManager.damage);                        
                    }                                        
                }
            }
        }

        Debug.DrawRay(ray.origin, ray.direction * shootDist, Color.red);
    }       
}