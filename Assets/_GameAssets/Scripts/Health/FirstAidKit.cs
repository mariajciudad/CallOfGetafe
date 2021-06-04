using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAidKit : MonoBehaviour
{
    public int addLifeAmount;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<HealthManager>().AddLife(addLifeAmount);
            Destroy(gameObject);

            //Otra forma de hacerlo:
            //GameObject player = GameObject.Find("FPSController");
            //player.GetComponent<HealthManager>().AddLife(addLifeAmount);
        }       
    }
}
