using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private BoxCollider2D bc;

    private float dirX = 0;
    [SerializeField] private float moveState = 5f;
    [SerializeField] private float jumpForce = 6f;
    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private AudioSource jumpAudio;

    private enum MovementState {idling, running, jumping, falling}
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");
        if (rb.bodyType != RigidbodyType2D.Static)
        {
            rb.velocity = new Vector2(dirX * moveState, rb.velocity.y);
        }

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpAudio.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
        animationState();
    }

    private void animationState()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            spriteRenderer.flipX = false;
        }
        else if(dirX < 0f)
        {
            state = MovementState.running;
            spriteRenderer.flipX = true;
        }
        else
        {
            state = MovementState.idling;
        }

        if (rb.velocity.y > .1f) 
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        animator.SetInteger("state", (int)state);
    }

    private bool IsGrounded() 
    {
        return Physics2D.BoxCast(bc.bounds.center, bc.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
