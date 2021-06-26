using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Invoca un número determinado de enemigos en un punto y tiempo indicado
public class EnemySpawner : MonoBehaviour
{
    public GameObject prefabEnemy;
    [SerializeField] int numberOfEnemies;
    [SerializeField] int enemiesCounter;
    [SerializeField] int invokeStart;
    [SerializeField] int invokeTime;

    void Start()
    {
        InvokeRepeating("SpawnEnemy", invokeStart, invokeTime);
    }

    private void SpawnEnemy()
    {
        Instantiate(prefabEnemy, transform.position, transform.rotation);
        enemiesCounter++;

        if(enemiesCounter == numberOfEnemies)
        {
            CancelInvoke();
        }
    }
}
