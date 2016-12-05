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
        private float MinOffset = -8f;
        private float MaxOffset = 8f;
        public float newPosition;
    

    private Rigidbody rb;


    private Vector3 translateVector = new Vector3(10.0f, 0.0f, 0.0f);

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
            transform.position = new Vector3(0f, -9.5f, 0f);
        }
        void Update()
        {

        
        
        
            if (currentPlatformAndroid == true)
             {
            
                 //  Accelerator();

                     TouchMove();
            
        }
            else
            {
                xPos = transform.position.x + (Input.GetAxis("Horizontal") * paddleSpeed);
                playerPos = new Vector3(Mathf.Clamp(xPos, -8f, 8f), -9.5f, 0f);
                transform.position = playerPos;
            }



            /* if (Input.touchCount == 1)
             {

                 // Move object across XY plane
                 transform.Translate(Input.touches[0].Position.x * paddleSpeed, 0, 0);
             }*/




            //EXIT

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (Time.time > _minCurrentTime && Time.time < _maxCurrentTime)
                {

                    _minCurrentTime = 0;
                    _maxCurrentTime = 0;

                    Application.Quit();
                }
                _minCurrentTime = Time.time + MinTimeToClick; _maxCurrentTime = Time.time + MaxTimeToClick;
            }

        }


        void TouchMove()
        {



            if (Input.touchCount > 0)
            {
                Touch touch = Input.GetTouch(0);
                float middle = Screen.width / 2;


                if (touch.position.x < middle && touch.phase == TouchPhase.Stationary)
                {
                    MoveLeft();
                }
                if (touch.position.x > middle && touch.phase == TouchPhase.Stationary)
                {
                    MoveRight();
                }

            }

        }
    
    /*void Accelerator()                                                              //to działa
    {
        xPos = transform.position.x + (Input.acceleration.x * paddleSpeed);  
        playerPos = new Vector3(Mathf.Clamp(xPos, MinOffset, MaxOffset), -9.5f, 0f);
        transform.position = playerPos;
    }
    public void MoveLeft()                                                              //to też się nie rusza
     {
         rb.velocity=new Vector3(Mathf.Clamp(paddleSpeed, -8f, 8f), 0f, 0f);

     }
         public void MoveRight()
     {
         rb.velocity = new Vector3(Mathf.Clamp(-paddleSpeed, -8f, 8f), 0f, 0f);
     }
}/*

    public void MoveLeft()                                           //tu nie wiem co się odjaniepawla nie porusza się paletka
     {
     newPosition = rb.velocity.x;
     if (newPosition >= MinOffset && newPosition <= MaxOffset)
     {
         transform.Translate(-paddleSpeed, 0f, 0f);
     }
     


     }
*/

    public void MoveLeft()                                             // EUREKA to jest to
    {
        newPosition = transform.position.x;

        if (newPosition >= MinOffset)
        {
            transform.Translate(-paddleSpeed, 0f, 0f);
        }
        

        

    }
    public void MoveRight()
    {


        newPosition = transform.position.x;

        if (newPosition <= MaxOffset)
        {
            transform.Translate(paddleSpeed, 0f, 0f);
        }
    }



    /*public void MoveLeft()                                              //te działają ale nie są ograniczone btw nie ruszać osi x bo crashuje a tak działa
    {

        transform.Translate(-paddleSpeed, 0f, 0f);
    }
        public void MoveRight()
        {


            transform.Translate(paddleSpeed, 0f, 0f);
        }*/
}
