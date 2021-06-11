using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cronometro : MonoBehaviour
{
    [SerializeField] float counter;

    // Update is called once per frame
    void Update()
    {
        counter += Time.deltaTime;
        Debug.Log(counter);
    }
}
