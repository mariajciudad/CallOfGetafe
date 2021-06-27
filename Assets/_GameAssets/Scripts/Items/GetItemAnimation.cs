using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItemAnimation : MonoBehaviour
{
    [SerializeField] Animator animator;

    void Start()
    {
        animator.Play("GetItemAnimation", 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 10)
        {

            Destroy(gameObject);
        }
    }
}
