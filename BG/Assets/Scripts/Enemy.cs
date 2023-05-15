using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D physic;
    public Transform player;
    public float speed;
    public float huntdistance;

    void Start()
    {
       physic = GetComponent<Rigidbody2D>(); 
    }

    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position); 

        if(distToPlayer < huntdistance) 
        {
            StartHunting();
        }
        else
        {
            StopHunting();
        }

        void StartHunting()
        {
            if (player.position.x < transform.position.x)
            {
                physic.velocity = new Vector2(-speed, -speed);
            }
            else if (player.position.x > transform.position.x)
            {
                physic.velocity = new Vector2(speed, speed);
            }
        }
        void StopHunting()
        {
            physic.velocity = new Vector2(0, 0);
        }
    }
}
