using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyEnemiesSpawner : MonoBehaviour
{
    public GameObject prefabEnemy;
    public Transform spawnPoint;

    [Range(1, 1000)]
    public int numberOfEnemies;
    [Range(1, 60)]  //No se puede poner 0 de rango porque se llamaria indefinidamente al metodo SpawnEnemy y se bloquearia Unity
    public float spawnDelay = 1;

    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy", 0, spawnDelay);
    }

    private void SpawnEnemy()
    {
        Instantiate(prefabEnemy, spawnPoint.position, spawnPoint.rotation);
        counter++;
        if (counter == numberOfEnemies)
        {
            CancelInvoke();
        }
    }
}
