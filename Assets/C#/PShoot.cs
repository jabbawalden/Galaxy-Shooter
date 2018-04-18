using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PShoot : MonoBehaviour {

    [SerializeField]
    float laserSpeed;

    public GameObject laserSpawn;

	// Use this for initialization
	void Start ()
    {
        laserSpeed = 10;
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        PlayerShoot();
	}

    void PlayerShoot ()
    {
        //if player presses space, instantiate laser at position above player
        //have lazer travelling at set speed

        Vector3 spawnPos = transform.position + new Vector3(0, 0.88f, 0);
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //spawn laserCopy

            GameObject lFinal = Instantiate(laserSpawn, spawnPos, Quaternion.identity);
            lFinal.GetComponent<Rigidbody2D>().velocity = new Vector3(0, laserSpeed, 0);
        }
      
    }
}
