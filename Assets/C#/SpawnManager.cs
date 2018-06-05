using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField]
    private GameObject _enemyship;
    [SerializeField]
    private GameObject[] _powerups;
    private GameControl _gameControl;
    // 0 = tripple, 1 = speed, 2 = shield

    public float enemyTime;
    public float powerUpTime;
    public float globalEnemySpeed;

    // Use this for initialization
    void Start ()
    { 
        _gameControl = GameObject.Find("GameManager").GetComponent<GameControl>();
    }


    private void SpawnEnemy()
    {
        float randomX = Random.Range(-7, 7);
        Vector3 enemySpawnLocation = new Vector3(randomX, 5, 0);
        Instantiate(_enemyship, enemySpawnLocation, Quaternion.identity);
    }

    
    public IEnumerator EnemySpawnTimer()
    {
        while (_gameControl.gameOver == false)
        {
            SpawnEnemy();
            print("spawnEnemySuccess");
            yield return new WaitForSeconds(enemyTime);
        }
    }

    private void PowerUpSpawn()
    {
        int randomPowerup = Random.Range(0, 3); //will choose either 0, 1 or 2
        float randomX = Random.Range(-7, 7);
        Vector3 powerUpSpawnLocation = new Vector3(randomX, 5, 0);

        Instantiate(_powerups[randomPowerup], powerUpSpawnLocation, Quaternion.identity);
    }

    public IEnumerator PowerUpSpawnTimer()
    {
        while (_gameControl.gameOver == false)
        {
            PowerUpSpawn();
            print("spawnPowerUpSuccess");
            yield return new WaitForSeconds(powerUpTime);  
        }
    }

    public IEnumerator TimeSpawnSpeedUp()
    {
        while (_gameControl.gameOver == false)
        {   
            yield return new WaitForSeconds(10);
            enemyTime /= 1.1f;
            powerUpTime /= 1.05f;
            globalEnemySpeed /= 1.005f;
            
        }
        
    }

    public void StartSpawn()
    {
        globalEnemySpeed = 2.5f;
        enemyTime = 2;
        powerUpTime = 8;
        StartCoroutine(EnemySpawnTimer());
        StartCoroutine(PowerUpSpawnTimer());
        StartCoroutine(TimeSpawnSpeedUp());
        
    }

    public void StopSpawn()
    {
        StopAllCoroutines();
    }
}
