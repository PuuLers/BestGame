using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slug : MonoBehaviour
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
    public float offset;
    public GameObject sphere;
    public Transform shotPoint;
    public float startTimeBtwShots;
    private float Reload;

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
            animator.SetInteger("Slime states", 1);
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
    private void Fire()
    {
        Instantiate(sphere, shotPoint.position, transform.rotation);
        Reload = startTimeBtwShots;
        animator.Play("shoot");
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
        if (distance < agrodistance)
        {
            AgroMode = true;
        }
        else
        {
            AgroMode = false;
        }
    }
}

