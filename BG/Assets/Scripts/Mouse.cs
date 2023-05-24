using Microsoft.Cci;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Mouse : MonoBehaviour
{

    public int HP = 10;
    public Transform player;
    public float speed;
    public float agrodistance;
    public Animator animator;


    public void TakeDamage(int Damage)
    {
        HP -= Damage;
    }

    void Start()
    {
        player  = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.fixedDeltaTime);

        if (HP <= 0)
        {
            animator.SetInteger("Mouse states", 1);
        }

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
} 
