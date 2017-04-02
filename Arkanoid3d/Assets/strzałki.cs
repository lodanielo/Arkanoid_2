using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class strzałki : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Paddle")
        {

            changeScale paddle = GameObject.FindGameObjectWithTag("Paddle").GetComponent<changeScale>();
            paddle.changeScalePadd(2);           
            Destroy(gameObject);
        }
        if (other.tag == "Water")
        {
            Destroy(gameObject);
        }
    }
    
	
}
