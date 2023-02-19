using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        rigidbody2D.velocity = new Vector2(dirX * 5f, rigidbody2D.velocity.y);

        if (Input.GetButtonDown("Jump"))
        {
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, 6f);
        }
    }
}
