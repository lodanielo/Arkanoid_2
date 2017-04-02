using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public float rotateSpeed = 1;
	// Update is called once per frame
	void Update () {
        transform.Rotate(new Vector3(0, 1, 0), 1 * rotateSpeed * Time.deltaTime);
	}
}
