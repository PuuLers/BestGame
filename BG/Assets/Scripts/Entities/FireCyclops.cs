using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.VersionControl.Asset;

public class FireCyclops : ENEMY
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    private Animator animator;
    private float fireCooldown = 0.6f;
    private float spawnCooldown = 13f;
    private int numberOfFireAreas = 6;
    public float bulletSpeed;
    public Transform shotPoint;
    public GameObject projectileFire;
    public GameObject FireArea;
    private bool isAttacking = false;
    private bool isSpawning = false;


    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        DistanceCheck();
        Move2();
        Death();
        Animation();
        Attack();
    }

    private void Animation()
    {
        if (AgroMode == true && distance > distanceToKeep)
        {
            animator.SetTrigger("Run");
            if (!isSpawning)
            {
                StartCoroutine(SpawnDelay());
            }
            IEnumerator SpawnDelay()
            {
                isSpawning = true;
                yield return new WaitForSeconds(spawnCooldown);
                animator.SetTrigger("specialAttack");
                isSpawning = false;
            }
        }
        else if (AgroMode == false || HP > 0)
        {
            animator.SetTrigger("Idle");
        }
        if (HP <= 0)
        {
            animator.SetTrigger("Die");
        }
        if (distance <= distanceToKeep)
        {
            animator.SetTrigger("Idle");
        }

    }


    protected void closeAttack()
    {
        Player.HealthPoint -= Damage;
        timeBtwAttack = startTimeBtwAttack;
    }//вызывается в анимации

    private void OnTriggerStay2D(Collider2D other)
    {
        if (AgroMode == true)
        {
            if (other.CompareTag("Player"))
            {
                if (timeBtwAttack <= 0)
                {
                    animator.Play("FireCyclops_meleeAttack");
                    Speed = 0;

                }
                else
                {
                    timeBtwAttack -= Time.deltaTime;
                    Speed = 0.07f;
                }
            }
        }

    }

    protected void LrAttack()
    {
        Vector2 direction = player.position - transform.position;
        shotPoint.right = direction;
        GameObject bullet = Instantiate(projectileFire, shotPoint.position, Quaternion.identity);
        bullet.transform.right = direction;
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = direction.normalized * bulletSpeed;
    }

    protected void SpecialAttack()
    {
        for (int i = 0; i < numberOfFireAreas; i++)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            GameObject fireTrail = Instantiate(FireArea, transform.position, Quaternion.identity);
            fireTrail.GetComponent<Rigidbody2D>().velocity = direction * Speed;
        }
    }

  

    protected void Attack()
    {
        if (AgroMode == true)
        {

            if (!isAttacking)
            {
                StartCoroutine(AttackDelay());
            }
            IEnumerator AttackDelay()
            {
                isAttacking = true;
                yield return new WaitForSeconds(fireCooldown);
                LrAttack();
                isAttacking = false;
            }
        }
    }


}