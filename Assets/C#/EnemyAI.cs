using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] private float _speed;
    [SerializeField] private GameObject _enemyExplosion; 

    private UIManager _uIManager;
    private SpawnManager _spawnManager;
    private GameControl _gameControl;

    [SerializeField] private AudioClip[] _explosion;

    private AudioSource source;
    public AudioMixerGroup _output;
    

    // Use this for initialization

    void Start ()
    {
        

        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _speed = _spawnManager.globalEnemySpeed;
        _uIManager = GameObject.Find("UI").GetComponent<UIManager>();
        _gameControl = GameObject.Find("GameManager").GetComponent<GameControl>();
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
        if (transform.position.y <= -6 || _gameControl.gameOver)
        {
            //between 7 and 7 on the x
            //transform.position = new Vector3(randomX, 7, transform.position.z);    
            _uIManager.DeductScore();
            Destroy(this.gameObject);
        }
    }

    //enemy destruction
    public void EnemyDestruction()
    {
        GameObject explosion = Instantiate(_enemyExplosion, transform.position, Quaternion.identity);
        PlaySound();
        Destroy(this.gameObject);
    }

    void PlaySound()
    {
        int randomExplosion = Random.Range(0, _explosion.Length);
        source = gameObject.AddComponent<AudioSource>();
        source.outputAudioMixerGroup = _output;
        source.clip = _explosion[randomExplosion];

        AudioSource.PlayClipAtPoint(source.clip, Camera.main.transform.position);
        
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

