using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; //Se importa la libreria de Dotween

public class TestDotween : MonoBehaviour
{
    public float bulletTime; //Tiempo de la bala
    public GameObject enemy; //Enemigo hasta donde quiero que llegue la bala

    Rigidbody enemyRb;

    private void Awake()
    {
        DOTween.Init(false, true, LogBehaviour.ErrorsOnly); //Se inicializa el Dotween
        enemy = GameObject.FindGameObjectWithTag("Enemy");        
    }

    void Start()
    {
        enemyRb = enemy.GetComponent<Rigidbody>();
        Vector3 v = enemyRb.velocity;

        transform.DOMove(enemy.transform.position + v * bulletTime, bulletTime).SetEase(Ease.Linear);
    }


    void Update()
    { 
        transform.DOMove(enemy.transform.position, bulletTime).SetEase(Ease.Linear); //Se mueve el objeto que tiene el script hasta la posicion del objeto enemy en un tiempo determinado con arranque y frenado linear
        //Las velocidades de arranque y freno (SetEase) pueden consultarse en: https://easings.net/

        transform.DOMove(enemy.transform.position, bulletTime).SetEase(Ease.InOutCubic).OnComplete(() => { Debug.Log("Se realiza una accion al terminar"); }); //Se mueve el objeto que tiene el script hasta la posicion del objeto enemy en un tiempo determinado, con arranque y frenado easeInOutCubic
    }
}
