using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ejercicio5 : MonoBehaviour
{
    //Método que dado un array de objetos (cualesquiera) me los baraje y posteriormente me devuelva el primero de ellos

    [SerializeField] GameObject[] enemy;

    // Start is called before the first frame update
    void Start()
    {
        ShuffleAndShowFirst();
    }

    void ShuffleAndShowFirst()
    {//Algoritmo de Knuth de barajar cartas
        for (int t = 0; t < enemy.Length; t++)
        {
            GameObject tmp = enemy[t];
            int r = Random.Range(t, enemy.Length);
            enemy[t] = enemy[r];
            enemy[r] = tmp;
        }
        Instantiate(enemy[0]);
    }
}
