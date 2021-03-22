using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    public float speed;

    public Transform leftPoint, rightPoint; // points to move to

    private bool movingRight;

    private Rigidbody2D theRB;
    public SpriteRenderer theSR; // public because it's a child obj
    private Animator anim;

    //public float moveTime, waitTime; frog
    //private float moveCount, waitCount; frog

    // Start is called before the first frame update
    void Start()
    {
        theRB = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        // on start, move points outside the enemy object so the points dont move with the object
        leftPoint.parent = null;
        rightPoint.parent = null;

        movingRight = true;

        //moveCount = moveTime; frog
    }

    // Update is called once per frame
    void Update()
    {

        //if (moveCount > 0) { frog animation and random wait time

           // moveCount -= Time.deltaTime;

            if (movingRight) {
                theRB.velocity = new Vector2(speed, theRB.velocity.y);
                theSR.flipX = true;
                if (transform.position.x > rightPoint.position.x) {
                    movingRight = false;
                }
            }
            else {
                theRB.velocity = new Vector2(-speed, theRB.velocity.y);
                theSR.flipX = false;
                if (transform.position.x < leftPoint.position.x) {
                    movingRight = true;
                }
            }

            /*if(moveCount <= 0) { frog animation and random wait time
                waitCount = Random.Range(waitTime * .75f, waitTime * 1.25f);
            }
            anim.SetBool("isMoving", true);
        }else if(waitCount > 0) {
            waitCount -= Time.deltaTime;
            theRB.velocity = new Vector2(0f, theRB.velocity.y);

            if(waitCount <= 0) {
                moveCount = Random.Range(moveTime * .75f, waitTime * .75f); ;
            }
            anim.SetBool("isMoving", false);
        }*/
    }
}
