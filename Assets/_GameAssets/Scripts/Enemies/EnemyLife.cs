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
}