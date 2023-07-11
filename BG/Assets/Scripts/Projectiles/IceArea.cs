using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class IceArea : IceCyclops
{

    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    private void Hit()
    {
        Player.HealthPoint -= 10;
        Player.playerFreeze += 1f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.CompareTag("Player"))
        {
            Hit();
        }
    }
}
