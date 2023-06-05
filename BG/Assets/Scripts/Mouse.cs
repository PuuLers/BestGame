using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Mouse : MonoBehaviour
{
    public int Damage = 10;
    public int HP = 10;
    private Transform player;
    public float speed;
    public float agrodistance;
    public float distance;
    private Animator animator;
    private bool AgroMode = false;
    public float attackRate = 1.0f;
    private bool canAttack = true;
    private float timer = 0.0f;

    public void TakeDamage(int Damage)
    {
        HP -= Damage;
    }


    private void Move()
    {

        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.fixedDeltaTime);
        Vector3 LocalScale = Vector3.one;
        if (transform.position.x > player.position.x)
        {
            LocalScale.x = LocalScale.x * 1;
        }
        else
        {
            LocalScale.x = LocalScale.x * -1;
        }
        transform.localScale = LocalScale;
    }


    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        DistanceCheck();

        if (AgroMode == true)
        {
            Move();
        }
        if (HP <= 0)
        {
            animator.SetInteger("Mouse states", 1);
            AgroMode = false;
            agrodistance = 0;
        }
        if (canAttack)
        {
            Attack();
            timer = 0.0f;
            canAttack = false;
            {
                timer += Time.deltaTime;
                if (timer >= attackRate)
                {
                    canAttack = true;
                }
            }
        }
    }

    public void Attack()
    {
        Player.HelthPoint -= Damage;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Attack();
        }
    }

    public void DistanceCheck()
    {
        distance = Vector3.Distance(player.position, transform.position);
        Vector2 direction = player.position - transform.position;
        RaycastHit2D hit;
        hit = Physics2D.Raycast(player.position, direction);
    
        if (distance < agrodistance && hit.collider == null)
        {
            AgroMode = true;
        }
        if (hit.collider != null)
        {
            if (hit.collider.gameObject.tag == "Wall")
            {
                AgroMode = false;
            }
        }
    }        
}
