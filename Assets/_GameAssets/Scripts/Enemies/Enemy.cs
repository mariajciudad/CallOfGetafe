using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int enemyLife;

    Rigidbody rb;

    [SerializeField]
    Material material;

    [SerializeField]
    Renderer ms;

    Agente ag;

    NavMeshAgent nMA;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        ms = GetComponent<Renderer>();
        ag = GetComponent<Agente>();
        nMA = GetComponent<NavMeshAgent>();
    }

    public void RemoveLife(int damage)
    {
        enemyLife -= damage;

        if (enemyLife <= 0)
        {           
            DesactiveParameters();
        }
    }

    public void ExplosionEffect()
    {       
        DesactiveParameters();
        rb.AddForce(new Vector3(Random.Range(-50, 50), Random.Range(10, 700), Random.Range(-500, 50)));
    }

    public void ExplosionEffect(Vector3 direction)
    {        
        DesactiveParameters();
        rb.AddForce(direction/*+ new Vector3(0,2,0)*/ * 100);
    }

    void DesactiveParameters()
    {
        rb.isKinematic = false;
        ag.enabled = false;
        ms.material = material;
        nMA.enabled = false;
    }
}
