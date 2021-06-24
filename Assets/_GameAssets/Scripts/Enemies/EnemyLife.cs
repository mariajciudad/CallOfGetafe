using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Gestiona la vida de los enemigos
public class EnemyLife : MonoBehaviour
{
    [SerializeField] int life;
    Rigidbody rigidBody;
    [SerializeField] Renderer ms;
    CrazyAgent crazyAgent;
    NavMeshAgent navMeshAgent;
    [SerializeField] EnemyVision enemyVision;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        ms = GetComponent<Renderer>();
        crazyAgent = GetComponent<CrazyAgent>();
        enemyVision = GetComponent<EnemyVision>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        Debug.Log("Vida enemigo: " + life);
    }

    //Reduce la vida del enemigo. Si llega a 0, muere 
    public void RemoveLife(int damage)
    {
        life -= damage;

       Debug.Log("Vida enemigo: " + life);

        if (life <= 0)
        {
            enemyVision.enabled = false;
            DesactiveParameters();
        }
    }
    
    //Desactiva los parámetros del enemigo para que deje de patrullar y le afecten las físicas
    void DesactiveParameters()
    {        
        rigidBody.isKinematic = false;
        crazyAgent.enabled = false;  
        navMeshAgent.enabled = false;
    }

    /*
    public void ExplosionEffect()
    {
        DesactiveParameters();
        rb.AddForce(new Vector3(Random.Range(-50, 50), Random.Range(10, 700), Random.Range(-500, 50)));
    }

    public void ExplosionEffect(Vector3 direction)
    {
        DesactiveParameters();
        rb.AddForce(direction/*+ new Vector3(0,2,0)*/ /** 100);
    }
    */
}