using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    private float _speed = 5;

    public int health;

    public bool SpeedPowerUp = false;
  
	// Use this for initialization
	private void Start ()
    {
        transform.position = new Vector3(0, 0, 0);
        health = 3;
	}
	
	// Update is called once per frame
	private void Update ()
    {

        //calls input
        // PInput();

        AlternativeMovement();
        PlayerBounds();
        SpeedControl();
      
    }

    private void AlternativeMovement ()
    {
        var deltaPosition = _speed * Time.deltaTime;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * deltaPosition * h);
        transform.Translate(Vector3.up * deltaPosition * v);
    } 

    private void SpeedControl()
    {
        if (SpeedPowerUp)
        {
            _speed = 8;
        }
        else
        {
            _speed = 5;
        }
    }

    private void PlayerBounds ()
    {
        float verticalBoundary = 4;
        float horizontalBoundary = 9.2f;


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

    public void SpeedPowerupOn()
    {
        SpeedPowerUp = true; 
        StartCoroutine(SpeedPowerupTimer()); 
    }

    public IEnumerator SpeedPowerupTimer()
    {
        yield return new WaitForSeconds(5.0f);
        SpeedPowerUp = false;
    }

    public void PlayerDamage()
    {
        health--;

        if (health < 1)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            PlayerDamage();
        }
        
    }


}
