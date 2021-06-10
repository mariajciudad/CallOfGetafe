using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRay3 : MonoBehaviour
{
    //Raycast para simular una espada laser

    [SerializeField] LayerMask layerMask;

    private void Start()
    {
        layerMask = LayerMask.GetMask("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray.origin, ray.direction, out hit, 3, layerMask))  //layerMask indica que objeto destruye?
        {
            Destroy(hit.collider.gameObject);
        }
        Debug.DrawRay(ray.origin, ray.direction * 3, Color.red);
    }

}
