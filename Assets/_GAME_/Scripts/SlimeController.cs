using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public Transform target;
    private Animator animator;
    private Rigidbody2D rb;
    public float speed = 2.0f;
    public float range = 5.0f;

    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
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
}
