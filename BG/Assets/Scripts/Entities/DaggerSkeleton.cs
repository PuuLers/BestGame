using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DaggerSkeleton : ENEMY
{
    private Animator animator;
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    private bool isAttacking = true;
    private string[] attackTriggers = {"meleeAttack1", "meleeAttack2", "meleeAttack3" };

    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    void Update()
    {
        DistanceCheck();
        Move();
        Death();
        Animation();
    }

    private void Animation()
    {
        if (AgroMode == true)
        {
            animator.SetTrigger("Run");
        }
        else
        {
            animator.SetTrigger("Idle");
        }
        if (HP <= 0)
        {
            animator.SetTrigger("Die");
        }

    }


    protected void closeAttack1()
    {
        Player.HealthPoint -= Damage;
        timeBtwAttack = startTimeBtwAttack;
    }//вызывается в анимации

    protected void closeAttack2()
    {
        Player.HealthPoint -= Damage + 3;
        timeBtwAttack = startTimeBtwAttack;
    }//вызывается в анимации

    protected void closeAttack3()
    {
        Player.HealthPoint -= Damage + 5;
        timeBtwAttack = startTimeBtwAttack;
    }//вызывается в анимации

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isAttacking)
            {
                int attackIndex = Random.Range(0, attackTriggers.Length);
                animator.SetTrigger(attackTriggers[attackIndex]);
                isAttacking = false;
                Invoke(nameof(ResetAttack), startTimeBtwAttack);
            }
        }
           
    }

    private void ResetAttack()
    {
        isAttacking = true;
    }
}
