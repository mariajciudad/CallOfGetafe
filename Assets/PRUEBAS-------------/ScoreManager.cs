using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager scoreManagerInstance;

    [SerializeField]
    int score;


    private void Awake()
    {
        if(scoreManagerInstance == null)
        {
            scoreManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);        
    }

    private void OnLevelWasLoaded(int level)
    {
        if(level == 8)
        {
            Destroy(gameObject);
        }
    }
}
