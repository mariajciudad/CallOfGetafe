using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Gestiona el comportamiento de los enemigos tontos
//Los enemigos tontos se dirigen a los puntos de destino aleatoriamente y no persiguen al player
public class CrazyAgent : MonoBehaviour
{
    public NavMeshAgent agent;
    public GameObject[] targets;  //Array vacío con los puntos de destino a los que se dirigirá los agentes
    [SerializeField] public Transform actualTarget;
    [SerializeField] public float agentVelocity;
    [SerializeField] public int lastPosition;
    [SerializeField] EnemyAnimations enemyAnimations;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        targets = GameObject.FindGameObjectsWithTag("Destiny"); //Rellena el array con los puntos de destino
        enemyAnimations = GetComponent<EnemyAnimations>();
        actualTarget = targets[0].transform;
        //Empezando el patrullaje en un punto alternativo: actualTarget = targets[Random.Range(0,targets.Length)].transform;
      
    }

    private void Start()
    {
        enemyAnimations.ChangeStateToWalk();
        agent.speed = agentVelocity;
        ChangeDestination();
    }

    void Update()
    {
        enemyAnimations.ChangeStateToWalk();
        agent.SetDestination(actualTarget.position);
    }

    public virtual void ChangeDestination()
    {        
        int temp = Random.Range(0, targets.Length);

        if (lastPosition == temp)
        {
            ChangeDestination();
        }
        else
        {
            agent.velocity = Vector3.zero;
            agent.isStopped = true;
            lastPosition = temp;
            StartCoroutine(CoroutineStopSliding(temp));
            enemyAnimations.ChangeStateToWalk();
        }
    }

    //Función para que no se pasen de frenada
    public IEnumerator CoroutineStopSliding(int t) 
    {
        yield return null;     
        actualTarget = targets[t].transform;
        agent.isStopped = false;
    }
}
