using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//----------
//Clase que gestiona el cambio de armas y el recogerlas del suelo. 
//Se comunica con las armas para su actualización.
//----------
public class WeaponManager : MonoBehaviour
{
    [SerializeField] GameObject[] weapons; 

    public GameObject actualWeapon;

    [SerializeField]
    bool[] availableWeapons;

    public int damage;    

    private void Start()
    {
        // POR BORRAR? damage = actualWeapon.GetComponent<Weapon>().weaponDamage;
        //POR BORRAR -> EquipWeapon(0, true); (SOLO SIRVE SI QUIERO EMPEZAR CON UN ARMA EQUIPADA)
    } 

    void Update()
    {
        CheckChangeWeapon();
    }
    public void EquipWeapon(int n)
    {
        actualWeapon.SetActive(false);
        actualWeapon = weapons[n];
        actualWeapon.SetActive(true);
        availableWeapons[n] = true;
        damage = actualWeapon.GetComponent<Weapon>().weaponDamage;      
    }

    void CheckChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (availableWeapons[0])
            {
                EquipWeapon(0);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (availableWeapons[1])
            {
                EquipWeapon(1);
            }
            else
            {
                print("No tengo más armas");
            }
        }        
    }
}
