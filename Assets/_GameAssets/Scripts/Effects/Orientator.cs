using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientator : MonoBehaviour
{
    [SerializeField] private Transform target; //O le arrastro el target porque esta en la escena y no es un prefab...
    [SerializeField] private string targetName;
    private void Start() {
        if (target==null && targetName.Length==0){
            Debug.LogError("Debes introducir o target o targetName");
            return;
        }
        if (target==null){
            target=GameObject.Find(targetName).transform;  //...o le pongo el nombre por escrito
        }
    }
    void Update()
    {
        transform.LookAt(target);
    }
}
