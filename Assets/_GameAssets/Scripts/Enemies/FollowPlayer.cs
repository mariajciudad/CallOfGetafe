using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform targetToFollow;
    [SerializeField] Transform zombie;

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
        zombie.transform.LookAt(targetToFollow.transform.position);
    }

    private void OnTriggerStay(Collider other)  //El collider trigger se ejecuta indefinidamente
    { 
        if (other.gameObject.CompareTag("Player"))
        {
            transform.LookAt(targetToFollow.transform.position);
            transform.position = Vector3.MoveTowards(transform.position, targetToFollow.transform.position, 1);
        }
    }

}
