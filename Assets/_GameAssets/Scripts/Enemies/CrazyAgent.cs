using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Gestiona el comportamiento de los enemigos tontos
public class CrazyAgent : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform[] targets;  //Array con los puntos a los que se dirigirá el enemigo Agent
    [SerializeField] public Transform actualTarget;
    [SerializeField] public float agentVelocity;
    [SerializeField] public int lastPosition;
    EnemyAnimations enemyAnimations;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyAnimations = EnemyAnimations.FindObjectOfType<EnemyAnimations>();
    }

    private void Start()
    {
        enemyAnimations.ChangeStateToWalk();
        agent.speed = agentVelocity;
        ChangeDestination();
    }

    // Update is called once per frame
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

    public IEnumerator CoroutineStopSliding(int t) //Función para que no se pasen de frenada.
    {
        yield return null;
        actualTarget = targets[t];
        agent.isStopped = false;
    }
}
