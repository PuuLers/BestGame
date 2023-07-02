using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCyclops : MonoBehaviour
{
    public int Damage = 10;
    public int HP = 10;
    public float speed;
    public float agrodistance;
    private float distance;
    private bool AgroMode = false;
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    private Animator animator;
    private Transform player;



    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        DistanceCheck();
        
        if (AgroMode == true)
        {
            Move();
        }
        if (HP <= 0)
        {
            animator.SetInteger("Cyclops states", 2);
            AgroMode = false;
            agrodistance = 0;
        }
    }

    public void TakeDamage(int Damage)
    {
        HP -= Damage;
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
            animator.SetInteger("Cyclops states", 0);   
        }
    }

    private void Move()
    {
        animator.SetInteger("Cyclops states", 1);
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

    public void closeAttack()
    {
        Player.HealthPoint -= Damage;
        timeBtwAttack = startTimeBtwAttack;
    }

    public void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (timeBtwAttack <= 0)
            {
                animator.SetTrigger("Attack");
            }
            else
            {
                timeBtwAttack -= Time.deltaTime;
            }
        }   
    }


}