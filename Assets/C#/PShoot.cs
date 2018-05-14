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

    // Use this for initialization
    private void Start ()
    {
        _laserSpeed = 10;
		
	}
	
	// Update is called once per frame
	private void Update ()
    {
        PlayerShoot();
	}

    private void PlayerShoot ()
    {
        //if player presses space, instantiate laser at position above player
        //have lazer travelling at set speed
        //sets firerate - adds fireRate to Time.time, then checks if the new amount of time has passed
        //before allowing for firing again.

        Vector3 spawnPos = transform.position + new Vector3(0, 0.88f, 0);
        
        if (Input.GetKey(KeyCode.Space) && Time.time > _nextFire || Input.GetMouseButton(0) && Time.time > _nextFire)
        {
            //spawn laserCopy
            _nextFire = Time.time + _fireRate;

            GameObject lFinal = Instantiate(_laserSpawn, spawnPos, Quaternion.identity);
            lFinal.GetComponent<Rigidbody2D>().velocity = new Vector3(0, _laserSpeed, 0);
        }
      
    }
}
