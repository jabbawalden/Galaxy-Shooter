using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PShoot : MonoBehaviour {

    

    [SerializeField]
    private float _laserSpeed;

    [SerializeField]
    private GameObject _laserSpawn;

    [SerializeField]
    private float _fireRate;
    private float _nextFire;

    public bool trippleShotUpgrade = false;
    private float _trippleTime = 0.0f;
    [SerializeField]
    private float _trippleSetTime;

    // Use this for initialization
    private void Start ()
    {
        _laserSpeed = 10;
		
	}
	
	// Update is called once per frame
	private void Update ()
    {
        PlayerShootInput();
        TrippleShotUpgrade();

    }

    private void TrippleShotUpgrade ()
    {
        if (trippleShotUpgrade)
        {
            _trippleSetTime -= 1;
            
            if (_trippleSetTime <= 0)
            {
                trippleShotUpgrade = false;
            }
        }

        if (!trippleShotUpgrade)
        {
            _trippleSetTime = 500;
            
        }


    }

    private void PlayerShootInput ()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            Shoot();
        }
    }

    private void Shoot ()
    {
        //if player presses space, instantiate laser at position above player
        //have lazer travelling at set speed
        //sets firerate - adds fireRate to Time.time, then checks if the new amount of time has passed
        //before allowing for firing again.

        Vector3 spawnPos = transform.position + new Vector3(0, 0.88f, 0);
        Vector3 spawnPos2 = transform.position + new Vector3(0.5f, -0.2f, 0);
        Vector3 spawnPos3 = transform.position + new Vector3(-0.5f, -0.2f, 0);

        if (Time.time > _nextFire)
        {
            //spawn laserCopy
            _nextFire = Time.time + _fireRate;

            GameObject Shot1 = Instantiate(_laserSpawn, spawnPos, Quaternion.identity);
            Shot1.GetComponent<Rigidbody2D>().velocity = new Vector3(0, _laserSpeed, 0);

            if (trippleShotUpgrade)
            {
                GameObject Shot2 = Instantiate(_laserSpawn, spawnPos2, Quaternion.identity);
                Shot2.GetComponent<Rigidbody2D>().velocity = new Vector3(0, _laserSpeed, 0);

                GameObject Shot3 = Instantiate(_laserSpawn, spawnPos3, Quaternion.identity);
                Shot3.GetComponent<Rigidbody2D>().velocity = new Vector3(0, _laserSpeed, 0);

                
            }
           
        }
      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }

}
