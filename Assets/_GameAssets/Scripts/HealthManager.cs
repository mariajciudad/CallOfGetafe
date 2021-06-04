using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; //Libreria del canvas

public class HealthManager : MonoBehaviour
{
    [SerializeField] int playerLife;
    [SerializeField] int maxLife;

    GameObject gameOverPanel;

    [SerializeField] Text textLife;

    private void Start()
    {
        textLife.text = playerLife.ToString(); //Al empezar el juego, se muestra su vida inicial
    }

    public void AddLife(int lifeCatch) //Añade o recupera vida, se cura
    {
        playerLife += lifeCatch;

        if (playerLife > maxLife)
        {
            playerLife = maxLife;
        }

        textLife.text = playerLife.ToString(); //Se accede a la propiedad Text del componente Text de un canvas
    }

    public void RemoveLife(int damage) //Recibe daño
    {
        playerLife -= damage;

        if (playerLife <= 0) //Si la vida del player es 
        {
            playerLife = 0;
            gameOverPanel.SetActive(true);
        }

        textLife.text = playerLife.ToString();
    }


}
