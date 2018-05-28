using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    [SerializeField]
    private float _speed;
    [SerializeField]
    private GameObject _enemyExplosion;

    private UIManager _uIManager;
    private SpawnManager _spawnManager;

    // Use this for initialization
    void Start ()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _speed = _spawnManager.globalEnemySpeed;
        _uIManager = GameObject.Find("UI").GetComponent<UIManager>();
    
    }
	
	// Update is called once per frame
	void Update ()
    {
        EnemyMovement();
        EnemyReposition();
	}

    public void EnemyMovement()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
    }

    private void EnemyReposition()
    {
        if (transform.position.y <= -6)
        {
            //between 7 and 7 on the x
            //transform.position = new Vector3(randomX, 7, transform.position.z);
            Destroy(this.gameObject);
        }
    }

    //enemy destruction
    public void EnemyDestruction()
    {
        GameObject explosion = Instantiate(_enemyExplosion, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag == "PlayerLaser")
        {
            EnemyDestruction();
            Destroy(collision.gameObject);

            if (_uIManager != null)
            {
                _uIManager.UpdateScore();
            }
           
        }

        if (collision.tag == "Player")
        {  
            EnemyDestruction();

            if (_uIManager != null)
            {
                _uIManager.UpdateScore();
            }
        }
    }
}

