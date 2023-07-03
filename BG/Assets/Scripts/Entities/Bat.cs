using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bat : ENEMY
{
    public int Damage = 15;
    private Animator animator;
    public float raycastDistance = 10f;
    public float attackDelay = 2f;
    private float nextAttackTime = 0f;



   

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        DistanceCheck();
        Death();
        Attack();
        animAnimation();
        Move();
    }


    public void Attack()
    {
        if (AgroMode == true)
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
                        nextAttackTime = Time.time + attackDelay;
                    }
                }
            }
        }
    }

    private void animAnimation()
    {
        if (player.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, -15f);
        }
        else
        {
            transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, 15f);
        }
        if (HP <= 0)
        {
            animator.SetInteger("Bat states", 1);
        }
    }


}
