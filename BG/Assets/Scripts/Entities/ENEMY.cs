using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMY : MonoBehaviour
{
    protected bool Takedamage = false;
    public int HP;
    public int Damage;
    public float Speed;
    public float agrodistance;
    protected float distance;
    public float distanceToKeep;
    public bool AgroMode = false;
    protected Transform player;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    public void TakeDamage(int Damage)
    {
        HP -= Damage;
        Takedamage = true;
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

    protected void Move()
    {
        if (AgroMode == true)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, Speed * Time.fixedDeltaTime);
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
    }

    protected void Death()
    {
        if (HP <= 0)
        {
            AgroMode = false;
            agrodistance = 0;
        }
    }

    protected void Move2()
    {
        if (AgroMode == true)
        {
            if (distance > distanceToKeep)
            {
                transform.position = Vector2.MoveTowards(transform.position, player.position, Speed * Time.fixedDeltaTime);
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
        }

    }



}

