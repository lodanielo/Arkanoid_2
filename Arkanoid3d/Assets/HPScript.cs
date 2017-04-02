using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPScript : MonoBehaviour {

	
	void Start () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Paddle")
        {
            
            GameObject.FindGameObjectWithTag("GM").GetComponent<GM>().addHP(1);
            Destroy(gameObject);
        }
        if (other.tag == "Water")
        {
            Destroy(gameObject);
        }
    }
	void Update () {
		
	}
}
