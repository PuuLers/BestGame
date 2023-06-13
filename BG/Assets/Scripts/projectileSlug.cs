using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class projectileSlug : MonoBehaviour
{
    public float Speed;
    public static int Damage;
    public LayerMask WhatIsSolid;
    public float distanse;
    public GameObject Slug;

    private void Start()
    {
    }  
 
    private void Update()
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

            Destroy(gameObject);
        }
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
      
    }    










}
