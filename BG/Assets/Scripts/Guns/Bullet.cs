using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Speed;
    public static int Damage;
    public LayerMask WhatIsSolid;
    public float distance;

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
        
 
