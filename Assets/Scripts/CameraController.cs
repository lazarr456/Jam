using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    public Transform target;

    public Transform farBG, middleBG, closeBG;

    public float minHeight, maxHeight;

    private float lastXPosition;

    // Start is called before the first frame update
    void Start()
    {
        lastXPosition = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        //cam follow
        /*
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);

        float clampedY = Mathf.Clamp(transform.position.y, minHeight, maxHeight);
        transform.position = new Vector3(transform.position.x, clampedY, transform.position.z);
        */

        //cam follow neat
        transform.position = new Vector3(target.position.x, Mathf.Clamp(target.position.y, minHeight, maxHeight), transform.position.z);


        



        float amountToMoveX = transform.position.x - lastXPosition;

        //moving different parts of bg at slower or faster pace for parallax effect
        farBG.position += new Vector3(amountToMoveX, 0f, 0f);
        middleBG.position += new Vector3(amountToMoveX * 0.4f, 0f, 0f);
        closeBG.position += new Vector3(amountToMoveX * 0.5f, 0f, 0f);
         
        lastXPosition = transform.position.x;



        
    }
}
