using UnityEngine;
using System.Collections;

public class Bricks : MonoBehaviour
{
    public int hp;
    [Range(1,100)]
    public int itemLucky=50;
    public GameObject brickParticle;
    public GameObject[] items;
    
    void OnCollisionEnter(Collision other)
    {
        hp -= 1;
        if (hp <= 0)
        {
            Instantiate(brickParticle, transform.position, Quaternion.identity);
            GM GM = GameObject.FindGameObjectWithTag("GM").GetComponent<GM>();
            GM.checkGame();
            GM.addScore(1);
            if (Random.Range(1, 100) < itemLucky)
            {
                int item = Random.Range(0, items.Length);
                Instantiate(items[item], transform.position, Quaternion.identity);
            }


            Destroy(gameObject);
        }
        
    }
}