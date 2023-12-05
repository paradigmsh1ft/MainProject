using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    private Animator animator;
    private Rigidbody2D rb;
    private CircleCollider2D cCollider;

    public float speed = 2.0f;
    public float range = 5.0f;
    public int maxHealth = 50;
    public int currentHealth;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        cCollider = rb.GetComponent<CircleCollider2D>();
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
            StartCoroutine(Die());
        }
    }
    IEnumerator Die()
    {
        animator.SetBool("isMoving", false);
        animator.SetBool("isDefeated", true);
      
        rb.velocity = Vector2.zero;

        cCollider.enabled = false;

        yield return new WaitForSeconds(0.6f); 

        Destroy(gameObject); 
    }
}
