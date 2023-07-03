using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.PackageManager;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Mouse : ENEMY
{
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
        Attack();
        Death();
        Animation();
        DistanceCheck();
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

    private void Animation()
    {
        if (AgroMode == true)
        {
            animator.SetInteger("Mouse states", 0);
        }
        if (HP <= 0)
        {
            animator.SetInteger("Mouse states", 1);
        }
    }
}


