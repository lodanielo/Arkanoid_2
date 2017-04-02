using UnityEngine;
using System.Collections;




    public class Ball : MonoBehaviour
    {

        public float startVelocity = 0.7f;
        public float ballSpeed = 10f;

        private Rigidbody rb;
        private bool ballInPlay;

        public GameObject deadPartical;
        GM GM;

        void Awake()
        {

            rb = GetComponent<Rigidbody>();
            GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GM>();

        }

        void Update()
        {
            

                if (Input.GetButtonDown("Fire1") && ballInPlay == false)
                {
                    transform.parent = null;
                    ballInPlay = true;
                    rb.isKinematic = false;
                    rb.velocity = new Vector3(startVelocity, startVelocity, 0)*ballSpeed;
                    
                }
              

        }
        void OnCollisionEnter(Collision col)
        {
            if (col.transform.tag == "Paddle")
            {
                Vector3 vel = rb.velocity;
               
                if(vel.normalized.x>=0)
                    rb.velocity = new Vector3(0.7f, 0.7f, 0)*ballSpeed;
                else rb.velocity = new Vector3(-0.7f, 0.7f, 0) * ballSpeed;
            }
            if (col.transform.tag == "Wall")
            {
                Vector3 vel = rb.velocity;

                if (vel.normalized.x >= 0 && vel.normalized.y > 0)//
                   rb.velocity = new Vector3(0.7f, 0.7f, 0) * ballSpeed;
                if (vel.normalized.x >= 0 && vel.normalized.y < 0) //
                    rb.velocity = new Vector3(0.7f, -0.7f, 0) * ballSpeed;
                if (vel.normalized.x < 0 && vel.normalized.y >= 0)
                    rb.velocity = new Vector3(-0.7f, 0.7f, 0) * ballSpeed;
                if (vel.normalized.x <= 0 && vel.normalized.y <= 0) 
                    rb.velocity = new Vector3(-0.7f, -0.7f, 0) * ballSpeed;
                
            }
            if (col.transform.tag == "Water")
            {
                
                Instantiate(deadPartical,transform.position,Quaternion.identity);
                GM.killPlayer();
                Destroy(gameObject);
            }
            
        }
        public bool BallInPlay()
        {
            return ballInPlay;
        }
        
    }
