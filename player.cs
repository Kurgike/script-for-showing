using System.Collections; 
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehavior 
{
    float horizontal;
    float speed = 8f;
    float jumpingPower = 16f;
    bool isFacingRight = true;

    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && IsGrounded) {
        rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
        }

        if (input.GetButtonUp("Jump") && rb.velocity.y > Of)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0,5f);
        }

        Flip();
    }

    void FixedUpdate() {
        rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
    }

    bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    void Flip() {
        if (isFacingRight && horizontal < Of || !isFacingRight && horizontal > Of)
    {
        isFacingRight = !isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }   
        }

}
