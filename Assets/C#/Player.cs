using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    Rigidbody2D rb;

    [SerializeField]
    private float _speed = 5;
    [SerializeField]
    private GameObject _explosion;
    [SerializeField]
    private int _shieldHits;
    [SerializeField]
    private GameObject _shield;

    public int health;


    public bool SpeedPowerUp = false;
    public bool shieldsActive = false;
    private UIManager _uIManager;
    private GameControl _gameControl;
    private SpawnManager _spawnManager;

	// Use this for initialization
	private void Start ()
    {
        transform.position = new Vector3(0, 0, 0);
        health = 3;
        _shieldHits = 3;
        _shield.SetActive(false);
        

        _uIManager = GameObject.Find("UI").GetComponent<UIManager>();
        _gameControl = GameObject.Find("GameManager").GetComponent<GameControl>();
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();

        if (_uIManager != null)
        {
            _uIManager.UpdateLives(health);
        }

        if (_spawnManager != null)
        {
            _spawnManager.StartSpawn();
        }
        
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

    private void HealthCheck()
    {
        if (health == 0)
        {
            _gameControl.gameOver = true;
        }
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

    public void EnableShields()
    {
        shieldsActive = true;
        _shield.SetActive(true);
    }

    public void PlayerDamage()
    {
        if (shieldsActive)
        {
            
            _shieldHits--;

            if (_shieldHits <= 0)
            {
                _shield.SetActive(false);
                shieldsActive = false;
                _shieldHits = 3;
                return;
            }
            

        }
        else if (!shieldsActive)
        {
            health--;
            _uIManager.UpdateLives(health);

            if (health <= 0)
            {
                Instantiate(_explosion, transform.position, Quaternion.identity);
                _gameControl.gameOver = true;
                Destroy(this.gameObject);  
            }

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
