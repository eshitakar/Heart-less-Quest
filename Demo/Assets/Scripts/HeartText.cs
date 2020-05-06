using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartText : MonoBehaviour
{
    public Text heartTxt;
    public Text heartBTxt;
    int numHearts;
    int numBroken;


    // Start is called before the first frame update
    void Start()
    {
        numHearts = GameObject.Find("Player").GetComponent<PlayerHealth>().numHeartsPlayer;
       // Debug.Log(numHearts);
        numBroken = GameObject.Find("Player").GetComponent<PlayerHealth>().numBrokenPlayer;
        heartTxt.text = "x " + numHearts;
        heartBTxt.text = "x " + numBroken;
    }

    // Update is called once per frame
    void Update()
    {
        numHearts = GameObject.Find("Player").GetComponent<PlayerHealth>().numHeartsPlayer;
        //Debug.Log(numHearts);
        numBroken = GameObject.Find("Player").GetComponent<PlayerHealth>().numBrokenPlayer;
        heartTxt.text = "x " + numHearts;
        heartBTxt.text = "x " + numBroken;
    }
}