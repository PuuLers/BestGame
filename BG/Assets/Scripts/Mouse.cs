using Microsoft.Cci;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;
using static UnityEditor.VersionControl.Asset;

public class Mouse : MonoBehaviour
{
    public int Damage = 10;
    public int HP = 10;
    private Transform player;
    public float speed;
    public float agrodistance;
    private Animator animator;
    private bool AgroMode = true;

    public void TakeDamage(int Damage)
    {
        HP -= Damage;
    }


    private void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.fixedDeltaTime);
        Vector3 LocalScale = Vector3.one;
        if (transform.position.x > player.position.x)
        {
            LocalScale.x = LocalScale.x * 1;
        }
        else
        {
            LocalScale.x = LocalScale.x * -1;
        }
        transform.localScale = LocalScale;
    }


    void Start()
    {
        animator = GetComponent<Animator>();
        player  = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
       if (AgroMode == true)
        {
            Move();
        }
        if (HP <= 0)
        {
            animator.SetInteger("Mouse states", 1);
            AgroMode = false;
        }
    }

    public void attacked()
    {
        Player.HelthPoint -= Damage;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            attacked();
        }
    }
}
