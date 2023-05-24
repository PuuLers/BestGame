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
    public float distanse;
    
    private void Update()
    {
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.right, distanse, WhatIsSolid);
        if(hitinfo.collider != null)
        {
            if (hitinfo.collider.CompareTag("Enemy"))
            {
                hitinfo.collider.GetComponent<TargetHumen>().TakeDamage(Damage);
            }


         Destroy(gameObject);
        }
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
        
    }
}
