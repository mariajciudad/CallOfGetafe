using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; //Se importa la libreria de Dotween

public class TestDotweenDoPath : MonoBehaviour
{
    public Vector3[] path1; //Array de Vectores3, es el camino que quiero que siga. En tiempo de ejecucion puede cambiar el camino
    public float pathTime; //El tiempo
    Sequence mySequence; //

    private void Awake()
    {
        DOTween.Init(false, true, LogBehaviour.ErrorsOnly); //Se inicializa el Dotween
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            transform.DOPath(path1, pathTime, PathType.CatmullRom, PathMode.Full3D, 10, Color.white).SetEase(Ease.InOutCubic); //
        }

        else if (Input.GetKeyDown(KeyCode.I))
        {
            transform.DOPath(path1, pathTime, PathType.CatmullRom, PathMode.Full3D, 10, Color.white).SetLoops(3, LoopType.Yoyo).SetEase(Ease.InOutCubic);
        }
        //Al pulsar U, se inicia el trayecto por el camino trazado anteriormente
        else if (Input.GetKeyDown(KeyCode.U))
        {
            mySequence = DOTween.Sequence(); //Crea un objeto de tipo sequence
            mySequence.Append(transform.DOPath(path1, pathTime, PathType.CatmullRom, PathMode.Full3D, 10, Color.white).SetLoops(3, LoopType.Yoyo).SetEase(Ease.InOutCubic)).OnComplete(() => { Debug.Log("Jose"); });
        }
        //Al pulsar Y, se detiene el trayecto
        else if (Input.GetKeyDown(KeyCode.Y))
        {
            mySequence.Kill();
        }
    }
}
