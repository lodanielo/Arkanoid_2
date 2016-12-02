using UnityEngine;
using System.Collections;


public class Paddle : MonoBehaviour
{
    public float MaxTimeToClick { get { return _maxTimeToClick; } set { _maxTimeToClick = value; } }
    public float MinTimeToClick { get { return _minTimeToClick; } set { _minTimeToClick = value; } }
    public float paddleSpeed = 1f;
    private float xPos;
    private bool currentPlatformAndroid = false;

    private float _maxTimeToClick = 0.60f;
    private float _minTimeToClick = 0.05f;
    private float _minCurrentTime;
    private float _maxCurrentTime;
    Rigidbody rb = new Rigidbody();

    private Vector3 playerPos = new Vector3(0, -9.5f, 0);

    private void Awake()
    {
            #if UNITY_ANDROID
                    currentPlatformAndroid = true;

            #else
                    currentPlatformAndroid = false;

            #endif
    }

    private void Start()
    {
        if (currentPlatformAndroid == true)
        {
            Debug.Log("Android");
            

        }
        else
        {
            Debug.Log("Other system");
           
        }
    }
    void Update()
    {

        if (currentPlatformAndroid == true)
        {

            Accelerator();
            
            //TouchMove();
           
        }
        else
        {
            xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
            playerPos = new Vector3(Mathf.Clamp(xPos, -18f, 18f), -9.5f, 0f);

            transform.position = playerPos;
        }
        


        /* if (Input.touchCount == 1)
         {

             // Move object across XY plane
             transform.Translate(Input.touches[0].deltaPosition.x * paddleSpeed, 0, 0);
         }
    }*/



        //EXIT

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.time >= _minCurrentTime && Time.time <= _maxCurrentTime)
            {

                _minCurrentTime = 0;
                _maxCurrentTime = 0;
                
                Application.Quit();
            }
            _minCurrentTime = Time.time + MinTimeToClick; _maxCurrentTime = Time.time + MaxTimeToClick;
        }
            
    }


 //    void TouchMove() {

 //       if (Input.touchCount > 0)
 //       {
 //           Touch touch = Input.GetTouch(0);
 //           float middle = Screen.width / 2;
 //           if (touch.position.x < middle && touch.phase == TouchPhase.Began)
 //           {
 //              MoveLeft();
 //           }
 //           if (touch.position.x > middle && touch.phase == TouchPhase.Began)
 //           {
 //               MoveRight();
 //           }
 //       }

 //}
    void Accelerator()
    {
        xPos = transform.position.x + (Input.acceleration.x * paddleSpeed);
        playerPos = new Vector3(Mathf.Clamp(xPos, -18f, 18f), -9.5f, 0f);
        transform.position = playerPos;
    }
     public void MoveLeft()
     {
         //rb.velocity=new Vector3(Mathf.Clamp(paddleSpeed, -8f, 8f), -9.5f, 0f);
        rb.velocity = new Vector3(Mathf.Clamp(paddleSpeed, -18f, 18f), -9.5f, 0f);
    }
         public void MoveRight()
     {
         //rb.velocity = new Vector3(Mathf.Clamp(-paddleSpeed, -8f, 8f), -9.5f, 0f);
        rb.velocity = new Vector3(Mathf.Clamp(-paddleSpeed, -18f, 18f), -9.5f, 0f);
    }
}

