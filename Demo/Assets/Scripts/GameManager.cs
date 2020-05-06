using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public int numHearts;
    public int numBroken;
    public int numEnem;
    void Start()
    {
        numHearts = 5;
        numBroken = 0;
        DontDestroyOnLoad(gameObject);
        numEnem = 1;
    }

    // Update is called once per frame
    void Update()
    {
       if(numEnem == 0)
        {
            SceneManager.LoadScene(sceneName: "Win");
        }
    }
}