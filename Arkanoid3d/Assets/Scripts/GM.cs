using UnityEngine;
using System.Collections;
using UnityEngine.UI;



    public class GM : MonoBehaviour
    {

        public int lives = 3;
        public int bricks = 20;
        public float resetDelay = 1f;
        public Text livesText;
        public Text timeTextW;
        public Text timeTextL;
        public GameObject gameOver;
        public GameObject youWon;
        public GameObject bricksPrefab;
        public GameObject paddle;
	public GameObject lvl1;
	public GameObject lvl2;
        public GameObject deathParticles;
        public static GM instance = null;
        private static float playTime=0f;
        private float cTime = 0f;
	public Vector3 plvl = new Vector3(-2.703976f, 2.211683f, -5.481205f);
	public static int lvl=1;



        private GameObject clonePaddle;

        // Use this for initialization
        void Awake()
        {
            
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(gameObject);

            Setup(lvl);


        }


        
            



	public void Setup(int level)
        {
            clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
            Instantiate(bricksPrefab, transform.position, Quaternion.identity);
		if (level == 1) 
		{
			Instantiate(lvl1, transform.position, Quaternion.identity);
		}

		if (level == 2) 
		{
			Instantiate(lvl2, transform.position, Quaternion.identity);
		}

		if (level > 2) 
		{
			Instantiate(lvl1, transform.position, Quaternion.identity);
			level = 1;
		}
        }

        void CheckGameOver()
        {
            if (bricks < 1)
            {
                cTime = Time.time;
                cTime = cTime - playTime;
                timeTextW.text = "YOU WON \r\n Time: " + cTime + "s";
                youWon.SetActive(true);
                
                Time.timeScale = .25f;
                playTime = Time.time;
                Invoke("Reset", resetDelay);
				lvl++;

            }

            if (lives < 1)
            {
                cTime = Time.time;
                cTime = cTime - playTime;
                timeTextL.text = "GAME OVER \r\n Time: " + cTime + "s";
                gameOver.SetActive(true);
                Time.timeScale = .25f;
                playTime = Time.time;
                Invoke("Reset", resetDelay);

            }
			
			

        }

        void Reset()
        {
		
            Time.timeScale = 1f;
            Application.LoadLevel(Application.loadedLevel);


    }

        public void LoseLife()
        {
            lives--;
            livesText.text = "Lives: " + lives;
            Instantiate(deathParticles, clonePaddle.transform.position, Quaternion.identity);
            Destroy(clonePaddle);
            Invoke("SetupPaddle", resetDelay);
            CheckGameOver();
        }

        void SetupPaddle()
        {
            clonePaddle = Instantiate(paddle, transform.position, Quaternion.identity) as GameObject;
        }

        public void DestroyBrick()
        {
            bricks--;
            CheckGameOver();
        }

       
    }
