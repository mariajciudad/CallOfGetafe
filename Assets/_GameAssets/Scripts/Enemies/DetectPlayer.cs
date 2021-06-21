using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    [SerializeField] Transform targetToDetect;
    [SerializeField] Transform followerToAlert;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            followerToAlert.transform.LookAt(targetToDetect.transform.position);
        }            
    }
}
