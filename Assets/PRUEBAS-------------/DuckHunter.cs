using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckHunter : MonoBehaviour
{
    private Rigidbody rbCube; 

    // Start is called before the first frame update
    void Start()
    {
        rbCube = GetComponent<Rigidbody>();

        Debug.Log(rbCube.ToString());

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
        {
            rbCube.AddForce(new Vector3(0, 100, 0));          
        }
    }
}
