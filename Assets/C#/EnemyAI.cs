using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    [SerializeField]
    private float _speed;

	// Use this for initialization
	void Start ()
    {
        _speed = 3f;
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
        float randomX = Random.Range(-7.5f, 7.5f);
        if (transform.position.y <= -6)
        {
            //between 7 and 7 on the x
            transform.position = new Vector3(randomX, 7, transform.position.z);
        }
    }
}

