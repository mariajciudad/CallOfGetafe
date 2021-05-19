using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapManager : MonoBehaviour
{
    public bool allowRotation = false;
    Transform target;
    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void Update()
    {
        transform.position =
            new Vector3(
                target.position.x,
                transform.position.y,
                target.position.z
            );
        if (allowRotation)
        {
            transform.rotation = Quaternion.Euler(
                transform.rotation.eulerAngles.x,
                target.rotation.eulerAngles.y,
                transform.rotation.eulerAngles.z);
        }
    }
}
