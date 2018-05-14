using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PProjectile : MonoBehaviour {

    

    // Use this for initialization
	private void Start ()
    {
		
	}
	
	// Update is called once per frame
	private void Update ()
    {
        DestroyOnBoundary();


    }

    private void DestroyOnBoundary ()
    {
        if (transform.position.y >= 6)
        {
            Destroy(this.gameObject);
        }
    }

}
