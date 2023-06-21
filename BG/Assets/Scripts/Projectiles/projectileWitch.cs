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
    public Transform player;
    private Rigidbody2D rb;
    public int rotateSpeed = 3;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        //Vector2 direction = (Vector2)player.position - rb.position;
        //direction.Normalize();
        //float rotateAmount = Vector3.Cross(direction, transform.forward).z;
        //rb.angularVelocity = -rotateAmount * rotateSpeed;
        //rb.velocity = transform.forward * Speed;
        //transform.position = Vector3.MoveTowards(transform.position, player.position, Speed * Time.deltaTime);
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
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
}
    