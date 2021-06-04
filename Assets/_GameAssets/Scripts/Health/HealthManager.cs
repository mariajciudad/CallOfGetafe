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
        textLife.text = playerLife.ToString(); //Al empezar el juego, se muestra la vida inicial
    }

    //Añade o recupera vida al coger un botiquin
    public void AddLife(int lifeCatch) 
    {
        playerLife += lifeCatch;

        if (playerLife > maxLife)
        {
            playerLife = maxLife;
        }

        textLife.text = playerLife.ToString(); //Se accede a la propiedad Text del componente Text de un canvas
    }

    //Recibe daño
    public void RemoveLife(int damage) 
    {
        playerLife -= damage;

        if (playerLife <= 0) 
        {
            playerLife = 0;
            ActivateGameOverPanel();
        }

        textLife.text = playerLife.ToString();
    }

    void ActivateGameOverPanel()
    {
        gameOverPanel.SetActive(true);
    }


}
