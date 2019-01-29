using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goose : MonoBehaviour {


    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = false;
    float dirX, moveSpeed;
    public float jumpForce = 1000;

    private Rigidbody2D rb2d;
    Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        moveSpeed = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("w"))
        {
            jump = true;
            anim.SetBool("isWalking", false);
            anim.SetBool("isFlying", true);
        }

        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + dirX, transform.position.y);

        if (dirX != 0 && !anim.GetCurrentAnimatorStateInfo(0).IsName("gooseFly"))
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (dirX > 0 && !facingRight)
        {
            Flip();
        }
        else if (dirX < 0 && facingRight)
        {
            Flip();
        }

        if (jump)
        {
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false; //So you cant double jump
        }

    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
