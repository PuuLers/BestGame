using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileWitch : MonoBehaviour
{
    public float Speed;
    public int Damage;
    public LayerMask WhatIsPlayer;
    public float distanse;
    public GameObject Witch;
    private Transform player;
    //private float projectileLifetime = 2f;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
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
        transform.position = Vector2.MoveTowards(transform.position, player.position, Speed * Time.deltaTime);

    }
}
    