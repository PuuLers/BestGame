using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.VersionControl.Asset;
public class IceCyclops : ENEMY
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    private Animator animator;
    private float fireCooldown = 0.6f;
    private float spawnCooldown = 13f;
    public float bulletSpeed;
    public Transform shotPoint;
    public GameObject projectileIce;
    public GameObject IceArea;
    public bool isAttacking = false;
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
    }//���������� � ��������

    private void OnTriggerStay2D(Collider2D other)
    {
        if (AgroMode == true)
        {
            if (other.CompareTag("Player"))
            {
                if (timeBtwAttack <= 0)
                {
                    animator.Play("IceCyclops_meleeAttack");
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
        GameObject bullet = Instantiate(projectileIce, shotPoint.position, Quaternion.identity);
        bullet.transform.right = direction;
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = direction.normalized * bulletSpeed;
    }

    protected void SpecialAttack()
    {
        for (int i = 0; i < 4; i++)
        {
            Vector3 icePosition = player.transform.position + new Vector3(Random.Range(-2f, 2f), Random.Range(-1f, 1f), 0);
            Instantiate(IceArea, icePosition, Quaternion.identity);
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