using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; //Se importa la libreria de Dotween

public class TestDotween : MonoBehaviour
{
    public float bulletTime; //Tiempo de la bala
    public GameObject enemy; //Enemigo hasta donde quiero que llegue la bala



    private void Awake()
    {
        DOTween.Init(false, true, LogBehaviour.ErrorsOnly); //Se inicializa el Dotween
        enemy = GameObject.FindGameObjectWithTag("Enemy");        
    }
    
    // Start is called before the first frame update
    void Update()
    { 

        transform.DOMove(enemy.transform.position, bulletTime).SetEase(Ease.Linear); //Se mueve el objeto que tiene el script hasta la posicion del objeto enemy en un tiempo determinado de forma linear
    }
}
