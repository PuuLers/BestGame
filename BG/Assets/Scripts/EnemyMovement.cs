using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyMovement : MonoBehaviour
{

    private Rigidbody2D physic;
    public Transform player;
    public float speed;
    public float agrodistance;
       

    void Start()
    {
        physic = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < agrodistance) 
        {
            StartHunting();
        }
        else 
        {
            StopHunting();
        }

        void StartHunting()
        {
            if (player.position.x < transform.position.x || player.position.y < transform.position.y)
            {
                physic.velocity = new Vector2(-speed, -speed);
            }


            else
            {
                physic.velocity = new Vector2(speed, speed);
            }
        }

        void StopHunting()
        {
            physic.velocity = new Vector2(0,0);
        }



    }
} 
