using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class projectileSlug : MonoBehaviour
{
    public float Speed;
    public static int Damage;
    public LayerMask WhatIsSolid;
    public float distanse;
    public GameObject Slug;
    //private float projectileLifetime = 2f;

    void Start()
    {

    }

    void Update()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.right, distanse, WhatIsSolid);
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
        }
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(UnityEngine.Collision2D collision) => Destroy(gameObject);










}
