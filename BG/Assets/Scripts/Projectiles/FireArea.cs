using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class FireArea : MonoBehaviour
{

    private void Start()
    {
        Destroy(gameObject, 5f);
    }
    private void Hit()
    {
        Player.HealthPoint -= 10;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null && other.CompareTag("Player"))    
        {
            Hit();
            other.GetComponent<Player>().StartBurning();
            //Player.playerFreeze -= 1f;
        }
    }
}
