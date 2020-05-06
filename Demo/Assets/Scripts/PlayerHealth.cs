using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    
    private int goalHearts;


    private int currHearts;
    public int numHeartsPlayer;
    public int numBrokenPlayer;

    public
    // Start is called before the first frame update
    void Start()
    {
        numHeartsPlayer = GameObject.Find("GameManager").GetComponent<GameManager>().numHearts;
        numBrokenPlayer = GameObject.Find("GameManager").GetComponent<GameManager>().numBroken;
        currHearts = 0;
        goalHearts = 3;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(int numDamage)
    {
       GetComponent<Animator>().SetTrigger("isHit");
       numBrokenPlayer += numDamage;
        if (numBrokenPlayer >= numHeartsPlayer)
        {
            gameOver();
        }
    }

    public void gainHeart()
    {
        numHeartsPlayer++;
        Debug.Log(numHeartsPlayer);
        currHearts++;
        if (currHearts >= goalHearts)
        {
            int level = SceneManager.GetActiveScene().buildIndex;
            GameObject.Find("GameManager").GetComponent<GameManager>().numHearts = numHeartsPlayer;
            GameObject.Find("GameManager").GetComponent<GameManager>().numBroken = numBrokenPlayer;
            SceneManager.LoadScene(sceneBuildIndex: level + 1);
        }
    }

    void gameOver()
    {
        GetComponent<Animator>().SetBool("died",true);

        SceneManager.LoadScene(sceneName: "GameOver");
    }
}