using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int enemyCurHealth;
    public int enemyMaxHealth;

    public GameObject Player;
    private bool death;
    private float time;
    private int numEnems;

    // Use this for initialization
    void Start()
    {
        enemyCurHealth = 4;
        enemyMaxHealth = 4;
        death = false;
        Player = GameObject.FindGameObjectWithTag("Player");
        numEnems = GameObject.Find("GameManager").GetComponent<GameManager>().numEnem;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyCurHealth > enemyMaxHealth)
        {
            enemyCurHealth = enemyMaxHealth;
        }

        if (death)
        {
                
                Player.GetComponent<PlayerHealth>().gainHeart();
                GameObject.Find("GameManager").GetComponent<GameManager>().numEnem--;
                Destroy(gameObject);
                
           
        }
    }

    public void Hit()
    {
        enemyCurHealth--;
        if (enemyCurHealth < 1)
        {
            death = true;
           // Destroy(gameObject);
        }
    }
}
