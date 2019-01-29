using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour{

    [HideInInspector] public bool facingRight = true;
    [HideInInspector] public bool jump = false;

    public float moveForce = 365;
    public float maxSpeed = 5f;
    public float jumpForce = 1000;
    public Transform groundCheck; //Check to see if the user is on the ground

    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;

	// Use this for initialization
	void Awake (){
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update (){
        //grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));
        //To implement double jump change grounded

        if (Input.GetButtonDown("Jump")){
            jump = true;
        }
	}

    private void FixedUpdate(){
        float h = Input.GetAxis("Horizontal");
        anim.SetFloat("Speed", Mathf.Abs(h)); //Use the positive float of the horizontal axis of the speed

        if (h * rb2d.velocity.x < maxSpeed){
            rb2d.AddForce(Vector2.right * h * moveForce);
        }

        if(Mathf.Abs(rb2d.velocity.x) > maxSpeed){
            rb2d.velocity = new Vector2 (Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
        }

        if(h > 0 && !facingRight){
            Flip();
        }
        else if(h < 0 && facingRight){
            Flip();
        }
        
        if(jump){
            anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false; //So you cant double jump
        }
    }

    void Flip(){ //Flip the sprite around
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
