using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpController : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private float fallGravityScale;
    private Rigidbody2D rb;

    [SerializeField] private bool onGround = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (rb != null)
        {
            if (onGround && Input.GetKeyDown(KeyCode.Space))
            {
                Jump();
                onGround = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (IsGrounded())
        {
            rb.gravityScale = 1f; 
        }
        else
        {
            rb.gravityScale = fallGravityScale; 
        }
    }

    private void Jump()
    {
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    private bool IsGrounded()
    {
        return onGround;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            onGround = true;
            print($"{gameObject.name} esta en el {collision.gameObject.name}");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            print($"{gameObject.name} ha saltado");
        }
    }
}
