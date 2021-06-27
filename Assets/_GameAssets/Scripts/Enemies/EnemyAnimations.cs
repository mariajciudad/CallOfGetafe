using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Gestiona las animaciones de los enemigos
public class EnemyAnimations : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void ChangeStateToIdle()
    {
        animator.SetBool("Walk", false);
    }

    public void ChangeStateToWalk()
    {
        animator.SetBool("Walk", true);
    }

    public void ChangeStateToRun()
    {
        animator.SetBool("Run", true);
    }

    public void ChangeStateToDie()
    {

    }

    public void ChangeStateToInmolate()
    {

    }
}
