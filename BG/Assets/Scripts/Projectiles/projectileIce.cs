using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileIce : MonoBehaviour
{
    public float Speed;
    public int Damage;
    public LayerMask WhatIsPlayer;
    public float distanse;

    void Update()
    {
        transform.Translate(Vector2.right * Speed * Time.deltaTime);
        RaycastHit2D hitinfo = Physics2D.Raycast(transform.position, transform.right, distanse, WhatIsPlayer);
        if (hitinfo.collider != null)
        {
            if (hitinfo.collider.CompareTag("Player"))
            {
                hitinfo.collider.GetComponent<Player>().TakeDamage(Damage);
                //hitinfo.collider.GetComponent<Player>().StopBurning();
                Player.playerFreeze += 1f;
            }
            Destroy(gameObject);
        }
    }
}

