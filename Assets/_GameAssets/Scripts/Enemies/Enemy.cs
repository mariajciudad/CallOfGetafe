using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    //MIO
    public int maxHealth;
    public int health;
    public GameObject prefabPSDamage;
    public GameObject prefabPSDeath;
    public float distanceToPlayer;
    public GameObject player;

    private void Awake()
    {
        health = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogError("Error en Enemy buscando el elemento con el tag Player");
        }
    }

    public virtual void Update()
    {
        distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
    }

    /// <summary>
    /// Determina si el player est? a la vista o no
    /// </summary>
    /// <returns></returns>
    public bool PlayerDetected()
    {
        //TODO Programar si est? viendo al Player
        return true;
    }


    /// <summary>
    /// Inflinge un da?o al enemigo
    /// </summary>
    public void ReceiveDamage(int damage, Vector3 impactPosition, Vector3 normal)
    {
        //TODO  , sistema de partIculas, emitir un sonido,
        health -= damage;
        if (health <= 0)
        {
            Death();
        }
        else
        {
            GameObject psDamage = Instantiate(prefabPSDamage, impactPosition, Quaternion.LookRotation(normal));
            psDamage.transform.SetParent(transform);
        }
    }

    /// <summary>
    /// Mata al enemigo
    /// </summary>
    public void Death()
    {
        //TODO sistema de part?culas, emitir un sonido y destruir el objeto
        Destroy(gameObject);
    }

    /// <summary>
    /// Ataque del enemigo
    /// </summary>
    public abstract void Attack();

}