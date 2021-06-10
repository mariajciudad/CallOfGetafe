using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejercicio4 : MonoBehaviour
{
    //Método que usando 2 arrays (una con gameObjects y otra con float) instancie de forma aleatoria un objeto del array dado en un tiempo aleatorio del array de float

    [SerializeField] GameObject[] enemies;
    [SerializeField] float[] spawntimes;

    void Start()
    {
        Invoke("SpawnEnemy", spawntimes[Random.Range(0, spawntimes.Length)]);   
    }

    void SpawnEnemy()
    {
        Instantiate(enemies[Random.Range(0, enemies.Length)], transform.position, Quaternion.identity);
        Invoke("SpawnEnemy", spawntimes[Random.Range(0, spawntimes.Length)]);
    }
}
