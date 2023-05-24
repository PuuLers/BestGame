using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Mouse : MonoBehaviour
{

    private Rigidbody2D rb;
    public Transform player;
    public float speed;
    public float agrodistance;
       

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
                rb.velocity = new Vector2(speed, -speed);
            }
            else
            {
                rb.velocity = new Vector2(-speed, speed);
            }
        }

        void StopHunting()
        {
            rb.velocity = new Vector2(0,0);
        }



    }
} 
