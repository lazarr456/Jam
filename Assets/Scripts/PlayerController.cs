using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpHeight;
    public Rigidbody2D theRB;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    private bool canDoubleJump;

    private Animator anim;
    private SpriteRenderer theSR;



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() 
    {

        theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);

        isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, 0.2f, whatIsGround);

        if (isGrounded) {
            canDoubleJump = true;
        }

        if (Input.GetButtonDown("Jump")) {
            if (isGrounded) {
                theRB.velocity = new Vector2(theRB.velocity.x, jumpHeight);
            } else {
                if (canDoubleJump) {
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpHeight);
                    canDoubleJump = false;
                }
            }
        }

        if(theRB.velocity.x < 0) {
            theSR.flipX = true;
        }else if(theRB.velocity.x > 0)
            theSR.flipX = false;

        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("speed", Mathf.Abs(theRB.velocity.x));



    }
}
