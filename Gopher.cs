using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gopher : MonoBehaviour {

    [HideInInspector] public bool facingRight = true;
    float dirX, moveSpeed;

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator> ();
        moveSpeed = 5f;
	}
	
	// Update is called once per frame
	void Update () {
        dirX = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;

        transform.position = new Vector2(transform.position.x + dirX, transform.position.y);

        if (dirX != 0 && !anim.GetCurrentAnimatorStateInfo(0).IsName("moleDig"))
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }

        if (Input.GetKeyDown("s") && !anim.GetCurrentAnimatorStateInfo(0).IsName("moleDig")&& dirX == 0)
        {
            
            anim.SetBool("isWalking", false);
            anim.SetTrigger("dig");
        }

        if (Input.GetKeyDown("w") && !anim.GetCurrentAnimatorStateInfo(0).IsName("moleDig")&& dirX == 0)
        {
            anim.SetBool("isWalking", false);
            anim.SetTrigger("digUp");
        }
        
        if (dirX > 0 && !facingRight)
        {
            Flip();
        }
        else if(dirX < 0 && facingRight)
        {
            Flip();
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
