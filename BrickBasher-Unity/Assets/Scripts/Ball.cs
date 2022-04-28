/**** 
 * Created by: Bob Baloney
 * Date Created: April 20, 2022
 * 
 * Last Edited by: 
 * Last Edited:
 * 
 * Description: Controls the ball and sets up the intial game behaviors. 
****/

/*** Using Namespaces ***/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Ball : MonoBehaviour
{
    //variables
    [Header("General Settings")]
    public int ballTxt;
    public int scoreTxt;

    [Header("Ball Settings")]
    public int numBalls;
    public float speed = 10f;
    Paddle paddle;
    public bool isInPlay = false;
    Rigidbody rb;


 


    //Awake is called when the game loads (before Start).  Awake only once during the lifetime of the script instance.
    void Awake()
    {
        rb = this.GetComponent<Rigidbody>();
    }//end Awake()


        // Start is called before the first frame update
        void Start()
    {
        SetStartingPos(); //set the starting position

    }//end Start()

    // Update is called once per frame
    void Update()
    {
        if(isInPlay == false)
        {
            Vector3 pos = new Vector3();
            pos.x = paddle.transform.position.x; //x position of the paddle.
            if (Input.GetKeyDown(KeyCode.Space))
            {
                isInPlay = true;
                Move();
            }
        }
    }//end Update()


    private void LateUpdate()
    {
        if(isInPlay == true)
        {
            rb.velocity = speed * rb.velocity.normalized;
        }

    }//end LateUpdate()


    void SetStartingPos()
    {
        isInPlay = false;//ball is not in play
        rb.velocity = Vector3.zero;//set velocity to keep ball stationary

        Vector3 pos = new Vector3();
        pos.x = paddle.transform.position.x; //x position of paddel
        pos.y = paddle.transform.position.y + paddle.transform.localScale.y; //Y position of paddle plus it's height

        transform.position = pos;//set starting position of the ball 
    }//end SetStartingPos()

    void OnTriggerEnter(collider other)
    {
        if(other.compareTag("Brick") == true)
        {
            scoreTxt += 100;
            Destroy(other);
        }
        if(other.compareTag("OutBounds") == true)
        {
            numBalls--;
        }
        if(numBalls > 0)
        {
            Invoke(SetStartingPos, 2);
        }
    }

    public void Move()
    {

    }
}
