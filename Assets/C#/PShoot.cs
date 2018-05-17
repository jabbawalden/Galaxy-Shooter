using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PShoot : MonoBehaviour {

    [SerializeField]
    private float _laserSpeed;

    [SerializeField]
    private GameObject _laserSpawn;
    [SerializeField]
    private GameObject _tripplShotSpawn;

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
        _laserSpeed = 13;
		
	}
	
	// Update is called once per frame
	private void Update ()
    {
        PlayerInput();
        //TrippleShotUpgrade();

    }

    private void PlayerInput ()
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
        //Vector3 spawnPos2 = transform.position + new Vector3(0.5f, -0.2f, 0);
        //Vector3 spawnPos3 = transform.position + new Vector3(-0.5f, -0.2f, 0);

        if (Time.time > _nextFire)
        {
            //spawn laserCopy
            _nextFire = Time.time + _fireRate;

            
            if (trippleShotUpgrade)
            {
                GameObject TrippleShot = Instantiate(_tripplShotSpawn, transform.position, Quaternion.identity);
                TrippleShot.GetComponent<Rigidbody2D>().velocity = new Vector3(0, _laserSpeed, 0);


                
            } else
            {
                GameObject Shot1 = Instantiate(_laserSpawn, spawnPos, Quaternion.identity);
                Shot1.GetComponent<Rigidbody2D>().velocity = new Vector3(0, _laserSpeed, 0);
            }
            
           
        }
      
    }

    public void TrippleShotPowerupOn()
    {
        trippleShotUpgrade = true;
        StartCoroutine(TrippleShotPowerTimer());
    }

    public IEnumerator TrippleShotPowerTimer()
    {
        yield return new WaitForSeconds(5.0f);
        trippleShotUpgrade = false;
    }
}
