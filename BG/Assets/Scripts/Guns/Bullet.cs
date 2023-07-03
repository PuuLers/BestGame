using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Range(0.1f, 50f)]
    public int Spread = 10;
    public float Speed;
    public static int Damage;
    public LayerMask WhatIsSolid;
    public float distance;

    private void Start()
    {
        transform.rotation *= Quaternion.Euler(0f, 0f, Random.Range(-Spread, Spread));
    }

    private void Update()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.right, distance, WhatIsSolid);
        if (hitinfo.collider != null)
        {

            if (hitinfo.collider.CompareTag("ENEMY"))
            {
                hitinfo.collider.GetComponent<ENEMY>().TakeDamage(Damage);
            }
            
            else if (hitinfo.collider.CompareTag("Mushroom"))
            {
                hitinfo.collider.GetComponent<Mushroom>().TakeDamage(Damage);
            }

            Destroy(gameObject);
        }
        transform.Translate(Vector2.right * Speed * Time.deltaTime);

    }


}
        
 
