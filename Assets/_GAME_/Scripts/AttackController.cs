using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public PlayerController playerController;
    private EnemyController enemyController;
    private Animator animator;
    private Rigidbody2D enemyRb;

    public bool isDamaging = false;
    public int attackDamage = 25;

    private void Start()
    {
        enemyController = FindAnyObjectByType<EnemyController>();
        animator = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();      
    }

    public void StartAttack()
    {
        if (!isDamaging)
        {
            isDamaging = true;
            animator.SetBool("isAttacking", true);                  
        }
    }

    public void EndAttack()
    {
        isDamaging = false;
        animator.SetBool("isAttacking", false);    
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy")
        {
            enemyController.TakeDamage(attackDamage);                          
        }
      
    }
}
