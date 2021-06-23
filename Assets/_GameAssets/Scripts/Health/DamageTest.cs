using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//TEST DE DAÑO Y SUBTITULOS
public class DamageTest : MonoBehaviour
{
    [SerializeField] PlayerHealth playerHealth;
    public int danyo;
    [SerializeField] Text dialogueTest;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            playerHealth.RemoveLife(danyo);

            dialogueTest.text = "He chocado contra algo";

            StartCoroutine(TextOff());
           
        }    


    }


    IEnumerator TextOff()
    {
        yield return new WaitForSeconds(3);
        dialogueTest.text = "";
    }


}


