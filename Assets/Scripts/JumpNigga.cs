using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpNigga : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed = 3;
    public float jumpAmount = 10;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    private Vector2 startPosition;
    private bool doubleJump;
    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        bool isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (isGrounded && doubleJump != true)
        {
            doubleJump = true;
        }
        if (isGrounded && Input.GetKeyDown(KeyCode.Space) || doubleJump == true && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpAmount, ForceMode2D.Impulse);
            doubleJump = false;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(Vector2.left * speed);
            rb.AddForce(Vector2.right - Vector2.right);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(Vector2.right * speed);
            rb.AddForce(Vector2.left - Vector2.left);
        }

        if (transform.position.y < -10)
        {
            ResetToStartPosition();
        }
    }

    void ResetToStartPosition()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
    }
}
