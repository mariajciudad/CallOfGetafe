using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerLife;

    [SerializeField] int maxPlayerLife;

    [SerializeField] Text lifeText;


    private void Start()
    {
        //Al empezar el juego, se muestra la vida inicial en la propiedad Text del componente Text del canvas
        lifeText.text = playerLife.ToString(); 
    }

    //Añade vida al coger un botiquín
    public void AddLife(int amount)
    {
        playerLife += amount;

        if(playerLife > maxPlayerLife)
        {
            playerLife = maxPlayerLife;
        }

        lifeText.text = playerLife.ToString();
    }

    public void RemoveLife(int amount)
    {
        playerLife -= amount;

        if (playerLife < 0)
        {
            playerLife = 0;
        }

        lifeText.text = playerLife.ToString();
    }
   
}
