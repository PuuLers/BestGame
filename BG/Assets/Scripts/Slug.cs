using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

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
    public float startTimeBtwShots;
    public GameObject projectileSlug;
    public Transform projectileSpawnPoint;
    public float fireRate = 1f;
    private float fireCooldown = 0f;
    public float bulletSpeed = 50;

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
            LocalScale.x = LocalScale.x * -1;
        }
        else
        {
            LocalScale.x = LocalScale.x * 1;
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
            CloseAttack();
            LrAttack();
        }
        if (HP <= 0)
        {
            animator.SetInteger("Slug states", 1);
            AgroMode = false;
            agrodistance = 0;
        }
    }

    public void CloseAttack()
    {
        Player.HelthPoint -= Damage;
    }

    public void LrAttack()
    {
       Instantiate(projectileSlug, projectileSpawnPoint.position, transform.rotation);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CloseAttack();
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

