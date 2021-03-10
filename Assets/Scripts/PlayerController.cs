using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public static PlayerController instance;

    public float moveSpeed;
    public float jumpHeight;
    public Rigidbody2D theRB;

    private bool isGrounded;
    public Transform groundCheckPoint;
    public LayerMask whatIsGround;

    private bool canDoubleJump;

    private Animator anim;
    private SpriteRenderer theSR;

    public float knockBackLength, knockBackForce;
    private float knockBackCounter;

    public float bounceForce;


    private void Awake() {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        theSR = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update() 
    {

        if (knockBackCounter <= 0) {

            theRB.velocity = new Vector2(moveSpeed * Input.GetAxis("Horizontal"), theRB.velocity.y);
            isGrounded = Physics2D.OverlapCircle(groundCheckPoint.position, 0.2f, whatIsGround);

            if (isGrounded) {
                canDoubleJump = true;
            }

            if (Input.GetButtonDown("Jump")) {
                if (isGrounded) {
                    theRB.velocity = new Vector2(theRB.velocity.x, jumpHeight);
                    AudioManager.instance.playSFX(5);
                }
                else {
                    if (canDoubleJump) {
                        theRB.velocity = new Vector2(theRB.velocity.x, jumpHeight);
                        canDoubleJump = false;
                        AudioManager.instance.playSFX(5);
                    }
                }
            }

           

            if (theRB.velocity.x < 0) {
                theSR.flipX = true;
            }
            else if (theRB.velocity.x > 0)
                theSR.flipX = false;

            

        }else {
            knockBackCounter -= Time.deltaTime;
            if (!theSR.flipX) {
                theRB.velocity = new Vector2(-knockBackForce, theRB.velocity.y);
            }else {
                theRB.velocity = new Vector2(knockBackForce, theRB.velocity.y);
            }
        }

        anim.SetBool("isGrounded", isGrounded);
        anim.SetFloat("speed", Mathf.Abs(theRB.velocity.x));

    }


    public void knockBack() {
        knockBackCounter = knockBackLength;
        theRB.velocity = new Vector2(0f, knockBackForce);
        anim.SetTrigger("hurt");
    }


    public void bounce() {
        theRB.velocity = new Vector2(theRB.velocity.x, bounceForce);
        AudioManager.instance.playSFX(5);
    }
}
