using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//----------
//Clase que portan las armas en tu jerarquía, controlan la munición y recarga
//en cada una de ellas de forma individual.
//----------
public class Weapon : MonoBehaviour
{

    public int weaponDamage;
    
    public int maxAmmoInBag; //Munición total de ese arma en concreto que el player puede llevar encima
    public int ammoInBag; //Munición de ese arma que el player tiene actualmente

    public int magazineSize; //Balas máximas que el arma puede tener
    public int ammoInMagazine; //Balas que el arma tiene cargadas


    private void Start()
    {
        ammoInMagazine = magazineSize; //El arma empieza completamente cargada
    }

    private void Update()
    {
        Reload();
    }

    public void GetAmmo(int n)
    {
        ammoInBag += n;

        if(ammoInBag > maxAmmoInBag)
        {
            ammoInBag = maxAmmoInBag;
        }
    }

    void Reload()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (ammoInBag > 0)
            {
                if((magazineSize - ammoInMagazine) > ammoInBag)
                {
                    ammoInMagazine = ammoInMagazine + ammoInBag;
                    ammoInBag = 0;
                    print("Me he quedado sin balas, será mejor que encuentre pronto");
                }
                else
                {
                    ammoInBag = ammoInBag - (magazineSize - ammoInMagazine);
                    ammoInMagazine = magazineSize;                    
                }
            }
        }
    }
}
