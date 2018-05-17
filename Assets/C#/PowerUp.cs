using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour {

    [SerializeField]
    float speed;
   

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PShoot player = collision.GetComponent<PShoot>();

            if (player != null)
            {
                player.TrippleShotPowerupOn();
            }


            Destroy(this.gameObject);

        }
     
    }
}
