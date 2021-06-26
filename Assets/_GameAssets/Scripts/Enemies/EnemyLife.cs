using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

//Gestiona la vida de los enemigos
public class EnemyLife : MonoBehaviour
{
    [SerializeField] int life;
    Rigidbody rigidBody;
    [SerializeField] Renderer ms;
    CrazyAgent crazyAgent;
    NavMeshAgent navMeshAgent;
    [SerializeField] EnemyVision enemyVision;
    [SerializeField] Slider healthBarSlider; 
    [SerializeField] Image healthBarColor;
    public SoundManager soundManager;

    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        ms = GetComponent<Renderer>();
        crazyAgent = GetComponent<CrazyAgent>();
        enemyVision = GetComponent<EnemyVision>();
        navMeshAgent = GetComponent<NavMeshAgent>();

        healthBarSlider.value = life;
        Debug.Log("Vida enemigo: " + life);
    }

    //Reduce la vida del enemigo. Si llega a 0, muere 
    public void RemoveLife(int damage)
    {
        life -= damage;

        HealthBar(life);

        soundManager.EnemySoundHurt();

        if (life <= 0)
        {
            enemyVision.enabled = false;
            DesactiveParameters();
            Destroy(gameObject);
        }
    }
    
    //Desactiva los parámetros del enemigo para que deje de patrullar y le afecten las físicas
    void DesactiveParameters()
    {        
        rigidBody.isKinematic = false;
        crazyAgent.enabled = false;  
        navMeshAgent.enabled = false;
    }

    public void HealthBar(int amount)
    {
        healthBarSlider.value = life;

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