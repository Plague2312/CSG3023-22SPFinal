/**** 
 * Created by: Bob Baloney
 * Date Created: April 20, 2022
 * 
 * Last Edited by: 
 * Last Edited:
 * 
 * Description: Paddle controler on Horizontal Axis
****/

/*** Using Namespaces ***/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float speed = 10; //speed of paddle

    // Update is called once per frame
    void Update()
    {
        float xAxis = Input.GetAxis("Horizontal");
        Vector3 pos = transform.position;
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            pos.x = pos.x - (xAxis * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            pos.x += xAxis * speed * Time.deltaTime;
        }
    }//end Update()
}
