using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeScale : MonoBehaviour {

    private bool buff = false;
    private float clock;
    public float buffTime = 2;
    private Vector3 startScale;
	void Start () 
    {
        startScale = transform.localScale;
	}
	
	// Update is called once per frame
	void Update () {
        if (buff == true)
        {
            clock += Time.deltaTime;
            if (clock >= buffTime)
            {
                buff = false;
                clock = 0;
                transform.localScale = startScale;
            }
        }
	}
    public void changeScalePadd(float value)
    {
        if (buff == false)
        {
            Vector3 scale = transform.localScale;
            transform.localScale = new Vector3(scale.x + value, scale.y, scale.z);
            buff = true;
        }
       
    }
}
