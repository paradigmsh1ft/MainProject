using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    private Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartAttack()
    {
        animator.SetBool("isAttacking", true);
    }
    public void EndAttack()
    {
        animator.SetBool("isAttacking", false);
    }




    }
