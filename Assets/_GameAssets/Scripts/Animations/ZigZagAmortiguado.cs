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
        y = Mathf.Cos(Time.time * speed) * amplitude;
        transform.position = new Vector3(
            transform.position.x, 
            initialY + y, 
            transform.position.z);
    }
}
