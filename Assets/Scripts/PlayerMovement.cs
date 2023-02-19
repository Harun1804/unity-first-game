using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private float dirX = 0;
    [SerializeField] private float moveState = 5f;
    [SerializeField] private float jumpForce = 6f;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        dirX = movementState();
        animationState();
    }
    private float movementState() 
    {
        dirX = Input.GetAxisRaw("Horizontal");
        rigidbody2D.velocity = new Vector2(dirX * moveState, rigidbody2D.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
        }

        return dirX;
    }
    private void animationState()
    {
        if (dirX > 0f)
        {
            animator.SetBool("is_running", true);
            spriteRenderer.flipX = false;
        }
        else if(dirX < 0f)
        {
            animator.SetBool("is_running", true);
            spriteRenderer.flipX = true;
        }
        else
        {
            animator.SetBool("is_running", false);
        }
    }
}
