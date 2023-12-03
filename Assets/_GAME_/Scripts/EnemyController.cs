using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    private Animator animator;
    private Rigidbody2D rb;
    public float speed = 2.0f;
    public float range = 5.0f;
    public int maxHealth = 50;
    public int currentHealth;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        if(distanceToTarget <= range)
        {
            FollowPlayer();
        }
        else
        {
            animator.SetBool("isMoving", false);
            rb.velocity = Vector2.zero;
        }
           
    }
    
    void FollowPlayer()
    {     

        animator.SetBool("isMoving", true);
        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * speed;

    }
   public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("isDefeated", true);
        Destroy(gameObject);
    }
}
