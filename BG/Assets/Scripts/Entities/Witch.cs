using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.VersionControl.Asset;

public class Witch : ENEMY
{
    public Transform shotPoint;
    private Animator animator;
    public GameObject projectileWitch;
    public GameObject bat;
    public GameObject mushroom;
    private float fireCooldown = 5f;
    public float spawnCooldown = 10f;
    public float bulletSpeed;
    private bool isAttacking = false;
    private bool isSpawning = false;
    public float attackDelay = 2f;
    private float nextAttackTime = 0f;


    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Animation()
    {
        if (AgroMode == true)
        {
            animator.SetInteger("Witch states", 1);
        }
        else 
        {
            animator.SetInteger("Witch states", 0);
        }
        if (HP <= 0)
        {
            animator.SetInteger("Witch states", 2);
        }
    }

    private void Update()
    {
        Attack();
        Death();
        Animation();
        DistanceCheck();
        BATDEF();
        Move();
    }

    private void Attack()
    {
        if (AgroMode == true)
        {
            SpecialAttack();

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

    void BATDEF()
    {
        if (Takedamage == true)
        {
            if (Time.time > nextAttackTime)
            {
                SpawnBats();
                bat.transform.parent = null;
                nextAttackTime = Time.time + attackDelay;
                Takedamage = false;
            }
        }
    }

    void SpawnBats()
    {
        for (int i = 0; i < 4; i++)
        {
            Vector3 batPosition = transform.position + new Vector3(Random.Range(-2f, 2f), Random.Range(-1f, 1f), 0);
            Instantiate(bat, batPosition, Quaternion.identity);
        }
    }

    public void LrAttack()
    {
        Vector2 direction = player.position - transform.position;
        shotPoint.right = direction;
        GameObject bullet = Instantiate(projectileWitch, shotPoint.position, Quaternion.identity);
        bullet.transform.right = direction;
        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = direction.normalized * bulletSpeed;
    }
    public void SpecialAttack()
    {
        if (AgroMode == true)
        {
            if (!isSpawning)
            {
                StartCoroutine(SpawnDelay());
            }
            IEnumerator SpawnDelay()
            {
                isSpawning = true;
                yield return new WaitForSeconds(spawnCooldown);
                Instantiate(mushroom, transform.position, Quaternion.identity);
                isSpawning = false;
            }
        }

    }




}
