using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public int damage;
    private void OnCollisionEnter(Collision other) {
        if (IsEnemy(other.gameObject)){
            Destroy(gameObject);
            other.gameObject.GetComponentInParent<Enemy>().ReceiveDamage(damage);
        }
    }

    private bool IsEnemy(GameObject candidate){
        return (candidate.CompareTag("Enemy"));
    }
}
