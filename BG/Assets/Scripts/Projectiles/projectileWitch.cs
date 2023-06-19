using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class projectileWitch : MonoBehaviour
{
    public float Speed;
    public int Damage;
    public LayerMask WhatIsPlayer;
    public float distanse;
    private Transform player;
    private Rigidbody2D rb;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.right, distanse, WhatIsPlayer);
        if (hitinfo.collider != null)
        {
            if (hitinfo.collider.CompareTag("Player"))
            {
                hitinfo.collider.GetComponent<Player>().TakeDamage(Damage);
            }
            Destroy(gameObject);
        }
    }
    void FixedUpdate()
    {
        if (player != null)
        {
            Vector2 direction = (Vector2)player.position - rb.position;
            direction.Normalize();
            rb.velocity = direction * Speed;
        }
    }
}
    