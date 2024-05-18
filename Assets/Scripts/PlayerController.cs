using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float moveSpeed;
    [SerializeField] float jumpStrength;
    public bool isGrounded;
    public PlayerHealth playerHealth;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
    void FixedUpdate()
    {
        PlayerMovement();
        Jump();
    }

    private void PlayerMovement()
    {
        float  moveX = Input.GetAxis("Horizontal") * moveSpeed; // assigns left and right player movement times the moveSpeed of the player;
        rb.velocity = new Vector2(moveX, rb.velocity.y);

        // Flips the player left and right
        if (moveX > 0.01f)
        {
            transform.localScale = Vector2.one;
        }
        else if (moveX < -0.01f)
        {
            transform.localScale = new Vector2(-1, 1);
        }
    }

    private void Jump()
    {
        if(Input.GetKey(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpStrength);
            isGrounded = false;
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Checks if the player is grounded. Is used to check if the player can jump or not
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
        // Check if the player is touching the enemy, check that enemy exists, and if collision take damage
        if(collision.gameObject.tag == "Enemy")
        {
            EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                playerHealth.TakeDamage();
            }
        }
    }
}
