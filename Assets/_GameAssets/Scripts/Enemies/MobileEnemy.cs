using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MobileEnemy : Enemy
{
    public float speed;
    public float timeToRotation;
    [Range(0, 360)]
    public float minAngle;
    [Range(0, 360)]
    public float maxAngle;
    [Range(1, 5)]
    public float distanceToExplosion;
    private void Start()
    {
        InvokeRepeating("Rotate", timeToRotation, timeToRotation);
    }

    public override void Update()
    {
        base.Update();
        Attack();
    }

    public void Move()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    public override void Attack()
    {
        if (distanceToPlayer <= distanceToExplosion)
        {
            Instantiate(prefabPSDeath, transform.position, transform.rotation);
            //Alternativa triste
            //GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            //Destroy(this);
            //Alternativa piadosa
            Destroy(gameObject);
        }
    }

    public virtual void Rotate()
    {
        int determinante = Random.Range(0, 100);
        int signo = determinante > 50 ? 1 : -1;
        /*
         * La linea de arriba es una expresion ternaria. El interrogante es una pregunta. Esto es como decir: 
         * ¿es el valor de determinante mayor que 50? Si es sí, seria 1. Si es no, seria -1
         * Tambien se puede escribir así:
         if (determinante > 50)
         {
           signo = 1;
         } else
         {
           signo = -1;
         }
         */
        transform.Rotate(0, Random.Range(minAngle, maxAngle) * signo, 0);
    }
}
