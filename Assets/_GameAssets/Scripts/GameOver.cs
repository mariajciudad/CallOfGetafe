using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{     
    [SerializeField] Text dialogueTest;
    [SerializeField] GameObject gameOverScreen;

    private void Awake()
    {
        gameOverScreen.SetActive(false);
    }

    public void StartGameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }

    public void FinishGame()
    {
        Application.Quit();
    }


}
