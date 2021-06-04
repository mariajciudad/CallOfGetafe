using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    [SerializeField] int addLifeAmount;
    [SerializeField] HealthManager healthManager; //Referenciando el script HealthManager antes, se ahorra Unity que lo busque. Solo funciona si el objeto esta en la escena

    private void Awake()
    {
        if(healthManager == null) //Si el objeto no esta en la escena y aun no tiene localizado el script HealthManager
        {
            healthManager = FindObjectOfType<HealthManager>(); //Lo busca y lo asigna a la variable healthManager
        }        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            healthManager.AddLife(addLifeAmount);
            Destroy(gameObject);

            //Otra forma de hacerlo:
            //GameObject player = GameObject.Find("FPSController");
            //player.GetComponent<HealthManager>().AddLife(addLifeAmount);
        }       
    }
}
