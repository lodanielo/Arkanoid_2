using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class Paddle : MonoBehaviour
{
    public float speed = 1;
    
    void Start()
    {
        transform.position = new Vector3(0, -9.5f, 0);
    }
    void Update()
    {
        moveControl();
    }
    void moveControl(){
        if (Input.GetKey(KeyCode.A))
            transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
        if(Input.GetKey(KeyCode.D))
             transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
    }
    void OnColisionEnter(Collision col){
        if(col.transform.tag=="Wall"){

        }
    }
    
} 
