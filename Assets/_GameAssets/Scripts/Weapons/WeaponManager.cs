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
        EquipWeapon(0, true);
    } 

    void Update()
    {
        CheckChangeWeapon();
    }
    public void EquipWeapon(int n, bool isCatch)
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
                EquipWeapon(0, false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (availableWeapons[1])
            {
                EquipWeapon(1, false);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (availableWeapons[2])
            {
                EquipWeapon(2, false);
            }
        }
    }
}
