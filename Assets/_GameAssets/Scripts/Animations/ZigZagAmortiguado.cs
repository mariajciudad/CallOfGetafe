using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZigZagAmortiguado : MonoBehaviour
{
    public float amplitude;
    public float speed;
    float initialY;
    float y;

    private void Awake()
    {
        initialY = transform.position.y;
        y = initialY;
    }
    void Update()
    {
        //Se calcula el coseno, que sirve para crear movimientos que no sean constantes, que tengan aceleracion y desaceleracion
        y = Mathf.Cos(Time.time * speed) * amplitude;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);
    }
}
