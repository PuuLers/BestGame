using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileSphere : MonoBehaviour
{
    public Transform projectileSpawnPoint;
    public float fireRate = 1f;
    private float fireCooldown = 0f;
    private Animator animator;
    private Transform player;
    public float agrodistance;
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        if (fireCooldown <= 0f)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
            if (distanceToPlayer <= agrodistance)
            {
                fireCooldown = 1f / fireRate;
            }
        }
        else
        {
            fireCooldown -= Time.deltaTime;
        }
    }
}
