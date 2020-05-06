using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPlatformerController : PhysicsObject
{

    public float maxSpeed = 20;
    public float jumpTakeOffSpeed = 20;
    public bool swordOut = false;
    public bool canAttack = false;
    public bool flipSprite = false;
    public bool isFlipped = false;
    private GameObject[] enemies;
    public float distance = 7f;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    //public Scene current;

    // Use this for initialization
    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        swordOut = false;
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        distance = 7f;
        //current = SceneManager.GetActiveScene();
    }

    public void Attack()
    {
        //attack code
        animator.SetTrigger("Attack");
        //Debug.Log("reached here");
        foreach (GameObject enemy in enemies)
        {
            //Debug.Log(Vector3.Distance(transform.position, enemy.transform.position) < distance);
            //Debug.Log(Vector3.Distance(transform.position, enemy.transform.position));
            //Debug.Log(distance);
            if (enemy != null && Vector3.Distance(transform.position, enemy.transform.position) < distance)
            {
                Debug.Log("Hit");
                enemy.GetComponent<Animator>().SetTrigger("isHit");
                enemy.GetComponent<EnemyHealth>().Hit();
            }
        }

    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;
        //animator.SetTrigger("Move");

        if (isFlipped)
        {
            spriteRenderer.flipX = true;
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (swordOut)
            {
                canAttack = false;
                animator.SetBool("sword", false);
                swordOut = !swordOut;
            }
            else
            {
                canAttack = true;
                animator.SetBool("sword", true);
                swordOut = !swordOut;
            }
        }
        if(Input.GetKeyDown(KeyCode.X))
        {
            Debug.Log(canAttack);
            if(canAttack)
            {
                Attack();
            }
        }

        move.x = Input.GetAxis("Horizontal");
        flipSprite = (spriteRenderer.flipX ? (move.x > 0.01f) : (move.x < -0.01f));
        if (flipSprite)
        {
            spriteRenderer.flipX = !spriteRenderer.flipX;
            isFlipped = spriteRenderer.flipX;
            Debug.Log(isFlipped);
        }
        if (move.x!= 0)
        {
            animator.SetTrigger("Move");

        }

        if (Input.GetButtonDown("Jump") && grounded)
        {
            velocity.y = jumpTakeOffSpeed;
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpTakeOffSpeed, ForceMode2D.Impulse);
            animator.SetTrigger("Jump");

        }
        else if (Input.GetButtonUp("Jump"))
        {
            if (velocity.y > 0)
            {
                velocity.y = velocity.y * 0.5f;
            }
        }


        targetVelocity = move * maxSpeed;

        
    }
}

