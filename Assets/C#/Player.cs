using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    float speed = 5;
  
	// Use this for initialization
	void Start ()
    {
        transform.position = new Vector3(0, 0, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {

        //calls input
        // PInput();

        AlternativeMovement();
        PlayerBounds();
    }

    void AlternativeMovement ()
    {
        var deltaPosition = speed * Time.deltaTime;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * deltaPosition * h);
        transform.Translate(Vector3.up * deltaPosition * v);
    } 

    void PlayerBounds ()
    {
        float verticalBoundary = 4;
        float horizontalBoundary = 9.2f;

        if (transform.position.x >= verticalBoundary)
        {
            //wrap left
        }
        else if (transform.position.x <= -verticalBoundary)
        {
            //wrap right
        }

        if (transform.position.y > verticalBoundary - 1f)
        {
            transform.position = new Vector3(transform.position.x, 3, 0);

        } else if (transform.position.y  < -verticalBoundary)
        {
            transform.position = new Vector3(transform.position.x, -4, 0);
        }

        if (transform.position.x > horizontalBoundary)
        {
            transform.position = new Vector3(-9, transform.position.y, 0);

        } else if (transform.position.x < -horizontalBoundary)
        {
            transform.position = new Vector3(9, transform.position.y, 0);
        }

    

    }

    /*
    //GetAxis input
    void PInput ()
    {
        var deltaPosition = speed * Time.deltaTime;

        //GetAxis is a float value attached to keyboard inputs.
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        var axisForce = new Vector2(h, v);

        //Add movement capability into MovementForce function * speed
        MovementForce(axisForce * deltaPosition);
    }

    void MovementForce (Vector2 speedInput)
    {
        //moves object via axisForce vector input in speedInput
        transform.Translate(speedInput);
    }
    */

    
}
