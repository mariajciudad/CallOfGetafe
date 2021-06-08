using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : MonoBehaviour
{
    private int health = 10;
    string message;
    // Start is called before the first frame update
    void Start()
    {
        if (health > 0)
        {
            message = "Player is alive";
        } 
        else
        {
            message = "Player is dead";
        }

        // Es lo mismo que decir: message = health > 0 ? "Player is alive" : "Player is dead";
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
