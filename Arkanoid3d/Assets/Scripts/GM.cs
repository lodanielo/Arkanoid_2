using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


    public class GM : MonoBehaviour
    {
        //##########STATS
        int actualLVL = 0;
        int hp = 3;
        public int maxHP = 3;

        int score = 0;
        bool playerIsDead = false;


        //############PREFABS
        public GameObject[] lvls;
        public GameObject playerPref;
        GameObject player;
        GameObject actualMap;



        
       //#########TEXT
        public Text hpText;
        public Text scoreText;



        void Start()
        {
            if(playerIsDead==false)
                loadLvl();
                spawnPlayer();
        }


        void Update()
        {
            
            if (playerIsDead == true)//kiedy kończy się życie
            {
                loadLvl();
                spawnPlayer();
                actualLVL = 0;
                hp = maxHP;
                hpText.text = "Lives :" + hp.ToString();
                score = 0;
                scoreText.text = "0";
                playerIsDead = false;
            }
        }


        void loadLvl()
        {
            if (actualLVL < lvls.Length)
            {
                Destroy(actualMap);
                actualMap = Instantiate(lvls[actualLVL]);
            }
            else
            {
                actualLVL = 0;
                Destroy(actualMap);
                actualMap = Instantiate(lvls[actualLVL]);
            }
           
        }


        void spawnPlayer()
        {
            
            player=Instantiate(playerPref);
            player.transform.position=new Vector3(0, -9.5f, 0);
        }


        public void checkGame()//Sprawdza czy zbito wszystkie klocki (Używa jej prefab brick )
        {
            if (actualMap != null)
            {
                if(actualMap.transform.GetChild(4).
                    transform.childCount<=1){
                        lvlUp();
                        Debug.Log("UP");
                        
                }
            }
        }


        public void killPlayer()
        {
            if (hp >1 ){
                hp -= 1; Destroy(player); 
                Destroy(GameObject.FindGameObjectWithTag("Ball").gameObject);
                hpText.text = "Lives :" + hp.ToString();
                spawnPlayer();
            }                         
            else { playerIsDead = true; Destroy(player); }                                
        }


        public void lvlUp()
        {
            actualLVL += 1;
            loadLvl();
            Destroy(GameObject.FindGameObjectWithTag("Ball").gameObject);
            Destroy(player);
            spawnPlayer();
        }


        public void addHP(int hp)
        {
            this.hp += hp;
            hpText.text = "Lives :" + this.hp.ToString();
        }

        public void addScore(int score)
        {
            this.score += score;
            scoreText.text = this.score.ToString();
        }

       

       
    }
