using UnityEngine;
using System.Collections;

public class EnemyController: MonoBehaviour
{

    public Transform Target;
    private GameObject Enemy;
    private GameObject Player;
    private float Range;
    public float Speed;
    public bool sympathy;
    Animator anim;
    BoxCollider2D enem;
    BoxCollider2D pcollider;
    public int damage;
    private float time;
    public bool flipSprite;
    SpriteRenderer spriteRenderer;
    public bool isFlipped = false;
    BoxCollider2D wall;
    private GameObject InvWall;

    // Use this for initialization
    void Start()
    {
        flipSprite = false;
        time = 3;
        Enemy = GameObject.FindGameObjectWithTag("Enemy");
        Player = GameObject.FindGameObjectWithTag("Player");
        //Debug.Log(Player);
        anim = Enemy.GetComponent<Animator>();
        enem = Enemy.GetComponent<BoxCollider2D>();
        pcollider = Player.GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        InvWall = GameObject.FindGameObjectWithTag("Wall");
        wall = InvWall.GetComponent<BoxCollider2D>();
        damage = 1;
        
    }

    
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        Range = Vector2.Distance(Enemy.transform.position, Player.transform.position);
        

        if(Range<1f)
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            if (time > 1)
            {
                AttackPlayer();
                time = 0;
            }
      
        }
        else if (Range <= 15f)
        {
            GetComponent<Rigidbody2D>().isKinematic = false;

            flipSprite = (spriteRenderer.flipX ? (transform.position.x > 0.01f) : (transform.position.x < -0.01f));
            if (flipSprite)
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
                isFlipped = spriteRenderer.flipX;
                //Debug.Log(isFlipped);
            }

            anim.SetTrigger("findPlayer");
            transform.position += Player.transform.position.normalized * Speed * Time.deltaTime;
            //transform.Translate(Vector2.MoveTowards(Enemy.transform.position, Player.transform.position, Range) * Speed * Time.deltaTime);
            float posy = (transform.position.y - Player.transform.position.y) > 0 ? (transform.position.y - Player.transform.position.y) : 0;
            Vector2 velocity = new Vector2((transform.position.x - Player.transform.position.x) * Speed, posy * Speed);
            transform.position = new Vector3(transform.position.x, transform.position.y, 0);

            GetComponent<Rigidbody2D>().velocity = -velocity;
        }
        else
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
            
        }
    }

    private void AttackPlayer()
    {
        anim.SetTrigger("hitPlayer");
        Player.GetComponent<PlayerHealth>().TakeDamage(damage);
    }
}