using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Subtítulos
public class Subtitles : MonoBehaviour
{
    [SerializeField] Text dialogueTest;
    public string subtitleText;
    private bool isFirstRead;

    private void Awake()
    {
        isFirstRead = true;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (isFirstRead)
        {
            if (other.gameObject.layer == 10)
            {            
                dialogueTest.text = subtitleText;
                StartCoroutine(TextOff());
            }
        }        
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 10)
        {
            isFirstRead = false;            
        }
    }


    IEnumerator TextOff()
    {
        yield return new WaitForSeconds(5);
        dialogueTest.text = "";
    }
}


