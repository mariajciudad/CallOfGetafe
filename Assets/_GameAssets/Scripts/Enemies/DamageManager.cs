using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    public int damage;
    public GameObject prefabImpacto;
    private void OnCollisionEnter(Collision other)
    {
        if (IsEnemy(other.gameObject)) //La llamada a este metodo es equivalente a: if (other.gameObject.CompareTag("Enemy")
        {
            //GetContact(0).point es el punto de donde se ha producido la colision de la bala para que se genere las particulas de sangre
            //GetContact(0).normal es la direccion en la que surgiran las particulas de sangre. La normal es el vector perpendicular de magnitud 1 en la superficie de impacto (la sangre surgira perpendicular al impacto de la bala)
            other.gameObject.GetComponentInParent<Enemy>().ReceiveDamage(damage, other.GetContact(0).point, other.GetContact(0).normal); 
            
            //Time.timeScale = 0.2f; permite ver modificar la escala de tiempo (ralentizarlo) para ver el resultado del codigo a camara lenta
        } else {
            GameObject psDamage = Instantiate(prefabImpacto, other.GetContact(0).point, Quaternion.LookRotation(other.GetContact(0).normal));
            psDamage.transform.SetParent(other.gameObject.transform);
        }
        Destroy(gameObject);
    }
    private bool IsEnemy(GameObject candidate)
    {
        return (candidate.CompareTag("Enemy"));  //Detecta si es un objeto con tag Enemy y lo devuelve
    }
}