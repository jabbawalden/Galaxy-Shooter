using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{

    [SerializeField]
    float speed;
    [SerializeField]
    private int powerupID; //0 = Tripple, 1 = speed boost, 2 = shield
    private GameControl _gameControl;
    [SerializeField]
    private AudioClip _audioPowerUp;
    // Use this for initialization
    void Start ()
    {
        _gameControl = GameObject.Find("GameManager").GetComponent<GameControl>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        Boundaries();

        if (_gameControl.gameOver)
        {
            DestroyObject();
        }
	}

    private void Boundaries()
    {
        if (transform.position.y <= -7)
        {
            DestroyObject();
        }
    }

    public void DestroyObject()
    {
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            PShoot player = collision.GetComponent<PShoot>();
            Player playerM = collision.GetComponent<Player>();
            if (player != null)
            {
                AudioSource.PlayClipAtPoint(_audioPowerUp, Camera.main.transform.position);

                if (powerupID == 0)
                {
                    //enable trippleshot
                    player.TrippleShotPowerupOn();
                }
                else if (powerupID == 1)
                {
                    //enable speed
                    playerM.SpeedPowerupOn();
                }
                else if (powerupID == 2)
                {
                    playerM.EnableShields();

                }
            }

            DestroyObject();
        }
     
    }

    //3 powerup setups
    //check name of object to activate relevant powerup
}
