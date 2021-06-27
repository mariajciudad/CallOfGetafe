using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Activa el boss cuando todos los enemigos esten muertos
public class ActivateBoss : MonoBehaviour
{
    [SerializeField] int totalEnemies;
    [SerializeField] int killedEnemies;

    public GameObject boss;

    void Start()
    {
        countTotalEnemies();
    }

    void Update()
    {
        isAllEnemiesDead();
    }

    private void countTotalEnemies()
    {
        //Obtener el total de enemigos en la escena
        totalEnemies += GameObject.Find("SpawnPointCrazy1").GetComponent<EnemySpawner>().getNumberOfEnemies();
        totalEnemies += GameObject.Find("SpawnPointCrazy2").GetComponent<EnemySpawner>().getNumberOfEnemies();
        totalEnemies += GameObject.Find("SpawnPointCrazy3").GetComponent<EnemySpawner>().getNumberOfEnemies();
        totalEnemies += GameObject.Find("SpawnPointSmart1").GetComponent<EnemySpawner>().getNumberOfEnemies();
        totalEnemies += GameObject.Find("SpawnPointSmart2").GetComponent<EnemySpawner>().getNumberOfEnemies();
        totalEnemies += GameObject.Find("SpawnPointSmart3").GetComponent<EnemySpawner>().getNumberOfEnemies();
    }

    //Se suma uno cada vez que un enemigo muere
    public void addKilledEnemies()
    {
        killedEnemies++;
    }

    //Si los enemigos muertos es igual al número de enemigos en la escena, se activa el boss
    private void isAllEnemiesDead()
    {
        if (killedEnemies == totalEnemies)
        {
            boss.SetActive(true);
        }        
    }
}
