using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] int playerLife;
    [SerializeField] int maxPlayerLife;   
    [SerializeField] Slider healthBarSlider; //Vida en la barra de salud
    [SerializeField] Image healthBarColor; //Colores en la barra de salud 

    private void Start()
    {
        //Al empezar el juego, el Slider mostrará la vida completa del player
        healthBarSlider.value = playerLife;
    }

    //El player recupera vida al coger un botiquín y se actualiza el Slider
    public void AddLife(int amount)
    {
        playerLife += amount;

        if(playerLife > maxPlayerLife)
        {
            playerLife = maxPlayerLife;
        }
    
        HealthBar(playerLife);
    }

    //El player recibe una cantidad de daño y se actualiza el Slider
    public void RemoveLife(int amount)
    {
        playerLife -= amount;

        if (playerLife < 0)
        {
            playerLife = 0;
        }

        HealthBar(playerLife);        
    }

    //La barra de salud cambia de tamaño y colores según aumente o disminuya la vida del player
    public void HealthBar(int amount)
    {
        healthBarSlider.value = playerLife;

        if (amount >= 50)
        {
            healthBarColor.color = new Color32(19, 233, 109, 255);
        }

        else if (amount > 25 && amount < 50)
        {
            healthBarColor.color = new Color32(233, 223, 19, 255);
        }
        else
        {
            healthBarColor.color = new Color32(233, 19, 25, 255);
        }
    }   
}
