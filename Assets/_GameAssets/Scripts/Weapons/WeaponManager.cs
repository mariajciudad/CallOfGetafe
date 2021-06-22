using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//----------
//Clase que gestiona el cambio de armas y el recogerlas del suelo. 
//Se comunica con las armas para su actualización.
//----------
public class WeaponManager : MonoBehaviour
{
    [SerializeField] GameObject[] weapons; //Array de GameObjects que contendrá las armas

    public GameObject actualWeapon; //Tendrá el arma que se esté usando

    [SerializeField] bool[] availableWeapons; //Indica si un arma este disponible

    public int damage;

    [SerializeField] GameObject crossHair;
    private bool crossHairIsActive;

    private void Start()
    {
        crossHair.SetActive(false);
        crossHairIsActive = true;
        // POR BORRAR? damage = actualWeapon.GetComponent<Weapon>().weaponDamage;     
    } 

    void Update()
    {
        ChangeWeapon();
    }

    //Al equipar el player un arma, la que esté usando se desactivará
    //La que haya recogido o escogido pasará a ser la que use y se activará
    public void EquipWeapon(int n)
    {
        actualWeapon.SetActive(false);
        actualWeapon = weapons[n];
        actualWeapon.SetActive(true);
        availableWeapons[n] = true;
        damage = actualWeapon.GetComponent<Weapon>().weaponDamage;    
        
        //Activa el crosshair al recoger la primera arma
        if (crossHairIsActive)
        {
            crossHairIsActive = false;
            crossHair.SetActive(true);
        }
    }

    //Cambiará el arma dependiendo de la tecla pulsada y su posición en el array
    void ChangeWeapon()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            if (availableWeapons[0])
            {
                EquipWeapon(0);
            }
            else
            {
                print("No tengo ningún arma");
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
                print("No tengo ningún arma");
            }
        }        
    }
}
