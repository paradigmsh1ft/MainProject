using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float sprintSpeed = 6f;
    public float playerStamina = 3f;
    private float standartSpeed;

    private Rigidbody2D rb;
    private Animator animator;
    private CapsuleCollider capsuleCollider;
    private AttackController attackController;

    private void Start()
    {
        standartSpeed = moveSpeed;
        rb = GetComponent<Rigidbody2D>();   
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        attackController = GetComponent<AttackController>();
    } 
    private void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(moveX, moveY).normalized * moveSpeed;
        rb.velocity = movement;   
        
        if(Input.GetKeyDown(KeyCode.K))
        {
            rb.velocity = Vector2.zero;
            attackController.StartAttack();
        }

        MovementAnimation(moveX, moveY, movement);
        PlayerSprint();
        
    }
    
    private void PlayerSprint()
    {
        if(Input.GetKey(KeyCode.LeftShift) && playerStamina > 0)
        {
            moveSpeed = sprintSpeed;
            playerStamina -= Time.deltaTime * 1.5f;
        }
        else
        {
            playerStamina += Time.deltaTime * 0.35f;
            moveSpeed = standartSpeed;
        }

        if (playerStamina > 3f) playerStamina = 3f;  
    
    }

    private void MovementAnimation(float moveX, float moveY, Vector2 movement)
    {
        bool isMoving;
        if (movement != Vector2.zero)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }
        animator.SetFloat("moveX", moveX);
        animator.SetFloat("moveY", moveY);
        animator.SetBool("isMoving", isMoving);

    }
}
