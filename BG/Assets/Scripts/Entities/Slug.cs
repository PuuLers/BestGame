using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Slug : ENEMY
{
    private bool isAttacking = false;
    public float raycastDistance = 10f;
    public float CloseAttackDelay = 2f;
    private float nextAttackTime = 0f;
    private Animator animator;
    public GameObject projectileSlug;
    public float startTimeBtwShots;
    private float fireCooldown = 0.6f;
    public float bulletSpeed;
    public Transform shotPoint;
    



    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Animation()
    {
        if (HP > 0)
        {
            animator.SetInteger("Slug states", 0);
        }
        else
        {
            animator.SetInteger("Slug states", 1);
        }
    }

    private void Update()
    {
        Attack();
        Death();
        Animation();
        DistanceCheck();
        Move();
    }



    private void Attack()
    {
        if (AgroMode == true)
        {
            closeAttack();
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

    private void closeAttack()
    {
        Vector2 raycastOrigin = transform.position;
        Vector2 raycastDirection = transform.right;
        RaycastHit2D hitinfo = Physics2D.Raycast(raycastOrigin, raycastDirection, raycastDistance);
        if (hitinfo.collider != null)
        {
            if (hitinfo.collider.CompareTag("Player"))
            {
                if (Time.time > nextAttackTime)
                {
                    Player.HealthPoint -= Damage;
                    nextAttackTime = Time.time + CloseAttackDelay;
                }
            }
        }

    }

    private void LrAttack()
    {
       Vector2 direction = player.position - transform.position;
       shotPoint.right = direction;
       GameObject bullet = Instantiate(projectileSlug, shotPoint.position, Quaternion.identity);
       bullet.transform.right = direction;  
       Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
       bulletRigidbody.velocity = direction.normalized * bulletSpeed;
    }


}

