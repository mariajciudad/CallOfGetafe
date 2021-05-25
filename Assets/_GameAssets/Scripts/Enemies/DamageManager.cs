using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public int damage;
    private void OnCollisionEnter(Collision other)
    {
        if (IsEnemy(other.gameObject))
        {            
            other.gameObject.GetComponentInParent<Enemy>().ReceiveDamage(damage, other.GetContact(0).point, other.GetContact(0).normal);
            Destroy(gameObject);
        }
    }
    private bool IsEnemy(GameObject candidate)
    {
        return (candidate.CompareTag("Enemy"));  //Detecta si es un objeto con tag Enemy y lo devuelve
    }
}