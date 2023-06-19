using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class projectileSlug : MonoBehaviour
{
    public float Speed;
    public int Damage;
    public LayerMask WhatIsPlayer;
    public float distanse;
    public GameObject Slug;
    //private float projectileLifetime = 2f;

    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.right, distanse, WhatIsPlayer);
        if (hitinfo.collider != null)
        {
            if (hitinfo.collider.CompareTag("Player"))
            {
                hitinfo.collider.GetComponent<Player>().TakeDamage(Damage);
            }
            else if (hitinfo.collider.CompareTag("Walls"))
            {
                Instantiate(Slug);
            }
            Destroy(gameObject);
        } 
    }
    










}
