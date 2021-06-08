using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRandom : MonoBehaviour
{
    [SerializeField] GameObject[] enemies;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("CreateEnemy", 5, 5); //Se ejecuta el metodo CreateEnemy a los 5 segundos y se sigue ejecutando cada 5 segundos
    }

    // Update is called once per frame
    void CreateEnemy()
    {
        int temp = Random.Range(0, enemies.Length); //Se obtiene un numero entre 0 y el tamaño del array
        Instantiate(enemies[temp], transform.position, Quaternion.identity); //Se instancia uno de los enemigos del array de forma aleatoria en cada ejecucion del metodo con la posicion y rotacion que tenga por defecto el objeto que tenga el script
    }
}
