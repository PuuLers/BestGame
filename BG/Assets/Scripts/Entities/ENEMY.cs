using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ENEMY : MonoBehaviour
{
    public int HP;
    public float Speed;
    public float agrodistance;
    private float distance;
    public bool AgroMode = true;
    protected Transform Player;


    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }


    public void TakeDamage(int Damage)
    {
        HP -= Damage;
    }

    public void DistanceCheck()
    {
        distance = Vector3.Distance(Player.position, transform.position);
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
        transform.position = Vector2.MoveTowards(transform.position, Player.position, Speed * Time.fixedDeltaTime);
        Vector3 LocalScale = Vector3.one;
        if (transform.position.x > Player.position.x)
        {
            LocalScale.x = LocalScale.x * -1;
        }
        else
        {
            LocalScale.x = LocalScale.x * 1;
        }
        transform.localScale = LocalScale;
    }

    protected void Death()
    {
        if (AgroMode == true)
        {
            Move();
        }
        if (HP <= 0)
        {
            AgroMode = false;
            agrodistance = 0;
        }
    }



}

