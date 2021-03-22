using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static PlayerController instance;

    public float moveSpeed;
    public float jumpHeight;
    public Rigidbody2D theRB; // rigidbody component var

    private bool isGrounded; //to check if the player is gruonded. Default value false
    public Transform groundCheckPoint; // point to check if player isGounded
    public LayerMask whatIsGround; // to set the interacting layer

    private bool canDoubleJump; // check if player can jump twice

    private Animator anim; // animator component
    private SpriteRenderer theSR; // sprite renderer component

    public float knockBackLength, knockBackForce;
    private float knockBackCounter;

    public float bounceForce;


    private void Awake() {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        // setting components to variables
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() 
    {

        if (knockBackCounter <= 0) {

            theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y); // movement
            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, 0.2f, whatIsGround); // set the value to true if the point is interacting with whatever the ground layer is

            if (isGrounded) {
                canDoubleJump = true; // if player is grounded - set true
            }

            if (Input.GetButtonDown("Jump")) {  
                if (isGrounded) {
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpHeight); // jumping if key is pressed and if grounded is true
                    AudioManager.instance.playSFX(5);
                }else { // if not on the ground and can doubleJump - jump and unset canDJ
                    if (canDoubleJump) { 
                        theRB.velocity = new Vector2(theRB.velocity.x, jumpHeight);
                        canDoubleJump = false;
                        AudioManager.instance.playSFX(5);
                    }
                }
            }

           
            // setting the x value of theSR depending on x axis velocity - direction
            if (theRB.velocity.x < 0) {
                theSR.flipX = true;
            }
            else if (theRB.velocity.x > 0)
                theSR.flipX = false;

            

        }else { // knock back in opposite dir
            knockBackCounter -= Time.deltaTime;
            if (theSR.flipX) {
                theRB.velocity = new Vector2(knockBackForce, theRB.velocity.y);
            }else {
                theRB.velocity = new Vector2(-knockBackForce, theRB.velocity.y);
            }
        }

        // setting values to animator
        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("speed", Mathf.Abs(theRB.velocity.x));
    }


    public void knockBack() {
        knockBackCounter = knockBackLength;
        theRB.velocity = new Vector2(0f, knockBackForce);
        anim.SetTrigger("hurt"); // set trigger to set off an animation
    }


    public void bounce() {
        theRB.velocity = new Vector2(theRB.velocity.x, bounceForce);
        AudioManager.instance.playSFX(5);
    }


    
}
